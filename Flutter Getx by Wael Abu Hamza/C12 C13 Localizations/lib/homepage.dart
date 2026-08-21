import 'package:flutter/material.dart';
import 'package:flutter_pro/locale/locale_controller.dart';
import 'package:flutter_pro/main.dart';
import 'package:flutter_pro/services/settings.dart';
import 'package:get/get.dart';
import 'package:get/get_core/src/get_main.dart';
import 'package:get/get_navigation/src/extension_navigation.dart';
import 'package:get/get_state_manager/src/rx_flutter/rx_getx_widget.dart';
import 'package:get/get_state_manager/src/simple/get_view.dart';
import 'package:get/get_utils/src/extensions/internacionalization.dart';

class HomePage extends GetView<SettingsServices> {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    MyLocalController langController = Get.find();

    return Scaffold(
      appBar: AppBar(title: Text("homepage".tr)),
      body: Center(
        child: Column(
          children: [
            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Center(
                  child: MaterialButton(
                    color: Colors.green,
                    onPressed: () {
                      controller.increase();
                    },
                    child: Text("++"),
                  ),
                ),
                Container(
                  padding: EdgeInsets.all(20),
                  child: GetX<SettingsServices>(
                    builder: (c) => Center(child: Text("${c.counter}")),
                  ),
                ),

                SizedBox(width: 10),
                Center(
                  child: MaterialButton(
                    color: Colors.red,
                    onPressed: () {
                      controller.decrease();
                    },
                    child: Text("--"),
                  ),
                ),
                SizedBox(width: 10),

                Center(
                  child: MaterialButton(
                    color: Colors.red,
                    onPressed: () {
                      controller.sharedPreferences.clear();
                    },
                    child: Text("Clear"),
                  ),
                ),
              ],
            ),
            SizedBox(height: 30),

            Row(
              mainAxisAlignment: MainAxisAlignment.center,

              children: [
                Center(
                  child: MaterialButton(
                    color: Colors.blue,
                    onPressed: () {
                      langController.changeLang("ar");
                    },
                    child: Text("arabic".tr),
                  ),
                ),
                SizedBox(width: 30),

                Center(
                  child: MaterialButton(
                    color: Colors.red,
                    onPressed: () {
                                            langController.changeLang("en");
                    },
                    child: Text("english".tr),
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
