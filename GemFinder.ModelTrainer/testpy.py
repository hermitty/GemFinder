
# Copyright 2018 The TensorFlow Authors. All Rights Reserved.
#
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
#
#     http://www.apache.org/licenses/LICENSE-2.0
#
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ==============================================================================
"""label_image for tflite."""

from __future__ import absolute_import
from __future__ import division
from __future__ import print_function

import argparse
import time

import numpy as np
from PIL import Image
import tensorflow as tf # TF2

import cv2
import os
import os.path
from os import path

def load_images_from_folder(folder):
    images = []
    for filename in os.listdir(folder):
        img = cv2.imread(os.path.join(folder,filename))
        if img is not None:
            images.append(os.path.join(folder,filename))
    return images

def load_labels(filename):
  with open(filename, 'r') as f:
    return [line.strip() for line in f.readlines()]

def split_list(a_list):
    half = len(a_list)//5
    return a_list[:half], a_list[half:]

if __name__ == '__main__':
  parser = argparse.ArgumentParser()
  parser.add_argument(
      '-i',
      '--image',
      default='C:/Users/User/Desktop/images/amethyst/3ac287d4-fd03-444b-be38-efe62bad5000.jpeg',
      help='image to be classified')
  parser.add_argument(
      '-m',
      '--model_file',
      default='C:/Users/User/Desktop/model/trained_model/new_mobile_model.tflite',
      help='.tflite model to be executed')
  parser.add_argument(
      '-l',
      '--label_file',
      default='C:/Users/User/Desktop/model/trained_model/class_labels.txt',
      help='name of file containing labels')
  parser.add_argument(
      '--input_mean',
      default=0, type=float,
      help='input_mean')
  parser.add_argument(
      '--input_std',
      default=255, type=float,
      help='input standard deviation')
  parser.add_argument(
      '--num_threads', default=None, type=int, help='number of threads')
  args = parser.parse_args()

  interpreter = tf.lite.Interpreter(
      model_path=args.model_file, num_threads=args.num_threads)
  interpreter.allocate_tensors()

  input_details = interpreter.get_input_details()
  output_details = interpreter.get_output_details()

  # check the type of the input tensor
  floating_model = input_details[0]['dtype'] == np.float32

  labelsList = load_labels(args.label_file)
  for label in labelsList :
      pathForImages = "C:/Users/User/Desktop/images/" + label
      print(label)
      licznik = 0
      suma = 0
      if path.exists(pathForImages) :
          imagePathList = load_images_from_folder(pathForImages)
          smallList = imagePathList[:10]
          for imagePath in smallList :
              height = input_details[0]['shape'][1]
              width = input_details[0]['shape'][2]
              img = Image.open(imagePath).resize((width, height))

              input_data = np.expand_dims(img, axis=0)
              if floating_model:
                  input_data = (np.float32(input_data) - args.input_mean) / args.input_std

              interpreter.set_tensor(input_details[0]['index'], input_data)
              interpreter.invoke()
              output_data = interpreter.get_tensor(output_details[0]['index'])
              results = np.squeeze(output_data)
              top_k = results.argsort()[-1:][::-1]
              labels = load_labels(args.label_file)
              for i in top_k:   
                if floating_model and labels[i] == label: 
                  print('{:08.6f}: {}'.format(float(results[i]), labels[i]))
                  suma += results[i]
                  licznik += 1
                elif labels[i] == label:
                  print('{:08.6f}: {}'.format(float(results[i] / 255.0), labels[i]))
                  suma += results[i]
                  licznik += 1
          print('srednia: ')
          srednia = suma / licznik
          print(srednia)




  # NxHxWxC, H:1, W:2
  #height = input_details[0]['shape'][1]
  #width = input_details[0]['shape'][2]
  #img = Image.open(args.image).resize((width, height))

  ## add N dim
  #input_data = np.expand_dims(img, axis=0)

  #if floating_model:
  #  input_data = (np.float32(input_data) - args.input_mean) / args.input_std

  #interpreter.set_tensor(input_details[0]['index'], input_data)

  #start_time = time.time()
  #interpreter.invoke()
  #stop_time = time.time()

  #output_data = interpreter.get_tensor(output_details[0]['index'])
  #results = np.squeeze(output_data)

  #top_k = results.argsort()[-1:][::-1]
  #labels = load_labels(args.label_file)
  #for i in top_k:
  #  if floating_model:
  #    print('{:08.6f}: {}'.format(float(results[i]), labels[i]))
  #  else:
  #    print('{:08.6f}: {}'.format(float(results[i] / 255.0), labels[i]))

  #print('time: {:.3f}ms'.format((stop_time - start_time) * 1000))
