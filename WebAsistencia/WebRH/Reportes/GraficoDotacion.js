var GraficoDotacion = {

    Inicializar: function () {
        var _this = this;
        //Para que no rompa la librería por si la página se cargó anteriormente
        if (window.Highcharts) {
            window.Highcharts = null;
        }
        $('#btn_armarGrafico').click(function () {
            _this.BuscarDatos();
        });
    },

    BuscarDatos: function () {
        var _this = this;
        Backend.GetGrafico()
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

    CrearDatos: function (resultado) {
        var datos = [];
        for (var i = 0; i < resultado.length; i++) {
            var porcion = [resultado[i].Tipo, resultado[i].Cantidad];
            datos.push(porcion);
        };
        return datos;
    },

    ArmarGrafico: function (resultado) {

        var datos = this.CrearDatos(resultado);
        var grafico = [{
            type: 'pie',
            name: 'Dotación',
            data: datos
        }];


        $('#container_grafico_torta').highcharts({
            chart: {
                type: 'pie',
                options3d: {
                    enabled: true,
                    alpha: 45,
                    beta: 0
                }
            },
            title: {
                text: 'Dotación del Área ...'
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
                        format: '{point.name}',
                        style: {
                            textShadow: ''
                        }
                    }
                }
            },
            series: grafico
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
