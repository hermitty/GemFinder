
import numpy as np

import tensorflow as tf
assert tf.__version__.startswith('2')

from tensorflow_examples.lite.model_maker.core.data_util.image_dataloader import ImageClassifierDataLoader
from tensorflow_examples.lite.model_maker.core.task import image_classifier
from tensorflow_examples.lite.model_maker.core.task.configs import QuantizationConfig
from tensorflow_examples.lite.model_maker.core.task.model_spec import mobilenet_v2_spec
from tensorflow_examples.lite.model_maker.core.task.model_spec import ImageModelSpec
from tensorflow_examples.lite.model_maker.core.export_format import ExportFormat

import matplotlib.pyplot as plt

#TODO config file
image_path = 'C:\\Users\\User\\Desktop\\images'
result_path = 'C:\\Users\\User\\Desktop\\model\\test\\trained'

data = ImageClassifierDataLoader.from_folder(image_path)
train_data, test_data = data.split(0.9)


model = image_classifier.create(train_data)

loss, accuracy = model.evaluate(test_data)

model.export(export_dir=resut_path, export_format=ExportFormat.TFLITE)
model.export(export_dir=resut_path, export_format=ExportFormat.SAVED_MODEL)
model.export(export_dir=resut_path, export_format=ExportFormat.LABEL)


