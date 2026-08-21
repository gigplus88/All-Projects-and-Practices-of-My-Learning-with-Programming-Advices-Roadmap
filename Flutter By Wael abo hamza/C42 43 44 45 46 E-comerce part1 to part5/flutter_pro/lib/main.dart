import 'package:flutter/material.dart';
import 'package:flutter_pro/homepage.dart';


void main() {
  runApp(MyApp());
}

class MyApp extends StatefulWidget {
  const MyApp({super.key});

  @override
  State<MyApp> createState() => _MyAppState();
}

class _MyAppState extends State<MyApp> with SingleTickerProviderStateMixin {
 
  TabController? tabController;

  List imagesNames = [
    "images/Gemini_Generated_Image_4b2rr94b2rr94b2r.png",
    "images/download(5).jpg",
    "images/20260514_183120.jpg",
    "images/ChatGPT Image Jul 6, 2026, 12_02_14 AM.png",
  ];

  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: HomePage(),
      routes:{
        '/home' : (context) => const HomePage(),
       
      }
    );
  }
}

