var checks_activos = ["GraficoPorArea"];
var filtro;
var spinner;
var tabla_resumen;
var tabla_detalle;

var GraficoContratos = {

    Inicializar: function () {
        var _this = this;
        //    GraficoHerramientas.InicializarFecha($('#txt_fecha_desde'));
        //        GraficoHerramientas.BlanquearParametrosDeBusqueda();
        //      GraficoHerramientas.ActivarPrimerCheck($('#cb1'), "Género");
        //       GraficoHerramientas.OcultarTodosLosReportesExcepto("Dotacion");
        _this.dibujarArbolOrganigrama();
        _this.SettearEventosDeLaPagina();
        //_this.SettearEventosDelMenu();
        $("#chk_incluir_dependencias").click(function () {
            _this.VisualizarGraficoYTablaResumen(true);
            _this.VisualizarTablaDetalle(false);
            $("#div_tabla_informes").hide();
            _this.BuscarDatos();
        });
    },

    SettearEventosDeLaPagina: function () {
        var _this = this;
        GraficoHerramientas.SettearEventosDeChecks(_this, $('.filtros'), $('#div_tabla_detalle'), $('#titulo_grafico'), "Bienes por ");

        $('#btn_armarGrafico').click(function () {
            _this.BuscarDatos();
        });
        $('#btn_excel').click(function () {
            _this.ObtenerLosDatosDeDotacionParaElExport();
        });
        $("#btn_refrescar").click(function () {
            _this.VisualizarGraficoYTablaResumen(true);
            _this.VisualizarTablaDetalle(false);
            $("#div_tabla_informes").hide();
            _this.BuscarDatos();
        });
    },
    SettearEventosDelMenu: function () {
        var _this = this;

    },
    armarGraficoDesdeMenu: function (mi_filtro, tipo, texto) {
        var _this = this;
        checks_activos = [];
        filtro = mi_filtro;
        _this.VisualizarGraficoYTablaResumen(true);
        checks_activos.push(tipo);
        _this.BuscarDatos();
        $('#titulo_grafico').html(texto);
        $('.filtros').each(function () {
            this.checked = false;
        });
    },

    BuscarDatos: function () {
        var _this = this;
        var check_seleccionado = checks_activos.slice(-1)[0];
        var fecha = new Date();
        var id_area = localStorage.getItem("idArea");
        var alias = localStorage.getItem("alias");
        var tipo = "GraficoPorArea";

        if (GraficoHerramientas.VerificarDatosObligatoriosParaBackend(fecha, check_seleccionado, id_area)) {
            _this.ObtenerLosDatosDeDotacion(tipo, fecha, id_area, $("#chk_incluir_dependencias").is(":checked"), "Bienes del Área " + alias, "container_grafico_torta_totales", "div_tabla_resultado_totales", "tabla_resultado_totales");
        }
    },


    //OBTENER LOS DATOS DESDE EL BACKEND
    ObtenerLosDatosDeDotacion: function (tipo, fecha, id_area, incluir_dependencias, titulo, div_grafico, div_tabla, tabla) {
        var _this = this;
        var spinner = new Spinner({ scale: 3 });
        spinner.spin($("html")[0]);
        _this.VisualizarTablaDetalle(false);


        //Backend.GetGraficoContratados({ tipo: tipo, fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: incluir_dependencias })
        Backend.GetGraficoBienes({ tipo: tipo, fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: incluir_dependencias })
            .onSuccess(function (grafico) {
                tabla_resumen = grafico.tabla_resumen;
                tabla_detalle = grafico.tabla_detalle_contratos;
                if (tabla_resumen == null) {
                    alertify.error("No hay bienes asignadas al Área seleccionada");

                } else {
                    if (tabla_resumen.length > 0) {
                        _this.VisualizarTablaResumenYGrafico(true);
                        _this.DibujarElGrafico(tabla_resumen, titulo, div_grafico);
                        _this.DibujarTablaResumen(tabla_resumen, div_tabla, tabla, tabla_detalle);
                        _this.BuscadorDeTabla();
                    } else {
                        _this.VisualizarTablaResumenYGrafico(false);
                        alertify.error("No hay Bienes en el Área seleccionada para la generación del Gráfico");
                    }
                }
                spinner.stop()

            })
            .onError(function (e) {
                spinner.stop();
                alertify.error("Error al pedir datos. Detalle: " + e);
            });
    },

    ObtenerLosDatosDeDotacionParaElExport: function () {
        var _this = this;
        var check_seleccionado = checks_activos.slice(-1)[0];
        var fecha = new Date();
        var id_area = localStorage.getItem("idArea");
        var tipo = "GraficoPorArea";

        var anio = fecha.getFullYear();
        var mes = fecha.getMonth() + 1;
        var dia = fecha.getDate();

        var fecha_completa = anio + "/" + mes + "/" + dia;

        if (GraficoHerramientas.VerificarDatosObligatoriosParaBackend(fecha, check_seleccionado, id_area)) {

            var spinner = new Spinner({ scale: 3 });
            spinner.spin($("html")[0]);

            Backend.ExcelGeneradoContratos({ tipo: tipo, fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: $("#chk_incluir_dependencias").is(":checked") })
            .onSuccess(function (resultado) {
                if (resultado.length > 0) {
                    var nombre_del_documento = "";
                    nombre_del_documento = "ESTADO_BIENES_";

                    var a = window.document.createElement('a');
                    a.href = "data:application/vnd.ms-excel;base64," + resultado;
                    a.download = nombre_del_documento + fecha_completa + "_.xlsx";
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
        var grafico = [{ type: 'pie', name: 'Selección de Bienes', data: datos}];
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
        _this.VisualizarTablaDetalle(true);
        //$('#div_detalle_informe').show();aaaaaaaaaa

        if (tabla.length > 0) {
            var titulo = "Tabla de Toda la Dotación del Área";
            if (criterio == "Total") {
                tabla_final = tabla;
            } else {
                switch (checks_activos[0]) {
                    case "GraficoPorArea":
                        titulo = "Bienes del Área " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].IdEstado == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        } break;
                    case "GraficoPorInforme":
                        titulo = "Personas del Informe " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].Informe == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        } break;
                    case "ImpresionInforme":
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].Informe == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        } break;
                }
            }

            if (checks_activos[0] == "ImpresionInforme") {
                return tabla_final;
            }
            else {
                titulo = titulo + " del Área " + localStorage.getItem("alias");
                $('#lb_titulo_tabla_detalle').text(titulo);
                _this.VisualizarTablaDetalle(true);
                _this.DibujarTablaDetalle(tabla_final, "div_tabla_detalle", "tabla_detalle");
            }

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

        var id_area = localStorage.getItem("idArea");

        columnas.push(new Columna("Información", {
            generar: function (un_registro) {
                nombre = un_registro.DescripcionGrafico.replace(/\|/g, "&nbsp;");
                un_registro.DescripcionGrafico = un_registro.DescripcionGrafico.replace(/\|/g, "");
                return nombre;
            }
        }));
        columnas.push(new Columna("Cantidad", { generar: function (un_registro) { return un_registro.Cantidad } }));
        columnas.push(new Columna("Porcentaje", { generar: function (un_registro) { return parseFloat(un_registro.Porcentaje).toFixed(2) + '%' } }));
        columnas.push(new Columna('Detalle', {
            generar: function (un_registro) {
                var cont = $('<div>');

                if (un_registro.Cantidad == 0) return cont;

                var btn_accion = $('<a>');
                var img = $('<img>');
                img.attr('src', '../Imagenes/detalle.png');
                img.attr('width', '15px');
                img.attr('height', '15px');
                btn_accion.attr('style', 'display:inline-block');
                btn_accion.append(img);
                btn_accion.click(function () {
                    var spinner = new Spinner({ scale: 3 });
                    spinner.spin($("html")[0]);

                    setTimeout(function () {
                        checks_activos = ["GraficoPorArea"];
                        $('#div_tabla_detalle').hide();
                        $('#div_tabla_informes').hide();

                        _this.FiltrarPersonasParaTablaDetalle(un_registro.Id, tabla_detalle);

                        spinner.stop();
                    }, 10);

                });
                cont.append(btn_accion);

//                if (un_registro.Id == 2 || un_registro.Id == 3) {
//                    var btn_informe = $('<input>');
//                    btn_informe.attr('type', 'button');
//                    btn_informe.attr('value', 'Generar Informe');
//                    btn_informe.attr('class', 'btn btn-info');
//                    btn_informe.attr('style', 'display:inline-block');
//                    btn_informe.click(function () {
//                        var spinner = new Spinner({ scale: 3 });
//                        spinner.spin($("html")[0]);
//                        var datos = { id_area: id_area,
//                            incluir_dependencias: $("#chk_incluir_dependencias").is(":checked"),
//                            id_estado: un_registro.Id //es el id de estado
//                        };

//                        Backend.GenerarInformeContrato(datos)
//                        .onSuccess(function (resultado) {
//                            alertify.success("Informe generado con éxito");
//                            spinner.stop();
//                        })
//                        .onError(function (e) {
//                            spinner.stop();
//                            alertify.error("Error al generar informe");
//                        });
//                        //$('#div_detalle_informe').show(); $('#div_tabla_detalle').show();aaaaaaaaaaaaaa
//                    });
//                    cont.append(btn_informe);
//                }

//                if (un_registro.Id == 4 || un_registro.Id == 5) {
//                    var btn_informe = $('<input>');
//                    btn_informe.attr('type', 'button');
//                    btn_informe.attr('value', 'Ver Informes');
//                    btn_informe.attr('class', 'btn btn-info');
//                    btn_informe.attr('style', 'display:inline-block');
//                    btn_informe.click(function () {
//                        $('#div_tabla_detalle').hide();
//                        //$('#div_tabla_detalle').hide();aaaaaaaaaaaaaaa

//                        var datos = { id_area: id_area,
//                            incluir_dependencias: $("#chk_incluir_dependencias").is(":checked"),
//                            id_estado: un_registro.Id
//                        };



//                        var spinner = new Spinner({ scale: 3 });
//                        spinner.spin($("html")[0]);
//                        //_this.FiltrarInformesParaTabla(un_registro.Id, tabla_detalle);
//                        Backend.GetInformesGeneradosPorArea(datos)
//                            .onSuccess(function (resultado) {
//                                spinner.stop();
//                                // _this.VisualizarTablaDetalle(true);
//                                _this.DibujarTablaInformes(resultado);
//                            })
//                            .onError(function (e) {
//                                spinner.stop();
//                                alertify.error("Error al generar informe");
//                            });


//                    });
//                    cont.append(btn_informe);
//                }

                return cont;
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

        $("#btn_exportarExcelDetalle").show();
        $("#btn_generarInforme").show();

        columnas.push(new Columna("Area", { generar: function (un_registro) { return un_registro.Area } }));
        columnas.push(new Columna("NroDocumento", { generar: function (un_registro) { return un_registro.NroDocumento } }));
        columnas.push(new Columna("Apellido_Nombre", { generar: function (un_registro) { return (un_registro.Apellido + ", " + un_registro.Nombre) } }));
        columnas.push(new Columna('Detalle', {
            generar: function (un_registro) {

                var div = $('<div>');

                //Si la persona ya fue informado, se deshabilitan los radio button, sino, no.
                var habilitado = "";
                if (un_registro.Informe != 0)
                    habilitado = "disabled";

                //Me fijo que estado tiene (Renovado, No renovado, Pendiente) para marcar los radios
                var checkRenovado = "";
                var checkNoRenovado = "";
                var checkPendiente = "";
                var ocultarRenovado = false;
                var ocultarNoRenovado = false;
                var ocultarPendiente = false;
                switch (un_registro.IdEstado) {
                    case 2:
                        checkRenovado = "checked";
                        checkNoRenovado = "";
                        checkPendiente = "";
                        break;
                    case 4:
                        checkRenovado = "checked";
                        checkNoRenovado = "";
                        checkPendiente = "";
                        ocultarNoRenovado = true;
                        ocultarPendiente = true;
                        break;
                    case 3:
                        checkRenovado = "";
                        checkNoRenovado = "checked";
                        checkPendiente = "";
                        break;
                    case 5:
                        checkRenovado = "";
                        checkNoRenovado = "checked";
                        checkPendiente = "";
                        ocultarRenovado = true;
                        ocultarPendiente = true;
                        break;
                    default:
                        checkRenovado = "";
                        checkNoRenovado = "";
                        checkPendiente = "checked";
                }


                if (!ocultarRenovado) {
                    var radioRenovar = $('<input id="radioRenovar" ' + habilitado + ' ' + checkRenovado + ' data-area="' + un_registro.IdArea + '" type="radio" name="contratos_' + un_registro.NroDocumento + '" value="2"  /> <span style="color:green;">Renovar</span><br/>');
                    div.append(radioRenovar);
                }

                if (!ocultarNoRenovado) {
                    var radioNoRenovar = $('<input id="radioNoRenovar" ' + habilitado + ' ' + checkNoRenovado + ' data-area="' + un_registro.IdArea + '" type="radio" name="contratos_' + un_registro.NroDocumento + '" value="3"  /> <span style="color:red;">No Renovar</span><br/>');
                    div.append(radioNoRenovar);
                }

                if (!ocultarPendiente) {
                    var radioPendiente = $('<input id="radioPendiente" ' + habilitado + ' ' + checkPendiente + ' data-area="' + un_registro.IdArea + '" type="radio" name="contratos_' + un_registro.NroDocumento + '" value="1"  /> <span style="color:#000;">Pendiente</span><br/>');
                    div.append(radioPendiente);
                }








                return div;
            }
        }));
        columnas.push(new Columna('Informe', {
            generar: function (un_registro) {
                var div = $('<div>');
                div.html(un_registro.Informe);

                return div;
            }
        }));




        _this.GrillaResumen = new Grilla(columnas);
        _this.GrillaResumen.SetOnRowClickEventHandler(function (un_registro) { });
        _this.GrillaResumen.CargarObjetos(tabla);
        _this.GrillaResumen.DibujarEn(divGrilla);
        _this.BuscadorDeTablaDetalle();

        //Bindeo eventos sobre los radio buttons
        $('input:radio').change(
                function () {
                    if ($(this).is(':checked')) {

                        var doc = $(this)[0].name.split('_')[1];
                        var accio = $(this).val(); // $(this).data("accion");
                        var area = $(this).data("area");

                        Backend.AgregarRenovacionContrato({ id_area: area, documento: doc, accion: accio })
                            .onSuccess(function (rto) {
                                alertify.success("Ok");

                            })
                            .onError(function (e) {

                                alertify.error("Error");
                            });

                    }
                });
    },

    //VISUALIZADORES
    VisualizarTablaResumenYGrafico: function (visualizar) {
        if (visualizar) {
            $('#container_grafico_torta_totales').show();
            $("#search").show();
            $('#div_graficos_y_tablas').show();
        } else {
            $('#container_grafico_torta_totales').hide();
            $("#search").hide();
            $('#div_graficos_y_tablas').hide();
        }
    },

    VisualizarTablaDetalle: function (visualizar) {
        if (visualizar) {
            $('#container_grafico_torta_totales').show();
            $('#search_detalle').show();
            $('#div_tabla_detalle').show();
        } else {
            $('#container_grafico_torta_totales').hide();
            $('#search_detalle').hide();
            $('#div_tabla_detalle').hide();
        }
    },

    VisualizarGraficoYTablaResumen: function (visualizar) {
        if (visualizar) {
            $('#div_grafico_de_dotacion').show();
            $('#div_filtros').show();
            $('#div_graficos_y_tablas').hide();
        }
    },

    //BUSCADORES DE LAS TALBAS
    BuscadorDeTabla: function () {
        var options = {
            valueNames: ['Información', 'Cantidad', 'Porcentaje']
        };
        var featureList = new List('div_tabla_resultado_totales', options);
    },
    BuscadorDeTablaDetalle: function () {
        var options = {
            valueNames: ['Area', 'NroDocumento', 'Apellido_Nombre']
        };
        var featureList = new List('div_tabla_detalle', options);
    },

    dibujarArbolOrganigrama: function () {
        var _this = this;
        _this.arbol_organigrama = new ArbolOrganigrama($("#contenedor_arbol_organigrama"));
        _this.arbol_organigrama.alSeleccionar(function (area) {
            $('.lista').show();
            $('#showLeftPush').click();
            localStorage.setItem("idArea", area.id);
            localStorage.setItem("alias", area.alias);
            $('#titulo_area').html(area.alias);
            $('#div_tabla_informes').hide();

            $('#div_grafico_de_dotacion').hide();
            $('#div_grafico_de_rango_etareo').hide();
            $('#titulo_grafico').html("Seleccionar Informe");

            $("#chk_incluir_dependencias").show();
            $("#lbl_incluir_dependencias").show();

            _this.armarGraficoDesdeMenu("Contrato", "GraficoPorArea", "Contrato por " + this.innerHTML);
            //para subir al tope de la pantalla
            /* $('html,body').animate({
            scrollTop: $("#Reportes").offset().top
            }, 1000);*/
            console.log(area);
        });
    },

    DibujarTablaInformes: function (informesJSON) {
        var _this = this;
        $("#tabla_informe").empty();
        $('#div_tabla_informes').show();
        var divGrilla = $('#tabla_informe');
        var informes = JSON.parse(informesJSON);
        var informes_no_duplicados = _.uniq(informes, 'Informe');
        var columnas = [];

        //$("#btn_exportarExcelDetalle").show();
        //$("#btn_generarInforme").show();

        columnas.push(new Columna("N° Informe", { generar: function (un_registro) { return un_registro.Informe } }));
        columnas.push(new Columna("Fecha", { generar: function (un_registro) {
            var fecha_sin_hora = un_registro.Fecha.split("T");
            var fecha = fecha_sin_hora[0].split("-");
            return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
        }
        }));
        columnas.push(new Columna("Usuario", { generar: function (un_registro) { return (un_registro.Usuario) } }));
        columnas.push(new Columna('Ver Detalle', {
            generar: function (un_registro) {

                var div = $('<div>');

                var btn_accion = $('<a>');
                var img = $('<img>');
                img.attr('src', '../Imagenes/detalle.png');
                img.attr('width', '15px');
                img.attr('height', '15px');
                btn_accion.attr('style', 'display:inline-block; border-bottom: none;');
                btn_accion.append(img);
                btn_accion.click(function () {
                    checks_activos = ["GraficoPorInforme"];
                    _this.FiltrarPersonasParaTablaDetalle(un_registro.Informe, tabla_detalle);
                });

                var btn_impresion = $('<a>');
                var img = $('<img>');
                img.attr('src', '../Imagenes/Botones/impresora.png');
                img.attr('width', '25px');
                img.attr('height', '25px');
                btn_impresion.attr('style', 'display:inline-block; border-bottom: none;');
                btn_impresion.append(img);
                btn_impresion.click(function () {
                    //GPR
                    checks_activos = ["ImpresionInforme"];
                    var tabla = _this.FiltrarPersonasParaTablaDetalle(un_registro.Informe, tabla_detalle);

                    DibujarGrillaInformeImpresion(un_registro, tabla);
                });

                div.append(btn_accion);
                div.append(btn_impresion);

                return div;
            }
        }));


        _this.GrillaResumen = new Grilla(columnas);
        _this.GrillaResumen.SetOnRowClickEventHandler(function (un_registro) { });
        _this.GrillaResumen.CargarObjetos(informes_no_duplicados);
        _this.GrillaResumen.DibujarEn(divGrilla);
        //_this.BuscadorDeTablaDetalle();


    }
}


var DibujarGrillaInformeImpresion = function (un_registro, tabla) {

    var vista_ddjj_imprimir = $("<table style='page-break-before: always; border:1; width:100%'>");
    DibujarGrillaPersonas(un_registro, tabla, vista_ddjj_imprimir);

    var w = window.open("ImpresionSeleccionDeContratos.aspx");

    w.onload = function () {
        var pantalla_impresion = $(w.document);

        //Declaro los campos que tiene la pantalla de impresion
        var t = w.document.getElementById("PanelImpresion");

        var leyendaPorAnio = w.document.getElementById("LeyendaPorAnio");
        var nroInforme = w.document.getElementById("NroInforme");
        var fecha = w.document.getElementById("Fecha");


        //Completo los campos
        Backend.GetLeyendaAnio(2016)
            .onSuccess(function (respuesta) {
                $(leyendaPorAnio).html(respuesta);
            })
            .onError(function (error, as, asd) {
                alertify.alert("Error al obtener leyenda del año");
            });

        $(nroInforme).html(un_registro.Informe.toString());

        var fecha_sin_hora = un_registro.Fecha.split("T");
        var fecha_sin_formato = fecha_sin_hora[0].split("-");
        $(fecha).html("Buenos Aires " + fecha_sin_formato[2] + "/" + fecha_sin_formato[1] + "/" + fecha_sin_formato[0]);

        $(t).html(vista_ddjj_imprimir.html());
    }
}

/// te dice si un vector de areas, contiene alguna con el id_area_dado
var contieneIdArea = function (id_area, array_areas) {
    for (var i = 0; i < array_areas.length; i++) {
        if (array_areas[i].IdArea == id_area) return true;
    }
    return false;
};

var personasDelArea = function (id_area, array_personas) {
    var resultado = [];
    for (var i = 0; i < array_personas.length; i++) {
        if (array_personas[i].IdArea == id_area) {
            resultado.push(array_personas[i]);
        };
    }
    return resultado;
}

var DibujarGrillaPersonas = function (un_registro, resultado, contenedor_grilla) {
    //Maximo por hoja solo con el 1er encabezado entran 56 personas.
    //Si hay otra area entran 52 personas porque el encabezado cuenta 4 personas mas.
    ////    var personas_pagina_1 = 43; //40;
    ////    var personas_pagina_mayor_que_1 = 62; //60;
    ////    var personas_calculo_por_hoja = 56; //esto es porque cuento los espacios para completar la hoja
    ////    var cantidad_de_persona_por_hoja = personas_pagina_1;
    ////    var cantidad_de_filas_por_cabecera = 4;
    ////    var contador_de_registros_por_pagina = 0;
    ////    var contador_de_paginas = 1;

    ////    var cantidad_total_de_personas = contarPersonasDelArea(un_area);
    ////    var cantidad_restantes_de_personas = cantidad_total_de_personas - cantidad_de_persona_por_hoja;
    ////    var cantidad_total_de_hojas = Math.ceil(cantidad_restantes_de_personas / personas_calculo_por_hoja) + 1;

    contenedor_grilla.empty();

    var areas_distintas = [];
    for (var i = 0; i < resultado.length; i++) {
        if (!contieneIdArea(resultado[i].IdArea, areas_distintas)) {
            areas_distintas.push(resultado[i]);
        }
    }

    for (var i = 0; i < areas_distintas.length; i++) {

        /*var queryResult = Enumerable.From(resultado)
        .Where(function (x) { return x.IdArea == resultado[i].IdArea });
        var data_post = { lista: queryResult.ToArray() };*/

        contenedor_grilla.append($("<br/>"));
        contenedor_grilla.append($("<div><b>" + areas_distintas[i].Area + "<b/></div>"));
        contenedor_grilla.append($("<br/>"));
        contenedor_grilla.append($());

        var columnas = [];
        //columnas.push(new Columna("Area", { generar: function (resultado) { return resultado.Area } }));
        columnas.push(new Columna("NroDocumento", { generar: function (resultado) { return resultado.NroDocumento } }));
        columnas.push(new Columna("Apellido_Nombre", { generar: function (resultado) { return (resultado.Apellido + ", " + resultado.Nombre) } }));
        columnas.push(new Columna("Estado", { generar: function (resultado) { return (resultado.Estado) } }));

        GrillaResumen = new Grilla(columnas);

        var personasArea = personasDelArea(areas_distintas[i].IdArea, resultado);

        GrillaResumen.CargarObjetos(personasArea);
        GrillaResumen.DibujarEn(contenedor_grilla);
        GrillaResumen.SetOnRowClickEventHandler(function (un_registro) { });
    }

    /*
    if (es_impresion) {
    contador_de_registros_por_pagina = contador_de_registros_por_pagina + cantidad_de_filas_por_cabecera;
    if (un_area.Personas.length > 0) {
    for (var i = 0; i < un_area.Personas.length; i++) {

    //CONTROLO PARA HACER LE SALTO DE PAGINA
    if (contador_de_registros_por_pagina >= cantidad_de_persona_por_hoja) {
    cantidad_de_persona_por_hoja = personas_pagina_mayor_que_1;
    contador_de_paginas = contador_de_paginas + 1;
    grilla.DibujarEn(contenedor_grilla);

    contenedor_grilla.append($("<br/>"));
    contenedor_grilla.append($("<br/>"));
    contenedor_grilla.append($("<br/>"));
    contenedor_grilla.append($("<br/>"));

    contenedor_grilla.append($("<div class='nombre_area_informal'><b>" + un_area.Nombre + " (continuación)" + "<b/>" + "(Pag: " + contador_de_paginas + "/" + cantidad_total_de_hojas + ")</div>"));
    grilla = new Grilla(
    [
    new Columna("APELLIDO Y NOMBRE", { generar: function (una_persona) { return una_persona.Apellido + ", " + una_persona.Nombre; } }),
    new Columna("CUIL/CUIT", { generar: function (una_persona) { return una_persona.Cuit; } }),
    new Columna("ESCALAFON O MODALIDAD DE CONTRATACION", { generar: function (una_persona) { return una_persona.Categoria.split("#")[1]; } }),
    new Columna("NIVEL O CATEGORIA", { generar: function (una_persona) { return una_persona.Categoria.split("#")[0]; } }),
    ]);
    contador_de_registros_por_pagina = cantidad_de_filas_por_cabecera;
    }
    //FIN SALTO DE PAGINA

    var obj = un_area.Personas[i];
    grilla.CargarObjeto(obj);
    contador_de_registros_por_pagina = contador_de_registros_por_pagina + 1;
    }
    }
    }
    else {
    grilla.CargarObjetos(un_area.Personas);
    }

    grilla.DibujarEn(contenedor_grilla);
    grilla.SetOnRowClickEventHandler(function () {
    return true;
    });
    */

}
