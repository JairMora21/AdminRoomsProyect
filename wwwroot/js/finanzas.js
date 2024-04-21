//$(document).ready(function () {
//    // Ocultar todas las pantallas por defecto excepto la primera
//    $("#Asignaciones, #Finanzas, #Facturas").hide();

//    // Manejar el clic en las opciones
//    $("#opc-asignaciones").click(function () {
//        $("#Facturas").hide();
//        $("#Finanzas").hide();
//        $("#Asignaciones").show();
//    });

//    $("#opc-facturas").click(function () {
//        $("#Asignaciones").hide();
//        $("#Finanzas").hide();
//        $("#Facturas").show();
//    });

//    $("#opc-finanzas").click(function () {
//        $("#Facturas").hide();
//        $("#Asignaciones").hide();
//        $("#Finanzas").show();
//    });

//    $("#Asignaciones").show();

//});

//document.addEventListener("DOMContentLoaded", function () {
//    var links = document.querySelectorAll(".menu-opc a");

//    links.forEach(function (link) {
//        link.addEventListener("click", function (event) {
//            // Remover la clase "active" de todos los enlaces
//            links.forEach(function (link) {
//                link.classList.remove("active");
//            });

//            // Agregar la clase "active" al enlace clicado
//            this.classList.add("active");
//        });
//    });
//});