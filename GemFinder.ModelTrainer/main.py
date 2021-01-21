import io
import tempfile
from absl import app
from absl import logging
import tensorflow as tf
import tensorflow_hub as hub

import train_helper as helper



default_params = helper.get_default_hparams()
tfhub_module = 'https://tfhub.dev/google/tf2-preview/mobilenet_v2/feature_vector/4'
image_dir = 'C:/Users/User/Desktop/data'
image_size = 224
saved_model_dir = 'C://Users//User//Desktop//model//trained_model'
tflite_output_file = 'C://Users//User//Desktop//model//trained_model//my_model.tflite'
labels_output_file = 'C://Users//User//Desktop//model//trained_model//my_labels.txt'


model, labels, train_result = helper.train_model(
    tfhub_module, image_dir, default_params,
    helper.get_distribution_strategy(None),
    image_size)


if labels_output_file:
  with tf.io.gfile.GFile(labels_output_file, "w") as f:
    f.write("\n".join(labels + ("",)))
  print("Labels written to", labels_output_file)


if saved_model_dir:
  tf.saved_model.save(model, saved_model_dir)
  print("SavedModel model exported to", saved_model_dir)

if tflite_output_file:
  converter = tf.lite.TFLiteConverter.from_saved_model(saved_model_dir)
  lite_model_content = converter.convert()
  with tf.io.gfile.GFile(tflite_output_file, "wb") as f:
    f.write(lite_model_content)
  print("TFLite model exported to", tflite_output_file)


  #C:\Users\User\AppData\Local\Temp\tfhub_modules