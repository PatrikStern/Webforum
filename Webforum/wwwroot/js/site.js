// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const BtnAdd = document.querySelector(".btn-addinput");
const expandsMore = document.querySelectorAll('[expand-more]');



expandsMore.forEach(expandMore => { expandMore.addEventListener('click', expand) });
BtnAdd.addEventListener("click", AddNewHeadLine);

function AddNewHeadLine() {
    const newInput = document.createElement("input");
    const newSubmitbtn = document.createElement("button");

    newInput.setAttribute("class", "m-1");
    newInput.setAttribute("type", "text");
    newInput.setAttribute("name", "newInput");
    newSubmitbtn.setAttribute("class", "btn btn-primary btn-sm")
    newSubmitbtn.innerHTML = "Lägg till";
    newSubmitbtn.setAttribute("type", "submit");
    var HtmlForm = document.getElementById("JStxtinput");
    HtmlForm.appendChild(newInput);
    HtmlForm.appendChild(newSubmitbtn);
}

function expand() {
    const showContent = document.getElementById(this.dataset.target)
    if (showContent.classList.contains('expand-active')) {
        this.innerHTML = this.dataset.showtext
    }
    else {
        this.innerHTML = this.dataset.hidetext
    }
    showContent.classList.toggle('expand-active')
}