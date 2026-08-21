import 'package:get/get.dart';
import 'package:shared_preferences/shared_preferences.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter_pro/main.dart';

class SettingsServices extends GetxService {
  late SharedPreferences sharedPreferences;

  RxInt counter = 0.obs;

  Future<SettingsServices> init() async {
    //start services
    sharedPreferences = await SharedPreferences.getInstance();

    //end services
    counter.value = sharedPreferences.getInt("counter") ?? 0;

    return this;
  }

  increase() {
    counter.value++;
    sharedPreferences.setInt("counter", counter.value);
  }

  decrease() {
    counter.value--;
    sharedPreferences.setInt("counter", counter.value);
  }


}
