$(document).ready(function () {
    // Ocultar todas las pantallas por defecto excepto la primera
    $("#cuartos-disponibles, #cuartos-ocupados, #cuartos-todo").hide();

    // Manejar el clic en las opciones
    $("#opc-disponibles").click(function () {
        $("#cuartos-ocupados").hide();
        $("#cuartos-todos").hide();
        $("#cuartos-disponibles").show();
    });

    $("#opc-ocupados").click(function () {
        $("#cuartos-disponibles").hide();
        $("#cuartos-todos").hide();
        $("#cuartos-ocupados").show();
    });

    $("#opc-todos").click(function () {
        $("#cuartos-disponibles").hide();
        $("#cuartos-ocupados").hide();
        $("#cuartos-todos").show();
    });

    $("#cuartos-todos").show();

});

document.addEventListener("DOMContentLoaded", function () {
    var links = document.querySelectorAll(".menu-opc a");

    links.forEach(function (link) {
        link.addEventListener("click", function (event) {
            // Remover la clase "active" de todos los enlaces
            links.forEach(function (link) {
                link.classList.remove("active");
            });

            // Agregar la clase "active" al enlace clicado
            this.classList.add("active");
        });
    });
});