import firebase from 'firebase'

var firebaseConfig = {
    apiKey: "AIzaSyAFqTo7mmqGalFJT0S6dLj0ELYBr6sNjnI",
    authDomain: "senai-spmedicalgroup.firebaseapp.com",
    databaseURL: "https://senai-spmedicalgroup.firebaseio.com",
    projectId: "senai-spmedicalgroup",
    storageBucket: "senai-spmedicalgroup.appspot.com",
    messagingSenderId: "1040652905505",
    appId: "1:1040652905505:web:5fc1c94e6b6e52de"
  };
  firebase.initializeApp(firebaseConfig)

  export default firebase