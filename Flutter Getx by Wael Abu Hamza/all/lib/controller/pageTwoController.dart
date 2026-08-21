import 'package:get/get.dart';

class PageTwoController extends GetxController {
  String? name;

  String? previousRoute;
  String? currentRoute;

  @override
  void onInit() {
    if (Get.arguments != null) {
      name = Get.arguments['name'] ?? "";
      previousRoute = Get.previousRoute;
      currentRoute = Get.routing.current;
    }

    super.onInit();
  }
}
