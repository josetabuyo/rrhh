describe("Tengo un buscador de legajos para digitalizacion", function () {
    var input_numero = {};
    var boton_buscar = {};
    var mock_repo_legajos = {};
    var mock_vista_de_resultados = {};
    var aviso_legajo_no_encontrado = {};
    var buscador = {};

    beforeEach(function () {
        var ui_buscador = $('<div>');
        input_numero = $('<input id="input_numero" type="text">');
        boton_buscar = $('<input id="boton_buscar" type="button">');
        aviso_legajo_no_encontrado = $('<div id="aviso_legajo_no_encontrado">');

        ui_buscador.append(input_numero);
        ui_buscador.append(boton_buscar);
        ui_buscador.append(aviso_legajo_no_encontrado);

        mock_srv_legajos = {
            getLegajo: function (numero_legajo, onSuccess, onError) {
                if (numero_legajo == '123') onSuccess();
                else onError();
            }
        };
        spyOn(mock_srv_legajos, 'getLegajo').andCallThrough();

        mock_vista_de_resultados = {
            mostrarLegajo: function (legajo) {
            }
        };
        spyOn(mock_vista_de_resultados, 'mostrarLegajo').andCallThrough();


        buscador = new BuscadorDeLegajos({
            ui: ui_buscador,
            servicioDeLegajos: mock_srv_legajos,
            vistaDeResultados: mock_vista_de_resultados
        });
    });
    it("Al ingresar el numero de legajo y presionar el boton buscar el buscador deberia pedir el legajo al servicio", function () {
        input_numero.val('123');
        boton_buscar.click();

        expect(mock_srv_legajos.getLegajo).toHaveBeenCalled();
    });
    it("Si el servicio de legajos no encuentra el legajo pedido se debería mostrar un aviso en la ui del buscador", function () {
        input_numero.val('2556');
        boton_buscar.click();

        expect(buscador.mostrandoAvisoDeLegajoNoEncontrado()).toBeTruthy();
    });
    it("Si el servicio de legajos encuentra el legajo pedido se deberia mostrar el legajo en la vista de resultados y además no se debería ver el aviso de legajo no encontrado", function () {
        input_numero.val('123');
        boton_buscar.click();

        expect(buscador.mostrandoAvisoDeLegajoNoEncontrado()).toBeFalsy();
        expect(mock_vista_de_resultados.mostrarLegajo).toHaveBeenCalled();
    });
});


describe("Tengo una vista de legajos", function () {
    var vista_legajos = {};
    var lbl_nombre = {};
    var lbl_apellido = {};
    var panel_documentos = {};

    beforeEach(function () {
        var ui_vista_legajo = $('<div>');
        lbl_nombre = $('<label id="lbl_nombre">');
        lbl_apellido = $('<label id="lbl_apellido">');
        panel_documentos = $('<div id="panel_documentos">');

        ui_vista_legajo.append(lbl_nombre);
        ui_vista_legajo.append(lbl_apellido);
        ui_vista_legajo.append(panel_documentos);

        var plantilla_vista_documento = $('<div class="documento">');
        plantilla_vista_documento.append($('<label id="lbl_descripcion_en_RRHH">'));
        plantilla_vista_documento.append($('<label id="lbl_jurisdiccion">'));
        plantilla_vista_documento.append($('<label id="lbl_organismo">'));
        plantilla_vista_documento.append($('<label id="lbl_folio">'));
        plantilla_vista_documento.append($('<label id="lbl_fechaDesde">'));
        plantilla_vista_documento.append($('<label id="lbl_tabla">'));
        plantilla_vista_documento.append($('<label id="lbl_id">'));

        vista_legajos = new VistaDeResultadosDeLegajos({
            ui: ui_vista_legajo,
            plantilla_vista_documento: plantilla_vista_documento
        });
    });
    it("Al mostrar un legajo con 3 documentos en la vista se debería popular la grilla de resultados con los documentos del legajo", function () {
        var un_legajo = {
            nombre: "jorge",
            apellido: "Silva",
            documentos: [
                { descripcionEnRRHH: "cv", jurisdiccion:"RRHH", organismo: "MDS", folio:"0011-2", fechaDesde:"20/11/1981", tabla:"curriculums", id:"1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" }
            ]
        };
        vista_legajos.mostrarLegajo(un_legajo);
        expect(lbl_nombre.text()).toEqual('jorge');
        expect(lbl_apellido.text()).toEqual('Silva');
        expect(panel_documentos.children().length).toEqual(3);
    });
    it("Los documentos deberian visualizarse con todos sus datos", function () {
        var un_legajo = {
            nombre: "jorge",
            apellido: "Silva",
            documentos: [
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" }
            ]
        };
        vista_legajos.mostrarLegajo(un_legajo);
        var div_primer_documento = $(panel_documentos.children()[0]);

        var lbl_descripcion_en_RRHH = div_primer_documento.find("#lbl_descripcion_en_RRHH");
        expect(lbl_descripcion_en_RRHH.text()).toEqual("cv");

        var lbl_jurisdiccion = div_primer_documento.find("#lbl_jurisdiccion");
        expect(lbl_jurisdiccion.text()).toEqual("RRHH");

        var lbl_organismo = div_primer_documento.find("#lbl_organismo");
        expect(lbl_organismo.text()).toEqual("MDS");

        var lbl_folio = div_primer_documento.find("#lbl_folio");
        expect(lbl_folio.text()).toEqual("0011-2");

        var lbl_fechaDesde = div_primer_documento.find("#lbl_fechaDesde");
        expect(lbl_fechaDesde.text()).toEqual("20/11/1981");

        var lbl_tabla = div_primer_documento.find("#lbl_tabla");
        expect(lbl_tabla.text()).toEqual("curriculums");

        var lbl_id = div_primer_documento.find("#lbl_id");
        expect(lbl_id.text()).toEqual("1");
    });

    it("Al refrescar una vista de un legajo, debería recargar los documentos, no sumar los nuevos", function () {
        var un_legajo = {
            nombre: "jorge",
            apellido: "Silva",
            documentos: [
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" }
            ]
        };
        vista_legajos.mostrarLegajo(un_legajo);
        vista_legajos.mostrarLegajo(un_legajo);
        expect(lbl_nombre.text()).toEqual('jorge');
        expect(lbl_apellido.text()).toEqual('Silva');
        expect(panel_documentos.children().length).toEqual(3);
    });
});