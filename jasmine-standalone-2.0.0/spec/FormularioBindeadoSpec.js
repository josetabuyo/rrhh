    var provincias = [
        { Id: 1, Descripcion: "Buenos Aires" },
        { Id: 2, Descripcion: "Entre Rios" },
        { Id: 5, Descripcion: "Santa Fe" },
        { Id: 8, Descripcion: "Mendoza" }
    ];

    var localidades = [
        { Id: 10, IdProvincia: 1, Nombre: "La Plata" },
        { Id: 11, IdProvincia: 1, Nombre: "Mar del Plata" },
        { Id: 21, IdProvincia: 2, Nombre: "Parana" },
        { Id: 22, IdProvincia: 2, Nombre: "Gualeguaychu" },
        { Id: 31, IdProvincia: 5, Nombre: "Rafaela" },
        { Id: 32, IdProvincia: 5, Nombre: "Rosario" },
        { Id: 41, IdProvincia: 8, Nombre: "Malargüe" },
        { Id: 42, IdProvincia: 8, Nombre: "Las leñas" },
        { Id: 42, IdProvincia: 8, Nombre: "San Rafael" },
        { Id: 51, IdProvincia: 11, Nombre: "Curucuacutuzú Cuatiá" }
    ];

    describe("Bindeos, tengo un objeto", function () {
        var persona;
        beforeEach(function () {
            persona = {
                nombre: "pepe",
                apellido: "pappo",
                madre: {
                    nombre: "porota"
                }
            };
        });

        it("ENTONCES: deberia poder observar cambios en sus variables", function () {
            var nuevo_nombre;
            var otro_nuevo_nombre;
            persona.watch("nombre", function (prop, oldval, newval) {
                nuevo_nombre = newval;
            });
            persona.watch("nombre", function (prop, oldval, newval) {
                otro_nuevo_nombre = newval;
            });
            persona.nombre = "coco";
            expect(nuevo_nombre).toEqual("coco");
            expect(otro_nuevo_nombre).toEqual("coco");
        });
        it("ENTONCES: deberia poder dejar de observar cambios en sus variables", function () {
            var nuevo_nombre;
            var otro_nuevo_nombre;
            var handler = function (prop, oldval, newval) {
                nuevo_nombre = newval;
            };
            persona.watch("nombre", handler);
            var otro_handler = function (prop, oldval, newval) {
                otro_nuevo_nombre = newval;
            };
            persona.watch("nombre", otro_handler);
            persona.nombre = "coco";
            persona.unwatch("nombre", otro_handler);
            persona.nombre = "lolo";

            expect(nuevo_nombre).toEqual("lolo");
            expect(otro_nuevo_nombre).toEqual("coco");
        });

        it("ENTONCES: se deberia poder observar una propiedad de un objeto anidado", function () {
            var nuevo_nombre;
            var handler = function (prop, oldval, newval) {
                nuevo_nombre = newval;
            };
            persona.watch("madre.nombre", handler);
            persona.madre.nombre = "pepa";
            expect(nuevo_nombre).toEqual("pepa");
        });

        it("ENTONCES: se deberia poder dejar de observar una propiedad de un objeto anidado", function () {
            var nuevo_nombre;
            var handler = function (prop, oldval, newval) {
                nuevo_nombre = newval;
            };
            persona.watch("madre.nombre", handler);
            persona.madre.nombre = "pepa";
            persona.unwatch("madre.nombre", handler);
            persona.madre.nombre = "cuca";

            expect(nuevo_nombre).toEqual("pepa");
        });
    });
    describe("ComboConBusquedaYAgregado", function () {
        beforeEach(function () {
            jasmine.Ajax.install();
            Backend.start();
        });

        afterEach(function () {
            jasmine.Ajax.uninstall();
        });

        function fakeResponse(response_object, index) {
            var fake_response = {
                responseText: JSON.stringify({
                    d: JSON.stringify(response_object)
                })
            };
            var request;
            if (index === undefined) request = jasmine.Ajax.requests.mostRecent();
            else request = jasmine.Ajax.requests.at(index);
            request.response(fake_response);
        };

        describe("DADO: Un elemento <select> dentro de un <div>", function () {
            var formulario;
            var select_provincias;

            beforeEach(function () {
                formulario = $('<div>');
                select_provincias = $('<select id="combo_provincias"></select>');
                formulario.append(select_provincias);
            });

            describe("DADO: un ComboConBusquedaYAgregado creado en base al <select> con un dataprovider de provincias", function () {
                var combo_provincias;
                beforeEach(function () {
                    combo_provincias = new ComboConBusquedaYAgregado({
                        select: select_provincias,
                        dataProvider: "Provincias"
                    });
                });

                it("ENTONCES: el combo debería cargarse con todas las provincias", function () {
                    fakeResponse(provincias);
                    expect(combo_provincias.objetosCargados.length).toEqual(provincias.length);
                });

                it("ENTONCES: el combo no debería tener ningún elemento seleccionado", function () {
                    fakeResponse(provincias);
                    expect(combo_provincias.idSeleccionado()).toEqual(undefined);
                    expect(combo_provincias.select.select2("val")).toEqual("");
                });

                it("ENTONCES: si selecciono un item programáticamente antes o después de que se cargue el combo debería seleccionarse ese item en el combo", function () {
                    combo_provincias.idSeleccionado(5);
                    expect(combo_provincias.idSeleccionado()).toEqual(5);
                    fakeResponse(provincias);
                    expect(combo_provincias.idSeleccionado()).toEqual(5);
                    expect(combo_provincias.itemSeleccionado().Descripcion).toEqual("Santa Fe");
                    expect(combo_provincias.select.select2('data').text).toEqual("Santa Fe");
                    expect(combo_provincias.select.select2('val')).toEqual("5");
                });

                it("ENTONCES: si el usuario selecciona un item desde el combo, el item seleccionado debería ser el correcto", function () {
                    fakeResponse(provincias);
                    combo_provincias.select.select2("val", 5);
                    combo_provincias.select.trigger("change");
                    expect(combo_provincias.idSeleccionado()).toEqual(5);
                    expect(combo_provincias.itemSeleccionado().Descripcion).toEqual("Santa Fe");
                    expect(combo_provincias.select.select2('data').text).toEqual("Santa Fe");
                });

                it("ENTONCES: si el usuario elimina la seleccion desde el combo, el item seleccionado debería ser ninguno", function () {
                    combo_provincias.idSeleccionado(5);
                    fakeResponse(provincias);
                    formulario.find(".select2-search-choice-close").mousedown();
                    expect(combo_provincias.idSeleccionado()).toEqual(undefined);
                    expect(combo_provincias.select.select2("val")).toEqual("");
                });

                it("ENTONCES: si se elimina la selección programaticamente, no debería haber ningún elemento seleccionado", function () {
                    combo_provincias.idSeleccionado(5);
                    fakeResponse(provincias);
                    combo_provincias.limpiarSeleccion();
                    expect(combo_provincias.idSeleccionado()).toEqual(undefined);
                    expect(combo_provincias.select.select2("val")).toEqual("");
                });

                it("ENTONCES: si se selecciona programaticamente un elemento que no existe, debería informarse por consola y limpiar la seleccion", function () {
                    combo_provincias.idSeleccionado(25);
                    fakeResponse(provincias);
                    expect(combo_provincias.idSeleccionado()).toEqual(undefined);
                    expect(combo_provincias.select.select2("val")).toEqual("");
                });

                it("ENTONCES: al cambiar el item seleccionado en el combo debería ejecutarse un callback", function () {
                    var valor_bindeado = -1;
                    combo_provincias.change(function () {
                        valor_bindeado = combo_provincias.idSeleccionado();
                    });
                    combo_provincias.idSeleccionado(5);
                    expect(valor_bindeado).toEqual(5);
                    fakeResponse(provincias);
                    expect(valor_bindeado).toEqual(5);
                    combo_provincias.idSeleccionado(52);
                    expect(valor_bindeado).toEqual(undefined);
                    combo_provincias.select.select2("val", 5);
                    combo_provincias.select.trigger("change");
                    expect(valor_bindeado).toEqual(5);
                });

                describe("DADO: otro combo, de Localidades", function () {
                    var select_localidades;
                    var combo_localidades;
                    beforeEach(function () {
                        select_localidades = $('<select id="combo_localidades"></select>');
                        formulario.append(select_localidades);
                        combo_localidades = new ComboConBusquedaYAgregado({
                            select: select_localidades,
                            dataProvider: "Localidades",
                            filtro: {
                                IdProvincia: 5
                            },
                            propiedadLabel: "Nombre"
                        });
                    });

                    it("ENTONCES: debería poder cambiar el filtro de un combo y este debería recargarse", function () {
                        fakeResponse(localidades.findAll({
                            IdProvincia: 5
                        }));
                        expect(combo_localidades.objetosCargados.length).toEqual(2);
                        expect(combo_localidades.select.children().length).toEqual(3);
                        combo_localidades.filtrarPor({
                            IdProvincia: 8
                        });
                        fakeResponse(localidades.findAll({
                            IdProvincia: 8
                        }));
                        expect(combo_localidades.objetosCargados.length).toEqual(3);
                        expect(combo_localidades.select.children().length).toEqual(4);
                    });
                });
            });
        });

        describe("DADO: varios elementos con atributos, dentro de un <div>", function () {
            var formulario;
            var select_provincia_nacimiento;
            var select_provincia_domicilio;
            var select_localidad_domicilio;
            var input_apellido;
            var datos_personales;

            beforeEach(function () {
                datos_personales = {
                    Nombre: 'Javi',
                    Apellido: 'Script',
                    Edad: 23,
                    ProvinciaNacimiento: 1,
                    Domicilio: {
                        Provincia: 5,
                        Localidad: 31
                    },
                    Madre: {
                        Nombre: 'Norma',
                        Domicilio: {
                            Localidad: 41,
                            Provincia: 8
                        }
                    }
                };
                formulario = $('<div>');
                select_provincia_nacimiento = $('<select id="combo_provincia_nacimiento" rh-control-type="combo" rh-data-provider="Provincias" rh-model-property="ProvinciaNacimiento"></select>');
                select_provincia_domicilio = $('<select id="combo_provincia_domicilio" rh-control-type="combo" rh-data-provider="Provincias" rh-model-property="Domicilio.Provincia"></select>');
                select_provincia_madre = $('<select id="combo_provincia_madre" rh-control-type="combo" rh-data-provider="Provincias" rh-model-property="Madre.Domicilio.Provincia"></select>');
                select_localidad_domicilio = $('<select id="combo_localidad_domicilio" rh-control-type="combo" rh-data-provider="Localidades" rh-propiedad-label="Nombre" rh-model-property="Domicilio.Localidad" rh-filter-key="IdProvincia" rh-filter-value="Domicilio.Provincia"></select>');
                input_apellido = $('<input id="txt_apellido" rh-control-type="textbox" rh-model-property="Apellido"/>');
                input_edad = $('<input id="txt_edad" rh-control-type="textbox" rh-model-property="Edad" data-validar="esNumeroNatural"/>');

                formulario.append(select_provincia_nacimiento);
                formulario.append(select_provincia_domicilio);
                formulario.append(select_provincia_madre);
                formulario.append(select_localidad_domicilio);
                formulario.append(input_apellido);
                formulario.append(input_edad);
            });

            describe("DADO: un FormularioBindeado creado en base al <div> y a un modelo", function () {
                var form_datos_personales;
                beforeEach(function () {
                    form_datos_personales = new FormularioBindeado({
                        formulario: formulario,
                        modelo: datos_personales
                    });
                    fakeResponse(provincias, 1);
                    fakeResponse(provincias, 2);
                    fakeResponse(provincias, 3);
                    fakeResponse(localidades.findAll({
                        IdProvincia: 5
                    }), 4);
                });

                it("ENTONCES: los combos deberían estar cargados correctamente y mostrando la opción correspondiente al modelo", function () {
                    expect(form_datos_personales.combo_provincia_nacimiento.itemSeleccionado().Descripcion).toEqual("Buenos Aires");
                    expect(form_datos_personales.combo_provincia_domicilio.itemSeleccionado().Descripcion).toEqual("Santa Fe");
                    expect(form_datos_personales.combo_provincia_madre.itemSeleccionado().Descripcion).toEqual("Mendoza");
                    expect(form_datos_personales.combo_localidad_domicilio.itemSeleccionado().Nombre).toEqual("Rafaela");
                    expect(form_datos_personales.combo_localidad_domicilio.itemSeleccionado().Nombre).toEqual("Rafaela");
                    expect(form_datos_personales.txt_apellido.val()).toEqual("Script");
                    expect(form_datos_personales.txt_edad.val()).toEqual("23");
                });

                it("ENTONCES: un cambio en la opción seleccionada en un combo debería reflejarse en el modelo", function () {
                    form_datos_personales.combo_localidad_domicilio.idSeleccionado(32);
                    expect(datos_personales.Domicilio.Localidad).toEqual(32);

                    form_datos_personales.combo_localidad_domicilio.select.select2("val", 31);
                    form_datos_personales.combo_localidad_domicilio.select.trigger("change");
                    expect(datos_personales.Domicilio.Localidad).toEqual(31);
                });

                it("ENTONCES: un cambio en el textbox debería verse reflejado en el modelo", function () {
                    form_datos_personales.txt_apellido.val("Lurgo");
                    form_datos_personales.txt_apellido.change();
                    expect(datos_personales.Apellido).toEqual("Lurgo");

                    form_datos_personales.txt_edad.val("32");
                    form_datos_personales.txt_edad.change();
                    expect(datos_personales.Edad).toEqual(32);

                    form_datos_personales.txt_edad.val("");
                    form_datos_personales.txt_edad.change();
                    expect(datos_personales.Edad).toEqual(null);
                });

                it("ENTONCES: un cambio en el modelo debería verse reflejado en el combo", function () {
                    datos_personales.Domicilio.Provincia = 2;
                    expect(form_datos_personales.combo_provincia_domicilio.itemSeleccionado().Descripcion).toEqual("Entre Rios");
                });

                it("ENTONCES: un cambio en el modelo debería verse reflejado en el textbox", function () {
                    datos_personales.Apellido = "Lurgo";
                    expect(form_datos_personales.txt_apellido.val()).toEqual("Lurgo");

                    datos_personales.Edad = 32;
                    expect(form_datos_personales.txt_edad.val()).toEqual("32");
                });

                it("ENTONCES: un cambio en la seleccion del combo de provincias debería recargar el combo localidades con el filtro correspondiente", function () {
                    form_datos_personales.combo_provincia_domicilio.idSeleccionado(8);
                    fakeResponse(localidades.findAll({
                        IdProvincia: 8
                    }));
                    expect(form_datos_personales.combo_localidad_domicilio.idSeleccionado()).toEqual(undefined);
                    expect(form_datos_personales.combo_localidad_domicilio.objetosCargados.length).toEqual(3);
                });
            });
        });
    });