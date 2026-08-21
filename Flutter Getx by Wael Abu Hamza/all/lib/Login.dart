import 'package:flutter/material.dart';
import 'package:flutter_pro/ScreenOne.dart';
import 'package:flutter_pro/ScreenTwo.dart';
import 'package:flutter_pro/main.dart';
import 'package:flutter_pro/utils/myBindings.dart';
import 'package:get/get_core/src/get_main.dart';
import 'package:get/get_navigation/src/extension_navigation.dart';

class Login extends StatefulWidget {
  const Login({super.key});

  @override
  State<Login> createState() => _LoginState();
}

class _LoginState extends State<Login> {
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
      appBar: AppBar(title: const Text("Login Page")),
      body: Center(
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Container(
                  padding: EdgeInsets.all(20),
                  child: MaterialButton(
                    onPressed: () {
                      sharedPreferences!.setString("role", "user");
                      Get.offNamed("/home");
                    },
                    child: Text("Login user"),
                  ),
                ),

                Container(
                  padding: EdgeInsets.all(20),
                  child: MaterialButton(
                    onPressed: () {
                      sharedPreferences!.setString("role", "admin");
                      Get.offNamed("/admin");
                    },
                    child: Text("Login Admin"),
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
