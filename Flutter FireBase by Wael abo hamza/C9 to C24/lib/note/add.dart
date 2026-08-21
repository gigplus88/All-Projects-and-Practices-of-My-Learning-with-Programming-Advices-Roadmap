import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:flutter/material.dart';
import 'package:flutter_pro/components/custombuttonadd.dart';
import 'package:flutter_pro/components/customsnackbar.dart';
import 'package:flutter_pro/components/customtextfieldadd.dart';
import 'package:flutter_pro/note/view.dart';

class AddNote extends StatefulWidget {
  final String docId;
  const AddNote({super.key, required this.docId});

  @override
  State<AddNote> createState() => _AddNoteState();
}

class _AddNoteState extends State<AddNote> {
  GlobalKey<FormState> globalKey = GlobalKey<FormState>();
  TextEditingController note = TextEditingController();

  bool isLoading = false;

  Future<void> addNote() async {
    CollectionReference noteCategory = FirebaseFirestore.instance
        .collection('categories')
        .doc(widget.docId)
        .collection('note');

    if (globalKey.currentState!.validate()) {
      try {
        await noteCategory.add({'note': note.text});

        //print("Category Added Successfully");
        CustomSnackBarWidget.show(
          context: context,
          message: 'Note added successfully',
          isSuccess: true,
        );

        if (!mounted) return;

        Navigator.of(context).pop(
          MaterialPageRoute(
            builder: (context) => NoteView(CategoryId: widget.docId),
          ),
        );
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
    note.dispose();
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: Text("Add Note")),

      body: Form(
        key: globalKey,
        child: Column(
          children: [
            SizedBox(height: 10),
            Container(
              padding: EdgeInsets.symmetric(vertical: 20, horizontal: 30),
              child: CustomTextFieldAdd(
                hinttext: "Enter your note",
                mycontroller: note,
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
                addNote();
              },
            ),
          ],
        ),
      ),
    );
  }
}
