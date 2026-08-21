import 'package:awesome_dialog/awesome_dialog.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/material.dart';
import 'package:flutter_pro/components/custombuttonauth.dart';
import 'package:flutter_pro/components/customlogoauth.dart';
import 'package:flutter_pro/components/textformfield.dart';
import 'package:flutter/gestures.dart';

class SignUp extends StatefulWidget {
  const SignUp({super.key});

  @override
  State<SignUp> createState() => _SignUpState();
}

class _SignUpState extends State<SignUp> {
  TextEditingController username = TextEditingController();
  TextEditingController email = TextEditingController();
  TextEditingController password = TextEditingController();
  GlobalKey<FormState> formState = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: Container(
        padding: const EdgeInsets.all(20),
        child: ListView(
          children: [
            Form(
              key: formState,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  Container(height: 50),
                  const CustomLogoAuth(),
                  Container(height: 20),
                  const Text(
                    "SignUp",
                    style: TextStyle(fontSize: 30, fontWeight: FontWeight.bold),
                  ),
                  Container(height: 10),
                  const Text(
                    "SignUp To Continue Using The App",
                    style: TextStyle(color: Colors.grey),
                  ),
                  Container(height: 20),
                  const Text(
                    "username",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
                  ),
                  Container(height: 10),
                  CustomTextForm(
                    hinttext: "ُEnter Your username",
                    mycontroller: username,
                    validator: (val) {
                      if (val!.isEmpty) {
                        return "Required";
                      }
                    },
                  ),
                  Container(height: 20),
                  const Text(
                    "Email",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
                  ),
                  Container(height: 10),
                  CustomTextForm(
                    hinttext: "ُEnter Your Email",
                    mycontroller: email,
                    validator: (val) {
                      if (val!.isEmpty) {
                        return "Required";
                      }
                    },
                  ),
                  Container(height: 10),
                  const Text(
                    "Password",
                    style: TextStyle(fontWeight: FontWeight.bold, fontSize: 18),
                  ),
                  Container(height: 10),
                  CustomTextForm(
                    hinttext: "ُEnter Your Password",
                    mycontroller: password,
                    validator: (val) {
                      if (val!.isEmpty) {
                        return "Required";
                      }
                    },
                  ),
                  Container(
                    margin: const EdgeInsets.only(top: 10, bottom: 20),
                    alignment: Alignment.topRight,
                    child: const Text(
                      "Forgot Password ?",
                      style: TextStyle(fontSize: 14),
                    ),
                  ),
                ],
              ),
            ),
            CustomButtonAuth(
              title: "SignUp",
              onPressed: () async {
                try {
                  final credential = await FirebaseAuth.instance
                      .createUserWithEmailAndPassword(
                        email: email.text,
                        password: password.text,
                      );
                  FirebaseAuth.instance.currentUser!.sendEmailVerification();
                  AwesomeDialog(
                    context: context,
                    dialogType: DialogType.info,
                    animType: AnimType.bottomSlide,
                    title: 'Info',
                    desc: "Please verify your email",
                    width: 400,
                    showCloseIcon: true,
                    btnOkOnPress: () {},
                    btnOkColor: Colors.blue,
                    buttonsTextStyle: TextStyle(color: Colors.white),
                    customHeader: Container(
                      decoration: const BoxDecoration(
                        shape: BoxShape.circle,
                        color: Colors.blue,
                      ),
                      child: const Icon(
                        Icons.info,
                        size: 40,
                        color: Colors.white,
                      ),
                    ),
                  )..show();
                  if (credential.user!.emailVerified) {
                    Navigator.pushReplacementNamed(context, "homepage");
                  }
                  print("Sign up is success ");
                } on FirebaseAuthException catch (e) {
                  if (e.code == 'weak-password') {
                    print('The password provided is too weak.');
                  } else if (e.code == 'email-already-in-use') {
                    print('The account already exists for that email.');
                  }
                } catch (e) {
                  print(e);
                }
              },
            ),
            Container(height: 20),

            Container(height: 20),

            // Text("Don't Have An Account ? Resister" , textAlign: TextAlign.center,)
            Center(
              child: Text.rich(
                TextSpan(
                  children: [
                    TextSpan(text: "Have An Account ? "),
                    TextSpan(
                      text: "Login",
                      style: TextStyle(
                        color: Colors.orange,
                        fontWeight: FontWeight.bold,
                      ),
                      recognizer: TapGestureRecognizer()
                        ..onTap = () {
                          Navigator.of(context).pushNamed("login");
                        },
                    ),
                  ],
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
