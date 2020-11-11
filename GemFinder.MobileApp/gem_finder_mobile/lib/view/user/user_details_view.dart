import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';
import 'dart:io';
import 'package:path/path.dart';

class ProfilePage extends StatefulWidget {
  @override
  _ProfilePageState createState() => _ProfilePageState();
}

class _ProfilePageState extends State<ProfilePage> {
  File _image;

  @override
  Widget build(BuildContext context) {
    Future getImage() async {
      var imagePicker = new ImagePicker();
      var image = await imagePicker.getImage(source: ImageSource.gallery);

      setState(() {
        _image = File(image.path);
        print('Image Path $_image');
      });
    }

    Future uploadPic(BuildContext context) async {
      String fileName = basename(_image.path);
      //  StorageReference firebaseStorageRef = FirebaseStorage.instance.ref().child(fileName);
      //  StorageUploadTask uploadTask = firebaseStorageRef.putFile(_image);
      //  StorageTaskSnapshot taskSnapshot = await uploadTask.onComplete;
      setState(() {
        print("Profile Picture uploaded");
        Scaffold.of(context)
            .showSnackBar(SnackBar(content: Text('Profile Picture Uploaded')));
      });
    }

    TextEditingController nameController = new TextEditingController(
        text: "User"); //new TextEditingController(text: contact.name + "");
    TextEditingController emailController = new TextEditingController(
        text:
            "email@email.com"); //new TextEditingController(text: contact.name + "");
    TextEditingController loctionController = new TextEditingController(
        text: "Poland"); //new TextEditingController(text: contact.name + "");
    TextEditingController passwordController = new TextEditingController(
        text:
            "*********"); //new TextEditingController(text: contact.name + "");

    Widget _formField(TextEditingController textEditingController,
        IconData icon, String text, TextInputType textInputType) {
      return new Container(
          child: new TextFormField(
            enabled: false,
            controller: textEditingController,
            decoration: InputDecoration(
                suffixIcon: new Icon(
                  icon,
                  color: Colors.blue[400],
                ),
                labelText: text,
                labelStyle: TextStyle(fontSize: 18.0)),
            keyboardType: textInputType,
          ),
          margin: EdgeInsets.only(bottom: 10.0));
    }

    final image = Container(
        child: Stack(
      children: [
        CircleAvatar(
          radius: 100,
          backgroundColor: Color(0xff476cfb),
          child: ClipOval(
            child: new SizedBox(
              width: 180.0,
              height: 180.0,
              child: (_image != null)
                  ? Image.file(
                      _image,
                      fit: BoxFit.fill,
                    )
                  : Image.network(
                      "https://images.unsplash.com/photo-1502164980785-f8aa41d53611?ixlib=rb-1.2.1&ixid=eyJhcHBfaWQiOjEyMDd9&auto=format&fit=crop&w=500&q=60",
                      fit: BoxFit.fill,
                    ),
            ),
          ),
        ),
        Positioned(
          bottom: 15,
          right: 15,
          child: IconButton(
            icon: Icon(
              Icons.camera_alt,
              size: 50.0,
            ),
            onPressed: () {
              getImage();
            },
          ),
        ),
      ],
    ));

    return Scaffold(
      body: Builder(
        builder: (context) => Container(
          margin: EdgeInsets.only(left: 30.0, right: 30.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.start,
            children: <Widget>[
              SizedBox(height: 80.0),
              image,
              _formField(
                  nameController, Icons.face, 'nick name', TextInputType.text),
              _formField(emailController, Icons.email, 'email',
                  TextInputType.emailAddress),
              _formField(loctionController, Icons.location_on, 'location',
                  TextInputType.text),
              _formField(passwordController, Icons.lock, 'password',
                  TextInputType.visiblePassword),
              SizedBox(
                height: 25.0,
              ),
              Row(
                mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                children: <Widget>[
                  RaisedButton(
                    color: Color(0xff476cfb),
                    onPressed: () {
                      Navigator.of(context).pop();
                    },
                    elevation: 4.0,
                    splashColor: Colors.blueGrey,
                    child: Text(
                      'Cancel',
                      style: TextStyle(color: Colors.white, fontSize: 16.0),
                    ),
                  ),
                  RaisedButton(
                    color: Color(0xff476cfb),
                    onPressed: () {
                      uploadPic(context);
                    },
                    elevation: 4.0,
                    splashColor: Colors.blueGrey,
                    child: Text(
                      'Submit',
                      style: TextStyle(color: Colors.white, fontSize: 16.0),
                    ),
                  ),
                ],
              )
            ],
          ),
        ),
      ),
    );
  }
}
