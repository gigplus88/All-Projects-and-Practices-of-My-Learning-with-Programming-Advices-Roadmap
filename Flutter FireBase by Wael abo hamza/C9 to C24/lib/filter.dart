import 'package:cloud_firestore/cloud_firestore.dart';
import 'package:flutter/material.dart';

class FilterFirestore extends StatefulWidget {
  const FilterFirestore({super.key});

  @override
  State<FilterFirestore> createState() => _FilterFirestoreState();
}

class _FilterFirestoreState extends State<FilterFirestore> {
  List<QueryDocumentSnapshot<Map<String, dynamic>>> data = [];
  bool isLoading = false;

  @override
  void initState() {
    super.initState();
    //initialData();
  }

  final Stream<QuerySnapshot> usersStream = FirebaseFirestore.instance
      .collection('users')
      .snapshots();

  /* Future<void> initialData() async {
    try {
      QuerySnapshot<Map<String, dynamic>> usersData = await FirebaseFirestore
          .instance
          .collection('users')
          .orderBy("age", descending: false)
          .startAfter([20])
          .get();

      setState(() {
        data = usersData.docs;
        isLoading = false;
      });
    } catch (error) {
      print("Failed to filter users data: $error");
      if (!mounted) return;
      setState(() {
        isLoading = false;
      });
    }
  }
*/
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(title: const Text("Filter Users")),

      //Floating
      /*floatingActionButton: FloatingActionButton(
        onPressed: () {
          // batch for all (delete , update , add );
          CollectionReference users = FirebaseFirestore.instance.collection(
            'users',
          );
          DocumentReference doc1 = FirebaseFirestore.instance
              .collection('users')
              .doc("1");
          DocumentReference doc2 = FirebaseFirestore.instance
              .collection('users')
              .doc("2");

          WriteBatch batch = FirebaseFirestore.instance.batch();

          batch.set(doc1, {
            "username": "Salima",
            "money": 120,
            "phone": "0637827384",
            "age": 22,
          });
          batch.set(doc2, {
            "username": "Karim",
            "money": 50,
            "phone": "0637839384",
            "age": 32,
          });

          batch.commit();
          Navigator.pushReplacementNamed(context, "Filterfirestore");
        },
        child: Icon(Icons.add),
      ),*/
      body: /* isLoading
          ? const Center(child: CircularProgressIndicator())
          : usersStream.length==0
          ? const Center(child: Text("No users found"))*/ Container(
        padding: const EdgeInsets.all(10),
        child: StreamBuilder(
          stream: usersStream,
          builder:
              (BuildContext context, AsyncSnapshot<QuerySnapshot> snapshot) {
                if (snapshot.hasError) {
                  return Center(
                    child: Text('Something went wrong: ${snapshot.error}'),
                  );
                }
                if (snapshot.connectionState == ConnectionState.waiting) {
                  return const Center(child: CircularProgressIndicator());
                }
                if (snapshot.connectionState == ConnectionState.done) {
                  if (!snapshot.hasData || snapshot.data!.docs.isEmpty) {
                    return const Center(child: Text("No users found"));
                  }
                }

                var usersData = snapshot.data!.docs;

                return ListView.builder(
                  itemCount: usersData.length,
                  itemBuilder: (context, index) {
                    // var userData = usersData[index];
                    var userData =
                        usersData[index].data() as Map<String, dynamic>;
                    return InkWell(
                      onTap: () {
                        DocumentReference documentReference = FirebaseFirestore
                            .instance
                            .collection('users')
                            .doc(usersData[index].id);

                        FirebaseFirestore.instance.runTransaction((
                          transaction,
                        ) async {
                          DocumentSnapshot snapshot = await transaction.get(
                            documentReference,
                          );

                          if (snapshot.exists) {
                            var snapshotData = snapshot.data();

                            if (snapshotData is Map<String, dynamic>) {
                              int money = snapshotData['money'] ?? 0 + 10;

                              // Perform an update on the document
                              transaction.update(documentReference, {
                                'money': money,
                              });
                              return money;
                            }
                          }

                          return throw Exception("User does not exist!");
                        });
                      },
                      child: Card(
                        child: ListTile(
                          title: Text(userData['username'] ?? 'No Name'),
                          subtitle: Text("Age: ${userData['age'] ?? 'N/A'}"),
                          leading: Text("Money: ${userData['money'] ?? 'N/A'}"),
                        ),
                      ),
                    );
                  },
                );
              },
        ),
      ),
    );
  }
}


//body

/*
ListView.builder(
                itemCount: data.length,
                itemBuilder: (BuildContext context, int index) {
                  var userData = data[index].data();

                  return InkWell(
                    onTap: () {},
                    child: Card(
                      child: ListTile(
                        title: Text(userData['username'] ?? 'No Name'),
                        subtitle: Text("Age: ${userData['age'] ?? 'N/A'}"),
                        leading: Text("Money: ${userData['money'] ?? 'N/A'}"),
                      ),
                    ),
                  );
                },
              ),
 */









/*

 DocumentReference documentReference = FirebaseFirestore
  .instance
  .collection('users')
  .doc(data[index].id);

FirebaseFirestore.instance
  .runTransaction((transaction) async {
    DocumentSnapshot snapshot = await transaction.get(
      documentReference,
    );

    if (snapshot.exists) {
      var snapshotData = snapshot.data();

      if (snapshotData is Map<String, dynamic>) {
        int money = snapshotData['money'] + 10;

        // Perform an update on the document
        transaction.update(documentReference, {
          'money': money,
        });
        return money;
      }
    }

    return Exception("User does not exist!");
  })
  .then((value) {
    Navigator.pushNamedAndRemoveUntil(
      context,
      "Filterfirestore",
      (route) => false,
    );
  });

 */