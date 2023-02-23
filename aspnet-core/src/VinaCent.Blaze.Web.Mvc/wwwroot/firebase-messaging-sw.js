// Initialize Firebase
const firebaseConfig = {
    apiKey: "AIzaSyAcHOx6UCBJM5Vrv_cXQpXbHmzDJ1HvoIw",
    authDomain: "demofcm-438a6.firebaseapp.com",
    projectId: "demofcm-438a6",
    storageBucket: "demofcm-438a6.appspot.com",
    messagingSenderId: "30235707698",
    appId: "1:30235707698:web:c72c8aa155932bf672af2b",
    measurementId: "G-PZH74MN07F"
};
// Give the service worker access to Firebase Messaging.
// Note that you can only use Firebase Messaging here. Other Firebase libraries
// are not available in the service worker.
importScripts('https://www.gstatic.com/firebasejs/8.10.1/firebase-app.js');
importScripts('https://www.gstatic.com/firebasejs/8.10.1/firebase-messaging.js');

// Initialize the Firebase app in the service worker by passing in
// your app's Firebase config object.
// https://firebase.google.com/docs/web/setup#config-object
firebase.initializeApp(firebaseConfig);

// Retrieve an instance of Firebase Messaging so that it can handle background
// messages.
const messaging = firebase.messaging();
messaging.onBackgroundMessage((payload) => {
    console.log(
        '[firebase-messaging-sw.js] Received background message ',
        payload
    );
    //// Customize notification here
    //const notificationTitle = 'Background Message Title';
    //const notificationOptions = {
    //    body: 'Background Message body.',
    //    icon: '/firebase-logo.png'
    //};

    //self.registration.showNotification(notificationTitle, notificationOptions);
});
