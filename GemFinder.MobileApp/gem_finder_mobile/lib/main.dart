import 'package:flutter/material.dart';
import 'package:gem_finder_mobile/view/side_menu/side_menu.dart';
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
    body: GalleryView()
    );
  }
}
