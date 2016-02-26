$(document).ready(function () {
    Backend.start(function () {
        Reportes.start();
    });
});

var Reportes = {
    start: function () {
        var _this = this;

        $('#btn_consulta_rapida').click(function () {
            window.location.replace("ConsultaRapida.aspx");
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



    },
    mostrarPersona: function (documento) {
        console.log(documento);
        var _this = this;
        //$(".contenedor_formulario").hide()
        //_this.limpiarPantalla();
        $('#')
        Backend.GetConsultaRapida(documento).onSuccess(function (datos) {
            var data = $.parseJSON(datos);
            $('#nombre').html(data.Apellido);
            $('#legajo').html(data.Legajo);
            $('#fechaNacimiento').html(data.FechaNacimiento);
            $('#edad').html(data.Edad);
            $('#cuil').html(data.Cuil);
            $('#sexo').html(data.Sexo);
            $('#estadoCivil').html(data.EstadoCivil);
            $('#documento').html(data.Documento);
            $('#domicilio').html(data.Domicilio);
            $('#estudio').html(data.Estudio);
            $('#nivel_grado').html(data.Nivel);
            $('#sector').html(data.Sector);
            $('#planta').html(data.Planta);
            $('#cargo').html(data.Cargo);
            $('#agrupamiento').html(data.Agrupamiento);
            $('#ing_min').html(data.IngresoMinisterio);
            $('#ant_min').html(data.AntMinisterio);
            $('#estado').html(data.AntEstado);
            $('#privada').html(data.AntPrivada);
            $('#total').html(data.AntTotal);
            $('#nombre').html(data.ANTTotalTotal);

        });
    },
    dibujarArbolOrganigrama: function () {
        var data_organigrama = {
            areaRaiz: {
                id: 1,
                nombre: "unidad ministro",
                areasDependientes: [
                    {
                        id: 2,
                        nombre: "secretaría de coordinación y monitoreo institucional",
                        areasDependientes: [
                            {
                                id: 3,
                                nombre: "subsecreataría de coordinación monitoreo y logística"
                            }
                        ]
                    },
                    {
                        id: 4,
                        nombre: "secretaría de economía social",
                        areasDependientes: [
                            {
                                id: 5,
                                nombre: "subsecreataría de políticas alimentarias"
                            }
                        ]
                    }
                ]
            }
        };

        var arbol_organigrama = new ArbolOrganigrama(data_organigrama, $("#contenedor_arbol_organigrama"));

    }
}
