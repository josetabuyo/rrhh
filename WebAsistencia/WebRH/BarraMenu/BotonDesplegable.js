
var BotonDesplegable = function (nombre_boton, elemento_desplegable) {

    var boton = $("#" + nombre_boton);
    var elemento = $("#" + elemento_desplegable);
    elemento.hide();

    boton.click(function () {
        elemento.toggle();

    });

    $(document).mouseup(function (e) {

        if (!elemento.is(e.target) && elemento.has(e.target).length === 0 && !boton.is(e.target) && boton.has(e.target).length === 0){
            elemento.hide();
        
        }
    });
}