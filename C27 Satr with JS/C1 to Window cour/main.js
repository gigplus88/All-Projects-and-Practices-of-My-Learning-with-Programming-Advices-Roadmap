// alert() method;
//let name = "Ayoub";

//window.name = "saad";
//console.log(window.name);

//alert("Hello " + name);

//window.alert("Hello " + name);

//alert(`5+4 = ${5+4}`);

//Confirm Method;
//let Result = confirm("Are You Sure");

//Result === true ? alert("Client is Agree") : alert("Client is not Agree");

//confirm("Are You Sure to leave this page") === true ? window.location.href = "https://www.facebook.com" : alert("Stayed in the page");

//Prompt Method;
//let Input = prompt("What is your name");

//Input === null ?alert("User Canceled") : alert(`Hello ${Input}`) ;

//prompt() method with default value;
//let Input2 = prompt("What is your name" , "Ayoub");
//if( Input2 === null)
//  alert("User Canceled")
//else if( Input2 === "")
//  alert("User Entered Empty Value")
//else
//alert(`Hello ${Input2}`) ;

// Some Two ops
//let num1 = prompt("Enter First Number");
//let num2 = prompt("Enter Second Number");

//num1 === null || num2 === null ? alert("User Canceled") :
//num1 === "" || num2 === "" ? alert("User Entered Empty Value") :
//isNaN(num1) || isNaN(num2) ? alert("Invalid Number") :
//alert(`The Sum is ${Number(num1) + Number(num2)}`);

//Write the input in the page
//let Input3 = prompt("What is your name", "Ayoub");

Input3 === null
  ? (Input3 = "User Canceled")
  : Input3 === ""
  ? (Input3 = "User Entered Empty Value")
  : (Input3 = `Hello ${Input3}`);

//document.getElementById("YourIndex").innerHTML = "<p>" + Input3 + "</p>" ;
//document.body.innerHTML = Input3;

//window.open(URL , name , specs ,relace);
//window.open("https://www.google.com" , "_blank" , "width=500,height=500,left=200,top=100");

function openMyWindow() {
  let newWindow = window.open(
    "",
    "myPopup",
    "width=500,height=500,left=200,top=100"
  );
  newWindow.document.write = "<h2>This is My Popup Window</h2>";
}

function openInfoPage() {
  let newWindow = window.open(
    "info.html",
    "_blank",
    "width=500,height=500,left=200,top=100"
  );
}

function openClosePage() {
  let newWindow = window.open(
    "info.html",
    "_blank",
    "width=500,height=500,left=200,top=100"
  );
newWindow.onload = () => {
  newWindow.document.querySelector("#info").innerHTML = "<p>Closing in 5 seconds...</p>";
};
  setTimeout(() => {
    newWindow.close();
  }, 5000);
}

function WritingToAPopupWindow() {
  let newWindow = window.open(
    "",
    "popup",
    "width=500,height=500,left=200,top=100"
  );

      newWindow.document.write("<h2>This is My Popup Window</h2>");
      newWindow.document.write("<p id='info'>This is some information</p>");
      newWindow.document.write("<button onclick='window.close()'>Close Window</button>");

 
    newWindow.document.body.style.backgroundColor = "yellow";
    newWindow.document.body.style.color = "red";
    newWindow.document.body.style.fontWeight = "bold";
    newWindow.document.body.style.textAlign = "center";
    newWindow.document.body.style.fontSize = "20px";
  }


  
function ShowInfo() {
  let newWindow = window.open(
    "info.html",
    "info",
    "width=500,height=500,left=200,top=100 , scrollbars=yes , resizable=yes"
  );

    
  }