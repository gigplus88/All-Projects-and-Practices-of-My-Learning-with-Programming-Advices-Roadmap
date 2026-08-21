import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class UserScreen extends StatelessWidget {
  const UserScreen({super.key});

  @override
  Widget build(BuildContext context) {
    return ChangeNotifierProvider(
      create: (context) => UserModel(),
      child: Scaffold(
        appBar: AppBar(title: const Text("مثال على استخدام Selector")),
        body: Padding(
          padding: const EdgeInsets.all(20.0),
          child: Column(
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              Selector<UserModel, String>(
                selector: (context, userModel) => userModel.name,
                builder: (context, name, child) {
                  print("جاري إعادة بناء ويدجت الاسم..."); // ستظهر فقط عند تغيير الاسم
                  return Text(
                    "مرحباً، $name",
                    style: const TextStyle(fontSize: 24, fontWeight: FontWeight.bold),
                  );
                },
              ),
              const SizedBox(height: 20),

              Selector<UserModel, int>(
                selector: (context, userModel) => userModel.score,
                builder: (context, score, child) {
                  print("جاري إعادة بناء ويدجت النقاط..."); // ستظهر فقط عند تغيير النقاط
                  return Text(
                    "النقاط: $score",
                    style: const TextStyle(fontSize: 24, color: Colors.blue),
                  );
                },
              ),
              const SizedBox(height: 40),

              ElevatedButton(
                onPressed: () {
                  context.read<UserModel>().incrementScore();
                },
                child: const Text("زيادة النقاط (الاسم لن يتم إعادة بناءه)"),
              ),
              const SizedBox(height: 10),
              ElevatedButton(
                onPressed: () {
                  context.read<UserModel>().updateName("محمد");
                },
                child: const Text("تغيير الاسم (النقاط لن يتم إعادة بناءها)"),
              ),
            ],
          ),
        ),
      ),
    );
  }
}

class UserModel extends ChangeNotifier {
  String _name = "أيوب";
  int _score = 0;

  String get name => _name;
  int get score => _score;

  void updateName(String newName) {
    _name = newName;
    notifyListeners();
  }

  void incrementScore() {
    _score++;
    notifyListeners();
  }
}