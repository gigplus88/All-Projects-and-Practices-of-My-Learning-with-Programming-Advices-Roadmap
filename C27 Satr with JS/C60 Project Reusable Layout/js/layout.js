async function loadComponent(selector, url) {
  const container = document.querySelector(selector);
  if (!container) return;

  const response = await fetch(url);
  container.innerHTML = await response.text();
}

loadComponent("#header", "components/header.html");
loadComponent("#sidebar", "components/sidebar.html");
loadComponent("#footer", "components/footer.html");

