$(document).ready(function () {

    //activo los tooltips
    $('[data-toggle="tooltip"]').tooltip()


    //agrego el handler de los componentes que cambian de pantalla
    $('[target_scr]').click(function () {
        var pantalla = this.attributes.target_scr.value
        mostrarPantalla(pantalla);
    })

    var mostrarPantalla = function(pantalla) {
        $('[role="tabpanel"]').hide()
        $(pantalla).show()
    }

})

