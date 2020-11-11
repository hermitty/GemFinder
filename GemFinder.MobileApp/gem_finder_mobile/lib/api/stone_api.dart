import 'dart:convert';
import 'dart:ui';
import 'package:http/http.dart' as http;
import 'package:gem_finder_mobile/service/uri_service.dart';

class StoneApi {
  UriService uriService;
  StoneApi() {
    uriService = new UriService();
  }
  Future<Image> GetStoneImage(String label) async {
    var response = await http.get(uriService.getAcrionUri('Stone/GetSingleImageStone/{label}'));
    if (response.statusCode == 200) {
      return json.decode(response.body)['image'];
    }
  }
}
