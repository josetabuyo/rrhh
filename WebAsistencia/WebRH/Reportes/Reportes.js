$(document).ready(function () {
    Backend.start(function () {
        Reportes.start();
    });
});

var Reportes = {
    start: function () {
        var _this = this;
        $('#btn_consulta_rapida').click(function () {
            window.location.href = "ConsultaIndividual.aspx";
        });
        $('#btn_consulta_legajos_baja').click(function () {
            window.location.href = "LegajosDeBaja.aspx";
        });
        $('#btn_grafico_dotacion').click(function () {
            checks_activos = ["GraficoPorGenero"];
            $('#titulo_grafico').html(this.innerHTML);
            GraficoHerramientas.OcultarTodosLosReportesExcepto("Dotacion");
            GraficoDotacion.Inicializar();
        });
        $('#btn_grafico_rangoEtario').click(function () {
            $('#titulo_grafico_rangoEtario').html(this.innerHTML);
            checks_activos = ["GraficoPorArea"];
            GraficoHerramientas.OcultarTodosLosReportesExcepto("RangoEtario");
            GraficoRangoEtario.Inicializar();
        });

        $('#btn_grafico_sueldo').click(function () {
            $('#titulo_grafico').html(this.innerHTML);
            checks_activos = ["GraficoPorArea"];
            GraficoHerramientas.OcultarTodosLosReportesExcepto("Sueldo");
            GraficoSueldos.Inicializar();
        });

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
        if (typeof (Storage) !== "undefined") {
            var documento = localStorage.getItem("documento");
            if (documento != null)
                _this.mostrarPersona(documento);
            localStorage.removeItem("documento");
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

                Backend.GetUsuarioPorIdPersona(data.IdPersona)
                    .onSuccess(function (usuario) {
                        if (usuario.Id != 0) {
                            if (usuario.Owner.IdImagen >= 0) {
                                var img = new VistaThumbnail({ id: usuario.Owner.IdImagen, contenedor: $("#foto_usuario") });
                                $("#foto_usuario").show();
                                $("#foto_usuario_generica.foto_usuario").hide();
                            }
                            else {
                                $("#foto_usuario").hide();
                                $("#foto_usuario_generica.foto_usuario").show();
                            }
                        } else {
                            $("#foto_usuario").hide();
                            $("#foto_usuario_generica.foto_usuario").show();
                        }
                    });



                $("#panel_izquierdo").delay(300).animate({ "opacity": "1" }, 300);
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

                if (data.FechaBaja != "") {
                    $('#baja').html("BAJA a partir del " + data.FechaBaja);
                } else {
                    $('#baja').html("Activo");
                }

                if (data.FechaBloqueo != "01/01/1900") {
                    $('#bloqueo').html(data.FechaBloqueo);
                    $('#bloqueo').parent().show();
                } else {
                    $('#bloqueo').parent().hide();
                }

                if (data.CargoGremial != "") {
                    $('#cargo_gremial').html(data.CargoGremial);
                    $('#cargo_gremial').parent().show();
                } else {
                    $('#cargo_gremial').parent().hide();
                }

                if (data.ActoAlta != "") {
                    $('#acto_alta').html(data.ActoAlta);
                    $('#acto_alta').parent().show();
                } else {
                    $('#acto_alta').parent().hide();
                }


                //$('#ant_min').html(data.AntMinisterio);
                //$('#estado').html(data.AntEstado);
                //$('#privada').html(data.AntPrivada);
                //$('#resta').html(data.RestaAnt);
                //$('#total').html(data.ANTTotalTotal);
                //$('#nombre').html(data.ANTTotalTotal);
                /*$('#btn_timeline').click(function () {
                Backend.GetCarreraAdministrativa(documento).onSuccess(function (datos) {
                $('#contenedor_timeLine').empty();
                _this.armarTimeline(datos);
                });
                })*/
            } else {
                $('#panel_izquierdo').hide();
                $('#mensaje').html("No se encontraron datos para la persona con documento " + documento);
            }
        });
    },

    dibujarArbolOrganigrama: function () {
        var arbol_organigrama = new ArbolOrganigrama($("#contenedor_arbol_organigrama"));
        arbol_organigrama.alSeleccionar(function (area) {
            $('.lista').show();
            $('#showLeftPush').click();
            localStorage.setItem("idArea", area.id);
            localStorage.setItem("alias", area.alias);
            $('#titulo_area').html(area.alias);

            $('#div_grafico_de_dotacion').hide();
            $('#div_grafico_de_rango_etareo').hide();
            $('#titulo_grafico').html("Seleccionar Informe");

            $("#chk_incluir_dependencias").show();
            $("#lbl_incluir_dependencias").show();

            //para subir al tope de la pantalla
            $('html,body').animate({
                scrollTop: $("#Reportes").offset().top
            }, 1000);
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
