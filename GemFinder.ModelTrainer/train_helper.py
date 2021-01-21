import collections
import contextlib

import tensorflow as tf
import tensorflow_hub as hub


class NoStrategy:
  scope = contextlib.contextmanager(lambda _: iter(range(1)))


def get_distribution_strategy():
  return NoStrategy()


class HParams(
    collections.namedtuple("HParams", [
        "train_epochs", "do_fine_tuning", "batch_size", "learning_rate",
        "momentum", "dropout_rate", "l1_regularizer", "l2_regularizer",
        "label_smoothing", "validation_split", "do_data_augmentation",
        "rotation_range", "horizontal_flip", "width_shift_range",
        "height_shift_range", "shear_range", "zoom_range"
    ])):
  """
  """


def get_default_hparams():
  """Returns a fresh HParams object initialized to default values."""
  return HParams(
      train_epochs=5,
      do_fine_tuning=False,
      batch_size=32,
      learning_rate=0.005,
      momentum=0.9,
      dropout_rate=0.2,
      l1_regularizer=0.0,
      l2_regularizer=0.0001,
      label_smoothing=0.1,
      validation_split=0.2,
      do_data_augmentation=False,
      rotation_range=40,
      horizontal_flip=True,
      width_shift_range=0.2,
      height_shift_range=0.2,
      shear_range=0.2,
      zoom_range=0.2)


def _get_data_with_keras(image_dir, image_size, batch_size, validation_split,
                         do_data_augmentation, augmentation_params):
  datagen_kwargs = dict(rescale=1. / 255, validation_split=validation_split)
  dataflow_kwargs = dict(target_size=image_size, batch_size=batch_size,
                         interpolation="bilinear")

  valid_datagen = tf.keras.preprocessing.image.ImageDataGenerator(
      **datagen_kwargs)
  valid_generator = valid_datagen.flow_from_directory(
      image_dir, subset="validation", shuffle=False, **dataflow_kwargs)

  if do_data_augmentation and len(augmentation_params):
    datagen_kwargs.update(**augmentation_params)
    train_datagen = tf.keras.preprocessing.image.ImageDataGenerator(
        **datagen_kwargs)
  else:
    train_datagen = valid_datagen
  train_generator = train_datagen.flow_from_directory(
      image_dir, subset="training", shuffle=True, **dataflow_kwargs)

  indexed_labels = [(index, label)
                    for label, index in train_generator.class_indices.items()]
  sorted_indices, sorted_labels = zip(*sorted(indexed_labels))
  assert sorted_indices == tuple(range(len(sorted_labels)))
  return ((train_generator, train_generator.samples),
          (valid_generator, valid_generator.samples),
          sorted_labels)


def _image_size_for_module(module_layer, requested_image_size=None):
  module_image_size = tuple(
      module_layer._func.__call__  
      .concrete_functions[0].structured_input_signature[0][0].shape[1:3])
  if requested_image_size is None:
    if None in module_image_size:
      raise ValueError("Must specify an image size because "
                       "the selected TF Hub module specifies none.")
    else:
      return module_image_size
  else:
    requested_image_size = tf.TensorShape(
        [requested_image_size, requested_image_size])
    assert requested_image_size.is_fully_defined()
    if requested_image_size.is_compatible_with(module_image_size):
      return tuple(requested_image_size.as_list())
    else:
      raise ValueError("The selected TF Hub module expects image size {}, "
                       "but size {} is requested".format(
                           module_image_size,
                           tuple(requested_image_size.as_list())))


def build_model(module_layer, hparams, image_size, num_classes):
  model = tf.keras.Sequential([
      tf.keras.Input(shape=(image_size[0], image_size[1], 3)), module_layer,
      tf.keras.layers.Dropout(rate=hparams.dropout_rate),
      tf.keras.layers.Dense(
          num_classes,
          activation="softmax",
          kernel_regularizer=tf.keras.regularizers.l1_l2(
              l1=hparams.l1_regularizer, l2=hparams.l2_regularizer))
  ])
  print(model.summary())
  return model


def train_model(model, hparams, train_data_and_size, valid_data_and_size,
                log_dir=None):
  train_data, train_size = train_data_and_size
  valid_data, valid_size = valid_data_and_size
  loss = tf.keras.losses.CategoricalCrossentropy(
      label_smoothing=hparams.label_smoothing)
  model.compile(
      optimizer=tf.keras.optimizers.SGD(
          lr=hparams.learning_rate, momentum=hparams.momentum),
      loss=loss,
      metrics=["accuracy"])
  steps_per_epoch = train_size // hparams.batch_size
  validation_steps = valid_size // hparams.batch_size
  callbacks = []
  if log_dir != None:
    callbacks.append(tf.keras.callbacks.TensorBoard(log_dir=log_dir,
                                                    histogram_freq=1))
  return model.fit(
      train_data,
      epochs=hparams.train_epochs,
      steps_per_epoch=steps_per_epoch,
      validation_data=valid_data,
      validation_steps=validation_steps,
      callbacks=callbacks)


def train_model(tfhub_module,
                          image_dir,
                          hparams,
                          distribution_strategy=None,
                          requested_image_size=None):
  augmentation_params = dict(
      rotation_range=hparams.rotation_range,
      horizontal_flip=hparams.horizontal_flip,
      width_shift_range=hparams.width_shift_range,
      height_shift_range=hparams.height_shift_range,
      shear_range=hparams.shear_range,
      zoom_range=hparams.zoom_range)

  with distribution_strategy.scope():
    module_layer = hub.KerasLayer(
        tfhub_module, trainable=hparams.do_fine_tuning)
    image_size = _image_size_for_module(module_layer, requested_image_size)
    print("Using module {} with image size {}".format(tfhub_module, image_size))
    train_data_and_size, valid_data_and_size, labels = _get_data_with_keras(
        image_dir, image_size, hparams.batch_size, hparams.validation_split,
        hparams.do_data_augmentation, augmentation_params)
    print("Found", len(labels), "classes:", ", ".join(labels))
    model = build_model(module_layer, hparams, image_size, len(labels))
    train_result = train_model(model, hparams, train_data_and_size,
                               valid_data_and_size, None)
  return model, labels, train_result


