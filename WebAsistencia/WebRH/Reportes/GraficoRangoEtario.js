var checks_activos = ["GraficoPorArea"];
var filtro;
var spinner;

var GraficoRangoEtario = {

    Inicializar: function () {

        var _this = this;
        GraficoHerramientas.InicializarFecha($('#txt_fecha_desde_rangoEtario'));
        GraficoHerramientas.BlanquearParametrosDeBusqueda();
        GraficoHerramientas.ActivarPrimerCheck($('#cb_SinAgrupar_RangoEtario'), "Áreas");
        _this.OcultarOtrosGraficos();
        _this.SettearEventosDeLaPagina();
    },

    SettearEventosDeLaPagina: function () {
        var _this = this;
        GraficoHerramientas.SettearEventosDeChecks(_this, $('.filtros_rangoEtario'), $('#div_tabla_rangoEtario_detalle'), $('#titulo_grafico_rangoEtario'), "Rango por ");

        $('#btn_armarGrafico_rangoEtario').click(function () {
            _this.BuscarDatos();
        });
        $('#btn_excel_rangoEtario').click(function () {
            _this.ObtenerLosDatosDeRangoEtarioParaElExport();
        });
    },


    BuscarDatos: function () {
        var _this = this;
        var check_seleccionado = checks_activos.slice(-1)[0];
        var fecha = $('#txt_fecha_desde_rangoEtario').val();
        var id_area = localStorage.getItem("idArea");
        var alias = localStorage.getItem("alias");

        if (GraficoHerramientas.VerificarDatosObligatoriosParaBackend(fecha, check_seleccionado, id_area)) {
            _this.ObtenerLosDatosDeRangoEtario(check_seleccionado, fecha, id_area, $("#chk_incluir_dependencias").is(":checked"), "Rango Etario por " + filtro + " del Área " + alias, "container_grafico_rangoEtario", "div_tabla_resultado_rangoEtario", "tabla_resultado_rangoEtareo");
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


    BuscarExcel: function (tipo, fecha, id_area) {
        var _this = this;

        var tipo = checks_activos.slice(-1)[0];
        var fecha = $('#txt_fecha_desde').val();
        //Me fijo si esta seteado el storage
        var id_area = localStorage.getItem("idArea");

        if (id_area == null) {
            return;
        }


        var resultado = Backend.ejecutarSincronico("ExcelGenerado", [{ tipo: parseInt(tipo), fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: $("#chk_incluir_dependencias").is(":checked")}]);

        if (resultado.length > 0) {

            var a = window.document.createElement('a');

            a.href = "data:application/vnd.ms-excel;base64," + resultado;

            // alert(tipo);

            switch (tipo.toString()) {

                case "1":

                    a.download = "DOTACION_POR_GENERO_" + fecha + "_.xlsx";
                    break;
                case "2":
                    a.download = "DOTACION__POR_NIVEL_" + fecha + "_.xlsx";
                    break;
                case "3":
                    a.download = "DOTACION_POR_ESTUDIO_" + fecha + "_.xlsx";
                    break;
                case "4":
                    a.download = "DOTACION_POR_PLANTA_" + fecha + "_.xlsx";
                    break;
                case "5":
                    a.download = "DOTACION_POR_AREA_" + fecha + "_.xlsx";
                    break;
                case "6":
                    a.download = "DOTACION_POR_SECRETARIAS_" + fecha + "_.xlsx";
                    break;
                case "7":
                    a.download = "DOTACION_POR_SUBSECRETARIAS_" + fecha + "_.xlsx";
                    break;
                //                case "6":                
                //                    a.download = "DOTACION_RANGO_ETARIO_" + fecha + "_.xlsx";                


                default:
                    //     alert('');
                    break;
            }



            // a.download = "excel.xlsx";

            // Append anchor to body.
            document.body.appendChild(a)
            a.click();


            // Remove anchor from body
            document.body.removeChild(a)


        }
        //   _this.GraficoYTabla(tipo, fecha, id_area, "Dotación por Nivel del Área aaa", "container_grafico_torta_totales", "div_tabla_resultado_totales", "tabla_resultado_totales");
    },



    BuscarExcelSueldos: function (tipo, fecha, id_area) {
        var _this = this;

        var tipo = checks_activos.slice(-1)[0];
        var fecha = $('#txt_fecha_desde').val();
        //Me fijo si esta seteado el storage
        var id_area = localStorage.getItem("idArea");

        if (id_area == null) {
            return;
        }


        var resultado = Backend.ejecutarSincronico("ExcelGeneradoSueldos", [{ tipo: parseInt(tipo), fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: $("#chk_incluir_dependencias").is(":checked")}]);

        if (resultado.length > 0) {

            var a = window.document.createElement('a');

            a.href = "data:application/vnd.ms-excel;base64," + resultado;

            // alert(tipo);

            //     switch (tipo.toString()) {

            //           case "1":

            a.download = "DETALLE_SUELDOS_" + fecha + "_.xlsx";
            //                    break;
            //                case "2":
            //                    a.download = "DOTACION__POR_NIVEL_" + fecha + "_.xlsx";
            //                    break;
            //                case "3":
            //                    a.download = "DOTACION_POR_ESTUDIO_" + fecha + "_.xlsx";
            //                    break;
            //                case "4":
            //                    a.download = "DOTACION_POR_PLANTA_" + fecha + "_.xlsx";
            //                    break;
            //                case "5":
            //                    a.download = "DOTACION_POR_AREA_" + fecha + "_.xlsx";
            //                    break;
            //                case "6":
            //                    a.download = "DOTACION_POR_SECRETARIAS_" + fecha + "_.xlsx";
            //                    break;
            //                case "7":
            //                    a.download = "DOTACION_POR_SUBSECRETARIAS_" + fecha + "_.xlsx";
            //                    break;
            //                //                case "6":              
            //                //                    a.download = "DOTACION_RANGO_ETARIO_" + fecha + "_.xlsx";              


            //                default:
            //                    //     alert('');
            //                    break;
            //}



            // a.download = "excel.xlsx";

            // Append anchor to body.
            document.body.appendChild(a)
            a.click();


            // Remove anchor from body
            document.body.removeChild(a)


        }
        //   _this.GraficoYTabla(tipo, fecha, id_area, "Dotación por Nivel del Área aaa", "container_grafico_torta_totales", "div_tabla_resultado_totales", "tabla_resultado_totales");
    },










    GraficoYTabla: function (tipo, fecha, id_area, incluir_dependencias, titulo, div_grafico, div_tabla, tabla) {
        var _this = this;
        $('#div_graficos_y_tablas').show();
        var spinner = new Spinner({ scale: 3 });
        spinner.spin($("html")[0]);
        Backend.GetGrafico({ tipo: parseInt(tipo), fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: incluir_dependencias })
            .onSuccess(function (grafico) {
                var resultado = grafico.tabla_resumen;
                var tabla_detalle = grafico.tabla_detalle;
                if (resultado.length > 0) {
                    _this.VisualizarContenido(true);
                    _this.ArmarGrafico(resultado, titulo, div_grafico);
                    _this.DibujarTabla(resultado, div_tabla, tabla, tabla_detalle);
                    _this.BuscadorDeTabla();

                } else {
                    _this.VisualizarContenido(false);
                    $('#div_graficos_y_tablas').hide();
                    alertify.error("No hay Personal en el Área seleccionada para la generación del Gráfico");
                }
                spinner.stop();
            })
            .onError(function (e) {
                var error = e;
                alertify.error("error al pedir datos");
                spinner.stop();
            });
    },

    GraficoYTablaRangoEtareo: function (tipo, fecha, id_area, titulo, div_grafico, div_tabla, tabla) {
        var _this = this;
        var grafico = Backend.ejecutarSincronico("GetGrafico", [{ tipo: parseInt(tipo), fecha: fecha, id_area: parseInt(id_area)}]);
        var resultado = grafico.tabla_resumen;
        var tabla_detalle = grafico.tabla_detalle;
        if (resultado.length > 0) {
            //_this.VisualizarContenido(true);
            _this.ArmarGraficoRangoEtareo(resultado, titulo, div_grafico);
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
                    if (resultado[i].DescripcionGrafico == null) {
                        nombre = resultado[i].Id.replace(/\|/g, "");
                    } else {
                        nombre = resultado[i].DescripcionGrafico;
                    }
                    var porcion = [nombre, parseInt(resultado[i].Cantidad)];
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
                        color: 'gray'
                        //                        color: (Highcharts.theme && Highcharts.theme.textColor) || 'gray'
                    }
                }
            },
            legend: {
                align: 'right',
                x: -30,
                verticalAlign: 'top',
                y: 25,
                floating: true,
                backgroundColor: 'white',
                //                backgroundColor: (Highcharts.theme && Highcharts.theme.background2) || 'white',
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
                        color: 'white',
                        //                        color: (Highcharts.theme && Highcharts.theme.dataLabelsColor) || 'white',
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


        var divGrilla = $('#' + tabla);
        var tabla = resultado;
        var columnas = [];
        var nombre = "";
        columnas.push(new Columna("Información", {
            generar: function (un_registro) {
                nombre = un_registro.Id.replace(/\|/g, "&nbsp;");
                un_registro.Id = un_registro.Id.replace(/\|/g, "");
                return nombre;

            }
        }));
        columnas.push(new Columna("Cantidad", { generar: function (un_registro) { return un_registro.Cantidad } }));
        columnas.push(new Columna("Porcentaje", { generar: function (un_registro) { return parseFloat(un_registro.Porcentaje).toFixed(2) + '%' } }));
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

        var divGrilla = $('#' + tabla);
        var tabla = resultado;

        var columnas = [];

        columnas.push(new Columna("Area", { generar: function (un_registro) { return un_registro.Area } }));
        columnas.push(new Columna("NroDocumento", { generar: function (un_registro) { return un_registro.NroDocumento } }));
        columnas.push(new Columna("Apellido_Nombre", { generar: function (un_registro) { return (un_registro.Apellido + ", " + un_registro.Nombre) } }));
        //columnas.push(new Columna("Nombre", { generar: function (un_registro) { return un_registro.Nombre } }));
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

        if (tabla.length > 0) {
            var titulo = "Tabla de Toda la Dotación del Área";
            if (criterio == "Total") {
                tabla_final = tabla;
            } else {
                switch (parseInt(checks_activos[0])) {
                    case 1:
                        titulo = "Tabla de la Dotación de Sexo " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].Sexo == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                        break;
                    case 2:
                        titulo = "Tabla de la Dotación de " + criterio;
                        var nivel = criterio.split(" ");
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].Nivel == nivel[1]) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                        break;
                    case 3:
                        titulo = "Tabla de la Dotación con Nivel de Estudios " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].NivelEstudio == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                        break;
                    case 4:
                        titulo = "Tabla de la Dotación con Tipo de Planta " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].Planta == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                        break;
                    case 5:
                        titulo = "Dotación del Área " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].Area == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                    case 6:
                        titulo = "Dotación de " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].NombreSecretaria == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                    case 7:
                        titulo = "Dotación de " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].NombresubSecretaria == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                        //                        titulo = "Tabla de la Dotación con Afiliación Gremial a " + criterio;
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
            valueNames: ['Area', 'NroDocumento', 'Apellido_Nombre', 'Sexo', 'Nivel', 'Grado', 'Planta', 'NivelEstudio', 'Titulo']
        };
        var featureList = new List('div_tabla_detalle', options);
    },

    OcultarOtrosGraficos: function () {
        $('#div_resultados_sueldos').hide();
        $('#div_filtros_sueldos').hide();
        $('#div_tabla_sueldo').hide();
        $('#div_tabla_sueldo_detalle').hide();
        $('#search_detalle_sueldo').hide();
        $('#search_sueldo').hide();
        $('#exportar_datos_sueldo').hide();
        $('#tabla_sueldo').hide();
        $('#tabla_sueldo_detalle').hide();
        $('#btn_mostrar_resumen').hide();
    },

    VisualizarContenido: function (visualizar) {
        if (visualizar) {
            $('#container_grafico_torta_totales').show();
        }

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
