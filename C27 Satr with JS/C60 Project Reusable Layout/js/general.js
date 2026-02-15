/* =====================================================
   general.js
   Purpose → Global shared functions for all pages
   Notes   → Loaded before page-specific scripts
   ===================================================== */

// Safe DOM ready helper
function onReady(callback) {
  if (document.readyState === "loading") {
    document.addEventListener("DOMContentLoaded", callback);
  } else {
    callback();
  }
}

// Simple selector helpers (optional but useful)
function $(selector) {
  return document.querySelector(selector);
}

function $all(selector) {
  return document.querySelectorAll(selector);
}

// Global log helper (easy to disable later)
function appLog(message) {
  console.log("[APP]", message);
}

function UpdateUserNameInHeader(UserName) {
  $("#UserName").innerText = UserName;
  appLog("UpdateUserNameInHeader function executed");
}
function UpdateMainInHeader(main) {
  $("#main").innerText = main;
  appLog("UpdateMainInHeader function executed");
}
