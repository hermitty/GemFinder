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
            padding: EdgeInsets.fromLTRB(30, 30, 16, 15),
            
            child: Text(
              'Gem Finder',
              
              style: TextStyle(color: Colors.white, fontSize: 45,),
              
            ),
            decoration: BoxDecoration(
              color: Colors.green,
              image: const DecorationImage(
      image: NetworkImage('https://hermitty.blob.core.windows.net/images/097915e6-9e16-4ae7-816e-6a4c1ec2e223.jpeg'),
      fit: BoxFit.cover,
    ),
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
