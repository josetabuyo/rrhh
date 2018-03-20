var GestionDeAusencias = {
    init: function () {

    },
    getAusencias: function () {

        var _this_original = this;

        Backend.getAusencias()
                    .onSuccess(function (ausencias) {

                        ausencias = _.sortBy(ausencias, 'Id').reverse();
                        var _this = this;

                        $("#tablaAusencias").empty();

                        var divGrilla_ausencias = $("#tablaAusencias");

                        var columnas_ausencias = [];

                        columnas_ausencias.push(new Columna("#", { generar: function (una_ausencia) { return una_ausencia.Id } }));
                        columnas_ausencias.push(new Columna("Agente", { generar: function (una_ausencia) { return una_ausencia.Persona.Apellido + ', ' + una_ausencia.Persona.Nombre } }));
                        columnas_ausencias.push(new Columna("Desde", { generar: function (una_ausencia) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_ausencia.Desde) } }));
                        columnas_ausencias.push(new Columna("Hasta", { generar: function (una_ausencia) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_ausencia.Hasta) } }));
                        columnas_ausencias.push(new Columna("Usuario", { generar: function (una_ausencia) { return una_ausencia.Usuario.Alias } }));
                        columnas_ausencias.push(new Columna('Acciones', {
                            generar: function (una_ausencia) {
                                var btn_accion = $('<a>');
                                var img = $('<img>');
                                img.attr('src', '../Imagenes/detalle.png');
                                img.attr('width', '15px');
                                img.attr('height', '15px');
                                btn_accion.append(img);
                                btn_accion.click(function () {
                                    _this_original.JustificarAusencia(una_ausencia);
                                });
                                return btn_accion;
                            }
                        }));

                        _this.divGrilla_ausencias = new Grilla(columnas_ausencias);
                        _this.divGrilla_ausencias.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.divGrilla_ausencias.SetOnRowClickEventHandler(function (una_tarea) { });
                        _this.divGrilla_ausencias.CargarObjetos(ausencias);
                        _this.divGrilla_ausencias.DibujarEn(divGrilla_ausencias);

                        $('.table-hover').removeClass("table-hover");

                        var options = {
                            valueNames: ['Agente', 'Usuario']
                        };

                        var featureList = new List('ausencias', options);
                    })
                    .onError(function (e) {

                    });
    },
    JustificarAusencia: function (ausencia) {
        var _this = this;

        vex.defaultOptions.className = 'vex-theme-os';
        vex.open({
            afterOpen: function ($vexContent) {
                $vexContent.load(window.location.origin + '/componentes/justificarAusencia.htm', function () {
                    Componente.start(ausencia, $vexContent)                                                                                                                                                               ;
                });

                return $vexContent;
            },
            css: {
                'padding-top': "4%",
                'padding-bottom': "0%",
                'background-color': "rgb(249, 248, 248)"
            },
            contentCSS: {
                width: "80%",
                height: "50%"
            }
        });

    }


}