function openPageWithFocus() {
  let newWindow = window.open(
    "info.html",
    "infoWindow",
    "width=500,height=500,left=200,top=100"
  );

  setTimeout(() => {
    newWindow.focus();
  }, 3000);
}

function openPageWithblur() {
  let newWindow = window.open(
    "info.html",
    "infoWindow",
    "width=500,height=500,left=200,top=100"
  );

  setTimeout(() => {
    newWindow.blur();
  }, 3000);
}

function openPageWithMoveTo() {
  let newWindow = window.open(
    "info.html",
    "infoWindow",
    "width=500,height=500,left=200,top=100"
  );

  setTimeout(() => {
    newWindow.moveTo(400, 400);
  }, 3000);
}

function TestInner() {
  console.clear();
  console.log("Content width: " + window.innerWidth);
  console.log("Content height: " + window.innerHeight);

  if (window.innerWidth < 700) {
    document.body.style.backgroundColor = "green";
    document.body.style.color = "white";
    window.alert("Your device background color is rose");
  } else {
    document.body.style.backgroundColor = "white";
    document.body.style.color = "black";
  }
}
function TestOuter() {
  console.clear();
  console.log("Content width: " + window.outerWidth);
  console.log("Content height: " + window.outerHeight);

  if (window.innerWidth < 700) {
    document.body.style.backgroundColor = "yellow";
    document.body.style.color = "white";
    //window.alert("Your device background color is rose");
  } else {
    document.body.style.backgroundColor = "white";
    document.body.style.color = "black";
  }
}

function TestScreen() {
  console.clear();
  console.log("Screen width: " + window.screenX);
  console.log("Screen height: " + window.screenY);

  if (window.screenX >= 500) {
    document.body.style.backgroundColor = "red";
    document.body.style.color = "white";
    //window.alert("Your device background color is rose");
  } else {
    document.body.style.backgroundColor = "white";
    document.body.style.color = "black";
  }
}
