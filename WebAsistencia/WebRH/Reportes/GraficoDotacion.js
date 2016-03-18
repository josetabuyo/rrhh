var checks_activos = [1];
var filtro;

var GraficoDotacion = {

    Inicializar: function () {
        var _this = this;

        $('#txt_fecha_desde').datepicker();
        $('#txt_fecha_desde').datepicker('option', 'dateFormat', 'dd/mm/yy');
        $('#txt_fecha_desde').datepicker("setDate", new Date());

        $('#btn_armarGrafico_RangoEtaero').datepicker();
        $('#btn_armarGrafico_RangoEtaero').datepicker('option', 'dateFormat', 'dd/mm/yy');
        $('#btn_armarGrafico_RangoEtaero').datepicker("setDate", new Date());
        $('#cb1').prop('checked', true);
        filtro = "Género";
        //Para que no rompa la librería por si la página se cargó anteriormente
        if (window.Highcharts) {
            window.Highcharts = null;
        }

        $('.filtros').change(function () {
            $('.filtros').each(function () {
                this.checked = false;
                checks_activos = [];
                $('#div_tabla_detalle').hide();
            });
            this.checked = true;

            filtro = this.dataset.filtro;
            var nombre = this.name;
            var lastChar = nombre.substr(nombre.length - 1);
            checks_activos.push(lastChar);

            _this.BuscarDatos();
            //_this.MarcarOpcionDeGrafico(lastChar, this);
        });

        $('#btn_armarGrafico').click(function () {
            _this.BuscarDatos();
        });
        $('#btn_armarGrafico_RangoEtaero').click(function () {
            _this.BuscarDatosRangoEtareo();
        });


        $('#btn_salir_menu').click(function () {
            $('#showTop').click();

        });
    },

    BuscarDatos: function () {
        var _this = this;
        var buscar = true;
        $('#div_tabla_detalle').hide();
        
        var tipo = checks_activos.slice(-1)[0];
        var fecha = $('#txt_fecha_desde').val();
        //Me fijo si esta seteado el storage
        if (typeof (Storage) !== "undefined") {
            var id_area = localStorage.getItem("idArea");
            var alias = localStorage.getItem("alias");

            if (tipo == null || tipo == undefined) {
                buscar = false;
                alertify.error("Debe seleccionar un filtro");
            }
            if (fecha == null || fecha == "") {
                buscar = false;
                alertify.error("Debe completar la fecha de corte para la búsqueda de datos");
            }
            if (id_area == null || id_area == "") {
                buscar = false;
                alertify.error("Debe seleccinar un área desde el organigrama");
            }
            if (buscar) {
                _this.GraficoYTabla(tipo, fecha, id_area, "Dotación por " + filtro + " del Área " + alias, "container_grafico_torta_totales", "div_tabla_resultado_totales", "tabla_resultado_totales");
            }


        } else {
            console.log("No soporta localStorage"); // No soporta Storage
        }

    },

    BuscarDatosRangoEtareo: function () {
        var _this = this;
        var buscar = true;
        $('#div_tabla_detalle_rango_etareo').hide();
        var fecha = $('#txt_fecha_desde_rango_etareo').val();
        //Me fijo si esta seteado el storage
        if (typeof (Storage) !== "undefined") {
            var id_area = localStorage.getItem("idArea");
            var alias = localStorage.getItem("alias");

            if (fecha == null || fecha == "") {
                buscar = false;
                alertify.error("Debe completar la fecha de corte para la búsqueda de datos");
            }
            if (id_area == null || id_area == "") {
                buscar = false;
                alertify.error("Debe seleccinar un área desde el organigrama");
            }
            if (buscar) {
                _this.GraficoYTablaRangoEtareo(6, fecha, id_area, "Rango Etáreo del Área " + alias, "container_grafico_rango_etareo", "div_tabla_resultado_rango_etareo", "tabla_resultado_rango_etareo");
            }


        } else {
            console.log("No soporta localStorage"); // No soporta Storage
        }

    },

    GraficoYTabla: function (tipo, fecha, id_area, titulo, div_grafico, div_tabla, tabla) {
        var _this = this;
        $('#div_graficos_y_tablas').show();
        var grafico = Backend.ejecutarSincronico("GetGrafico", [{ tipo: parseInt(tipo), fecha: fecha, id_area: parseInt(id_area)}]);
        var resultado = grafico.tabla_resumen;
        var tabla_detalle = grafico.tabla_detalle;
        if (resultado.length > 0) {
            _this.VisualizarContenido(true);
            _this.ArmarGrafico(resultado, titulo, div_grafico);
            _this.DibujarTabla(resultado, div_tabla, tabla, tabla_detalle);
            _this.BuscadorDeTabla();

        } else {
            _this.VisualizarContenido(false);
            alertify.error("No hay Reportes para los parámetros seleccionados");
        }
    },

    GraficoYTablaRangoEtareo: function (tipo, fecha, id_area, titulo, div_grafico, div_tabla, tabla) {
        var _this = this;
        var grafico = Backend.ejecutarSincronico("GetGraficoRangoEtareo", [{ tipo: parseInt(tipo), fecha: fecha, id_area: parseInt(id_area)}]);
        var resultado = grafico.tabla_resumen;
        var tabla_detalle = grafico.tabla_detalle;
        if (resultado.length > 0) {
            _this.VisualizarContenido(true);
            _this.ArmarGrafico(resultado, titulo, div_grafico);
            _this.DibujarTabla(resultado, div_tabla, tabla, tabla_detalle);
            _this.BuscadorDeTabla();

        } else {
            _this.VisualizarContenido(false);
            alertify.error("No hay Reportes para los parámetros seleccionados");
        }
    },

    CrearDatos: function (resultado) {
        var datos = [];
        for (var i = 0; i < resultado.length; i++) {
            if (resultado[i].Id != "Total") {
                if (parseInt(resultado[i].Cantidad) > 0) {
                    var porcion = [resultado[i].Id, parseInt(resultado[i].Cantidad)];
                    datos.push(porcion);
                }
            }

        };
        return datos;
    },

    CrearDatosRangoEtareo: function (resultado) {
        var datos = [{
            name: 'John',
            data: [5, 3, 4, 7, 2]
        }, {
            name: 'Jane',
            data: [2, 2, 3, 2, 1]
        }, {
            name: 'Joe',
            data: [3, 4, 4, 2, 5]
        }]

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
                pointFormat: '{series.name}: <b>{point.percentage:.2f}%</b>'
            },
            plotOptions: {
                pie: {
                    allowPointSelect: true,
                    cursor: 'pointer',
                    depth: 35,
                    dataLabels: {
                        enabled: true,
                        format: '{point.name}' + ': ' + '{point.percentage:.2f}' + '%',
                        style: {
                            textShadow: ''
                        }
                    }
                }
            },
            series: grafico
        });

    },
    ArmarGraficoRangoEtareo: function (resultado, titulo, div_grafico) {

        var datos = this.CrearDatosRangoEtareo(resultado);

        var edades = ['Apples', 'Oranges', 'Pears', 'Grapes', 'Bananas'];
        $('#' + div_grafico).highcharts({
            chart: {
                type: 'column'
            },
            title: {
                text: titulo
            },
            xAxis: {
                categories: edades
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'Conteo de Edad'
                },
                stackLabels: {
                    enabled: true,
                    style: {
                        fontWeight: 'bold',
                        color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                    }
                }
            },
            legend: {
                align: 'right',
                x: -30,
                verticalAlign: 'top',
                y: 25,
                floating: true,
                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
                borderColor: '#CCC',
                borderWidth: 1,
                shadow: false
            },
            tooltip: {
                headerFormat: '<b>{point.x}</b><br/>',
                pointFormat: '{series.name}: {point.y}<br/>Total: {point.stackTotal}'
            },
            plotOptions: {
                column: {
                    stacking: 'normal',
                    dataLabels: {
                        enabled: true,
                        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',
                        style: {
                            textShadow: '0 0 3px black'
                        }
                    }
                }
            },
            series: datos
        });






    },

    DibujarTabla: function (resultado, div_tabla, tabla, tabla_detalle) {
        var _this = this;
        $("#" + tabla).empty();
        $("#search").show();
        $("#exportar_datos").show();

        var divGrilla = $('#' + tabla);
        var tabla = resultado;

        var columnas = [];
        columnas.push(new Columna("Información", { generar: function (un_registro) { return un_registro.Id } }));
        columnas.push(new Columna("Cantidad", { generar: function (un_registro) { return un_registro.Cantidad } }));
        columnas.push(new Columna("Porcentaje", { generar: function (un_registro) { return un_registro.Porcentaje + '%' } }));
        columnas.push(new Columna('Detalle', {
            generar: function (un_registro) {
                var btn_accion = $('<a>');
                var img = $('<img>');
                img.attr('src', '../Imagenes/detalle.png');
                img.attr('width', '15px');
                img.attr('height', '15px');
                btn_accion.append(img);
                btn_accion.click(function () {
                    $('#div_tabla_detalle').show();
                    _this.BuscarPersonas(un_registro.Id, tabla_detalle);
                });
                return btn_accion;
            }
        }));

        _this.GrillaResumen = new Grilla(columnas);
        _this.GrillaResumen.SetOnRowClickEventHandler(function (un_registro) {
        });
        _this.GrillaResumen.CargarObjetos(tabla);
        _this.GrillaResumen.DibujarEn(divGrilla);

    },

    DibujarTablaDetalle: function (resultado, div_tabla, tabla) {
        var _this = this;
        $("#" + tabla).empty();
        $("#search").show();
        $("#exportar_datos").show();
        var divGrilla = $('#' + tabla);
        var tabla = resultado;

        var columnas = [];
        columnas.push(new Columna("NroDocumento", { generar: function (un_registro) { return un_registro.NroDocumento } }));
        columnas.push(new Columna("Apellido", { generar: function (un_registro) { return un_registro.Apellido } }));
        columnas.push(new Columna("Nombre", { generar: function (un_registro) { return un_registro.Nombre } }));
        columnas.push(new Columna("Sexo", { generar: function (un_registro) { return un_registro.Sexo } }));
        columnas.push(new Columna("FechaNacimiento", { generar: function (un_registro) { return _this.ConvertirFecha(un_registro.FechaNacimiento) } }));
        columnas.push(new Columna("Nivel", { generar: function (un_registro) { return un_registro.Nivel } }));
        columnas.push(new Columna("Grado", { generar: function (un_registro) { return un_registro.Grado } }));
        columnas.push(new Columna("Planta", { generar: function (un_registro) { return un_registro.Planta } }));
        columnas.push(new Columna("NivelEstudio", { generar: function (un_registro) { return un_registro.NivelEstudio } }));
        columnas.push(new Columna("Titulo", { generar: function (un_registro) { return un_registro.Titulo } }));
        columnas.push(new Columna('Detalle', {
            generar: function (un_registro) {
                var btn_accion = $('<a>');
                var img = $('<img>');
                img.attr('src', '../Imagenes/detalle.png');
                img.attr('width', '15px');
                img.attr('height', '15px');
                btn_accion.append(img);
                btn_accion.click(function () {
                    console.log(un_registro);
                    localStorage.setItem("documento", un_registro.NroDocumento);
                    window.open('ConsultaIndividual.aspx', '_blank');
                    //window.location.replace("ConsultaIndividual.aspx");
                });

                return btn_accion;
            }
        }));

        _this.GrillaResumen = new Grilla(columnas);
        _this.GrillaResumen.SetOnRowClickEventHandler(function (un_registro) {
        });
        _this.GrillaResumen.CargarObjetos(tabla);
        _this.GrillaResumen.DibujarEn(divGrilla);
        _this.BuscadorDeTablaDetalle();
    },
    BuscarPersonas: function (criterio, tabla) {
        var _this = this;
        var tabla_final = [];
        $('#search_detalle').show();
        $('#exportar_datos_detalle').show();

        if (tabla.length > 0) {
            var titulo = "Tabla de Toda la Dotación del Área";
            if (criterio == "Total") {
                tabla_final = tabla;
            } else {
                switch (parseInt(checks_activos[0])) {
                    //CUANDO ES INFORME DE GENERO                       
                    case 1:
                        titulo = "Tabla de la Dotación de Sexo " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].Sexo == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                        break;
                    //CUANDO ES INFORME DE NIVEL                        
                    case 2:
                        titulo = "Tabla de la Dotación de " + criterio;
                        var nivel = criterio.split(" ");
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].Nivel == nivel[1]) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                        break;
                    //CUANDO ES INFORME DE ESTUDIOS                         
                    case 3:
                        titulo = "Tabla de la Dotación con Nivel de Estudios " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].NivelEstudio == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                        break;
                    //CUANDO ES INFORME DE PLANTAS                         
                    case 4:
                        titulo = "Tabla de la Dotación con Tipo de Planta " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].Planta == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                        break;
                    //CUANDO ES INFORME DE AFILICIACION                         
                    case 5:
                        titulo = "Tabla de la Dotación con Afiliación Gremial a " + criterio;
                        /*for (var i = 0; i < tabla.length; i++) {
                        if (tabla[i].Nivel == nivel[1]) {
                        tabla_final.push(tabla[i]);
                        }
                        }*/
                        break;
                }


            }
            titulo = titulo + " del Área " + localStorage.getItem("alias");
            $('#lb_titulo_tabla_detalle').text(titulo);
            _this.VisualizarContenido(true);
            _this.DibujarTablaDetalle(tabla_final, "div_tabla_detalle", "tabla_detalle");

        } else {
            _this.VisualizarContenido(false);
            alertify.error("No hay Reportes para los parámetros seleccionados");
        }
    },
    BuscadorDeTabla: function () {

        var options = {
            valueNames: ['Información', 'Cantidad', 'Porcentaje']
        };
        var featureList = new List('div_tabla_resultado_totales', options);
    },

    BuscadorDeTablaDetalle: function () {

        var options = {
            valueNames: ['NroDocumento', 'Apellido', 'Nombre', 'Sexo', 'Nivel', 'Grado', 'Planta', 'NivelEstudio', 'Titulo']
        };
        var featureList = new List('div_tabla_detalle', options);
    },
    ExportarDatosGraficoValorMercadoYContable: function () {
        //                var sessionTable = "ExportarDatosGraficoValorMercadoYContable";
        //                var fecha_reporte = $("#fecha_hasta").val().toString();
        //                var fileName = "GraficoValorMercadoYContable_" + fecha_reporte + '_' + $("#id_cartera option:selected").text();
        //                exportXLS(sessionTable, fileName);
    },

    ConvertirFecha: function (fecha) {
        var dia = fecha.substring(8, 10);
        var mes = fecha.substring(5, 7);
        var anio = fecha.substring(0, 4);
        return dia + "/" + mes + "/" + anio;
    },

    VisualizarContenido: function (visualizar) {
        $('#container_grafico_torta_totales').show();
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
