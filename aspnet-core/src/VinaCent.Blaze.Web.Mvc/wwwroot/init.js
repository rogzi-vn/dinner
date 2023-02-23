// Import the functions you need from the SDKs you need
import { initializeApp } from "https://www.gstatic.com/firebasejs/9.17.1/firebase-app.js";
import { getMessaging, getToken } from "https://www.gstatic.com/firebasejs/9.17.1/firebase-messaging.js";

const firebaseConfig = {
    apiKey: "AIzaSyAcHOx6UCBJM5Vrv_cXQpXbHmzDJ1HvoIw",
    authDomain: "demofcm-438a6.firebaseapp.com",
    projectId: "demofcm-438a6",
    storageBucket: "demofcm-438a6.appspot.com",
    messagingSenderId: "30235707698",
    appId: "1:30235707698:web:c72c8aa155932bf672af2b",
    measurementId: "G-PZH74MN07F"
};

function requestPermission() {
    console.log("Requesting permission...");
    Notification.requestPermission().then((permission) => {
        if (permission === "granted") {
            console.log("Notification permission granted.");
            const app = initializeApp(firebaseConfig);

            const messaging = getMessaging(app);
            getToken(messaging, {
                vapidKey:
                    "BI5OQvG5T99Nf7F0WnbLXfbPEzk4_CUXwEIxDDJdTfx2srlSyi7aDi3aQMQ7nfCnshcrm9Nxbwa1S4ERFv2i3HI",
            }).then((currentToken) => {
                if (currentToken) {
                    console.log("currentToken: ", currentToken);
                } else {
                    console.log("Can not get token");
                }
            });
        } else {
            console.log("Do not have permission!");
        }
    });
}

requestPermission();