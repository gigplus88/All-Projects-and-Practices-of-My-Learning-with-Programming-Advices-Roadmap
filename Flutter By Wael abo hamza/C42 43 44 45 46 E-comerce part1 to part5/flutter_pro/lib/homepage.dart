import 'package:flutter/material.dart';
import 'package:flutter_pro/customwidget/category.dart';
import 'package:flutter_pro/customwidget/bestselling.dart';
import 'package:flutter_pro/details.dart';

GlobalKey<ScaffoldState> scaffoldKey = GlobalKey<ScaffoldState>();

class HomePage extends StatelessWidget {
  const HomePage({super.key});

  @override
  Widget build(BuildContext context) {
    final List<Map<String, dynamic>> categories = [
    {
      "icon": Icons.shower_sharp,
      "title": "Toilette",
    },
    {
      "icon": Icons.card_giftcard,
      "title": "Cars",
    },
    {
      "icon": Icons.mobile_friendly,
      "title": "Mobile",
    },
    {
      "icon": Icons.bathroom,
      "title": "Bathroom",
    },
    {
      "icon": Icons.laptop,
      "title": "Laptop",
    },
    {
      "icon": Icons.baby_changing_station,
      "title": "Baby",
    },
  ];

    final List<Map<String, dynamic>> products = [
      {
        "image": "images/images.jpg",
        "title": "Phone 1",
        "subtitle": "This is your perfect phone my client",
        "price": 20.0,
      },
      {
        "image": "images/download(7).png",
        "title": "Phone 2",
        "subtitle": "This is your perfect phone my client",
        "price": 35.0,
      },
      {
        "image": "images/images@.png",
        "title": "Phone 3",
        "subtitle": "This is your perfect phone my client",
        "price": 50.0,
      },
    ];

    return Scaffold(
      bottomNavigationBar: BottomNavigationBar(
        iconSize: 40,
        unselectedItemColor: Colors.grey[400],
        selectedItemColor: Colors.orange,
        items: [
        BottomNavigationBarItem(icon: Icon(Icons.home_outlined ) , label: ".pe"),
        BottomNavigationBarItem(icon: Icon(Icons.shopping_bag_outlined) , label: "."),
        BottomNavigationBarItem(icon: Icon(Icons.person_2_outlined) , label: "."),
      ],),
      key: scaffoldKey,
      body: Container(
        padding: const EdgeInsets.all(30),
        child: ListView(
          children: [
            Row(
              children: [
                Expanded(
                  child: TextFormField(
                    decoration: InputDecoration(
                      border: InputBorder.none,
                      fillColor: Colors.grey[200],
                      filled: true,
                      prefixIcon: const Icon(Icons.search),
                      iconColor: Colors.white,
                      labelText: "Search",
                    ),
                  ),
                ),
                const Padding(
                  padding: EdgeInsets.only(left: 15),
                  child: Icon(Icons.menu, size: 40),
                ),
              ],
            ),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 20),
              child: const Text(
                "Categories",
                style: TextStyle(fontWeight: FontWeight.bold, fontSize: 30),
              ),
            ),
            SizedBox(
              height: 150,
              child: ListView(
                scrollDirection: Axis.horizontal,
                children:
                List.generate(categories.length, (index) {
                  return Category(icon: categories[index]["icon"], title: categories[index]["title"]);
                }),
              ),
            ),
            Container(
              margin: const EdgeInsets.symmetric(vertical: 20),
              child: const Text(
                "Best Selling",
                style: TextStyle(fontWeight: FontWeight.bold, fontSize: 30),
              ),
            ),

           
            GridView(
            gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
              crossAxisCount: 2,
              childAspectRatio: 0.8,
              crossAxisSpacing: 20,
              mainAxisSpacing: 20,
            ),
            physics: const NeverScrollableScrollPhysics(),
            shrinkWrap: true,
            children: List.generate(products.length, (index) {
              return InkWell(
                onTap: () => Navigator.push(
                  context,
                  MaterialPageRoute(
                    builder: (context) => ItemsDetails(data: products[index]),
                  ),
                ),
                child: BestSelling(
                  image: products[index]["image"],
                  title: products[index]["title"],
                  subtitle: products[index]["subtitle"],
                  price: products[index]["price"],
                ),
              );
            }),
          ),
            
          ],
        ),
      ),
    );
  }
}
