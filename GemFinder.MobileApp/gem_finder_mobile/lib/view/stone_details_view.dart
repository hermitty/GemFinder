import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:gem_finder_mobile/view/widgets/gallery_widget.dart';

class StoneDetailsView extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: SingleChildScrollView(
      child: Column(
        children: [
          SizedBox(height: 60.0),
          Text(
            'Amber',
            style: TextStyle(fontSize: 50),
          ),
          SizedBox(height: 30.0),
          GalleryView(),
          Padding(
            padding: EdgeInsets.fromLTRB(40, 20, 40, 20),
            child: Text(
              "",
              textAlign: TextAlign.justify,
            ),
          ),
          ButtonTheme(
            minWidth: 250.0,
            height: 70,
                      child: RaisedButton(
              child: Text('see stores', style: TextStyle(color: Colors.white, fontSize: 30)),
              color: Colors.lightBlueAccent,
              shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.circular(24),
              ),
              onPressed: () {},
            ),
          ),
          SizedBox(height: 30.0),
        ],
      ),
    ));
  }
}
