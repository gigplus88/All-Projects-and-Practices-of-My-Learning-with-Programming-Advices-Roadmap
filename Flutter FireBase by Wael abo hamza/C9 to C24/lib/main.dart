import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:firebase_core/firebase_core.dart';
import 'package:flutter_pro/auth/signup.dart';
import 'package:flutter_pro/categories/add.dart';
import 'package:flutter_pro/homepage.dart';
import 'firebase_options.dart';
import 'package:flutter_pro/auth/login.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  await Firebase.initializeApp(options: DefaultFirebaseOptions.currentPlatform);
  runApp(MyApp());
}

class MyApp extends StatefulWidget {
  const MyApp({super.key});

  @override
  State<MyApp> createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> with SingleTickerProviderStateMixin {
  @override
  void initState() {
    FirebaseAuth.instance.authStateChanges().listen((User? user) {
      if (user == null) {
        print("=================");
        print('User is currently signed out!');
      } else {
        print('User is signed in!');
      }
    });
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      theme: ThemeData(
        appBarTheme: AppBarTheme(
          backgroundColor: Colors.blue[100],
          titleTextStyle: TextStyle(
            color: Colors.blue[800],
            fontSize: 25.0,
            fontWeight: FontWeight.bold,
          ),
          centerTitle: true,
          iconTheme: IconThemeData(color: Colors.blue[800], size: 30),
          toolbarHeight: 60,
        ),
        textTheme: TextTheme(
          //bodySmall: TextStyle(color: Colors.red, fontSize: 16),
          //bodyMedium: TextStyle(color: Colors.blue, fontSize: 20),
          //bodyLarge: TextStyle(color: Colors.green, fontSize: 24),
        ),
        //fontFamily: "Lumanosimo",
      ),
      home:
          FirebaseAuth.instance.currentUser != null &&
              FirebaseAuth.instance.currentUser!.emailVerified
          ? HomePage()
          : Login(),
      routes: {
        "signup": (context) => SignUp(),
        "login": (context) => Login(),
        "homepage": (context) => HomePage(),
        "addcategory": (context) => AddCategory(),
      },
    );
  }
}
