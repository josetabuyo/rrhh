var checks_activos = ["GraficoPorArea"];
var filtro;
var spinner;

var GraficoRangoEtario = {

    Inicializar: function () {
        var _this = this;
        GraficoHerramientas.InicializarFecha($('#txt_fecha_desde_rangoEtario'));
        GraficoHerramientas.ActivarPrimerCheck($('#cb_SinAgrupar_rangoEtario'), "Sin Agrupar");
        GraficoHerramientas.OcultarTodosLosReportesExcepto("RangoEtario");
        _this.SettearEventosDeLaPagina();
    },

    SettearEventosDeLaPagina: function () {
        var _this = this;
        GraficoHerramientas.SettearEventosDeChecks(_this, $('.filtros_rangoEtario'), $('#div_tabla_detalle_rangoEtario'), $('#titulo_grafico_rangoEtario'), "Agrupar por ");

        $('#btn_armarGrafico_rangoEtario').click(function () {
            GraficoHerramientas.OcultarTodosLosReportesExcepto("RangoEtario");
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
            _this.ObtenerLosDatosDeRangoEtario(check_seleccionado, fecha, id_area, $("#chk_incluir_dependencias").is(":checked"), "Rango Etário del Área " + alias, "container_grafico_rangoEtario", "div_tabla_resultado_rangoEtario", "tabla_resultado_rangoEtario");
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

            Backend.ExcelGeneradoRangoEtario({ tipo: check_seleccionado, fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: $("#chk_incluir_dependencias").is(":checked") })
            .onSuccess(function (resultado) {
                if (resultado.length > 0) {
                    var nombre_del_documento = "DETALLE_RANGOETARIO_" + fecha;
                    var a = window.document.createElement('a');
                    a.href = "data:application/vnd.ms-excel;base64," + resultado;
                    a.download = nombre_del_documento + ".xlsx";
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

    ObtenerCategorias: function (categorias) {
        var detalle_categorias = [];
        for (var i = 0; i < categorias.length; i++) {
            if (categorias[i].Id != "Total") {
                detalle_categorias.push(categorias[i].Id);
            }
        }
        return detalle_categorias;
    },

    //DIBUJAR GRAFICO
    DibujarElGrafico: function (datos_del_resumen, titulo, div_grafico) {
        var _this = this;
        var datos = this.CrearDatosDesdeElResumenParaArmarElGrafico(datos_del_resumen);
        var categorias = _this.ObtenerCategorias(datos_del_resumen);

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
        var hombres = [];
        var mujeres = [];
        for (var i = 0; i < resumen.length; i++) {
            if (resumen[i].Id != "Total") {
                hombres.push(resumen[i].CantidadHombres);
                mujeres.push(resumen[i].CantidadMujeres);
            }
        }

        var datos = [{
            name: 'Hombres',
            data: hombres
        }, {
            name: 'Mujeres',
            data: mujeres
        }];

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
                var fecha_menor = 0;
                var fecha_mayor = 0;
                switch (checks_activos[0]) {
                    case "GraficoPorArea":
                        if (criterio.indexOf('-') > -1) {
                            fecha_menor = parseInt(criterio.substring(0, 2));
                            fecha_mayor = parseInt(criterio.substring(3, 5));
                            for (var i = 0; i < tabla.length; i++) {
                                if (tabla[i].EdadPersona >= fecha_menor && tabla[i].EdadPersona <= fecha_mayor) {
                                    tabla_final.push(tabla[i]);
                                }
                            }
                        } else {
                            fecha_menor = parseInt(criterio.substring(1, 3));
                            for (var i = 0; i < tabla.length; i++) {
                                if (tabla[i].EdadPersona >= fecha_menor) {
                                    tabla_final.push(tabla[i]);
                                }
                            }
                        }
                        break;
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
            titulo = "Detalle de Rango Etário del Área "; //+ criterio;
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
        columnas.push(new Columna("Porcentaje Hombres", { generar: function (un_registro) { return parseFloat(un_registro.PorcentajeHombres).toFixed(2) + '%' } }));
        columnas.push(new Columna("Porcentaje Mujeres", { generar: function (un_registro) { return parseFloat(un_registro.PorcentajeMujeres).toFixed(2) + '%' } }));
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
        columnas.push(new Columna("CUIL", { generar: function (un_registro) { return un_registro.CUIL } }));
        columnas.push(new Columna("Apellido_Nombre", { generar: function (un_registro) { return (un_registro.Apellido + ", " + un_registro.Nombre) } }));
        columnas.push(new Columna("Edad", { generar: function (un_registro) { return un_registro.EdadPersona } }));
        columnas.push(new Columna("Sexo", { generar: function (un_registro) { return un_registro.Sexo } }));
        columnas.push(new Columna("FechaNacimiento", { generar: function (un_registro) { return GraficoHerramientas.ConvertirFecha(un_registro.FechaNacimiento) } }));
        columnas.push(new Columna("FechaIngreso", { generar: function (un_registro) { return GraficoHerramientas.ConvertirFecha(un_registro.FechaIngreso) } }));
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
            $("#btn_excel_rangoEtario").show();
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
            $("#btn_excel_rangoEtario").show();
        }
    },

    VisualizarGraficoYTablaResumen: function (visualizar) {
        if (visualizar) {
            $('#div_grafico_de_rangoEtario').show();
            $('#div_filtros_rangoEtario').show();
            $('#div_graficos_y_tablas_rangoEtario').hide();
            $("#btn_excel_rangoEtario").show();
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
            valueNames: ['Area', 'NroDocumento', 'Apellido_Nombre', 'Edad', 'Sexo', 'Nivel', 'Grado', 'Planta', 'NivelEstudio', 'Titulo']
        };
        var featureList = new List('div_tabla_detalle_rangoEtario', options);
    }
}
