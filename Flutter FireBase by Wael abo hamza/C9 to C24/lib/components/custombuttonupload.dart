import 'package:flutter/material.dart';

class customButtonUpload extends StatelessWidget {
  final void Function()? onPressed;
  final String title;
  final bool isSelected;
  const customButtonUpload({
    super.key,
    this.onPressed,
    required this.title,
    required this.isSelected,
  });

  @override
  Widget build(BuildContext context) {
    return MaterialButton(
      height: 40,
      padding: EdgeInsets.all(20),
      shape: RoundedRectangleBorder(borderRadius: BorderRadius.circular(20)),
      color: isSelected ? Colors.blue : Colors.orange,
      textColor: Colors.white,
      onPressed: onPressed,
      child: Text(title),
    );
  }
}
