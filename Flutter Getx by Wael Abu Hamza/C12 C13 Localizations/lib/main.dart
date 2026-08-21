import 'package:flutter/material.dart';
import 'package:flutter_pro/Login.dart';
import 'package:flutter_pro/admin.dart';
import 'package:flutter_pro/homepage.dart';
import 'package:flutter_pro/locale/locale.dart';
import 'package:flutter_pro/locale/locale_controller.dart';
import 'package:flutter_pro/middleware/auth_middleware.dart';
import 'package:flutter_pro/middleware/super_middleware.dart';
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
    MyLocalController langController = Get.put(MyLocalController());

    return GetMaterialApp(
      debugShowCheckedModeBanner: false,
      home: HomePage(),
      locale:
          langController.initialLang, //Get.deviceLocale,
      translations: MyLocale(),
      //fallbackLocale: const Locale('en'),
      // initialRoute: '/',
      //initialBinding: MyBindings(), //Method1
      getPages: [
        //Method2 for binding
        GetPage(
          name: '/',
          page: () => const Login(),
          //middlewares: [AuthMiddleware(), SuperMiddleware()],
        ),
        GetPage(name: '/home', page: () => const HomePage()),
        GetPage(name: '/admin', page: () => const Admin()),
        GetPage(name: '/super', page: () => const Super()),
      ],
    );
  }
}
