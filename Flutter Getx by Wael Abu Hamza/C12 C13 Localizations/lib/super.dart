import 'package:flutter/material.dart';

import 'package:flutter_pro/main.dart';
import 'package:get/get_core/src/get_main.dart';
import 'package:get/get_navigation/src/extension_navigation.dart';

class Super extends StatefulWidget {
  const Super({super.key});

  @override
  State<Super> createState() => _SuperState();
}

class _SuperState extends State<Super> {
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
      appBar: AppBar(title: const Text("Super ")),
      body: Center(
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Container(
                  padding: EdgeInsets.all(20),
                  child: Text("Super page"),
                ),
              ],
            ),
          ],
        ),
      ),
    );
  }
}
