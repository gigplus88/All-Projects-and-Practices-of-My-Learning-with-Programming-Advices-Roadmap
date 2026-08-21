import 'package:flutter/material.dart';
import 'package:flutter_pro/homepage.dart';
import 'package:flutter_pro/model/cart.dart';
import 'package:flutter_pro/test.dart';
import 'package:provider/provider.dart';

void main() async {
  WidgetsFlutterBinding.ensureInitialized();
  //await Firebase.initializeApp(options: DefaultFirebaseOptions.currentPlatform);
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
    super.initState();
  }

  @override
 Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (context) => CartProvider()),
      ],
      child: const MaterialApp(
        debugShowCheckedModeBanner: false,
        home: HomePage(), 
      ),
    );
  }
}
    /* return ChangeNotifierProvider(
      create: (context) {
        return ProvAll();
      },
      child: MaterialApp(
        home: MultiProvider(
          providers: [
            ChangeNotifierProvider(create: (context) => ProvAll()),
            ChangeNotifierProvider(create: (context) => Model()),
            ChangeNotifierProvider(create: (context) => Model2()),
          ],
          child: const MaterialApp(
            debugShowCheckedModeBanner: false,
            home: Test(),
          ),
        ),
        /*ChangeNotifierProvider(
        create: (context) => UserModel(),
        child: const UserScreen(),
      ),*/
        routes: {},
      ),
    );*/

class ProvAll with ChangeNotifier {
  String hereVarGlobal = "ayoub All Provider";
}
