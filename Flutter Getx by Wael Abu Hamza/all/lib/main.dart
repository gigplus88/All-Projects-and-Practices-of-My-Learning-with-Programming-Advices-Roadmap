import 'package:flutter/material.dart';
import 'package:flutter_pro/Login.dart';
import 'package:flutter_pro/ScreenTwo.dart';
import 'package:flutter_pro/admin.dart';
import 'package:flutter_pro/controller/ThemeController.dart';
import 'package:flutter_pro/homepage.dart';
import 'package:flutter_pro/locale/locale.dart';
import 'package:flutter_pro/locale/locale_controller.dart';
import 'package:flutter_pro/middleware/auth_middleware.dart';
import 'package:flutter_pro/middleware/super_middleware.dart';
import 'package:flutter_pro/pagetwo.dart';
import 'package:flutter_pro/services/settings.dart';
import 'package:flutter_pro/super.dart';
import 'package:get/get_core/src/get_main.dart';
import 'package:get/get_instance/src/extension_instance.dart';

import 'package:get/get_navigation/get_navigation.dart';
import 'package:get/get_navigation/src/root/get_material_app.dart';
import 'package:shared_preferences/shared_preferences.dart';

SharedPreferences? sharedPreferences;

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  sharedPreferences = await SharedPreferences.getInstance();
  await initialServices();

  runApp(MyApp());
}

Future initialServices() async {
  print("init services");
  await Get.putAsync(() => SettingsServices().init());
}

class MyApp extends StatefulWidget {
  const MyApp({super.key});

  @override
  State<MyApp> createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> with SingleTickerProviderStateMixin {
  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
        ThemeController theme = Get.put(ThemeController());

    //MyLocalController langController = Get.put(MyLocalController());
    return GetMaterialApp(
      debugShowCheckedModeBanner: false,
      //home: HomePage(),
      locale: Get.deviceLocale /*langController.initialLang*/,
      //Get.deviceLocale,
      translations: MyLocale(),
      //fallbackLocale: const Locale('en'),
      initialRoute: '/homepage',
      //initialBinding: MyBindings(), //Method1
      theme: /* ThemeData.dark()*/ /* Themes.customDarkTheme*/ theme.myTheme,
      getPages: [
        //Method2 for binding
        GetPage(
          name: '/homepage',
          page: () => const HomePage(),
          //middlewares: [AuthMiddleware(), SuperMiddleware()],
        ),
        GetPage(name: '/pagetwo', page: () => const PageTwo()),
      ],
    );
  }
}

class Themes {
  static ThemeData customDarkTheme = ThemeData.dark().copyWith(
    appBarTheme: AppBarTheme(
      backgroundColor: Colors.white,
      titleTextStyle: TextStyle(color: Colors.black),
    ),
  );
  static ThemeData customLightTheme = ThemeData.light().copyWith(
    appBarTheme: AppBarTheme(backgroundColor: Colors.green),
  );
}
