var saveButton = document.querySelector("#button-save");
var textInput = document.querySelector("#text-input");
var ulElement = document.querySelector("#ul-list");

function getInputText() {
  return textInput.value;
}

function clearInputText() {
  textInput.value = "";
}

function addNewItem() {
  saveButton.addEventListener("click", (event) => {
    const liElement = document.createElement("li");

    const p = document.createElement("p");
    p.innerHTML = getInputText();

    const btn = document.createElement("button");
    btn.className = "btn-delete";
    btn.innerHTML = "Sil";

    liElement.prepend(p, btn);

    ulElement.prepend(liElement);

    addItemToLocalStorage();

    clearInputText();
  });
}

function deleteItem() {
  ulElement.addEventListener("click", (event) => {
    if (event.target.className === "btn-delete") {
      event.target.parentElement.remove();
      deleteItemFromLocalStorage(
        event.target.parentElement.children[0].textContent
      );
    }
  });
}

function addItemToLocalStorage() {
  let storage = [];
  let items = document.querySelectorAll("#ul-list li p");

  for (let i = 0; i < items.length; i++) {
    storage.push(items[i].innerText);
    localStorage.setItem("item", JSON.stringify(storage));
  }
}

let items = "";

function getItemsFromLocalStorage() {
  if (localStorage.getItem("item") === null) {
    items = [];
  } else {
    items = JSON.parse(localStorage.getItem("item"));
  }
  return items;
}

function deleteItemFromLocalStorage(text) {
  items = getItemsFromLocalStorage();

  for (let i = 0; i < items.length; i++) {
    if (items[i] === text) {
      items.splice(i, 1);
    }
  }
  localStorage.setItem("item", JSON.stringify(items));
}

function fillData() {
  let items = getItemsFromLocalStorage();
  let result = items.map((item) => {
    let li = document.createElement("li");
    let p = document.createElement("p");
    let button = document.createElement("button");
    button.className = "btn-delete";
    button.innerText = "Sil";
    p.innerText = item;

    li.prepend(p, button);

    ulElement.prepend(li);
  });
}

fillData();

deleteItem();

addNewItem();
