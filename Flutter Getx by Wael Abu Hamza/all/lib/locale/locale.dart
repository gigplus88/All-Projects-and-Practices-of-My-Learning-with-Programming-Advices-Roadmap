import 'package:get/get_navigation/get_navigation.dart';

class MyLocale implements Translations {
  @override
  Map<String, Map<String, String>> get keys => {
    "ar": {
      "homepage": "الصفحة الرئيسة",
      "arabic": "عربي",
      "english": "انجليزي",
    },
    "en": {"homepage": "homepage", "arabic": "arabic", "english": "english"},
  };
}
