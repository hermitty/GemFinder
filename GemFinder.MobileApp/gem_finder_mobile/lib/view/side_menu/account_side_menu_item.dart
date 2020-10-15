import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';
import 'package:gem_finder_mobile/view/side_menu/sign_in_view.dart';

class AccountSideMenuItem extends StatelessWidget {
  @override
  Widget build(BuildContext context) {
    return false ? _accountInfoItem(context) : SignInView();
  } 

  Column _accountInfoItem(BuildContext context) {
    return Column(children: <Widget>[
      ListTile(
        title: Text('My account'),
        onTap: () => {Navigator.of(context).pop()},
      ),
      (() {
        if (true)
          return ListTile(
            title: Text('My store'),
            onTap: () => {Navigator.of(context).pop()},
          );
        else
          ListTile(
            title: Text('Create own store'),
            onTap: () => {Navigator.of(context).pop()},
          );
      }())
    ]);
  }

  Column _loggingItem(BuildContext context) {
    return Column(children: <Widget>[
      ListTile(
        title: Text('Sign in'),

      ),
      ExpansionTile(
        title: Text('Sign up'), 
      ),
    ]);
  }
}
