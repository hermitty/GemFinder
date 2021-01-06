import 'dart:async';
import 'package:gem_finder_mobile/service/image_classification_service.dart';
import 'package:image_picker/image_picker.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:gem_finder_mobile/model/stone_model.dart';
import 'package:gem_finder_mobile/service/stone_service.dart';
import 'debouncer.dart';
import 'image_picker_choice_btn.dart';

class StoneListView extends StatefulWidget {
  StoneListView() : super();

  @override
  StoneListViewState createState() => StoneListViewState();
}

class StoneListViewState extends State<StoneListView> {
  final _debouncer = Debouncer(milliseconds: 300);
  List<StoneModel> stones = List();
  List<StoneModel> filteredStones = List();

  @override
  void initState() {
    super.initState();

    StoneService().getStoneOffline().then((value) => setState(() {
          stones = value;
          filteredStones = value;
        }));
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: <Widget>[
        SizedBox(
          height: 20.0,
        ),
        Row(
          children: [
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
        ),
        Expanded(
          child: ListView.builder(
            padding: EdgeInsets.all(10.0),
            itemCount: filteredStones.length,
            itemBuilder: (BuildContext context, int index) {
              return Card(
                child: Padding(
                  padding: EdgeInsets.all(10.0),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.start,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: <Widget>[
                      Text(
                        filteredStones[index].name,
                        style: TextStyle(
                          fontSize: 16.0,
                          color: Colors.black,
                        ),
                      ),
                      SizedBox(
                        height: 5.0,
                      ),
                      // Text(
                      //   filteredStones[index].name.toLowerCase(),
                      //   style: TextStyle(
                      //     fontSize: 14.0,
                      //     color: Colors.grey,
                      //   ),
                      // ),
                    ],
                  ),
                ),
              );
            },
          ),
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
              var labels = value.map<String>((e) => e["label"]).toList();
              filteredStones =
                  stones.where((u) => (labels.contains(u.label))).toList();
            }));
  }
}
