importScripts(
  "https://www.gstatic.com/firebasejs/10.12.0/firebase-app-compat.js",
);
importScripts(
  "https://www.gstatic.com/firebasejs/10.12.0/firebase-messaging-compat.js",
);

firebase.initializeApp({
  apiKey: "AIzaSyBlzZoezXtjyfC0HtrPhwVWuxAkjZPwG8Q",
  authDomain: "flutter-pro-app-2026.firebaseapp.com",
  projectId: "flutter-pro-app-2026",
  storageBucket: "flutter-pro-app-2026.firebasestorage.app",
  messagingSenderId: "342813350391",
  appId: "1:342813350391:web:1c3686285eff4c1b13b6f2",
});

const messaging = firebase.messaging();

messaging.onBackgroundMessage((payload) => {
  console.log(
    "[firebase-messaging-sw.js] Received background message ",
    payload,
  );
});
