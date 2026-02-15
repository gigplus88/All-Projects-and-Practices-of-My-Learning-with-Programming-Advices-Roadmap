export class Calculator {
  add(a, b) {
    this.#validateNumbers(a, b);
    return a + b;
  }

  multiplication(a, b) {
    this.#validateNumbers(a, b);
    return a * b;
  }

  substraction(a, b) {
    this.#validateNumbers(a, b);
    return a - b;
  }

  division(a, b) {
    this.#validateNumbers(a, b);
    this.#validateZero(b);
    return a / b;
  }

   #validateNumbers(a, b) {
    if (typeof a !== 'number' || typeof b !== 'number') {
        throw new Error("You must enter only a number");
    }
    }
    #validateZero(b) {
    if (typeof b === 0 ) {
        throw new Error("you should have great tan zero value");
    }
    }
}


