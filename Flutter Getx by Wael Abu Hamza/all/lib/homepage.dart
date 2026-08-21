import 'package:flutter/material.dart';
import 'package:flutter_pro/controller/ThemeController.dart';
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
    // MyLocalController langController = Get.find();
    String? myTheme;
    return Scaffold(
      appBar: AppBar(title: Text("homepage".tr)),
      body: Container(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,

          children: [
            Center(
              child: MaterialButton(
                color: Colors.green,

                //navigate with arguments
                onPressed: () {
                  Get.toNamed("/pagetwo", arguments: {'name': "ayoub"});
                },
                child: Text("Go to Page two"),
              ),
            ),
            const SizedBox(height: 20),

            Center(
              child: MaterialButton(
                color: Colors.green,

                //navigate with arguments
                onPressed: () {
                  Get.snackbar(
                    "title",
                    "message",
                    backgroundColor: Colors.amber,
                    colorText: Colors.black,
                  );
                },
                child: Text("Show snackbar"),
              ),
            ),
            const SizedBox(height: 20),

            Center(
              child: MaterialButton(
                color: Colors.blue,

                //navigate with arguments
                onPressed: () {
                  print(Get.isSnackbarOpen);
                },
                child: Text("Check"),
              ),
            ),

            const SizedBox(height: 20),

            Center(
              child: MaterialButton(
                color: Colors.blue,

                //navigate with arguments
                onPressed: () {
                  // print(GetPlatform.isWeb);
                  //print(GetPlatform.isAndroid);
                  //print(Get.width);
                  print(context.isLandscape);
                  print(context.isPortrait);
                },
                child: Text("Show Platform"),
              ),
            ),

            const SizedBox(height: 20),

            Center(
              child: MaterialButton(
                color: Colors.blue,

                //navigate with arguments
                onPressed: () {
                  if (Get.isDarkMode) {
                    Get.changeTheme(Themes.customLightTheme);
                   // myTheme = "light";
                  } else {
                    Get.changeTheme(Themes.customDarkTheme);
                    //myTheme = "dark";
                  }

                  sharedPreferences!.setString("theme", myTheme?? "");
                },
                child: Text("Change theme"),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
