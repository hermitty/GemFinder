import 'package:tflite/tflite.dart';

class ImageClassificationService {
//TODO load model in ctor
  static Future<List> classifyImage(String imagePath) async {
    var model = await Tflite.loadModel(
        labels: "assets/my_labels.txt", model: "assets/my_model.tflite");
    print(model);
    return await Tflite.runModelOnImage(
        path: imagePath,
        numResults: 10,
        threshold: 0.5,
        imageMean: 127.5,
        imageStd: 127.5);
  }
}
