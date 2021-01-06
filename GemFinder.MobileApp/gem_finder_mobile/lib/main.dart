import 'package:flutter/material.dart';
import 'package:gem_finder_mobile/view/list_view/grid_view.dart';
import 'package:gem_finder_mobile/view/list_view/list_view.dart';
import 'package:gem_finder_mobile/view/side_menu/side_menu.dart';
import 'package:gem_finder_mobile/view/sign_up/sign_up_view.dart';
import 'package:gem_finder_mobile/view/store_details_view.dart';
import 'package:gem_finder_mobile/view/user/user_details_view.dart';
import 'package:gem_finder_mobile/view/widgets/gallery_widget.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: HomePage(),
    );
  }
}

class HomePage extends StatefulWidget {
  HomePage() : super();

  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  // this will keep track of the current page index

  @override
  Widget build(BuildContext context) {
    return Scaffold(drawer: SideMenu(), 
    body: StoneGridView()
    );
  }
}
Color myColor = Color(0xff00bfa5);

class RoundedAlertBox extends StatefulWidget {
  @override
  _RoundedAlertBoxState createState() => _RoundedAlertBoxState();
}
class _RoundedAlertBoxState extends State<RoundedAlertBox> {
  @override
  Widget build(BuildContext context) {
    return Center(
      child: RaisedButton(
        onPressed: openAlertBox,
        color: myColor,
        child: Text(
          "Add review",
          style: TextStyle(color: Colors.white),
        ),
      ),
    );
  }

  openAlertBox() {
    return showDialog(
        context: context,
        builder: (BuildContext context) {
          return AlertDialog(
            shape: RoundedRectangleBorder(
                borderRadius: BorderRadius.all(Radius.circular(32.0))),
            contentPadding: EdgeInsets.only(top: 10.0),
            content: Container(
              width: 300.0,
              child: Column(
                mainAxisAlignment: MainAxisAlignment.start,
                crossAxisAlignment: CrossAxisAlignment.stretch,
                mainAxisSize: MainAxisSize.min,
                children: <Widget>[
                  Row(
                    mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                    mainAxisSize: MainAxisSize.min,
                    children: <Widget>[
                      Text(
                        "Rate",
                        style: TextStyle(fontSize: 24.0),
                      ),
                      Row(
                        mainAxisSize: MainAxisSize.min,
                        children: <Widget>[
                          Icon(
                            Icons.star_border,
                            color: myColor,
                            size: 30.0,
                          ),
                          Icon(
                            Icons.star_border,
                            color: myColor,
                            size: 30.0,
                          ),
                          Icon(
                            Icons.star_border,
                            color: myColor,
                            size: 30.0,
                          ),
                          Icon(
                            Icons.star_border,
                            color: myColor,
                            size: 30.0,
                          ),
                          Icon(
                            Icons.star_border,
                            color: myColor,
                            size: 30.0,
                          ),
                        ],
                      ),
                    ],
                  ),
                  SizedBox(
                    height: 5.0,
                  ),
                  Divider(
                    color: Colors.grey,
                    height: 4.0,
                  ),
                  Padding(
                    padding: EdgeInsets.only(left: 30.0, right: 30.0),
                    child: TextField(
                      decoration: InputDecoration(
                        hintText: "Add Review",
                        border: InputBorder.none,
                      ),
                      maxLines: 8,
                    ),
                  ),
                  InkWell(
                    child: Container(
                      padding: EdgeInsets.only(top: 20.0, bottom: 20.0),
                      decoration: BoxDecoration(
                        color: myColor,
                        borderRadius: BorderRadius.only(
                            bottomLeft: Radius.circular(32.0),
                            bottomRight: Radius.circular(32.0)),
                      ),
                      child: Text(
                        "Rate store",
                        style: TextStyle(color: Colors.white),
                        textAlign: TextAlign.center,
                      ),
                    ),
                  ),
                ],
              ),
            ),
          );
        });
  }
}
