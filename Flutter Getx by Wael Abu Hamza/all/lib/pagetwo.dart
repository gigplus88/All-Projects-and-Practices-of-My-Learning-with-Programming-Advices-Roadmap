import 'package:flutter/material.dart';
import 'package:flutter_pro/controller/pageTwoController.dart';
import 'package:get/get.dart';

class PageTwo extends StatelessWidget {
  const PageTwo({super.key});

  @override
  Widget build(BuildContext context) {
    PageTwoController controller = Get.put(PageTwoController());

    return Scaffold(
      appBar: AppBar(
        title: const Text("Page Two"),
        backgroundColor: Colors.green,
        foregroundColor: Colors.white,
      ),
      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text(
              "Previous page: ${controller.currentRoute}",
              style: const TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
                color: Colors.blue,
              ),
            ),
            const SizedBox(height: 20),
            Text(
              "Previous page: ${controller.previousRoute}",
              style: const TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.bold,
                color: Colors.red,
              ),
            ),
            const SizedBox(height: 20),
            Text(
              "Name: ${controller.name}",
              style: const TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
            ),
            const SizedBox(height: 20),
            MaterialButton(
              color: Colors.green,
              onPressed: () {
                Get.back();
              },
              child: const Text("Back to Home"),
            ),
          ],
        ),
      ),
    );
  }
}
