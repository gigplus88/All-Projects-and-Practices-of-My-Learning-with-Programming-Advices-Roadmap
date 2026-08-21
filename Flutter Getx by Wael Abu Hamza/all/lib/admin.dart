import 'package:flutter/material.dart';
import 'package:flutter_pro/main.dart';
import 'package:get/get_core/src/get_main.dart';
import 'package:get/get_navigation/src/extension_navigation.dart';
import 'package:shared_preferences/shared_preferences.dart';

class Admin extends StatefulWidget {
  const Admin({super.key});

  @override
  State<Admin> createState() => _AdminState();
}

class _AdminState extends State<Admin> {
  int counter = 0;
  //final controller = Get.lazyPut(() => HomeController());

  @override
  void initState() {
    super.initState();
  }

  @override
  void dispose() {
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Admin Page")),
      body: Center(
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Container(
                  padding: EdgeInsets.all(20),
                  child: MaterialButton(
                    color: Colors.red,
                    onPressed: () async {
                      sharedPreferences!.clear();

                      Get.offAllNamed('/');
                    },
                    child: Text("Sign Out"),
                  ),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
