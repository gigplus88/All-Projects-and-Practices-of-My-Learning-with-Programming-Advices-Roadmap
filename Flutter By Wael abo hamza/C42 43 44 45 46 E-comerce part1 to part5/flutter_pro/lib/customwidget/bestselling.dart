import 'package:flutter/material.dart';

class BestSelling extends StatelessWidget {
  final String image;
  final String? title;
  final String? subtitle;
  final double? price;

  const BestSelling({
    super.key,
    required this.image,
    required this.title,
    required this.subtitle,
    required this.price,
  });

  @override
  Widget build(BuildContext context) {
    return Card(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Expanded(
            child: Container(
              width: double.infinity,
              color: Colors.grey[300],
              child: Image.asset(image, fit: BoxFit.cover),
            ),
          ),
          Padding(
            padding: const EdgeInsets.all(8.0),
            child:
            Column(
              spacing: 10,
              
              crossAxisAlignment:CrossAxisAlignment.start ,
              children: [
                Text(
                  "$title",
                  style: const TextStyle(fontWeight: FontWeight.bold, fontSize: 16),
                ),
               
                Text(
                  "$subtitle",
                  style: const TextStyle(fontWeight: FontWeight.bold, color:Color.fromARGB(255, 139, 120, 120) ,fontSize: 12),
                ),
                Text(
                  "\$$price",
                  style: const TextStyle(fontWeight: FontWeight.bold, color: Colors.green),
                ),
              ],
            )
          ),
         
        ],
      ),
    );
  }
}
