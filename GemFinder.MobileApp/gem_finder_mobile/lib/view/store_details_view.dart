import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:font_awesome_flutter/font_awesome_flutter.dart';
import 'package:gem_finder_mobile/view/widgets/gallery_widget.dart';

import '../main.dart';

class StoreDetailsView extends StatelessWidget {
  Widget _formField(TextEditingController textEditingController, IconData icon,
      String text, TextInputType textInputType) {
    return new Container(
        child: new TextFormField(
          enabled: false,
          controller: textEditingController,
          decoration: InputDecoration(

              prefixIcon: new Icon(
                icon,
                color: Colors.blue[400],
              ),
              labelText: text,
              labelStyle: TextStyle(fontSize: 18.0)),
          keyboardType: textInputType,
        ),
        margin: EdgeInsets.only(bottom: 10.0));
  }

  TextEditingController nameController = new TextEditingController(
      text: "facebook.com/stone_shop"); //new TextEditingController(text: contact.name + "");
      TextEditingController nameController2 = new TextEditingController(
      text: "@stone_shop"); //new TextEditingController(text: contact.name + "");
  @override
  Widget build(BuildContext context) {
    return Scaffold(
        body: SingleChildScrollView(
      child: Column(
        children: [
          SizedBox(height: 60.0),
          Text(
            'Stone shop',
            style: TextStyle(fontSize: 50),
          ),
          Padding(
            padding: EdgeInsets.fromLTRB(130, 0, 40, 0),
            child: Row(
              children: [
                Icon(Icons.location_on),
                Text(
                  'Poland, Rzeszow',
                  textAlign: TextAlign.justify,
                ),
              ],
            ),
          ),
          SizedBox(height: 30.0),
          GalleryView(),
          Padding(
            padding: EdgeInsets.fromLTRB(40, 20, 40, 20),
            child: Text(
              'moonstone, labradorite, othes stones, stone, stone ',
              textAlign: TextAlign.justify,
            ),
          ),
          
         
          SizedBox(height: 10.0),
          Column(
            mainAxisAlignment: MainAxisAlignment.center,

            children: [
              Container(
                padding: EdgeInsets.fromLTRB(50, 0, 50, 0),
                child: _formField(
                    nameController, FontAwesomeIcons.facebook, 'facebook', TextInputType.text),
              ),
              Container(
                padding: EdgeInsets.fromLTRB(50, 0, 50, 0),
                child: _formField(
                    nameController2, FontAwesomeIcons.instagramSquare, 'instagram', TextInputType.text),
              ),
            ],
          ),
                  RoundedAlertBox()

        ],
      ),
    ));
  }
}
