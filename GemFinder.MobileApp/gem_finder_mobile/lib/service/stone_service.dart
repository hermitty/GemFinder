import 'package:gem_finder_mobile/model/stone_model.dart';

class StoneService {
  static const String url = 'https://jsonplaceholder.typicode.com/users';

  static List<StoneModel> getStones() {
    var list = new List<StoneModel>();
    list.add(new StoneModel('moon stone', 'moon_stone'));
    list.add(new StoneModel('labradorite', 'labradorite'));
    list.add(new StoneModel('obsidian', 'obsidian'));
    return list;
  }
}
