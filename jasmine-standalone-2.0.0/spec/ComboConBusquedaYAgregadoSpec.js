var provincias = [
        { Id: 1, Descripcion: "Buenos Aires" },
        { Id: 2, Descripcion: "Entre Rios" },
        { Id: 5, Descripcion: "Santa Fe" },
        { Id: 8, Descripcion: "Mendoza" }
    ];
var localidades = [
        { Id: 10, Provincia: 1, Descripcion: "La Plata" },
        { Id: 11, Provincia: 1, Descripcion: "Mar del Plata" },
        { Id: 21, Provincia: 2, Descripcion: "Parana" },
        { Id: 22, Provincia: 2, Descripcion: "Gualeguaychu" },
        { Id: 31, Provincia: 5, Descripcion: "Rafaela" },
        { Id: 32, Provincia: 5, Descripcion: "Rosario" },
        { Id: 41, Provincia: 8, Descripcion: "Malargüe" },
        { Id: 42, Provincia: 8, Descripcion: "Las leñas" },
        { Id: 51, Provincia: 11, Descripcion: "Curucuacutuzú Cuatiá" }
    ];

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
                var select;

                beforeEach(function () {
                    formulario = $('<div>');
                    select = $('<select id="combo_provincias"></select>');
                    formulario.append(select);
                });

                describe("DADO: un ComboConBusquedaYAgregado creado en base al <select> con un dataprovider de provincias", function () {
                    var combo;
                    beforeEach(function () {
                        combo = new ComboConBusquedaYAgregado({
                            select: select,
                            dataProvider: "Provincias"
                        });
                    });

                    it("ENTONCES: el combo debería cargarse con todas las provincias", function () {
                        fakeResponse(provincias);
                        expect(combo.objetosCargados.length).toEqual(provincias.length);
                    });

                    it("ENTONCES: el combo no debería tener ningún elemento seleccionado", function () {
                        fakeResponse(provincias);
                        expect(combo.idSeleccionado()).toEqual(undefined);
                        expect(combo.select.select2("val")).toEqual("");
                    });

                    it("ENTONCES: si selecciono un item programáticamente antes o después de que se cargue el combo debería seleccionarse ese item en el combo", function () {
                        combo.idSeleccionado(5);
                        expect(combo.idSeleccionado()).toEqual(5);
                        fakeResponse(provincias);
                        expect(combo.idSeleccionado()).toEqual(5);
                        expect(combo.itemSeleccionado().Descripcion).toEqual("Santa Fe");
                        expect(combo.select.select2('data').text).toEqual("Santa Fe");
                        expect(combo.select.select2('val')).toEqual("5");
                    });

                    it("ENTONCES: si el usuario selecciona un item desde el combo, el item seleccionado debería ser el correcto", function () {
                        fakeResponse(provincias);
                        combo.select.select2("val", 5);
                        combo.select.trigger("change");
                        expect(combo.idSeleccionado()).toEqual(5);
                        expect(combo.itemSeleccionado().Descripcion).toEqual("Santa Fe");
                        expect(combo.select.select2('data').text).toEqual("Santa Fe");
                    });

                    it("ENTONCES: si el usuario elimina la seleccion desde el combo, el item seleccionado debería ser ninguno", function () {
                        combo.idSeleccionado(5);
                        fakeResponse(provincias);
                        formulario.find(".select2-search-choice-close").mousedown();
                        expect(combo.idSeleccionado()).toEqual(undefined);
                        expect(combo.select.select2("val")).toEqual("");
                    });

                    it("ENTONCES: si se elimina la selección programaticamente, no debería haber ningún elemento seleccionado", function () {
                        combo.idSeleccionado(5);
                        fakeResponse(provincias);
                        combo.limpiarSeleccion();
                        expect(combo.idSeleccionado()).toEqual(undefined);
                        expect(combo.select.select2("val")).toEqual("");
                    });

                    it("ENTONCES: si se selecciona programaticamente un elemento que no existe, debería informarse por consola y limpiar la seleccion", function () {
                        combo.idSeleccionado(25);
                        fakeResponse(provincias);
                        expect(combo.idSeleccionado()).toEqual(undefined);
                        expect(combo.select.select2("val")).toEqual("");
                    });

                    it("ENTONCES: al cambiar el item seleccionado en el combo debería ejecutarse un callback", function () {
                        var valor_bindeado = -1;
                        combo.change(function () {
                            valor_bindeado = combo.idSeleccionado();
                        });
                        combo.idSeleccionado(5);
                        expect(valor_bindeado).toEqual(5);
                        fakeResponse(provincias);
                        expect(valor_bindeado).toEqual(5);
                        combo.idSeleccionado(52);
                        expect(valor_bindeado).toEqual(undefined);
                        combo.select.select2("val", 5);
                        combo.select.trigger("change");
                        expect(valor_bindeado).toEqual(5);
                    });
                });
            });

            describe("DADO: Un elemento <select> con atributos, dentro de un <div>", function () {
                var formulario;
                var select_provincias;
                var select_localidades;
                var domicilio;

                beforeEach(function () {
                    domicilio = {
                        Provincia: 5,
                        Localidad: 31
                    }
                    formulario = $('<div>');
                    select_provincias = $('<select id="combo_provincias" rh-control-type="combo" rh-data-provider="Provincias" rh-modelo="Provincia"></select>');
                    select_localidades = $('<select id="combo_localidades" rh-control-type="combo" rh-data-provider="Localidades" rh-modelo="Localidad"></select>');
                    formulario.append(select_provincias);
                    formulario.append(select_localidades);
                });

                describe("DADO: un FormularioBindeado creado en base al <div> y a un modelo", function () {
                    var form_direccion;
                    beforeEach(function () {
                        form_direccion = new FormularioBindeado({
                            formulario: formulario,
                            modelo: domicilio
                        });
                        fakeResponse(provincias, 1);
                        fakeResponse(localidades, 2);
                    });

                    it("ENTONCES: los combos deberían estar cargados correctamente y mostrando la opción correspondiente al modelo", function () {
                        expect(form_direccion.combo_provincias.itemSeleccionado().Descripcion).toEqual("Santa Fe");
                        expect(form_direccion.combo_localidades.itemSeleccionado().Descripcion).toEqual("Rafaela");
                    });

                    it("ENTONCES: un cambio en la opción seleccionada en un combo debería reflejarse en el modelo", function () {
                        form_direccion.combo_localidades.idSeleccionado(32);
                        expect(domicilio.Localidad).toEqual(32);

                        form_direccion.combo_localidades.select.select2("val", 31);
                        form_direccion.combo_localidades.select.trigger("change");
                        expect(domicilio.Localidad).toEqual(31);
                    });

                    it("ENTONCES: un cambio en el modelo debería verse reflejado en el combo", function () {
                        domicilio.Provincia = 2;
                        expect(form_direccion.combo_provincias.itemSeleccionado().Descripcion).toEqual("Entre Rios");
                    });
                });
            });
        });