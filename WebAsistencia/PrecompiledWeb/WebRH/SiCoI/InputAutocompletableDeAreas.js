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
    $.extend(true, this, selectorDeArea);
}