var GraficoLicencias = {

    Inicializar: function () {
        var _this = this;
        //Para que no rompa la librería por si la página se cargó anteriormente
        if (window.Highcharts) {
            window.Highcharts = null;
        };
        $('#btn_armarGrafico').click(function () {
            _this.BuscarDatos();
        });

    },

    BuscarDatos: function () {
        var _this = this;
        var hoy = new Date();
        var fin_de_los_tiempos = hoy.setFullYear(9999, 11, 30);
        Backend.GetMeses()
                .onSuccess(function (datos) {
                    if (datos.length == 0) {
                        _this.VisualizarContenido(false);
                        alertify.error("No hay Reportes Definitivos para los parámetros seleccionados");
                    } else {
                        _this.VisualizarContenido(true);
                        _this.ArmarGrafico(datos);
                        _this.DibujarTablas(datos);
                        _this.BuscadorDeTabla();
                    }
                });
    },

    ArmarGrafico: function (resultado) {
        $(function () {
            $('#container').highcharts({
                data: {
                    table: 'datatable'
                },
                chart: {
                    type: 'column'
                },
                title: {
                    text: 'Licencias Soliciadas'
                },
                yAxis: {
                    allowDecimals: false,
                    title: {
                        text: 'Personas'
                    }
                },
                tooltip: {
                    formatter: function () {
                        return '<b>' + this.series.name + '</b><br/>' +
                    this.point.y + ' ' + this.point.name.toLowerCase();
                    }
                }
            });
        });
    },

    DibujarTablas: function (resultado) {
        var _this = this;
        $("#div_tabla_resultado").empty();
        var divGrilla = $('#div_tabla_resultado');


        var tabla = resultado;

        var columnas = [];
        columnas.push(new Columna("Pendientes de Aprobación", { generar: function (un_registro) { return un_registro.uno } }));
        columnas.push(new Columna("Aprobadas por RRHH", { generar: function (un_registro) { return un_registro.dos } }));

        this.GrillaResumen = new Grilla(columnas);
        this.GrillaResumen.CargarObjetos(tabla);
        this.GrillaResumen.DibujarEn(divGrilla);


    },



    BuscadorDeTabla: function () {
        var options = {
            valueNames: ['Pendientes', 'Aprobadas']
        };

        var featureList = new List('div_tabla_resultado', options);
    },

    ExportarDatosGraficoValorMercadoYContable: function () {
//        var sessionTable = "ExportarDatosGraficoValorMercadoYContable";
//        var fecha_reporte = $("#fecha_hasta").val().toString();
//        var fileName = "GraficoValorMercadoYContable_" + fecha_reporte + '_' + $("#id_cartera option:selected").text();
//        exportXLS(sessionTable, fileName);
    },

    VisualizarContenido: function (visualizar) {
        //        if (visualizar) {
        //            $('#div_grafico').show();
        //            $('#div_tabla_resumen').show();
        //            $('#div_tabla_valores').show();
        //            $('#label_base_pesos').show();
        //            $('#referencia_tabla').show();
        //            $('#exportar_grafico').show();
        //            $('#exportar_datos').show();
        //        } else {
        //            $('#div_tabla_resumen').hide();
        //            $('#div_tabla_valores').hide();
        //            $('#label_base_pesos').hide();
        //            $('#referencia_tabla').hide();
        //            $('#exportar_grafico').hide();
        //            $('#exportar_datos').hide();
        //        }
    }

}
