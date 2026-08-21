import 'package:flutter/material.dart';

class Chat extends StatefulWidget {
  const Chat({super.key});

  @override
  State<Chat> createState() => _ChatState();
}

class _ChatState extends State<Chat> {
  @override
  void initState() {
    super.initState();
    //initialData();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Filter Users")),

      body: Container(
        child: Column(
          children: [
            Text("Chat page"),
            const SizedBox(height: 20),

            MaterialButton(
              color: Colors.blue,
              textColor: Colors.white,
              padding: EdgeInsets.all(10),
              onPressed: () async {},
              child: Text("Get Your Image"),
            ),

            const SizedBox(height: 20),
          ],
        ),
      ),
    );
  }
}
