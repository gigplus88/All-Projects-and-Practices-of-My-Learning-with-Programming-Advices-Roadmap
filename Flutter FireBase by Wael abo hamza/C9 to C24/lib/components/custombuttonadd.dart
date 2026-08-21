import 'package:flutter/material.dart';

class CustomButtonAdd extends StatelessWidget {
  final void Function()? onPressed;
  final String title;
  const CustomButtonAdd({super.key, this.onPressed, required this.title});

  @override
  Widget build(BuildContext context) {
    return MaterialButton(
      height: 40,
      padding: EdgeInsets.all(20),
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
      color: Colors.blue,
      textColor: Colors.white,
      onPressed: onPressed,
      child: Text(title),
    );
  }
}
