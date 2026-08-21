import 'package:flutter/material.dart';


GlobalKey<ScaffoldState> scaffoldKey = GlobalKey<ScaffoldState>();
  
class ItemsDetails extends StatefulWidget {
  final Map<String, dynamic> data;

  const ItemsDetails({super.key, required this.data});

  @override
  State<ItemsDetails> createState() => _ItemsDetailsState();
  
}

class _ItemsDetailsState extends State<ItemsDetails> {
  String selectedColor = "Black"; 
  String selectedSize = "39";

  @override
  Widget build(BuildContext context) {
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
      endDrawer: const Drawer(width: 250, backgroundColor: Colors.red),
      key: scaffoldKey,
      appBar: AppBar(
        centerTitle: true,
        title: const Row(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            Text("Gipsy ", style: TextStyle(fontWeight: FontWeight.bold)),
            Padding(
              padding: EdgeInsets.all(10.0),
              child: Text(
                "Bee",
                style: TextStyle(
                  fontWeight: FontWeight.bold,
                  color: Colors.orange,
                ),
              ),
            ),
          ],
        ),
        backgroundColor: Colors.grey[200],
        elevation: 0.0,
        iconTheme: IconThemeData(color: Colors.grey),
      ),
      body: Container(
        //padding: const EdgeInsets.all(30),
        child: ListView(
          children: [
            Container(
              width: 200,
              color: Colors.grey[100],
              child: Image.asset(widget.data["image"] ?? "", fit: BoxFit.cover),
            ),

            //Title
            const SizedBox(height: 20),
            Text(
              widget.data["title"] ?? "",
              textAlign: TextAlign.center,
              style: const TextStyle(fontSize: 24, fontWeight: FontWeight.w700),
            ),

            //SubTitle
            const SizedBox(height: 10),
            Text(
              widget.data["subtitle"] ?? "",
              textAlign: TextAlign.center,
              style: const TextStyle(fontSize: 16, color: Colors.grey),
            ),

            //Price
            const SizedBox(height: 20),
            Text(
              "\$${widget.data["price"]}",
              textAlign: TextAlign.center,
              style: const TextStyle(
                fontSize: 20,
                fontWeight: FontWeight.w900,
                color: Colors.orange,
              ),
            ),

            //Color
            Container(
              margin: EdgeInsets.only(top: 20),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text("Color :" , style: TextStyle(color: Colors.grey),),
                  //Gray Color
                  SizedBox(width: 15),
                 /* Container(
                    height: 20,
                    width: 20,
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(30),
                      color: Colors.grey,
                      border:Border.all(color: Colors.orange)
                    ),
                  ),*/
                  //Grey color
                  buildColorOption("Grey" , Colors.grey),
                  SizedBox(width: 15),
                  //Black color
                  buildColorOption("Black" , Colors.black),
                

                  //Black Color
                 /* Container(
                    height: 20,
                    width: 20,
                    decoration: BoxDecoration(
                      borderRadius: BorderRadius.circular(30),
                      color: Colors.black,
                    ),
                  ),
                  SizedBox(width: 5),
                  Text("Black", style: TextStyle()),
                  */

                  
                ],
              ),
              
            ),
            Container(
              margin: EdgeInsets.only(top: 10),
              child: Row(
                mainAxisAlignment: MainAxisAlignment.center,
                children: [
                  Text("Size :" , style: TextStyle(color: Colors.grey ), textAlign: TextAlign.center,),
                  //Gray Color
                  SizedBox(width: 15),
                 
                  //Sizes 
                  buildSizeOption("39"),
                  SizedBox(width: 10),
                  buildSizeOption("40"),
                  SizedBox(width: 10),
                   buildSizeOption("41"),
                  SizedBox(width: 10),
                   buildSizeOption("42"),
                  SizedBox(width: 10),
                   buildSizeOption("43"),
                  SizedBox(width: 10),
                
                ],
              ),              
            ),
            Container(
              margin: EdgeInsets.symmetric(horizontal: 220 , vertical: 20),
              child: MaterialButton(
                padding: EdgeInsets.symmetric(vertical: 25),
                color:Colors.black,
                textColor: Colors.white,
                onPressed: (){} , 
                 child: Text("Add To Cart"),
                ),
            ),
          ],
        ),
      ),
    );
  }





  Widget buildColorOption(String colorName, Color colorValue) {
    bool isSelected = selectedColor == colorName;

    return GestureDetector(
      onTap: () {
        setState(() {
          selectedColor = colorName; 
        });
      },
      child: Container(
        padding: const EdgeInsets.all(4),
        decoration: BoxDecoration(
          shape: BoxShape.circle,
          border: Border.all(
            color: isSelected ? Colors.orange : Colors.transparent,
            width: 3,
          ),
        ),
        child: Container(
          width: 40,
          height: 40,
          decoration: BoxDecoration(
            color: colorValue,
            shape: BoxShape.circle,
          ),
        ),
      ),
    );
  }


Widget buildSizeOption(String size) {
    bool isSelected = selectedSize == size;

    return GestureDetector(
      onTap: () {
        setState(() {
          selectedSize = size; 
        });
      },

        child: Text(
          size,
          style: TextStyle(
            fontWeight:isSelected? FontWeight.bold :FontWeight.normal,
            fontSize: 18,
            color: isSelected ? Colors.black : Colors.grey,
          ),
        ),
      
    );
  }
}









  