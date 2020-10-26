import 'dart:convert';

import 'package:flutter/services.dart';
import 'package:gem_finder_mobile/model/stone_model.dart';

class StoneService {

  Future<List<StoneModel>> getStones() async {
    var list = await _getStoneFromFile();
    return list;
  }

  Future<List<StoneModel>> _getStoneFromFile() async {
    String labels = await rootBundle.loadString('assets/my_labels.txt');
    return LineSplitter().convert(labels).map((s) => StoneModel(s)).toList();
  }
}
