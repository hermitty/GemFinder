import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:gem_finder_mobile/view/side_menu/account_side_menu_item.dart';

class SideMenu extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return Drawer(
      child: ListView(
        padding: EdgeInsets.zero,
        children: <Widget>[
          DrawerHeader(
            child: Text(
              'Gem Finder',
              style: TextStyle(color: Colors.white, fontSize: 25),
            ),
            decoration: BoxDecoration(
              color: Colors.green,
            ),
          ),
          ListTile(
            leading: Icon(Icons.panorama),
            title: Text('Gems'),
            onTap: () => {},
          ),
          ListTile(
            leading: Icon(Icons.local_grocery_store),
            title: Text('Stores'),
            onTap: () => {Navigator.of(context).pop()},
          ),
          ExpansionTile(
            leading: Icon(Icons.account_circle),
            title: Text('Profile'),
            children: <Widget>[AccountSideMenuItem()]
          ),
          ListTile(
            leading: Icon(Icons.help),
            title: Text('Support'),
            onTap: () => {Navigator.of(context).pop()},
          ),
        ],
      ),
    );
  }
}
