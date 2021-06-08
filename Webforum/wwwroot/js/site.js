// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const BtnAdd = document.querySelector(".btn-addinput");

BtnAdd.addEventListener("click", AddNewHeadLine);

function AddNewHeadLine() {
    const newInput = document.createElement("input");
    const newSubmitbtn = document.createElement("button");
    
    newInput.setAttribute("type", "text");
    newInput.setAttribute("name", "newInput");
    newSubmitbtn.setAttribute("type", "submit");
    var HtmlForm = document.getElementById("JStxtinput");
    HtmlForm.appendChild(newInput);
    HtmlForm.appendChild(newSubmitbtn);
}