import 'package:firebase_messaging/firebase_messaging.dart';
import 'package:flutter/material.dart';
import 'package:flutter_pro/chart.dart';

class Test extends StatefulWidget {
  const Test({super.key});

  @override
  State<Test> createState() => _TestState();
}

class _TestState extends State<Test> {
  Future<void> myRequestPermission() async {
    FirebaseMessaging messaging = FirebaseMessaging.instance;

    NotificationSettings settings = await messaging.requestPermission(
      alert: true,
      announcement: false,
      badge: true,
      carPlay: false,
      criticalAlert: false,
      provisional: false,
      sound: true,
    );

    if (settings.authorizationStatus == AuthorizationStatus.authorized) {
      print('User granted permission');
    } else if (settings.authorizationStatus ==
        AuthorizationStatus.provisional) {
      print('User granted provisional permission');
    } else {
      print('User declined or has not accepted permission');
    }
  }

  Future<void> getToken() async {
    try {
      String? myToken = await FirebaseMessaging.instance.getToken();
      print("FCM Token: $myToken");
    } catch (e) {
      print("Error getting token: $e");
    }
  }

  getInit() async {
    RemoteMessage? initialMessage = await FirebaseMessaging.instance
        .getInitialMessage();

    // If the message also contains a data property with a "type" of "chat",
    // navigate to a chat screen
    if (initialMessage != null) {
      String? title = initialMessage.notification!.title ?? "empty title";

      _handleMessage(initialMessage);
    }
  }

  void _handleMessage(RemoteMessage message) {
    if (message.data['type'] == 'chat') {
      Navigator.push(context, MaterialPageRoute(builder: (context) => Chat()));
    }
  }

  sendMessage(title, message) async {
    var headerList = "fl";

    var url = Uri.parse("https...");
    var body = {
      "to":
          "eo7SDKQInb8laeTQfjH5WU:APA91bHLZTE_mdafbkVoOjU6tfW79Im1cimSEAs6DT41rjQ6mH15f5mSuYurC8TavtSio0si2rStK8PPu43FuTrX9MRBtsCz8I6DsnxSo3b9Fl0AOYas8Rg",
      "notification": {"title": "Hello guys", "body": "Welcome"},
    };
  }

  sendMessageTopic(title, message, topics) async {
    var headerList = "fl";

    var url = Uri.parse("https...");
    var body = {
      "to": "/topic/$topics",
      "notification": {"title": "Hello guys", "body": "Welcome"},
    };
  }

  @override
  void initState() {
    //getInit();
    super.initState();
    WidgetsBinding.instance.addPostFrameCallback((_) {
      myRequestPermission();
      getToken();
    });

    // Alert I can t send message notification with my API beacause i have a key problem
    FirebaseMessaging.onMessage.listen((RemoteMessage message) {
      if (message.notification != null) {
        print("==========================");
        print(message.notification!.title);
        print(message.notification!.title);
        //if i send data with notification
        print(message.data);

        print("==========================");
      }
    });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Add Category")),
      body: Container(
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            //Text("Check your console for FCM Token"),
            MaterialButton(
              color: Colors.blue,
              onPressed: () async {
                //getToken();
                // subscribe to topic on each app start-up
                await FirebaseMessaging.instance.subscribeToTopic(
                  'AyoubFellah',
                );
              },
              child: Text("subscribe"),
            ),
            MaterialButton(
              color: Colors.amber,
              onPressed: () async {
                // subscribe to topic on each app start-up
                await FirebaseMessaging.instance.unsubscribeFromTopic(
                  'AyoubFellah',
                );
              },
              child: Text("unsubscribe"),
            ),
            MaterialButton(
              color: Colors.grey,
              onPressed: () {
                sendMessageTopic("Hello", "I am good", "AyoubFellah");
              },
              child: Text("send message Topic"),
            ),
          ],
        ),
      ),
    );
  }
}
