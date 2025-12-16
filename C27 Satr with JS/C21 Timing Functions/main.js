let count = 0;

function TestFuncInterval() {
  let Interval = setInterval(() => {
    count++;
    document.body.innerHTML += "<p>Run the code every 2 seconds</p>";
    count > 5 ? clearInterval(Interval) : null;
  }, 2000);
  //clearInterval(Interval); //to clear interval before use it
}
//clearInterval(); //to clear interval after use it

function TestFuncInterval() {
  let Interval = setInterval(() => {
    count++;
    document.getElementById("output").innerHTML = count;
    count >= 5 ? clearInterval(Interval) : null;
  }, 2000);
  //clearInterval(Interval); //to clear interval before use it
}

function TestFuncTimeout() {
  let TimeOut = setTimeout(() => {
    alert("Hello after 5 seconds");
  }, 5000);
  //clearTimeout(TimeOut); //to clear timeout before use it
}

function TestFuncIntervalCountDown() {
  count = 5;
  let CurrentNum = document.getElementById("outputDown");

  CurrentNum.innerHTML = count;
  let Interval = setInterval(() => {
    count--;
    CurrentNum.innerHTML = count;
    count <= 0
      ? (clearInterval(Interval),
        setTimeout(() => {
          alert("Countdown Finished");
        }, 500))
      : null;
  }, 1000);
  //clearInterval(Interval); //to clear interval before use it
}

function TestTime() {
  const now = new Date();
  let hours = now.getHours();
  let minutes = now.getMinutes();
  let seconds = now.getSeconds();

  const Interval = setInterval(() => {
    seconds++;

    seconds === 60
      ? ((seconds = 0), minutes++)
      : minutes === 60
      ? ((minutes = 0), hours++)
      : hours === 24
      ? (hours = 0)
      : null;

    // تحديث عناصر الساعة
    document.getElementById("hours").textContent = hours;
    document.getElementById("minutes").textContent = minutes;
    document.getElementById("seconds").textContent = seconds;

    // مثال: إيقاف المؤقت عند الدقيقة 55
    if (minutes === 55) {
      clearInterval(Interval);
    }
  }, 1000);
}
