import 'package:flutter/src/widgets/navigator.dart';
import 'package:get/get_navigation/src/routes/route_middleware.dart';

class SuperMiddleware extends GetMiddleware {
  @override
  int? get priority => 1;
  bool myVar = true;

  @override
  RouteSettings? redirect(String? route) {
    if (myVar == true) {
      return RouteSettings(name: "/super");
    }

    return super.redirect(route);
  }
}
