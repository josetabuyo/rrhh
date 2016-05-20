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
        })
        $('#btn_grafico_dotacion').click(function () {
            checks_activos = ["GraficoPorGenero"];
            $('#titulo_grafico').html(this.innerHTML);

            $('#div_grafico_de_dotacion').show();
            $('#div_filtros').show();
            $('#div_graficos_y_tablas').hide();
            $('#div_filtros_rango_etareo').hide();
            $('#div_resultados_sueldos').hide();
            $('#div_filtros_sueldos').hide();
        })
        $('#btn_rango_etareo').click(function () {
            $('#titulo_grafico').html(this.innerHTML);
            $('#div_grafico_de_dotacion').hide();
            $('#div_filtros').hide();
            $('#div_resultados_sueldos').hide();
            $('#div_filtros_sueldos').hide();
            $('#div_grafico_de_rango_etareo').show();
            $('#div_filtros_rango_etareo').show();
        })

        $('#btn_grafico_licencias').click(function () {
        })

        $('#btn_grafico_sueldo').click(function () {
            $('#titulo_grafico').html(this.innerHTML);
            checks_activos = ["GraficoPorArea"];
            $('#div_grafico_de_dotacion').hide();
            $('#div_filtros').hide();
            $('#div_graficos_y_tablas').hide();
            $('#div_filtros_rango_etareo').hide();
            $('#div_resultados_sueldos').show();
            $('#div_filtros_sueldos').show();
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
            localStorage.removeItem("documento");
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
        var arbol_organigrama = new ArbolOrganigrama($("#contenedor_arbol_organigrama"));

        arbol_organigrama.alSeleccionar(function (area) {
            $('.lista').show();
            //$('#btn_grafico_licencias').show();
            $('#showLeftPush').click();
            localStorage.setItem("idArea", area.id);
            localStorage.setItem("alias", area.alias);
            $('#titulo_area').html(area.alias);

            //$('#btn_armarGrafico').click();
            //$('#cb1').click();
            //$('#cb1').checked = true;
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
