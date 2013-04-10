var InputAutocompletableDeAreas = function (input, listaAreas, inputAreaSeleccionada) {
    inputAreaSeleccionada = inputAreaSeleccionada || $("<input>");
    var areaSeleccionada = { id: "", descripcion: "" };

    var selectorDeArea = new InputAutocompletable(input,
                                                    listaAreas,
                                                    function (a) { return a.id; },
                                                    function (a) { return a.descripcion; },
                                                    function (a) {
                                                        if (!(a === undefined)) {
                                                            inputAreaSeleccionada.val(a.id);
                                                            areaSeleccionada = a;
                                                        }
                                                        else {
                                                            inputAreaSeleccionada.val('');
                                                            areaSeleccionada = { id: "", descripcion: "" };
                                                        }
                                                        inputAreaSeleccionada.change();
                                                    }
                                                 );
    selectorDeArea.limpiar = function () {
        selectorDeArea.val('');
        inputAreaSeleccionada.val('');
        inputAreaSeleccionada.change();
        areaSeleccionada = { id: "", descripcion: "" };
    };
    selectorDeArea.areaSeleccionada = function () {
        return areaSeleccionada;
    };
    selectorDeArea.setAreaSeleccionada = function (area) {
        input.val(area.descripcion);
        areaSeleccionada = area;
    };
    inputAreaSeleccionada.change(function () {
        if (inputAreaSeleccionada.val() == '' && selectorDeArea.val() != '') selectorDeArea.val('');
    });

    $.extend(true, this, selectorDeArea);
}