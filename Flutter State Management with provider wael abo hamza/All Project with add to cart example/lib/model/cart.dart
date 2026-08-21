import 'package:flutter/material.dart';
import 'Item.dart'; 

class CartProvider with ChangeNotifier {
  final List<Item> _items = [];
  double _discountPercentage = 0.0;

  List<Item> get items => _items;
  
  int get count => _items.length;

  double get subtotal {
    return _items.fold(0.0, (sum, item) => sum + (item.price??0) );
  }

  double get totalPrice {
    return subtotal - (subtotal * _discountPercentage);
  }

  double get discountPercentage => _discountPercentage;

  void add(Item item) {
    _items.add(item);
    notifyListeners();
  }

  void remove(Item item) {
    _items.remove(item);
    notifyListeners();
  }

  void applyDiscount(double percentage) {
    _discountPercentage = percentage;
    notifyListeners();
  }

  void reset() {
    _items.clear();
    _discountPercentage = 0.0;
    notifyListeners();
  }
}