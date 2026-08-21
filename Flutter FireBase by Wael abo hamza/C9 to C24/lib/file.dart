import 'dart:io';
import 'dart:typed_data';
import 'package:path/path.dart';
import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:firebase_storage/firebase_storage.dart';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';

class FileOperations extends StatefulWidget {
  const FileOperations({super.key});

  @override
  State<FileOperations> createState() => _FileOperationsState();
}

class _FileOperationsState extends State<FileOperations> {
  //for phones
  //File? file;

  //for cross platform
  File? selectedImage;
  var url;
  getImage() async {
    final picker = ImagePicker();
    // Pick an image.
    //final XFile? image = await picker.pickImage(source: ImageSource.gallery);
    // Capture a photo.
    final XFile? photo = await picker.pickImage(source: ImageSource.gallery);

    //file = File(photo!.path);
    if (photo != null) {
      selectedImage = File(photo.path);

      var imagename = basename(photo.path);
      var refStorage = FirebaseStorage.instance.ref("images/$imagename");
      await refStorage.putFile(selectedImage!);

      url = await refStorage.getDownloadURL();
    }
    setState(() {});
  }

  @override
  void initState() {
    super.initState();
    //initialData();
  }

  final Stream<QuerySnapshot> usersStream = FirebaseFirestore.instance
      .collection('users')
      .snapshots();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Filter Users")),

      body: Container(
        child: Column(
          children: [
            const SizedBox(height: 20),

            MaterialButton(
              color: Colors.blue,
              textColor: Colors.white,
              padding: EdgeInsets.all(10),
              onPressed: () async {
                await getImage();
              },
              child: Text("Get Your Image"),
            ),

            const SizedBox(height: 20),

            if (url != null)
            Image.network( url , width:100 , height: 100, fit: BoxFit.fill, )
            else
               Text("no image found"),
              /*FutureBuilder<Uint8List>(
                future: selectedImage!.readAsBytes(),
                builder: (context, snapshot) {
                  if (snapshot.connectionState == ConnectionState.done &&
                      snapshot.hasData) {
                    return SizedBox(
                      height: 200,
                      width: 200,
                      child: url != null? Image.network(snapshot.data!, fit: BoxFit.cover),
                    );
                  }
                  return const CircularProgressIndicator();
                },
              ),*/
          ],
        ),
      ),
    );
  }
}
