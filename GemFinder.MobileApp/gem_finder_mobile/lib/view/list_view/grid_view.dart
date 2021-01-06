import 'dart:async';
import 'package:gem_finder_mobile/service/image_classification_service.dart';
import 'package:image_picker/image_picker.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:gem_finder_mobile/model/stone_model.dart';
import 'package:gem_finder_mobile/service/stone_service.dart';
import 'debouncer.dart';
import 'image_picker_choice_btn.dart';
import 'item_list_view.dart';

class StoneGridView extends StatefulWidget {
  StoneGridView() : super();

  @override
  StoneGridViewState createState() => StoneGridViewState();
}

class StoneGridViewState extends State<StoneGridView> {

  final stoneService = StoneService();
  final _debouncer = Debouncer(milliseconds: 300);
  List<StoneModel> stones = List();
  List<StoneModel> filteredStones = List();

  @override
  void initState() {
    super.initState();

    StoneService().getStones().then((value) => 
      setList(value));
   
  }

  void setList(List<StoneModel> list) {
    if(list != null) {
setState(() {
          stones = list;
          filteredStones = list;
        });
    } 
    else {
    StoneService().getStoneOffline().then((value) => 
    setState(() {
          stones = value;
          filteredStones = value;
        }));

    };

  }

  @override
  Widget build(BuildContext context) {
    final filterField = Row(
          children: [
            SizedBox(height: 50),
            Expanded(
              child: TextField(
                decoration: InputDecoration(
                  contentPadding: EdgeInsets.all(15.0),
                  hintText: 'Filter by name',
                ),
                onChanged: (value) {
                  _debouncer.run(() {
                    setState(() {
                      filteredStones = stones
                          .where((u) => (u.name
                              .toLowerCase()
                              .contains(value.toLowerCase())))
                          .toList();
                    });
                  });
                },
              ),
            ),
            ImagePickerChoiceBtn(onSelected: _filterByImage)
          ],
        );

final itemList = GridView.builder(
        padding: const EdgeInsets.all(10.0),
        itemCount: filteredStones.length,
        itemBuilder: (ctx, i) => GridViewItem(
              filteredStones[i].label,
              filteredStones[i].name,
              filteredStones[i].imageUrls.first
            ),
        gridDelegate: SliverGridDelegateWithFixedCrossAxisCount(
          crossAxisCount: 2,
          childAspectRatio: 3 / 2,
          crossAxisSpacing: 10,
          mainAxisSpacing: 10,
        ),
      );

    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: <Widget>[
        SizedBox(
          height: 50.0,
        ),
        filterField,
        Expanded(
          child: itemList
        ),
      ],
    );
  }

  Future<void> _filterByImage(ImageSource imageSource) async {
    var img = await ImagePicker().getImage(
      source: imageSource,
      maxWidth: 600,
    );

    if (img == null) return;

    await ImageClassificationService.classifyImage(img.path)
        .then((value) => setState(() {
              var labels = value.where((element) => element["confidence"] > 0.24).map<String>((e) => e["label"]).toList();
              if(labels.isEmpty)
              {
                var max = value.first;
                value.forEach((element) {
                  if(element["confidence"]> max["confidence"])
                  max = element;
                });
                var val = max["label"].toString();
                labels = List();
                labels.add(val);
              }
               
              filteredStones =
                  stones.where((u) => (labels.contains(u.label))).toList();
            }));
  }
}
