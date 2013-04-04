var InputAutocompletableDeAreas = function (input, listaAreas, inputAreaSeleccionada) {
    var selectorDeArea = new InputAutocompletable(input,
                                                    listaAreas,
                                                    function (a) { return a.id; },
                                                    function (a) { return a.descripcion; },
                                                    function (a) {
                                                        if (!(a === undefined)) inputAreaSeleccionada.val(a.id);
                                                        else inputAreaSeleccionada.val('');
                                                        inputAreaSeleccionada.change();
                                                    }
                                                 );
    selectorDeArea.limpiar = function () {
        selectorDeArea.val('');
        inputAreaSeleccionada.val('');
        inputAreaSeleccionada.change();
    };
    inputAreaSeleccionada.change(function () {
        if (inputAreaSeleccionada.val() == '' && selectorDeArea.val() != '') selectorDeArea.val('');
    });
    $.extend(true, this, selectorDeArea);
}