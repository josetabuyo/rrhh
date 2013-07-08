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
    var panel_imagenes_no_asignadas = {};
    var mock_srv_imagenes = {};

    beforeEach(function () {
        var ui_vista_legajo = $('<div>');
        lbl_nombre = $('<label id="lbl_nombre">');
        lbl_apellido = $('<label id="lbl_apellido">');
        panel_documentos = $('<div id="panel_documentos">');
        panel_imagenes_no_asignadas = $('<div id="panel_imagenes_no_asignadas">');
        ui_visualizador_de_imagenes = $('<div id="visualizador_de_imagenes">');

        ui_vista_legajo.append(lbl_nombre);
        ui_vista_legajo.append(lbl_apellido);
        ui_vista_legajo.append(panel_imagenes_no_asignadas);
        ui_vista_legajo.append(panel_documentos);
        ui_vista_legajo.append(ui_visualizador_de_imagenes);

        var plantilla_vista_documento = $('<div class="documento">');
        plantilla_vista_documento.append($('<label id="lbl_descripcion_en_RRHH">'));
        plantilla_vista_documento.append($('<label id="lbl_jurisdiccion">'));
        plantilla_vista_documento.append($('<label id="lbl_organismo">'));
        plantilla_vista_documento.append($('<label id="lbl_folio">'));
        plantilla_vista_documento.append($('<label id="lbl_fechaDesde">'));
        plantilla_vista_documento.append($('<label id="lbl_tabla">'));
        plantilla_vista_documento.append($('<label id="lbl_id">'));

        var plantilla_vista_imagen = $('<div class="imagen">');
        plantilla_vista_imagen.append($('<label id="lbl_nombre">'));
        plantilla_vista_imagen.append($('<img id="img_thumbnail">'));

        mock_srv_imagenes = {
            getImagenSinAsignar: function (legajo, nombre_imagen, onSuccess, onError) {
                onSuccess({ nombre: "Imagen_1", bytesImagen: "aaa111aaa" });
            }
        };
        spyOn(mock_srv_imagenes, 'getImagenSinAsignar').andCallThrough();


        vista_legajos = new VistaDeResultadosDeLegajos({
            ui: ui_vista_legajo,
            plantilla_vista_documento: plantilla_vista_documento,
            plantilla_vista_imagen: plantilla_vista_imagen,
            servicioDeImagenes: mock_srv_imagenes
        });
    });
    it("Al mostrar un legajo con 3 documentos en la vista se debería popular con los datos del legajo", function () {
        var un_legajo = {
            nombre: "jorge",
            apellido: "Silva",
            documentos: [
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" }
            ],
            imagenesSinAsignar: []
        };
        vista_legajos.mostrarLegajo(un_legajo);
        expect(lbl_nombre.text()).toEqual('jorge');
        expect(lbl_apellido.text()).toEqual('Silva');
        expect(panel_documentos.children().length).toEqual(3);
    });
    it("Los documentos deberian visualizarse con descripcion y folio", function () {
        var un_legajo = {
            nombre: "jorge",
            apellido: "Silva",
            documentos: [
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" }
            ],
            imagenesSinAsignar: []
        };
        vista_legajos.mostrarLegajo(un_legajo);
        var div_primer_documento = $(panel_documentos.children()[0]);

        var lbl_descripcion_en_RRHH = div_primer_documento.find("#lbl_descripcion_en_RRHH");
        expect(lbl_descripcion_en_RRHH.text()).toEqual("cv");

        var lbl_folio = div_primer_documento.find("#lbl_folio");
        expect(lbl_folio.text()).toEqual("0011-2");
    });

    it("Al refrescar una vista de un legajo, debería recargar los documentos, no sumar los nuevos", function () {
        var un_legajo = {
            nombre: "jorge",
            apellido: "Silva",
            documentos: [
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" }
            ],
            imagenesSinAsignar: []
        };
        vista_legajos.mostrarLegajo(un_legajo);
        vista_legajos.mostrarLegajo(un_legajo);
        expect(lbl_nombre.text()).toEqual('jorge');
        expect(lbl_apellido.text()).toEqual('Silva');
        expect(panel_documentos.children().length).toEqual(3);
    });

    it("Al mostrar un legajo con 3 imagenes no asignadas a ningun documento debería popularse el panel de imagenes no asignadas con 3 elementos con el nombre de cada imagen", function () {
        var un_legajo = {
            nombre: "jorge",
            apellido: "Silva",
            documentos: [
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" }
            ],
            imagenesSinAsignar: [
                { nombre: "imagen_1" },
                { nombre: "imagen_2" },
                { nombre: "imagen_3" }
            ]
        };
        vista_legajos.mostrarLegajo(un_legajo);
        expect(panel_imagenes_no_asignadas.children().length).toEqual(3);

        var div_primera_imagen = $(panel_imagenes_no_asignadas.children()[0]);

        var lbl_nombre = div_primera_imagen.find("#lbl_nombre");
        expect(lbl_nombre.text()).toEqual("imagen_1");
    });

    it("Al refrescar una vista de un legajo, debería recargar las imagenes, no sumar las nuevas", function () {
        var un_legajo = {
            nombre: "jorge",
            apellido: "Silva",
            documentos: [
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" },
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" }
            ],
            imagenesSinAsignar: [
                { nombre: "imagen_1" },
                { nombre: "imagen_2" },
                { nombre: "imagen_3" }
            ]
        };
        vista_legajos.mostrarLegajo(un_legajo);
        expect(panel_imagenes_no_asignadas.children().length).toEqual(3);

        vista_legajos.mostrarLegajo(un_legajo);
        expect(panel_imagenes_no_asignadas.children().length).toEqual(3);
    });

    it("Al hacer click en una imagen sin asignar en miniatura, el servicio de imagenes deberia recibir el mensaje getImagenSinAsignar con el numero de legajo y el nombre de la imagen como parametros", function () {
        var un_legajo = {
            nombre: "jorge",
            apellido: "Silva",
            idInterna: "111111",
            documentos: [
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" }
            ],
            imagenesSinAsignar: [
                { nombre: "imagen_1" }
            ]
        };
        vista_legajos.mostrarLegajo(un_legajo);

        var div_primera_imagen = $(panel_imagenes_no_asignadas.children()[0]);

        var img_thumbnail = div_primera_imagen.find("#img_thumbnail");
        img_thumbnail.click();
        expect(mock_srv_imagenes.getImagenSinAsignar.mostRecentCall.args[0] == '111111').toBeTruthy();
        expect(mock_srv_imagenes.getImagenSinAsignar.mostRecentCall.args[1] == 'imagen_1').toBeTruthy();
    });

    it("Al hacer click en una imagen sin asignar en miniatura, el visualizador de imagenes deberia recibir el mensaje mostrarImagen una imagen como parametro", function () {
        var un_legajo = {
            nombre: "jorge",
            apellido: "Silva",
            documentos: [
                { descripcionEnRRHH: "cv", jurisdiccion: "RRHH", organismo: "MDS", folio: "0011-2", fechaDesde: "20/11/1981", tabla: "curriculums", id: "1" }
            ],
            imagenesSinAsignar: [
                { nombre: "imagen_1" }
            ]
        };
        vista_legajos.mostrarLegajo(un_legajo);

        var div_primera_imagen = $(panel_imagenes_no_asignadas.children()[0]);

        var img_thumbnail = div_primera_imagen.find("#img_thumbnail");
        expect(vista_legajos.mostrandoVisualizadorDeImagenes()).toBeFalsy();
        img_thumbnail.click();
        expect(vista_legajos.mostrandoVisualizadorDeImagenes()).toBeTruthy();
    });
});


describe("Tengo un servicio de legajos", function () {
    var srv_de_legajos;
    beforeEach(function () {
        var mock_proveedor_ajax = {
            postearAUrl: function (datos_del_post) {
                if (datos_del_post.data.numero_documento == 29193500) {
                    datos_del_post.success({
                        codigoDeResultado:'OK'
                    });
                }
                else {
                    datos_del_post.success({
                        codigoDeResultado: 'LEGAJO_NO_ENCONTRADO'
                    });
                }
            }
        };
        srv_de_legajos = new ServicioDeLegajos(mock_proveedor_ajax);
    });
    it("Si pido el legajo de documento 29193500 debería encontrarlo", function () {
        var realizo_comportamiento_esperado = false;
        srv_de_legajos.getLegajo(29193500,
                                    function (respuesta) { realizo_comportamiento_esperado = true; },
                                    function (respuesta) { realizo_comportamiento_esperado = false; })
        expect(realizo_comportamiento_esperado).toBeTruthy();
    });
    it("Si pido el legajo de documento 88888888 no deberia encontrarlo", function () {
        var realizo_comportamiento_esperado = false;
        srv_de_legajos.getLegajo(88888888,
                                    function (respuesta) { realizo_comportamiento_esperado = false; },
                                    function (respuesta) { realizo_comportamiento_esperado = true; })
        expect(realizo_comportamiento_esperado).toBeTruthy();
    });
});


describe("Tengo un servicio de imagenes", function () {
    var srv_de_imagenes;
    beforeEach(function () {
        var mock_proveedor_ajax = {
            postearAUrl: function (datos_del_post) {
                datos_del_post.success({ nombre: "imagen_1", bytesImagen: "aaa111aaa" });
            }
        };
        srv_de_imagenes = new ServicioDeImagenes(mock_proveedor_ajax);
    });
    it("Deberia poder pedir la imagen sin asignar 'imagen_1' del legajo '111111'", function () {
        var realizo_comportamiento_esperado = false;
        srv_de_imagenes.getImagenSinAsignar('111111',
                                            'imagen_1',
                                            function (imagen) { realizo_comportamiento_esperado = true; },
                                            function (respuesta) { realizo_comportamiento_esperado = false; })
        expect(realizo_comportamiento_esperado).toBeTruthy();
    });
});