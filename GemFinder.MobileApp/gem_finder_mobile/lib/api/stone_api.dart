import 'dart:convert';
import 'dart:ui';
import 'package:gem_finder_mobile/model/stone_model.dart';
import 'package:http/http.dart' as http;
import 'package:gem_finder_mobile/service/uri_service.dart';

class StoneApi {
  UriService uriService;
  StoneApi() {
    uriService = new UriService();
  }

  Future<List<StoneModel>> getImagesStones() async {
    var uri = uriService.getAcrionUri('Stone/GetImagesStones/');
    var response = await http.get(uri);
    if (response.statusCode == 200) {
      List<StoneModel> list;
      list = (json.decode(response.body)as List).map((e) => StoneModel.formJson(e)).toList();
      return list;
    }
    return null;
  }
}
