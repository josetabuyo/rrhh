describe("El documento esta en un area distinta a la del usuario", function () {

    it("la grilla deberia mostrar la accion enviar a traves de area intermedia", function () {
        var btnEnviarDocumento = $("<div>");
        var btnEnviarDocumentoConAreaIntermedia = $("<div>");
        var divDocumentoAEnviar = $("<div>");
        var panelDocumentos = $("<div>");
        var panelDetalle = $("<div>");
        var panelDetalle = $("<div>");
        panelDetalle.mostrarDocumento = function (doc) { };

        var cfg_grilla = {
            areaDelUsuario: areaDeMarta,
            divDocumentoAEnviar: divDocumentoAEnviar,
            btnEnviarDocumento: btnEnviarDocumento,
            btnEnviarDocumentoConAreaIntermedia: btnEnviarDocumentoConAreaIntermedia,
            panelDetalle: panelDetalle,
            listaDocumentos: [documentoEnAreaDeCastagneto]
        }

        var grillaDocumentos = new GrillaDeDocumentos(cfg_grilla);
        expect(grillaDocumentos).toBeDefined();
        spyOn(btnEnviarDocumento, 'click');
        spyOn(btnEnviarDocumentoConAreaIntermedia, 'click');
        grillaDocumentos.DibujarEn(panelDocumentos);
        //hago click en el boton de la grilla
        panelDocumentos.find('#btnEnviarDocumentoEnGrilla').click();

        expect(btnEnviarDocumento.click.calls.length).toEqual(0);
        expect(btnEnviarDocumentoConAreaIntermedia.click.calls.length).toEqual(1);
    });

});

describe("El documento esta en el area del usuario", function () {
    it("la grilla deberia mostrar la accion enviar directamente a un area", function () {
        var btnEnviarDocumento = $("<div>");
        var btnEnviarDocumentoConAreaIntermedia = $("<div>");
        var divDocumentoAEnviar = $("<div>");
        var panelDocumentos = $("<div>");
        var panelDetalle = $("<div>");
        panelDetalle.mostrarDocumento = function (doc) { };

        var cfg_grilla = {
            areaDelUsuario: areaDeMarta,
            divDocumentoAEnviar: divDocumentoAEnviar,
            btnEnviarDocumento: btnEnviarDocumento,
            btnEnviarDocumentoConAreaIntermedia: btnEnviarDocumentoConAreaIntermedia,
            panelDetalle: panelDetalle,
            listaDocumentos: [documentoEnAreaDeMarta]
        }

        var grillaDocumentos = new GrillaDeDocumentos(cfg_grilla);
        expect(grillaDocumentos).toBeDefined();
        spyOn(btnEnviarDocumento, 'click');
        spyOn(btnEnviarDocumentoConAreaIntermedia, 'click');
        grillaDocumentos.DibujarEn(panelDocumentos);
        //hago click en el boton de la grilla
        panelDocumentos.find('#btnEnviarDocumentoEnGrilla').click();

        expect(btnEnviarDocumento.click.calls.length).toEqual(1);
        expect(btnEnviarDocumentoConAreaIntermedia.click.calls.length).toEqual(0);
    });


    describe("Pantalla de alta de documento", function () {
        it("Al abrir la pantalla, el botón de guardar documento está deshabilitado", function () {

            var panelAltaDocumentos = $("<div>");
            var btnGuardarDocumento = $("<input>");

            expect(btnGuardarDocumento).toBeDefined();
            btnGuardarDocumento.prop('disabled', true);
            expect(btnGuardarDocumento.prop('disabled')).toBeTruthy();

        });
    });


    describe("Pantalla de alta de documento", function () {
        it("Al enviarle un botón a un objeto deshabilitador de controles, este debe deshabilitarlo", function () {
            var btnGuardarDocumento = $("<input>");
            btnGuardarDocumento.prop('disabled', false);
            expect(btnGuardarDocumento).toBeDefined();
            var deshabilitadorDeControl = new DeshabilitarControl(btnGuardarDocumento);
            expect(btnGuardarDocumento.prop('disabled')).toBeTruthy();

        });
    });

    describe("Pantalla de alta de documento", function () {
        it("Al enviarle 4 textbox a un objeto en el inicio de la página, este debe cambiarles el color de fondo si están vacios", function () {

            var TipoDocumento = $("<input>");
            var CategoriaDocumento = $("<input>");
            var areaOrigen = $("<input>");
            var Extracto = $("<input>");

            TipoDocumento.attr("type", "text");
            CategoriaDocumento.attr("type", "text");
            areaOrigen.attr("type", "text");
            Extracto.attr("type", "text");

            TipoDocumento.css("background-color", 'rgb(255, 255, 255)');

            TipoDocumento.val("");
            CategoriaDocumento.val("");
            areaOrigen.val("asdasd");
            Extracto.val("asdasda");


            var ArrayDeTextbox = [TipoDocumento, CategoriaDocumento, areaOrigen, Extracto];

            expect(ArrayDeTextbox).toBeDefined();

            var Validador = new ValidadorComponenteVacio(ArrayDeTextbox);

            expect(TipoDocumento.css("background-color") == 'rgb(255, 255, 235)').toBeTruthy();

        });
    });



    describe("Pantalla de alta de documento", function () {
        it("Al enviarle 4 textbox y un botón a un objeto en el inicio de la página, este debe deshabilitar el botón si al menos uno de los textbox está vacio", function () {
            // var btnGuardarDocumento = $("<input>");
            var TipoDocumento = $("<input>");
            var CategoriaDocumento = $("<input>");
            var areaOrigen = $("<input>");
            var Extracto = $("<input>");
            var BotonAgregarDocumento = $("<input>");

            TipoDocumento.attr("type", "text");
            CategoriaDocumento.attr("type", "text");
            areaOrigen.attr("type", "text");
            Extracto.attr("type", "text");

            TipoDocumento.val("1");
            CategoriaDocumento.val("1");
            areaOrigen.val("1");

            BotonAgregarDocumento.attr("type", "submit");

            var ArrayDeControlesDeAltaDeDocumento = [TipoDocumento, CategoriaDocumento, areaOrigen, Extracto, BotonAgregarDocumento];

            var ValidadorDeAlta = new ValidadorDeAltaDeDocumento(ArrayDeControlesDeAltaDeDocumento);

            expect(BotonAgregarDocumento.attr("type") == "submit").toBeTruthy();
            expect(BotonAgregarDocumento.prop('disabled')).toBeTruthy();

        });
    });

    describe("Pantalla de alta de documento", function () {
        it("Al enviarle 4 textbox y un botón a un objeto en el inicio de la página, este debe habilitar el botón si no hay campos vacìos", function () {

            var BotonAgregarDocumento = $("<input>");
            var TipoDocumento = $("<textarea>");
            var CategoriaDocumento = $("<textarea>");
            var areaOrigen = $("<textarea>");
            var Extracto = $("<textarea>");

            TipoDocumento.attr("type", "text");
            CategoriaDocumento.attr("type", "text");
            areaOrigen.attr("type", "text");
            Extracto.attr("type", "text");

            TipoDocumento.val("1");
            CategoriaDocumento.val("1");
            areaOrigen.val("1");
            Extracto.val("asdasdasd");

            BotonAgregarDocumento.attr("type", "submit");
            BotonAgregarDocumento.prop('disabled', true);

            var ArrayDeControlesDeAltaDeDocumento = [TipoDocumento, CategoriaDocumento, areaOrigen, Extracto, BotonAgregarDocumento];

            var ValidadorDeAlta = new ValidadorDeAltaDeDocumento(ArrayDeControlesDeAltaDeDocumento);

            expect(BotonAgregarDocumento.attr("type") == "submit").toBeTruthy();
            expect(BotonAgregarDocumento.prop('disabled')).toBeFalsy();

        });
    });
});


describe("Pruebas del panel de filtros", function () {
    describe("Tengo un filtro por numero y un input vacio asociado", function () {
        var filtro_numero;
        var input_numero;
        var blanco = 'rgb(255, 255, 255)';
        var amarillo = 'rgb(255, 255, 200)';

        beforeEach(function () {
            input_numero = $('<input>');
            input_numero.attr('type', 'text');
            filtro_numero = new FiltroPorNumero(input_numero, amarillo, blanco);
        });

        it("El color de fondo del input deberia ser blanco", function () {
            expect(input_numero.css('background-color')).toEqual(blanco);
        });
        it("El filtro no deberia estar activo", function () {
            expect(filtro_numero.estaActivo()).toBeFalsy();
        });
        it("El filtro no deberia agregar ningun elemento a la coleccion de filtros que se le pasa", function () {
            var lista_filtros = [];
            filtro_numero.agregarFiltroAListaParaAplicar(lista_filtros);
            expect(lista_filtros.length).toEqual(0);
        });

        describe("Ingreso un valor en el input", function () {
            beforeEach(function () {
                input_numero.val("12");
                input_numero.change();
            });

            it("El color de fondo del input deberia ser amarillo", function () {
                expect(input_numero.css('background-color')).toEqual(amarillo);
            });
            it("El filtro deberia estar activo", function () {
                expect(filtro_numero.estaActivo()).toBeTruthy();
            });
            it("El filtro deberia agregar 1 elemento a la coleccion de filtros que se le pasa", function () {
                var lista_filtros = [];
                filtro_numero.agregarFiltroAListaParaAplicar(lista_filtros);
                expect(lista_filtros.length).toEqual(1);
                expect(lista_filtros[0].tipoDeFiltro).toEqual("FiltroDeDocumentosPorNumero");
                expect(lista_filtros[0].numero).toEqual("12");
            });

            describe("Borro el valor del input", function () {
                beforeEach(function () {
                    input_numero.val("");
                    input_numero.change();
                });
                it("El color de fondo del input deberia ser blanco", function () {
                    expect(input_numero.css('background-color')).toEqual(blanco);
                });
            });
        });
    });

    describe("Tengo un filtro por extracto y un input vacio asociado", function () {
        var filtro_extracto;
        var input_extracto;
        var blanco = 'rgb(255, 255, 255)';
        var amarillo = 'rgb(255, 255, 200)';

        beforeEach(function () {
            input_extracto = $('<input>');
            input_extracto.attr('type', 'text');
            filtro_extracto = new FiltroPorExtracto(input_extracto, amarillo, blanco);
        });

        it("El color de fondo del input deberia ser blanco", function () {
            expect(input_extracto.css('background-color')).toEqual(blanco);
        });
        it("El filtro no deberia estar activo", function () {
            expect(filtro_extracto.estaActivo()).toBeFalsy();
        });
        it("El filtro no deberia agregar ningun elemento a la coleccion de filtros que se le pasa", function () {
            var lista_filtros = [];
            filtro_extracto.agregarFiltroAListaParaAplicar(lista_filtros);
            expect(lista_filtros.length).toEqual(0);
        });

        describe("Ingreso un valor en el input", function () {
            beforeEach(function () {
                input_extracto.val("carta");
                input_extracto.change();
            });

            it("El color de fondo del input deberia ser amarillo", function () {
                expect(input_extracto.css('background-color')).toEqual(amarillo);
            });
            it("El filtro deberia estar activo", function () {
                expect(filtro_extracto.estaActivo()).toBeTruthy();
            });
            it("El filtro deberia agregar 1 elemento a la coleccion de filtros que se le pasa", function () {
                var lista_filtros = [];
                filtro_extracto.agregarFiltroAListaParaAplicar(lista_filtros);
                expect(lista_filtros.length).toEqual(1);
                expect(lista_filtros[0].tipoDeFiltro).toEqual("FiltroDeDocumentosPorExtracto");
                expect(lista_filtros[0].extracto).toEqual("carta");
            });

            describe("Borro el valor del input", function () {
                beforeEach(function () {
                    input_extracto.val("");
                    input_extracto.change();
                });
                it("El color de fondo del input deberia ser blanco", function () {
                    expect(input_extracto.css('background-color')).toEqual(blanco);
                });
            });
        });
    });

    describe("Tengo panel de filtros con un filtro por numero y uno por extracto", function () {
        var filtro_numero;
        var filtro_extracto;

        var input_numero;
        var input_extracto;
        var boton_panel;

        var blanco = 'rgb(255, 255, 255)';
        var amarillo = 'rgb(255, 255, 200)';

        var panel_filtros;

        beforeEach(function () {
            input_numero = $('<input>');
            input_numero.attr('type', 'text');
            input_extracto = $('<input>');
            input_extracto.attr('type', 'text');
            boton_panel = $('<div>');

            filtro_numero = new FiltroPorNumero(input_numero, amarillo, blanco, panel_filtros);
            filtro_extracto = new FiltroPorExtracto(input_extracto, amarillo, blanco, panel_filtros);
            panel_filtros = new PanelDeFiltros(boton_panel, [filtro_numero, filtro_extracto]);
            //panel_filtros.setFiltros([filtro_numero, filtro_extracto]);
                
        });

        it("El panel de filtros deberia tener 0 filtros activos", function () {
            expect(panel_filtros.cantidadDeFiltrosActivos()).toEqual(0);
        });
        it("El boton del panel no deberia tener la clase boton_que_abre_panel_desplegable_activo_con_filtros", function () {
            expect(boton_panel.hasClass('boton_que_abre_panel_desplegable_activo_con_filtros')).toBeFalsy();
        });

        describe("Ingreso un valor en el input del numero", function () {
            beforeEach(function () {
                input_numero.val("12");
                input_numero.change();
            });

            it("El panel de filtros deberia tener 1 filtro activo", function () {
                expect(panel_filtros.cantidadDeFiltrosActivos()).toEqual(1);
            });
            it("El boton del panel deberia tener la clase boton_que_abre_panel_desplegable_activo_con_filtros", function () {
                expect(boton_panel.hasClass('boton_que_abre_panel_desplegable_activo_con_filtros')).toBeTruthy();
            });

            describe("Ingreso un valor en el input del extracto", function () {
                beforeEach(function () {
                    input_extracto.val("caca");
                    input_extracto.change();
                });
                it("El panel de filtros deberia tener 2 filtros activos", function () {
                    expect(panel_filtros.cantidadDeFiltrosActivos()).toEqual(2);
                });
                it("El boton del panel deberia tener la clase boton_que_abre_panel_desplegable_activo_con_filtros", function () {
                    expect(boton_panel.hasClass('boton_que_abre_panel_desplegable_activo_con_filtros')).toBeTruthy();
                });
            });

            describe("Borro el valor del input del numero", function () {
                beforeEach(function () {
                    input_numero.val("");
                    input_numero.change();
                });
                it("El panel de filtros deberia tener 0 filtros activos", function () {
                    expect(panel_filtros.cantidadDeFiltrosActivos()).toEqual(0);
                });
                it("El boton del panel no deberia tener la clase boton_que_abre_panel_desplegable_activo_con_filtros", function () {
                    expect(boton_panel.hasClass('boton_que_abre_panel_desplegable_activo_con_filtros')).toBeFalsy();
                });
            });
        });
    });
});