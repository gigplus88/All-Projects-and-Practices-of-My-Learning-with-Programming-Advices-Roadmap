import 'package:awesome_dialog/awesome_dialog.dart';
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:flutter_pro/note/add.dart';
import 'package:flutter_pro/note/edit.dart';
import 'package:google_sign_in/google_sign_in.dart';

class NoteView extends StatefulWidget {
  final String CategoryId;
  const NoteView({super.key, required this.CategoryId});

  @override
  State<NoteView> createState() => _NoteViewState();
}

class _NoteViewState extends State<NoteView> {
  Map<String, dynamic> data = {};
  bool isLoading = true;

  Future<void> getData() async {
    try {
      QuerySnapshot querySnapshot = await FirebaseFirestore.instance
          .collection("categories")
          .doc(widget.CategoryId)
          .collection("note")
          .get();

      setState(() {
        for (var doc in querySnapshot.docs) {
          data[doc.id] = doc.data() as Map<String, dynamic>;
        }
        isLoading = false;
      });
    } catch (e) {
      print("Error fetching data: $e");
      setState(() {
        isLoading = false;
      });
    }
  }

  @override
  void initState() {
    super.initState();
    getData();
  }

  @override
  void dispose() {
    super.dispose();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      floatingActionButton: FloatingActionButton(
        onPressed: () {
          Navigator.of(context).push(
            MaterialPageRoute(
              builder: (context) => AddNote(docId: widget.CategoryId),
            ),
          );
        },
        backgroundColor: Colors.blue[100],
        child: const Icon(Icons.add),
      ),
      appBar: AppBar(
        title: const Text("Notes"),
        leading: IconButton(
          icon: const Icon(Icons.arrow_back),
          onPressed: () {
            Navigator.pushNamedAndRemoveUntil(
              context,
              "homepage",
              (route) => false,
            );
          },
        ),
        actions: [
          IconButton(
            onPressed: () async {
              GoogleSignIn googleSignIn = GoogleSignIn();
              googleSignIn.disconnect();

              await FirebaseAuth.instance.signOut();
              print("Is sign out");
              Navigator.pushNamedAndRemoveUntil(
                context,
                "login",
                (route) => false,
              );
            },
            icon: const Icon(Icons.exit_to_app),
          ),
        ],
      ),
      body: PopScope(
        canPop: false, // منع الرجوع الافتراضي
        onPopInvokedWithResult: (bool didPop, dynamic result) {
          if (didPop) {
            return;
          }
          Navigator.pushNamedAndRemoveUntil(
            context,
            "homepage",
            (route) => false,
          );
        },
        child: isLoading
            ? const Center(child: CircularProgressIndicator())
            : data.isEmpty
            ? const Center(child: Text("No notes found"))
            : GridView.builder(
                gridDelegate: const SliverGridDelegateWithFixedCrossAxisCount(
                  crossAxisCount: 2,
                  mainAxisExtent: 250,
                ),
                itemCount: data.length,
                itemBuilder: (BuildContext context, int index) {
                  String key = data.keys.elementAt(index);
                  var noteData = data[key];

                  return InkWell(
                    onDoubleTap: () {
                      showModalBottomSheet(
                        context: context,
                        shape: const RoundedRectangleBorder(
                          borderRadius: BorderRadius.vertical(
                            top: Radius.circular(20),
                          ),
                        ),
                        builder: (context) {
                          return Container(
                            padding: const EdgeInsets.all(20),
                            child: Column(
                              mainAxisSize: MainAxisSize.min,
                              children: [
                                Container(
                                  width: 40,
                                  height: 5,
                                  decoration: BoxDecoration(
                                    color: Colors.grey[300],
                                    borderRadius: BorderRadius.circular(10),
                                  ),
                                ),
                                const SizedBox(height: 20),
                                const Text(
                                  "Note Details",
                                  style: TextStyle(
                                    fontSize: 20,
                                    fontWeight: FontWeight.bold,
                                  ),
                                ),
                                const Divider(),
                                const SizedBox(height: 10),
                                ListTile(
                                  leading: const Icon(
                                    Icons.note,
                                    color: Colors.blue,
                                  ),
                                  title: const Text("Note Content"),
                                  subtitle: Text(
                                    noteData['note'] ?? 'No Content',
                                  ),
                                ),
                                ListTile(
                                  leading: const Icon(
                                    Icons.badge,
                                    color: Colors.blue,
                                  ),
                                  title: const Text("Document ID"),
                                  subtitle: Text(key),
                                ),
                                const SizedBox(height: 20),
                              ],
                            ),
                          );
                        },
                      );
                    },
                    onLongPress: () {
                      AwesomeDialog(
                        context: context,
                        dialogType: DialogType.warning,
                        animType: AnimType.bottomSlide,
                        title: 'Warning',
                        desc: "Choose What do you want?",
                        width: 400,
                        showCloseIcon: true,
                        btnOkOnPress: () async {
                          Navigator.push(
                            context,
                            MaterialPageRoute(
                              builder: (context) => EditNote(
                                categoryId: widget.CategoryId,
                                noteId: key,
                                oldName: noteData['note'],
                              ),
                            ),
                          );
                        },
                        btnOkText: "Update",
                        btnOkColor: Colors.blue,
                        btnCancelText: "Delete",

                        btnCancelOnPress: () async {
                          await FirebaseFirestore.instance
                              .collection("categories")
                              .doc(widget.CategoryId)
                              .collection("note")
                              .doc(key)
                              .delete();

                          Navigator.pushReplacement(
                            context,
                            MaterialPageRoute(
                              builder: (context) =>
                                  NoteView(CategoryId: widget.CategoryId),
                            ),
                          );
                        },

                        customHeader: Container(
                          decoration: const BoxDecoration(
                            shape: BoxShape.circle,
                            color: Colors.red,
                          ),
                          child: const Icon(
                            Icons.warning,
                            size: 40,
                            color: Colors.white,
                          ),
                        ),
                      )..show();
                    },
                    child: Card(
                      margin: const EdgeInsets.symmetric(
                        vertical: 20,
                        horizontal: 10,
                      ),
                      child: Container(
                        padding: const EdgeInsets.all(20),
                        child: Column(
                          children: [
                            /*Image.asset(
                              "images/imagesremovebgpreview.png",
                              height: 150,
                            ),*/
                            const SizedBox(height: 10),
                            Text(
                              noteData['note'] ?? 'No Note',
                              style: const TextStyle(
                                fontWeight: FontWeight.bold,
                                fontSize: 16,
                              ),
                            ),
                          ],
                        ),
                      ),
                    ),
                  );
                },
              ),
      ),
    );
  }
}
