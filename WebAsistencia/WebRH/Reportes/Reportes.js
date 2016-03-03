$(document).ready(function () {
    Backend.start(function () {
        Reportes.start();
    });
});

var Reportes = {
    start: function () {
        var _this = this;

        $('#btn_consulta_rapida').click(function () {
            window.location.replace("ConsultaIndividual.aspx");
        })
        $('#btn_grafico_dotacion').click(function () {
            window.location.replace("GraficoDotacion.aspx");
        })
        $('#btn_grafico_licencias').click(function () {
            window.location.replace("GraficoLicencias.aspx");
        })

        this.dibujarArbolOrganigrama();
    },
    iniciarConsultaRapida: function () {
        var _this = this;

        var selector_personas = new SelectorDePersonas({
            ui: $('#selector_usuario'),
            repositorioDePersonas: new RepositorioDePersonas(new ProveedorAjax("../")),
            placeholder: "nombre, apellido, documento o legajo"
        });
        selector_personas.alSeleccionarUnaPersona = function (la_persona_seleccionada) {
            _this.mostrarPersona(la_persona_seleccionada.documento);
        };

        //localStorage.removeItem("documento");
        //localStorage.setItem("documento", "31046911");

        if (typeof (Storage) !== "undefined") {
            var documento = localStorage.getItem("documento");
            if (documento != null)
                _this.mostrarPersona(documento);

            // selector_personas.selector_usuario.alSeleccionarUnaPersona(persona_seleccionada);
        } else {
            console.log("No soporta localStorage"); // Sorry! No Web Storage support..
        }





    },
    mostrarPersona: function (documento) {
        console.log(documento);
        var _this = this;

        Backend.GetConsultaRapida(documento).onSuccess(function (datos) {
            var data = $.parseJSON(datos);

            if (!$.isEmptyObject(data)) {
                $("#panel_izquierdo").delay(700).animate({ "opacity": "1" }, 700);

                $('#mensaje').html("");

                $('#nombre_consulta').html(data.Apellido);
                $('#legajo_consulta').html(data.Legajo);
                $('#fechaNacimiento').html(data.FechaNacimiento);
                $('#edad').html(data.Edad);
                $('#cuil').html(data.Cuil);
                $('#sexo').html(data.Sexo);
                $('#estadoCivil').html(data.EstadoCivil);
                $('#documento_consulta').html(data.Documento);
                $('#domicilio').html(data.Domicilio);
                $('#estudio').html(data.Estudio);
                $('#nivel_grado').html(data.Nivel);
                $('#sector').html(data.Sector);
                $('#planta').html(data.Planta);
                $('#cargo').html(data.Cargo);
                $('#agrupamiento').html(data.Agrupamiento);
                $('#ing_min').html(data.IngresoMinisterio);
                //$('#ant_min').html(data.AntMinisterio);
                //$('#estado').html(data.AntEstado);
                //$('#privada').html(data.AntPrivada);
                //$('#resta').html(data.RestaAnt);
                //$('#total').html(data.ANTTotalTotal);
                //$('#nombre').html(data.ANTTotalTotal);

                $('#btn_timeline').click(function () {
                    Backend.GetCarreraAdministrativa(documento).onSuccess(function (datos) {
                        $('#contenedor_timeLine').empty();
                        _this.armarTimeline(datos);
                    });
                })

            } else {
                $('#panel_izquierdo').hide();
                $('#mensaje').html("No se encontraron datos para la persona con documento " + documento);

            }

        });
    },
    dibujarArbolOrganigrama: function () {
        //        var data_organigrama = {
        //            areaRaiz: {
        //                id: 1,
        //                nombre: "unidad ministro",
        //                areasDependientes: [
        //                    {
        //                        id: 2,
        //                        nombre: "secretaría de coordinación y monitoreo institucional",
        //                        areasDependientes: [
        //                            {
        //                                id: 3,
        //                                nombre: "subsecreataría de coordinación monitoreo y logística"
        //                            }
        //                        ]
        //                    },
        //                    {
        //                        id: 4,
        //                        nombre: "secretaría de economía social",
        //                        areasDependientes: [
        //                            {
        //                                id: 5,
        //                                nombre: "subsecreataría de políticas alimentarias"
        //                            }
        //                        ]
        //                    }
        //                ]
        //            }
        //        };

        var arbol_organigrama = new ArbolOrganigrama($("#contenedor_arbol_organigrama"));

        arbol_organigrama.alSeleccionar(function (area) {
            console.log(area);
        });

    },
    armarTimeline: function (data) {
        var data = $.parseJSON(data);

        data.sort(SortByFechaDesde);

        if (data.length == 0) {
            alert("No hay datos");
            return;
        }

        var contenedor_timeline = $('#contenedor_timeLine');


        for (i = 0; i < data.length; i++) {
            var bloque = $('#bloque_timeline').clone();
            bloque.find(".titulo_hito").html(data[i].DescCausa);
            bloque.find(".descripcion_hito").html("Agrupamiento: " + data[i].Agrupamiento + " (" + data[i].Nivel + data[i].Grado + ")");
            bloque.find(".cd-date").html(data[i].FechaDesde);
            bloque.attr("id", "hito" + i);

            contenedor_timeline.append(bloque);
        }



        function SortByFechaDesde(a, b) {
            return new Date(a.FechaDesde) - new Date(b.FechaDesde);
        }


    }
}
