import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:flutter/material.dart';
import 'package:flutter_pro/components/custombuttonadd.dart';
import 'package:flutter_pro/components/customsnackbar.dart';
import 'package:flutter_pro/components/customtextfieldadd.dart';

class AddCategory extends StatefulWidget {
  const AddCategory({super.key});

  @override
  State<AddCategory> createState() => _AddCategoryState();
}

class _AddCategoryState extends State<AddCategory> {
  GlobalKey<FormState> globalKey = GlobalKey<FormState>();
  TextEditingController name = TextEditingController();

  bool isLoading = false;

  Future<void> addCategory() async {
    
  CollectionReference categories = FirebaseFirestore.instance.collection(
    'categories',
  );
    if (globalKey.currentState!.validate()) {
      try {
        await categories.add({'name': name.text});

        //print("Category Added Successfully");
        CustomSnackBarWidget.show(
          context: context,
          message: 'Category added successfully',
          isSuccess: true,
        );

        if (!mounted) return;

        Navigator.of(
          context,
        ).pushNamedAndRemoveUntil("homepage", (route) => false);
      } catch (error) {
        print("Failed to add category: $error");
        isLoading = false;
        setState(() {});
      }
    } else {
      print("Validation failed");
    }
  }

  @override
  void dispose() {
    name.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Add Category")),

      body: Form(
        key: globalKey,
        child: Column(
          children: [
            SizedBox(height: 10),
            Container(
              padding: EdgeInsets.symmetric(vertical: 20, horizontal: 30),
              child: CustomTextFieldAdd(
                hinttext: "Enter your Name",
                mycontroller: name,
                validator: (val) {
                  if (val == null || val.trim().isEmpty) {
                    return "Required";
                  }
                  return null;
                },
              ),
            ),
            CustomButtonAdd(
              title: "Add",
              onPressed: () async {
                setState(() {
                  isLoading = true;
                });
                addCategory();
              },
            ),
          ],
        ),
      ),
    );
  }
}
