$(document).ready(function () {
    Backend.start(function () {
        TramitacionesIndividuales.start();
    });
});

TramitacionesIndividuales = {
    start: () => {
        $("#buscador_personas").load("../Componentes/BuscadorDePersonas.htm", function () {
            Componente.start($("#buscador_personas"));
        });
    }
};