var checks_activos = [1];

var GraficoDotacion = {

    Inicializar: function () {
        var _this = this;

        //Para que no rompa la librería por si la página se cargó anteriormente
        if (window.Highcharts) {
            window.Highcharts = null;
        }
        $('#cb1').click();
        $('#btn_armarGrafico').click(function () {
            _this.BuscarDatos();
        });
        $('#cb1').change(function () {
            _this.MarcarOpcionDeGrafico(1);
        });
        $('#cb2').change(function () {
            _this.MarcarOpcionDeGrafico(2);
        });
        $('#cb3').change(function () {
            _this.MarcarOpcionDeGrafico(3);
        });
        $('#cb4').change(function () {
            _this.MarcarOpcionDeGrafico(4);
        });
        $('#cb5').change(function () {
            _this.MarcarOpcionDeGrafico(5);
        });
        $('#btn_salir_menu').click(function () {
            $('#showTop').click();

        });

        $('#btn_excel').click(function () {
            _this.BuscarExcel();
        });

    },
    MarcarOpcionDeGrafico: function (checkbox) {

        if ($.inArray(checkbox, checks_activos) == -1) {
            for (var i = 1; i < 6; i++) {
                if ($.inArray(i, checks_activos) !== -1) {
                    var nombre = "#cb" + i
                    $(nombre).click();
                    checks_activos.splice($.inArray(i, checks_activos), 1);
                }
            }
            checks_activos.push(checkbox);
        } else {
            checks_activos = [];
        }
        console.log(checks_activos);
    },

    BuscarDatos: function () {
        var _this = this;
        var tipo = checks_activos.slice(-1)[0];
        var fecha = new Date();
        var id_area = 1024;
        _this.GraficoYTabla(tipo, fecha, id_area, "Dotación por Nivel del Área aaa", "container_grafico_torta_totales", "div_tabla_resultado_totales", "tabla_resultado_totales");
    },



    BuscarExcel: function () {
        var _this = this;

        var resultado = Backend.ejecutarSincronico("ExcelGenerado", []);

        if (resultado.length > 0) {

            var a = window.document.createElement('a');

            a.href = "data:application/vnd.ms-excel;base64," + resultado;
            a.download = "excel.xlsx";

            // Append anchor to body.
            document.body.appendChild(a)
            a.click();


            // Remove anchor from body
            document.body.removeChild(a)


        }
        //   _this.GraficoYTabla(tipo, fecha, id_area, "Dotación por Nivel del Área aaa", "container_grafico_torta_totales", "div_tabla_resultado_totales", "tabla_resultado_totales");
    },


    GraficoYTabla: function (tipo, fecha, id_area, titulo, div_grafico, div_tabla, tabla) {
        var _this = this;
        var resultado = Backend.ejecutarSincronico("GetGrafico", [{ tipo: parseInt(tipo), fecha: fecha, id_area: parseInt(id_area)}]);
        //personas = Backend.ejecutarSincronico("GetGrafico", [{ tipo: parseInt(2)}]);
        if (resultado.length > 0) {
            _this.VisualizarContenido(true);
            _this.ArmarGrafico(resultado, titulo, div_grafico);
            _this.DibujarTabla(resultado, div_tabla, tabla);
            _this.BuscadorDeTabla();
        } else {
            _this.VisualizarContenido(false);
            alertify.error("No hay Reportes para los parámetros seleccionados");
        }
    },

    CrearDatos: function (resultado) {
        var datos = [];
        for (var i = 0; i < resultado.length; i++) {
            var porcion = [resultado[i].clave, parseInt(resultado[i].valor)];
            datos.push(porcion);
        };
        return datos;
    },

    ArmarGrafico: function (resultado, titulo, div_grafico) {

        var datos = this.CrearDatos(resultado);
        var grafico = [{
            type: 'pie',
            name: 'Dotación',
            data: datos
        }];

        $('#' + div_grafico).highcharts({
            chart: {
                type: 'pie',
                options3d: {
                    enabled: true,
                    alpha: 45,
                    beta: 0
                }
            },
            title: {
                text: titulo
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

    DibujarTabla: function (resultado, div_tabla, tabla) {
        var _this = this;
        $("#" + tabla).empty();
        $("#search").show();
        $("#exportar_datos").show();
        var divGrilla = $('#' + tabla);
        var tabla = resultado;

        var columnas = [];
        columnas.push(new Columna("Nivel", { generar: function (un_registro) { return un_registro.clave } }));
        columnas.push(new Columna("Cantidad", { generar: function (un_registro) { return un_registro.valor } }));
        columnas.push(new Columna("Porcentaje", { generar: function (un_registro) { return un_registro.valor } }));
        columnas.push(new Columna('Detalle', {
            generar: function (un_registro) {
                var btn_accion = $('<a>');
                var img = $('<img>');
                img.attr('src', '../Imagenes/detalle.png');
                img.attr('width', '25px');
                img.attr('height', '25px');
                btn_accion.append(img);
                btn_accion.click(function () {
                    _this.BuscarPersonas(un_registro.clave);
                });

                return btn_accion;
            }
        }));

        this.GrillaResumen = new Grilla(columnas);
        this.GrillaResumen.CargarObjetos(tabla);
        this.GrillaResumen.DibujarEn(divGrilla);

    },
    BuscarPersonas: function (id_area) {
        var _this = this;
        var resultado = Backend.ejecutarSincronico("GetGrafico", [{ tipo: parseInt(2)}]);
        if (resultado.length > 0) {
            _this.VisualizarContenido(true);
            _this.DibujarTabla(resultado, "div_tabla_detalle", "tabla_detalle");

        } else {
            _this.VisualizarContenido(false);
            alertify.error("No hay Reportes para los parámetros seleccionados");
        }
    },
    BuscadorDeTabla: function () {
        $('#search').show();
        var options = {
            valueNames: ['Nivel', 'Cantidad']
        };
        var featureList = new List('div_tabla_resultado_totales', options);
    },

    ExportarDatosGraficoValorMercadoYContable: function () {
        //                var sessionTable = "ExportarDatosGraficoValorMercadoYContable";
        //                var fecha_reporte = $("#fecha_hasta").val().toString();
        //                var fileName = "GraficoValorMercadoYContable_" + fecha_reporte + '_' + $("#id_cartera option:selected").text();
        //                exportXLS(sessionTable, fileName);
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
