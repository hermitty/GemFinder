import numpy as np
from PIL import Image
import tensorflow as tf 
import cv2
import os
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



model_file = 'C:/Users/User/Desktop/model/trained_model/my_model.tflite'
label_file = 'C:/Users/User/Desktop/model/trained_model/my_labels.txt'
input_mean = 0
input_std = 255
image_path = "C:/Users/User/Desktop/test/"

interpreter = tf.lite.Interpreter(
    model_path = model_file, num_threads=None)
interpreter.allocate_tensors()
input_details = interpreter.get_input_details()
output_details = interpreter.get_output_details()
floating_model = input_details[0]['dtype'] == np.float32

labelsList = load_labels(label_file)
for label in labelsList :
    pathForImages = image_path + label

    if path.exists(pathForImages) :
        imagePathList = load_images_from_folder(pathForImages)
        smallList = imagePathList[:15]
        for imagePath in smallList :
            height = input_details[0]['shape'][1]
            width = input_details[0]['shape'][2]
            img = Image.open(imagePath).resize((width, height))

            input_data = np.expand_dims(img, axis=0)
            if floating_model:
                input_data = (np.float32(input_data) - input_mean) / input_std

            interpreter.set_tensor(input_details[0]['index'], input_data)
            interpreter.invoke()
            output_data = interpreter.get_tensor(output_details[0]['index'])
            results = np.squeeze(output_data)
            top_k = results.argsort()[-5:][::-1]
            labels = load_labels(label_file)

            print(label)
            for i in top_k:   
                if floating_model: 
                    print('{}: {:05.2f}%'.format(labels[i], float(results[i])*100))
                else:
                    print('{}: {:05.2f}%'.format(labels[i], float(results[i] / 255.0)*100))

            print("")

