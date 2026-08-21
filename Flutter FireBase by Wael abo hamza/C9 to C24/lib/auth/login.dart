import 'package:awesome_dialog/awesome_dialog.dart';
import 'package:firebase_auth/firebase_auth.dart';
import 'package:flutter/gestures.dart';
import 'package:flutter/material.dart';
import 'package:flutter_pro/components/custombuttonauth.dart';
import 'package:flutter_pro/components/customlogoauth.dart';
import 'package:flutter_pro/components/textformfield.dart';
import 'package:google_sign_in/google_sign_in.dart';

class Login extends StatefulWidget {
  const Login({super.key});

  @override
  State<Login> createState() => _LoginState();
}

class _LoginState extends State<Login> {
  bool isLoading = false;
  bool isLoadingByGoogle = false;
  TextEditingController email = TextEditingController();
  TextEditingController password = TextEditingController();
  GlobalKey<FormState> formState = GlobalKey<FormState>();

  // it help to login and sign up
  Future signInWithGoogle() async {
    try {
      const webClientId =
          "558888092449-6sko72jst2t3jund29gmps7ts4aut694.apps.googleusercontent.com";

      final GoogleSignInAccount? googleUser = await GoogleSignIn(
        clientId: webClientId,
      ).signIn();

      // if the user open google window and he is not sign in
      if (googleUser == null) return;

      final GoogleSignInAuthentication? googleAuth =
          await googleUser.authentication;

      final credential = GoogleAuthProvider.credential(
        accessToken: googleAuth?.accessToken,
        idToken: googleAuth?.idToken,
      );

      // 4. Once signed in, return the UserCredential
      await FirebaseAuth.instance.signInWithCredential(credential);
      print("Google Sign-In successfully");

      if (!mounted) return;
      Navigator.pushNamedAndRemoveUntil(context, "homepage", (route) => false);
    } catch (e) {
      print("Google Sign-In Error: $e");

      if (!mounted) return;
      AwesomeDialog(
        context: context,
        dialogType: DialogType.error,
        animType: AnimType.bottomSlide,
        title: 'Google Sign-In Error',
        desc: "error to sign in with google",
        width: 400,
        showCloseIcon: true,
        btnOkOnPress: () {},
        btnOkColor: Colors.red,
      )..show();
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: isLoading
          ? const Center(child: CircularProgressIndicator())
          : Container(
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
                          "Login",
                          style: TextStyle(
                            fontSize: 30,
                            fontWeight: FontWeight.bold,
                          ),
                        ),
                        Container(height: 10),
                        const Text(
                          "Login To Continue Using The App",
                          style: TextStyle(color: Colors.grey),
                        ),
                        Container(height: 20),
                        const Text(
                          "Email",
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                            fontSize: 18,
                          ),
                        ),
                        Container(height: 10),
                        CustomTextForm(
                          hinttext: "Enter Your Email",
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
                          style: TextStyle(
                            fontWeight: FontWeight.bold,
                            fontSize: 18,
                          ),
                        ),
                        Container(height: 10),
                        CustomTextForm(
                          hinttext: "Enter Your Password",
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
                          child: Text.rich(
                            TextSpan(
                              children: [
                                const TextSpan(
                                  text: "Forgot Password ? ",
                                  style: TextStyle(
                                    color: Colors.grey,
                                    fontSize: 14,
                                  ),
                                ),
                                TextSpan(
                                  text: "Reset",
                                  style: const TextStyle(
                                    color: Colors.blue,
                                    fontWeight: FontWeight.bold,
                                    fontSize: 14,
                                  ),
                                  recognizer: TapGestureRecognizer()
                                    ..onTap = () async {
                                      if (email.text == "") {
                                        (AwesomeDialog(
                                          context: context,
                                          dialogType: DialogType.warning,
                                          animType: AnimType.bottomSlide,
                                          title: 'Warning',
                                          desc: "Please center your email yet",
                                          width: 400,
                                          showCloseIcon: true,
                                          btnOkOnPress: () {},
                                          btnOkColor: Colors.red,
                                          buttonsTextStyle: TextStyle(
                                            color: Colors.white,
                                          ),
                                          customHeader: Container(
                                            decoration: const BoxDecoration(
                                              shape: BoxShape.circle,
                                              color: Colors.red,
                                            ),
                                            child: const Icon(
                                              Icons.error,
                                              size: 40,
                                              color: Colors.white,
                                            ),
                                          ),
                                        )..show());
                                        return;
                                      }

                                      try {
                                        await FirebaseAuth.instance
                                            .sendPasswordResetEmail(
                                              email: email.text,
                                            );

                                        AwesomeDialog(
                                          context: context,
                                          dialogType: DialogType.info,
                                          animType: AnimType.bottomSlide,
                                          title: 'Info',
                                          desc:
                                              "Please check your email to reset your password",
                                          width: 400,
                                          showCloseIcon: true,
                                          btnOkOnPress: () {},
                                          btnOkColor: Colors.blue,
                                          buttonsTextStyle: TextStyle(
                                            color: Colors.white,
                                          ),
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
                                      } catch (e) {
                                        print(e);
                                      }
                                    },
                                ),
                              ],
                            ),
                          ),
                        ),
                      ],
                    ),
                  ),
                  CustomButtonAuth(
                    title: "login",
                    onPressed: () async {
                      if (formState.currentState!.validate()) {
                        try {
                          isLoading = true;
                          final credential = await FirebaseAuth.instance
                              .signInWithEmailAndPassword(
                                email: email.text.trim(),
                                password: password.text,
                              );
                          isLoading = false;
                          print("Sign in successfully");

                          if (!mounted) return;
                          if (credential.user!.emailVerified) {
                            Navigator.pushReplacementNamed(context, "homepage");
                          } else {
                            FirebaseAuth.instance.currentUser!
                                .sendEmailVerification();
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
                          }
                        } on FirebaseAuthException catch (e) {
                          print("Error Code: ${e.code}");

                          String errorMessage =
                              "An error occurred, please try again.";

                          if (e.code == 'user-not-found' ||
                              e.code == 'wrong-password' ||
                              e.code == 'invalid-credential') {
                            errorMessage = "invalid-credential";
                            print("invalid credentials");
                          } else if (e.code == 'invalid-email') {
                            errorMessage = "invalid-credential";
                            print("The email address is badly formatted");
                          } else {
                            errorMessage = "Error: ${e.message}";
                            print("Error: ${e.message}");
                          }

                          if (!mounted) return;

                          AwesomeDialog(
                            context: context,
                            dialogType: DialogType.error,
                            animType: AnimType.bottomSlide,
                            title: 'Error',
                            desc: errorMessage,
                            width: 400,
                            showCloseIcon: true,
                            btnOkOnPress: () {},
                            btnOkColor: Colors.red,
                            customHeader: Container(
                              decoration: const BoxDecoration(
                                shape: BoxShape.circle,
                                color: Colors.red,
                              ),
                              child: const Icon(
                                Icons.close,
                                size: 40,
                                color: Colors.white,
                              ),
                            ),
                          )..show();
                        }
                      } else {
                        print("invalid empty inputs");
                      }
                    },
                  ),
                  Container(height: 20),

                  MaterialButton(
                    padding: const EdgeInsets.all(20),
                    height: 40,
                    shape: RoundedRectangleBorder(
                      borderRadius: BorderRadius.circular(20),
                    ),
                    color: Colors.red[700],
                    textColor: Colors.white,
                    onPressed: () async {
                      isLoadingByGoogle = true;

                      signInWithGoogle();
                    },
                    child: Row(
                      mainAxisAlignment: MainAxisAlignment.center,
                      children: [
                        const Text("Login With Google  "),
                        Image.asset("images/google.png", width: 20),
                      ],
                    ),
                  ),

                  Container(height: 20),
                  Center(
                    child: Text.rich(
                      TextSpan(
                        children: [
                          const TextSpan(text: "Don't Have An Account ? "),
                          TextSpan(
                            text: "Register",
                            style: const TextStyle(
                              color: Colors.blue,
                              fontWeight: FontWeight.bold,
                            ),
                            recognizer: TapGestureRecognizer()
                              ..onTap = () {
                                Navigator.of(
                                  context,
                                ).pushReplacementNamed("signup");
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
