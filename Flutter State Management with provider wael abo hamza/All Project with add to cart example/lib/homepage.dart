import 'package:flutter/material.dart';
import 'package:flutter_pro/checkout.dart';
import 'package:flutter_pro/main.dart';
import 'package:flutter_pro/model/cart.dart';

import 'package:provider/provider.dart';
import './model/Item.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  List<Item> items = [
    Item(name: "Adidas", price: 250),
    Item(name: "Puma", price: 200),
  ];

  @override
  void initState() {
    super.initState();
  }

  @override
  void dispose() {
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Home Page"),
        actions: [
          Row(
            children: [
              IconButton(
                onPressed: () {
                  Navigator.push(
                    context,
                    MaterialPageRoute(builder: (context) => const CheckOut()),
                  );
                },
                icon: Icon(Icons.add_shopping_cart),
              ),
              Padding(
                padding: const EdgeInsets.all(8.0),
                child: Consumer<CartProvider>(
                  builder: (context, cart, child) {
                    return Text(
                      "${cart.count}",
                      style: TextStyle(
                        color: cart.count == 0 ? Colors.black : Colors.red,
                        fontWeight: cart.count == 0
                            ? FontWeight.normal
                            : FontWeight.bold,
                      ),
                    );
                  },
                ),
              ),
            ],
          ),
        ],
      ),
      body: ListView.builder(
        itemCount: items.length,
        itemBuilder: (context, i) {
          return Card(
            child: Consumer<CartProvider>(
              builder: (context, cart, child) {
                return ListTile(
                  title: Text("${items[i].name}"),
                  trailing: Row(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      IconButton(
                        onPressed: () {
                          context.read<CartProvider>().remove(items[i]);
                        },
                        icon: const Icon(Icons.remove, color: Colors.red),
                      ),

                      IconButton(
                        onPressed: () {
                          context.read<CartProvider>().add(items[i]);
                        },
                        icon: const Icon(Icons.add, color: Colors.green),
                      ),
                    ],
                  ),
                );
              },
            ),
          );
        },
      ),
    );
  }
}

/*import 'package:flutter/material.dart';
import 'package:flutter_pro/model/cart.dart';
import 'package:provider/provider.dart';
import './model/Item.dart';

class HomePage extends StatefulWidget {
  const HomePage({super.key});

  @override
  State<HomePage> createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  final List<Item> items = [
    Item(name: "Adidas", price: 250),
    Item(name: "Puma", price: 200),
  ];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Home Page"),
        actions: [
          Row(
            children: [
              const Icon(Icons.shopping_cart),
              Padding(
                padding: const EdgeInsets.all(8.0),
                // استخدام Consumer لعرض عدد العناصر في الأيقونة
                child: Consumer<CartProvider>(
                  builder: (context, cart, child) {
                    return Text(
                      "${cart.count}",
                      style: TextStyle(
                        color: cart.count == 0 ? Colors.black : Colors.red,
                        fontWeight: cart.count == 0
                            ? FontWeight.normal
                            : FontWeight.bold,
                      ),
                    );
                  },
                ),
              ),
            ],
          ),
        ],
      ),
      body: Column(
        children: [
          // قائمة المنتجات
          Expanded(
            child: ListView.builder(
              itemCount: items.length,
              itemBuilder: (context, i) {
                return Card(
                  child: ListTile(
                    title: Text(items[i].name),
                    subtitle: Text("\$${items[i].price}"),
                    trailing: IconButton(
                      onPressed: () {
                        // استخدام context.read لإضافة المنتج دون إعادة بناء القائمة بالكامل
                        context.read<CartProvider>().add(items[i]);
                      },
                      icon: const Icon(Icons.add),
                    ),
                  ),
                );
              },
            ),
          ),

          // قسم عرض المجاميع، الخصم، وأزرار التحكم
          Container(
            padding: const EdgeInsets.all(16.0),
            color: Colors.grey[200],
            child: Consumer<CartProvider>(
              builder: (context, cart, child) {
                return Column(
                  crossAxisAlignment: CrossAxisAlignment.stretch,
                  children: [
                    Text("المجموع الفرعي: \$${cart.subtotal}"),
                    Text("الخصم: ${(cart.discountPercentage * 100).toStringAsFixed(0)}%"),
                    Text(
                      "المجموع النهائي: \$${cart.totalPrice.toStringAsFixed(2)}",
                      style: const TextStyle(
                        fontSize: 18, 
                        fontWeight: FontWeight.bold, 
                        color: Colors.blue,
                      ),
                    ),
                    const SizedBox(height: 10),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.spaceEvenly,
                      children: [
                        // زر تطبيق خصم 20%
                        ElevatedButton(
                          onPressed: () {
                            cart.applyDiscount(0.20); // خصم 20%
                          },
                          child: const Text("تطبيق خصم 20%"),
                        ),
                        // زر إعادة التصفير (Reset)
                        ElevatedButton(
                          style: ElevatedButton.styleFrom(backgroundColor: Colors.red, foregroundColor: Colors.white),
                          onPressed: () {
                            cart.reset();
                          },
                          child: const Text("Reset"),
                        ),
                      ],
                    ),
                  ],
                );
              },
            ),
          ),
        ],
      ),
    );
  }
} */
