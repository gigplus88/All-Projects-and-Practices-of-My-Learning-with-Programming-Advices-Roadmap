import 'package:flutter/material.dart';
import 'package:flutter_pro/main.dart';
import 'package:get/get.dart';

class ThemeController extends GetxController {
  String? themeName;
  ThemeData? myTheme;

  @override
  void onInit() {
    if (sharedPreferences!.get("theme") == null)
      myTheme = Themes.customLightTheme;
    else
      myTheme = Themes.customDarkTheme;

    super.onInit();
  }
}
