var checks_activos = ["GraficoPorArea"];
var filtro;
var spinner;

var GraficoRangoEtario = {

    Inicializar: function () {
        var _this = this;
        GraficoHerramientas.InicializarFecha($('#txt_fecha_desde_rangoEtario'));
        //        GraficoHerramientas.BlanquearParametrosDeBusqueda();
        GraficoHerramientas.ActivarPrimerCheck($('#cb_SinAgrupar_rangoEtario'), "Sin Agrupar");
        GraficoHerramientas.OcultarTodosLosReportesExcepto("RangoEtario");
        _this.SettearEventosDeLaPagina();
    },

    SettearEventosDeLaPagina: function () {
        var _this = this;
        GraficoHerramientas.SettearEventosDeChecks(_this, $('.filtros_rangoEtario'), $('#div_tabla_detalle_rangoEtario'), $('#titulo_grafico_rangoEtario'), "Agrupar por ");

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
            _this.ObtenerLosDatosDeRangoEtario(check_seleccionado, fecha, id_area, $("#chk_incluir_dependencias").is(":checked"), "Rango Etário por " + filtro + " del Área " + alias, "container_grafico_rangoEtario", "div_tabla_resultado_rangoEtario", "tabla_resultado_rangoEtario");
        }
    },


    //OBTENER LOS DATOS DESDE EL BACKEND
    ObtenerLosDatosDeRangoEtario: function (tipo, fecha, id_area, incluir_dependencias, titulo, div_grafico, div_tabla, tabla) {
        var _this = this;
        var spinner = new Spinner({ scale: 3 });
        spinner.spin($("html")[0]);

        Backend.GetGraficoRangoEtario({ tipo: tipo, fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: incluir_dependencias })
            .onSuccess(function (grafico) {
                var tabla_resumen = grafico.tabla_resumen;
                var tabla_detalle = grafico.tabla_detalle;
                if (tabla_resumen.length > 0) {
                    _this.VisualizarTablaResumenYGrafico(true);
                    _this.DibujarElGrafico(tabla_resumen, titulo, div_grafico);
                    _this.DibujarTablaResumen(tabla_resumen, div_tabla, tabla, tabla_detalle);
                    _this.BuscadorDeTabla();
                } else {
                    _this.VisualizarTablaResumenYGrafico(false);
                    alertify.error("No hay Personal en el Área seleccionada para la generación del Gráfico");
                }
                spinner.stop();
            })
            .onError(function (e) {
                spinner.stop();
                alertify.error("Error al pedir datos. Detalle: " + e);
            });
    },

    ObtenerLosDatosDeRangoEtarioParaElExport: function () {
        var _this = this;
        var check_seleccionado = checks_activos.slice(-1)[0];
        var fecha = $('#txt_fecha_desde_rangoEtario').val();
        var id_area = localStorage.getItem("idArea");

        if (GraficoHerramientas.VerificarDatosObligatoriosParaBackend(fecha, check_seleccionado, id_area)) {

            var spinner = new Spinner({ scale: 3 });
            spinner.spin($("html")[0]);

            Backend.ExcelGenerado({ tipo: check_seleccionado, fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: $("#chk_incluir_dependencias").is(":checked") })
            .onSuccess(function (resultado) {
                if (resultado.length > 0) {
                    var nombre_del_documento = "DETALLE_RANGOETARIO_" + fecha + "_.xlsx";
                    var a = window.document.createElement('a');
                    a.href = "data:application/vnd.ms-excel;base64," + resultado;
                    a.download = nombre_del_documento + fecha + "_.xlsx";
                    document.body.appendChild(a);
                    a.click();
                    document.body.removeChild(a);
                } else {
                    alertify.error("No se han encontrado datos para Exportar");
                }
                spinner.stop();
            })
            .onError(function (e) {
                spinner.stop();
                alertify.error("error al Exportar datos. Detalle: " + e);
            });

        }
    },


    //DIBUJAR GRAFICO
    DibujarElGrafico: function (datos_del_resumen, titulo, div_grafico) {
        var datos = this.CrearDatosDesdeElResumenParaArmarElGrafico(datos_del_resumen);
        var grafico = [{ type: 'pie', name: 'Rango Etário', data: datos}];
        var categorias = ['18 a 25', '26 a 35', '36 a 45', '46 a 55', '56 a 60', '61 a 65', '> 65'];
        var datos = [{
                name: 'Hombres',
                data: [5, 3, 4, 7, 2, 5, 1]
            }, {
                name: 'Mujeres',
                data: [3, 4, 4, 2, 5, 3, 54]
            }];

        $('#' + div_grafico).highcharts({
            chart: {
                type: 'column'
            },
            title: {
                text: titulo
            },
            xAxis: {
                categories: categorias
            },
            yAxis: {
                min: 0,
                title: {
                    text: 'Cantidad de Personas'
                },
                stackLabels: {
                    enabled: true,
                    style: {
                        fontWeight: 'bold',
                        color: 'gray'
                    }
                }
            },
            legend: {
                align: 'right',
                x: -0,
                verticalAlign: 'top',
                y: 55,
                floating: true,
                backgroundColor: 'white',
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
                        style: {
                            textShadow: '0 0 3px black'
                        }
                    }
                }
            },
            series: datos
        });
    },

    CrearDatosDesdeElResumenParaArmarElGrafico: function (resumen) {
        var datos = [];
        for (var i = 0; i < resumen.length; i++) {
            if (resumen[i].Id != "Total") {
                if (parseInt(resumen[i].Cantidad) > 0) {
                    if (resumen[i].DescripcionGrafico == null) {
                        nombre = resumen[i].Id.replace(/\|/g, "");
                    } else {
                        nombre = resumen[i].DescripcionGrafico;
                    }
                    var porcion = [nombre, parseInt(resumen[i].Cantidad)];
                    datos.push(porcion);
                }
            }
        };
        return datos;
    },

    FiltrarPersonasParaTablaDetalle: function (criterio, tabla) {
        var _this = this;
        var tabla_final = [];

        if (tabla.length > 0) {
            var titulo = "Tabla de Todos los Rangos Etários del";
            if (criterio == "Total") {
                tabla_final = tabla;
            } else {
                switch (checks_activos[0]) {
                    case "GraficoPorArea":
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].Area == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        } break;
                    case "GraficoPorSecretarias":
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].NombresubSecretaria == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        } break;
                    case "GraficoPorSubSecretarias":
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].NombresubSecretaria == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        } break;
                }
            }
            titulo = "Detalle de Rango Etário del Área " + criterio;
            //titulo = titulo + " del Área " + localStorage.getItem("alias");
            $('#lb_titulo_tabla_detalle_rangoEtario').text(titulo);
            _this.VisualizarTablaDetalle(true);
            _this.DibujarTablaDetalle(tabla_final, "div_tabla_detalle_rangoEtario", "tabla_detalle_rangoEtario");

        } else {
            _this.VisualizarTablaDetalle(false);
            alertify.error("No hay Datos para la Fila de Resumen Seleccionada");
        }
    },

    //DIBUJO DE LAS TABLAS
    DibujarTablaResumen: function (resultado, div_tabla, tabla, tabla_detalle) {
        var _this = this;
        $("#" + tabla).empty();

        var divGrilla = $('#' + tabla);
        var tabla = resultado;
        var nombre = "";
        var columnas = [];

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
                    _this.FiltrarPersonasParaTablaDetalle(un_registro.Id, tabla_detalle);
                });
                return btn_accion;
            }
        }));
        _this.GrillaResumen = new Grilla(columnas);
        _this.GrillaResumen.SetOnRowClickEventHandler(function (un_registro) { });
        _this.GrillaResumen.CargarObjetos(tabla);
        _this.GrillaResumen.DibujarEn(divGrilla);
    },

    DibujarTablaDetalle: function (resultado, div_tabla, tabla) {
        var _this = this;
        $("#" + tabla).empty();
        var divGrilla = $('#' + tabla);
        var tabla = resultado;
        var columnas = [];

        columnas.push(new Columna("Area", { generar: function (un_registro) { return un_registro.Area } }));
        columnas.push(new Columna("NroDocumento", { generar: function (un_registro) { return un_registro.NroDocumento } }));
        columnas.push(new Columna("Apellido_Nombre", { generar: function (un_registro) { return (un_registro.Apellido + ", " + un_registro.Nombre) } }));
        columnas.push(new Columna("Sexo", { generar: function (un_registro) { return un_registro.Sexo } }));
        columnas.push(new Columna("FechaNacimiento", { generar: function (un_registro) { return GraficoHerramientas.ConvertirFecha(un_registro.FechaNacimiento) } }));
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
                });
                return btn_accion;
            }
        }));
        _this.GrillaResumen = new Grilla(columnas);
        _this.GrillaResumen.SetOnRowClickEventHandler(function (un_registro) { });
        _this.GrillaResumen.CargarObjetos(tabla);
        _this.GrillaResumen.DibujarEn(divGrilla);
        _this.BuscadorDeTablaDetalle();
    },

    //VISUALIZADORES
    VisualizarTablaResumenYGrafico: function (visualizar) {
        if (visualizar) {
            $('#container_grafico_rangoEtario').show();
            $("#search_rangoEtario").show();
            $('#div_graficos_y_tablas_rangoEtario').show();
        } else {
            $('#container_grafico_rangoEtario').hide();
            $("#search_rangoEtario").hide();
            $('#div_graficos_y_tablas_rangoEtario').hide();
        }
    },

    VisualizarTablaDetalle: function (visualizar) {
        if (visualizar) {
            $('#container_grafico_rangoEtario').show();
            $('#search_detalle_rangoEtario').show();
            $('#div_tabla_detalle_rangoEtario').show();
        } else {
            $('#container_grafico_rangoEtario').hide();
            $('#search_detalle_rangoEtario').hide();
            $('#div_tabla_detalle_rangoEtario').hide();
        }
    },

    VisualizarGraficoYTablaResumen: function (visualizar) {
        if (visualizar) {
            $('#div_grafico_de_rangoEtario').show();
            $('#div_filtros_rangoEtario').show();
            $('#div_graficos_y_tablas_rangoEtario').hide();
        }
    },

    //BUSCADORES DE LAS TALBAS
    BuscadorDeTabla: function () {
        var options = {
            valueNames: ['Información', 'Cantidad', 'Porcentaje']
        };
        var featureList = new List('div_tabla_resultado_rangoEtario', options);
    },
    BuscadorDeTablaDetalle: function () {
        var options = {
            valueNames: ['Area', 'NroDocumento', 'Apellido_Nombre', 'Sexo', 'Nivel', 'Grado', 'Planta', 'NivelEstudio', 'Titulo']
        };
        var featureList = new List('div_tabla_detalle_rangoEtario', options);
    }
}
