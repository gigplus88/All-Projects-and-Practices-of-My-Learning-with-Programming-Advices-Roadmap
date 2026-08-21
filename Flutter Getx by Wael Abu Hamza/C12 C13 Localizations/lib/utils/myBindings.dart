import 'package:flutter_pro/controller/HomeController.dart';
import 'package:get/instance_manager.dart';

class MyBindings implements Bindings {
  @override
  void dependencies() {
    // Get.put(HomeController(), permanent: true);
    Get.lazyPut(() => HomeController());
  }
}
