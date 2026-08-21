import 'package:flutter/material.dart';
import 'package:flutter_pro/controller/HomeController.dart';
import 'package:get/get.dart';

class ScreenOne extends StatefulWidget {
  const ScreenOne({super.key});

  @override
  State<ScreenOne> createState() => _ScreenOneState();
}

class _ScreenOneState extends State<ScreenOne> {
  //HomeController controller = Get.put(HomeController(), permanent: true);
  HomeController controller = Get.find();

  @override
  Widget build(BuildContext context) {
    print("build");
    return Scaffold(
      appBar: AppBar(
        title: const Text("الصفحة الأولى"),
        backgroundColor: Colors.blue,
        foregroundColor: Colors.white,
      ),

      body: Center(
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            const Text(
              "مرحباً بك في الصفحة الأولى",
              style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
            ),
            const SizedBox(height: 30),

            Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                IconButton(
                  onPressed: () {
                    controller.decrement();
                  },
                  icon: const Icon(Icons.remove, size: 35),
                  color: Colors.red,
                ),

                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 20.0),
                  child: GetBuilder<HomeController>(
                    builder: (controller) {
                      return Text(
                        "${controller.counter}",
                        style: const TextStyle(
                          fontSize: 26,
                          fontWeight: FontWeight.bold,
                        ),
                      );
                    },
                  ),
                ),

                IconButton(
                  onPressed: () {
                    controller.increment();
                  },
                  icon: const Icon(Icons.add, size: 35),
                  color: Colors.green,
                ),
              ],
            ),

            const SizedBox(height: 40),

            ElevatedButton(
              style: ElevatedButton.styleFrom(
                backgroundColor: Colors.blue,
                foregroundColor: Colors.white,
              ),
              onPressed: () {
                Get.toNamed('/two');
              },
              child: const Text("الانتقال إلى الصفحة الثانية"),
            ),
          ],
        ),
      ),
    );
  }
}
