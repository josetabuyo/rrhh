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
        { Id: 31, Provincia: 3, Descripcion: "Rafaela" },
        { Id: 32, Provincia: 3, Descripcion: "Rosario" },
        { Id: 41, Provincia: 4, Descripcion: "Malargüe" },
        { Id: 42, Provincia: 4, Descripcion: "Las leñas" },
        { Id: 51, Provincia: 5, Descripcion: "Curucuacutuzú Cuatiá" }
    ];

        describe("ComboConBusquedaYAgregado", function () {
            beforeEach(function () {
                jasmine.Ajax.install();
                Backend.start();
            });

            afterEach(function () {
                jasmine.Ajax.uninstall();
            });

            function fakeResponse(response_object) {
                var fake_response = {
                    responseText: JSON.stringify({
                        d: JSON.stringify(response_object)
                    })
                };
                jasmine.Ajax.requests.mostRecent().response(fake_response);
            };

            describe("DADO: Un elemento select sin atributos", function () {
                var select;

                beforeEach(function () {
                    select = $('<select id="combo_provincias"></select>');
                });

                it("ENTONCES: debería poder crear un combo de provincias pasandole un dataProvider y que no tire error", function () {
                    var combo = new ComboConBusquedaYAgregado({
                        select: select,
                        dataProvider: "Provincias"
                    });
                });

                describe("DADO: un ComboConBusquedaYAgregado creado con un dataprovider de provincias", function () {
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
                        expect(combo.select.select2("val")).toEqual(null);
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
                });
            });
        });

//describe("FormBindeado", function () {
//    beforeEach(function () {
//        jasmine.Ajax.install();
//        Backend.start()
//    });

//    afterEach(function () {
//        jasmine.Ajax.uninstall();
//    });

//    function fakeResponse(response_object) {
//        var fake_response = {
//            responseText: JSON.stringify({
//                d: JSON.stringify(response_object)
//            })
//        };
//        jasmine.Ajax.requests.mostRecent().response(fake_response);
//    };

//    describe("DADO: Un elemento select sin atributos", function () {
//        var select;

//        beforeEach(function () {
//            select = $('<select id="combo_provincias"></select>');
//        });

//        it("ENTONCES: debería poder crear un combo de provincias pasandole un dataProvider y que no tire error", function () {
//            var combo = new ComboConBusquedaYAgregado({
//                select: select,
//                dataProvider: "Provincias"
//            });
//        });

//        describe("DADO: un ComboConBusquedaYAgregado creado con un dataprovider de provincias", function () {
//            var combo;
//            beforeEach(function () {
//                combo = new ComboConBusquedaYAgregado({
//                    select: select,
//                    dataProvider: "Provincias"
//                });
//            });

//            it("ENTONCES: el combo debería cargarse con todas las provincias", function () {
//                fakeResponse(provincias);
//                expect(combo.objetosCargados.length).toEqual(provincias.length);
//            });

//            it("ENTONCES: el combo no debería tener ningún elemento seleccionado", function () {
//                fakeResponse(provincias);
//                expect(combo.idSeleccionado()).toEqual(undefined);
//            });

//            it("ENTONCES: si selecciono un item programáticamente antes o después de que se cargue el combo debería seleccionarse ese item en el combo", function () {
//                combo.idSeleccionado(5);
//                expect(combo.idSeleccionado()).toEqual(5);
//                fakeResponse(provincias);
//                expect(combo.idSeleccionado()).toEqual(5);
//                expect(combo.itemSeleccionado().Descripcion).toEqual("Santa Fe");
//                expect(combo.select.select2('data').text).toEqual("Santa Fe");
//            });
//        });
//    });
//});