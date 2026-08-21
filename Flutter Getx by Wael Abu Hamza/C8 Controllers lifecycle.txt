import 'package:get/get.dart';
import 'package:get/get_state_manager/get_state_manager.dart';

class HomeController extends GetxController {
  int counter = 0;

  void increment() {
    counter++;
    update();
  }

  void decrement() {
    if (counter <= 0) return;
    counter--;
    update();
  }

  //It s like init State
  @override
  void onInit() {
    print("init HomeController");
    super.onInit();
  }

  @override
  void onReady() {
    print("Ready HomeController");

    super.onReady();
  }

  @override
  void onClose() {
    print("Close HomeController");
    super.onClose();
  }
}
