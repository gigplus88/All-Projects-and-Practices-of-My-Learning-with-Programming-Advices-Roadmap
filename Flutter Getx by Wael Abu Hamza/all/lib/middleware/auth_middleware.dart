import 'package:flutter/src/widgets/navigator.dart';
import 'package:flutter_pro/main.dart';
import 'package:get/get_navigation/src/routes/route_middleware.dart';

class AuthMiddleware extends GetMiddleware {

  @override
    int? get priority => 2;
  

  @override
  RouteSettings? redirect(String? route) {
    if (sharedPreferences!.getString("role") == "user") {
      return RouteSettings(name: "/home");
    }
    if (sharedPreferences!.getString("role") == "admin") {
      return RouteSettings(name: "/admin");
    }
    return super.redirect(route);
  }
}
