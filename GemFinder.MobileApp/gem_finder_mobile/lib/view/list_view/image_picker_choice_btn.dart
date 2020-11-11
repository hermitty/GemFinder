import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';

class ImagePickerChoiceBtn extends StatelessWidget {
  final Function onSelected;
  ImagePickerChoiceBtn({
    @required this.onSelected
    });

  @override
  Widget build(BuildContext context) {
    return PopupMenuButton(
      icon: Icon(Icons.camera),
      onSelected: (ImageSource result) {
        onSelected(result);
      },
      itemBuilder: (BuildContext context) => <PopupMenuEntry<ImageSource>>[
        PopupMenuItem<ImageSource>(
          value: ImageSource.gallery,
          child: Row(children: [Icon(Icons.photo), Text('Gallery')]),
        ),
        PopupMenuItem<ImageSource>(
          value: ImageSource.camera,
          child: Row(children: [Icon(Icons.camera_alt), Text('Camera')]),
        ),
      ],
    );
  }
}