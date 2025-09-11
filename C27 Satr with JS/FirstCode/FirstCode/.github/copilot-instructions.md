# Copilot Instructions for This Project

## Project Overview
- This is a simple JavaScript project with a single HTML file (`index.html`) and a script file (`script.js`).
- The HTML file loads the JavaScript using the `defer` attribute, ensuring scripts run after the DOM is parsed.
- The project demonstrates basic JavaScript output and variable usage.

## Key Files
- `index.html`: Main HTML entry point. Loads `script.js` with `defer`.
- `script.js`: Contains all JavaScript logic. Example: logs name, age, and a sum to the console.

## Patterns & Conventions
- Always use the `defer` attribute when including scripts in HTML. This is explicitly noted in the HTML comment.
- JavaScript is written in a single file and is not modularized.
- Console output is used for all user feedback and demonstration.
- Variable declarations use `let` (e.g., `let Age;`).

## Developer Workflow
- Open `index.html` in a browser to view the page and see console output.
- No build, test, or dependency management tools are used.
- No external libraries or frameworks are present.

## Examples
- To add new JavaScript, edit `script.js` and reload the HTML page in your browser.
- To add more HTML, edit `index.html`.

## Project-Specific Notes
- The comment in `index.html` ("never ever forget the defer attribute") is a key convention: always use `defer` for scripts.
- There are no hidden build steps or custom commands.

---

For more complex workflows or conventions, update this file as the project evolves.
