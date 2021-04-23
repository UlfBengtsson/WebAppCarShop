var allBtnElement = document.getElementById("allBtn");
var inputBtnElement = document.getElementById("inputBtn");
var textInputElement = document.getElementById("textInput");
var resultDivElement = document.getElementById("resultDiv");

allBtnElement.addEventListener("click", ajaxGetAllCars);
inputBtnElement.addEventListener("click", ajaxPostDetailCar);

function ajaxGetAllCars() {
    $.get("Exampel/AllCarsPartcialView", function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);
        resultDivElement.innerHTML = data;
    });
}

function ajaxPostDetailCar() {

    //if textInputElement.value is null/empty don´t do post

    $.post("Exampel/DetailsPartcialView",
        {
            id: textInputElement.value
        }
        , function (data, status) {
        console.log("Data: " + data + "\nStatus: " + status);
        resultDivElement.innerHTML = data;
    });
}