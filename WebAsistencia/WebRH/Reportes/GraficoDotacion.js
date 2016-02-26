var GraficoDotacion = {

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
        Backend.GetMeses()
                .onSuccess(function (datos) {
                    if (datos.length == 0) {
                        _this.VisualizarContenido(false);
                        alertify.error("No hay Reportes Definitivos para los parámetros seleccionados");
                    } else {
                        _this.VisualizarContenido(true);
                        _this.ArmarGrafico(datos);
//                        _this.DibujarTablas(datos);
//                        _this.BuscadorDeTabla();
                    }
                });
    },

    ArmarGrafico: function (resultado) {
        $(function () {
            $('#container').highcharts({
                chart: {
                    type: 'pie',
                    options3d: {
                        enabled: true,
                        alpha: 45,
                        beta: 0
                    }
                },
                title: {
                    text: 'Browser market shares at a specific website, 2014'
                },
                tooltip: {
                    pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                },
                plotOptions: {
                    pie: {
                        allowPointSelect: true,
                        cursor: 'pointer',
                        depth: 35,
                        dataLabels: {
                            enabled: true,
                            format: '{point.name}'
                        }
                    }
                },
                series: [{
                    type: 'pie',
                    name: 'Browser share',
                    data: [
                ['Firefox', 45.0],
                ['IE', 26.8],
                {
                    name: 'Chrome',
                    y: 12.8,
                    sliced: true,
                    selected: true
                },
                ['Safari', 8.5],
                ['Opera', 6.2],
                ['Others', 0.7]
            ]
                }]
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
