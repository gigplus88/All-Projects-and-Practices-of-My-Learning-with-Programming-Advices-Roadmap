import 'package:flutter/material.dart';
import 'package:flutter_pro/homepage.dart';
import 'package:provider/provider.dart';

class Test extends StatelessWidget {
  const Test({super.key});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("MultiProvider Example")),
      body: Container(
        padding: const EdgeInsets.all(16),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Consumer<Model2>(
              builder: (context, model2, child) {
                return Center(
                  child: Text(
                    model2.name2Model2,
                    style: const TextStyle(fontSize: 22, color: Colors.blue),
                  ),
                );
              },
            ),
            const SizedBox(height: 20),

            Center(
              child: Text(
                context.watch<Model>().name2,
                style: const TextStyle(fontSize: 22, color: Colors.green),
              ),
            ),
            const SizedBox(height: 20),
            Consumer<Model2>(
              builder: (context, model2, child) {
                return MaterialButton(
                  color: Colors.blue,
                  textColor: Colors.white,
                  onPressed: () {
                    model2.changeName2();
                  },
                  child: const Text("Change Model 2 Name"),
                );
              },
            ),
            MaterialButton(
              onPressed: () {
                Navigator.push(
                  context,
                  MaterialPageRoute(builder: (context) => const HomePage()),
                );
              },
              child: Text("Home"),
            ),
          ],
        ),
      ),
    );
  }
}

class Model extends ChangeNotifier {
  String name1 = "Welcome";
  String name2 = "Welcome2";

  void changeName() {
    name1 = "Ayoub";
    notifyListeners();
  }

  void changeName2() {
    name2 = "Ayoub2";
    notifyListeners();
  }
}

class Model2 extends ChangeNotifier  {
  String name1Model2 = "Welcome from Model2";
  String name2Model2 = "Welcome2 from Model2";

  void changeName() {
    name1Model2 = "Ayoub Model2";
    //notifyListeners();
  }

  void changeName2() {
    name2Model2 = "Ayoub2 Model2";
    //notifyListeners();
  }
}
