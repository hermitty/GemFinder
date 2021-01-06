import 'dart:convert';
import 'package:flutter/services.dart';
import 'package:gem_finder_mobile/api/stone_api.dart';
import 'package:gem_finder_mobile/model/stone_model.dart';

class StoneService {
  final api = StoneApi();

  final dict = 
{
  'labradorite':'https://hermitty.blob.core.windows.net/images/cb4e3564-46ae-42fc-8a2c-e160a6d4a346.jpeg',
	'moon_stone':'https://hermitty.blob.core.windows.net/images/79a43800-2c3c-4711-aac9-fd798c6f0452.jpeg',
	'obsidian':'https://hermitty.blob.core.windows.net/images/1d239b6d-9ef7-4fef-9144-9b92d3397ff4.jpeg',
	'agate':'https://hermitty.blob.core.windows.net/images/78e2eda2-e7b5-40a2-b8ac-a7cf44e0c0b6.jpeg',
	'amber':'https://hermitty.blob.core.windows.net/images/21c65152-51a8-4b5a-aab3-4b10548f877c.jpeg',
	'apatite':'https://hermitty.blob.core.windows.net/images/81dce8ae-bde9-4399-88d3-a9a1c5e97f8a.jpeg',
	'amethyst':'https://hermitty.blob.core.windows.net/images/7772906e-4437-4b23-bac6-d2d49dbfadc0.jpeg',
	'azurite':'https://hermitty.blob.core.windows.net/images/afe889e0-2c11-4f9a-878f-f44e20a7084b.jpeg',
	'lapis_lazuli':'https://hermitty.blob.core.windows.net/images/30c3c5ed-3ce6-4640-ac1c-07a7198ea82f.jpeg',
	'larimar':'https://hermitty.blob.core.windows.net/images/7e202157-ef74-43d8-af6b-1fc9b76c64bc.jpeg',
	'lazurite':'https://hermitty.blob.core.windows.net/images/4e747d68-ff27-42eb-9761-287e5ca53eec.jpeg',
	'malachite':'https://hermitty.blob.core.windows.net/images/4ba66bca-cf0c-4d94-a08a-ecacd4ccb63d.jpeg',
	'rose_quartz':'https://hermitty.blob.core.windows.net/images/7d4594a7-4ced-4246-8201-b7d4edb0373d.jpeg',
	'tiger_eye':'https://hermitty.blob.core.windows.net/images/85c81abc-e26f-4b3b-b1de-07045bd060c0.jpeg',
	'turquoise':'https://hermitty.blob.core.windows.net/images/14a60b0a-4195-4a47-bc7a-217b1529999f.jpeg',
	'ammonite':'https://hermitty.blob.core.windows.net/images/40d6ebd0-422d-486b-9d02-a9bd72fa94d3.jpeg',
	'amazonite':'https://hermitty.blob.core.windows.net/images/bd2362b6-7b09-47e5-ade6-0f3cdaef0328.jpeg',
	'dendrite':'https://hermitty.blob.core.windows.net/images/850ff868-2cae-468b-8e9c-d6dbb6f890af.jpeg',
	'coral_fossil':'https://hermitty.blob.core.windows.net/images/f36e61ee-f1b3-4d41-bd94-97f33306d5a5.jpeg'
};

  Future<List<StoneModel>> getStones() async {
    var list = await api.getImagesStones();
    // if(list = null)
    //   list = await _getStoneFromFile();
    return list;
  }

  Future<List<StoneModel>> getStoneOffline() async {
     var list = await _getStoneFromFile();
     list.forEach((element) {element.addImageUrl(dict[element.label]);});
    return list;
  }

  Future<List<StoneModel>> _getStoneFromFile() async {
    String labels = await rootBundle.loadString('assets/my_labels.txt');
    return LineSplitter().convert(labels).map((s) => StoneModel(s)).toList();
  }
}
