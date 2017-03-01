$(document).ready(function () {
    $(document).mousedown(function (e) {
        if (e.which == 3) {
            alert("Botón derecho deshabilitado, por favor imprima utilizando el botón Imprimir del formulario.");
            return false;
        }
    });
    $('body').addClass('no_imprimible');
    $(':submit').mousedown(function () {
        $('body').removeClass('no_imprimible');
    });
});
function ImprimirPantalla() {
    window.print();
    alert("La Licencia quedó activada en el Sistema");
};
