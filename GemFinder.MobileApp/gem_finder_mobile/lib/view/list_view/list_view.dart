import 'dart:async';
import 'dart:io';
import 'package:gem_finder_mobile/service/image_classification_service.dart';
import 'package:image_picker/image_picker.dart';

import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:gem_finder_mobile/model/stone_model.dart';
import 'package:gem_finder_mobile/service/stone_service.dart';
import 'package:tflite/tflite.dart';

class StoneListView extends StatefulWidget {
  StoneListView() : super();

  @override
  StoneListViewState createState() => StoneListViewState();
}

class Debouncer {
  final int milliseconds;
  VoidCallback action;
  Timer _timer;

  Debouncer({this.milliseconds});

  run(VoidCallback action) {
    if (null != _timer) {
      _timer.cancel();
    }
    _timer = Timer(Duration(milliseconds: milliseconds), action);
  }
}

class StoneListViewState extends State<StoneListView> {
  final _debouncer = Debouncer(milliseconds: 500);
  List<StoneModel> users = List();
  List<StoneModel> filteredUsers = List();

  @override
  void initState() {
    super.initState();

    setState(() {
      users = StoneService.getStones();
      filteredUsers = StoneService.getStones();
    });
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      mainAxisAlignment: MainAxisAlignment.center,
      children: <Widget>[
        SizedBox(
          height: 20.0,
        ),
        TextField(
          decoration: InputDecoration(
            contentPadding: EdgeInsets.all(15.0),
            hintText: 'Filter by name',
          ),
          onChanged: (string) {
            _debouncer.run(() {
              setState(() {
                filteredUsers = users
                    .where((u) => (u.name
                            .toLowerCase()
                            .contains(string.toLowerCase()) ||
                        u.name.toLowerCase().contains(string.toLowerCase())))
                    .toList();
              });
            });
          },
        ),
        PopupMenuButton(
          icon: Icon(Icons.camera),
          onSelected: (result) {},
          itemBuilder: (BuildContext context) =>
              <PopupMenuEntry<MaterialButton>>[
            PopupMenuItem<MaterialButton>(
              value: null,
              child: MaterialButton(
                onPressed: () {
                  _filterByImage(ImageSource.camera);
                },
                child: Text('Camera'),
              ),
            ),
            PopupMenuItem<MaterialButton>(
              value: null,
              child: MaterialButton(
                onPressed: () {
                  _filterByImage(ImageSource.gallery);
                },
                child: Text('Gallery'),
              ),
            ),
          ],
        ),
        Expanded(
          child: ListView.builder(
            padding: EdgeInsets.all(10.0),
            itemCount: filteredUsers.length,
            itemBuilder: (BuildContext context, int index) {
              return Card(
                child: Padding(
                  padding: EdgeInsets.all(10.0),
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.start,
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: <Widget>[
                      Text(
                        filteredUsers[index].name,
                        style: TextStyle(
                          fontSize: 16.0,
                          color: Colors.black,
                        ),
                      ),
                      SizedBox(
                        height: 5.0,
                      ),
                      Text(
                        filteredUsers[index].name.toLowerCase(),
                        style: TextStyle(
                          fontSize: 14.0,
                          color: Colors.grey,
                        ),
                      ),
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
    await ImageClassificationService.classifyImage(img.path)
        .then((value) => setState(() {
              var labels = value.map<String>((e) => e["label"]).toList();
              filteredUsers =
                  users.where((u) => (labels.contains(u.label))).toList();
            }));
  }
}
