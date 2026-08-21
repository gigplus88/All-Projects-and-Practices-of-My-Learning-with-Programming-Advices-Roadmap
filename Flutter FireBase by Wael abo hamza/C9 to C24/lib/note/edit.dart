import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:flutter/material.dart';
import 'package:flutter_pro/components/custombuttonadd.dart';
import 'package:flutter_pro/components/customsnackbar.dart';
import 'package:flutter_pro/components/customtextfieldadd.dart';
import 'package:flutter_pro/note/view.dart';

class EditNote extends StatefulWidget {
  final String categoryId;
  final String noteId;
  final String oldName;

  const EditNote({
    super.key,
    required this.oldName,
    required this.categoryId,
    required this.noteId,
  });

  @override
  State<EditNote> createState() => _EditNoteState();
}

class _EditNoteState extends State<EditNote> {
  GlobalKey<FormState> globalKey = GlobalKey<FormState>();
  late TextEditingController name;

  bool isLoading = false;

  @override
  void initState() {
    super.initState();
    name = TextEditingController(text: widget.oldName);
  }

  @override
  void dispose() {
    name.dispose();
    super.dispose();
  }

  Future<void> editCategory() async {
    CollectionReference categories = FirebaseFirestore.instance
        .collection('categories')
        .doc(widget.categoryId)
        .collection('note');

    if (globalKey.currentState!.validate()) {
      try {
        setState(() {
          isLoading = true;
        });

        await categories.doc(widget.noteId).update({'note': name.text});
        /*await categories.doc(widget.noteId).set({
          'note': name.text,
        }, SetOptions(merge: true));*/

        if (!mounted) return;

        CustomSnackBarWidget.show(
          context: context,
          message: 'Note updated successfully',
          isSuccess: true,
        );

        Navigator.pushReplacement(
          context,
          MaterialPageRoute(
            builder: (context) => NoteView(CategoryId: widget.categoryId),
          ),
        );
      } catch (error) {
        print("Failed to update category: $error");
        setState(() {
          isLoading = false;
        });
      }
    } else {
      print("Validation failed");
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Edit Note")),
      body: isLoading
          ? const Center(child: CircularProgressIndicator())
          : Form(
              key: globalKey,
              child: Column(
                children: [
                  const SizedBox(height: 10),
                  Container(
                    padding: const EdgeInsets.symmetric(
                      vertical: 20,
                      horizontal: 30,
                    ),
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
                    title: "Save",
                    onPressed: () async {
                      editCategory();
                    },
                  ),
                ],
              ),
            ),
    );
  }
}
