var Licencias = {

    CambiarSegmentos: function () {
        if ($("body").find("[class=VerificarSegmento]").length > 0) {
            alert("hola");
            $($("body").find("[class=VerificarSegmento]")).removeClass("VerificarSegmento");
        }

        setTimeout(function () { Licencias.CambiarSegmentos() }, 10000)
    }
}