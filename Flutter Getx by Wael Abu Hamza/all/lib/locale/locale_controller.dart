import 'package:flutter_pro/main.dart';
import 'package:get/get.dart';
import 'package:flutter/cupertino.dart';

class MyLocalController extends GetxController {
  Locale initialLang = sharedPreferences!.getString("lang") == null
      ? Get.deviceLocale!
      : Locale(sharedPreferences!.getString("lang")!);

  void changeLang(String codelang) {
    Locale locale = Locale(codelang);

    sharedPreferences!.setString("lang", codelang);
    Get.updateLocale(locale);
  }
}
