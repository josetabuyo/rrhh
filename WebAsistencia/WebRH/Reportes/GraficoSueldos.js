var checks_activos = ["GraficoPorArea"];
var filtro;
var spinner;


var GraficoSueldos = {
    Inicializar: function () {

        var _this = this;
        GraficoHerramientas.InicializarFecha($('#txt_fecha_desde_sueldo'));
        GraficoHerramientas.BlanquearParametrosDeBusqueda();
        GraficoHerramientas.ActivarPrimerCheck($('#cb_SinAgrupar'), "Áreas");
        _this.OcultarOtrosGraficos();
        _this.SettearEventosDeLaPagina();
        //_this.SettearEventosDelMenu();

        $('#btn_mostrar_resumen').click(function () {
            _this.VisualizarResumenDeSueldos(true);

        });
    },


    SettearEventosDeLaPagina: function () {
        var _this = this;
        GraficoHerramientas.SettearEventosDeChecks(_this, $('.filtros_sueldo'), $('#div_tabla_sueldo_detalle'), $('#titulo_grafico'), "Sueldo por ");

        $('#btn_buscar_sueldo').click(function () {
            _this.BuscarDatos();
        });
        $('#exportar_datos_sueldo').click(function () {
            _this.ObtenerLosDatosDeSueldoParaElExport();
        });

        $('#txt_fecha_desde_sueldo').change(function () {
            _this.VisualizarTablaResumen(false);
        });
    },


    BuscarDatos: function () {

        var _this = this;
        var check_seleccionado = checks_activos.slice(-1)[0];
        var fecha = $('#txt_fecha_desde_sueldo').val();
        var id_area = localStorage.getItem("idArea");
        var alias = localStorage.getItem("alias");

        if (GraficoHerramientas.VerificarDatosObligatoriosParaBackend(fecha, check_seleccionado, id_area)) {
            _this.ObtenerLosDatosDeSueldo(check_seleccionado, fecha, id_area, $("#chk_incluir_dependencias").is(":checked"), "Recibos por " + filtro + " del Área " + alias, " ", "div_tabla_sueldo", "tabla_sueldo");
        }
    },

    ObtenerLosDatosDeSueldo: function (tipo, fecha, id_area, incluir_dependencias, titulo, container, div_tabla, tabla) {
        var _this = this;
        var spinner = new Spinner({ scale: 3 });
        spinner.spin($("html")[0]);

        Backend.GetReporteSueldos({ tipo: tipo, fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: incluir_dependencias })
            .onSuccess(function (grafico) {
                var tabla_resumen = grafico.tabla_resumen;
                var tabla_detalle = grafico.tabla_detalle;
                if (tabla_detalle.length > 0) {
                    _this.VisualizarTablaResumen(true);
                    _this.DibujarTabla(tabla_resumen, div_tabla, tabla, tabla_detalle);
                    _this.BuscadorDeTabla();
                } else {
                    _this.VisualizarTablaResumen(false);
                    alertify.error("No hay Personal en el Área seleccionada para la generación del Gráfico");
                }
                spinner.stop();
            })
            .onError(function (e) {
                alertify.error("Error al pedir datos. Detalle: " + e);
                spinner.stop();
            });
    },

    ObtenerLosDatosDeSueldoParaElExport: function () {
        var _this = this;
        var check_seleccionado = checks_activos.slice(-1)[0];
        var fecha = $('#txt_fecha_desde_sueldo').val();
        var id_area = localStorage.getItem("idArea");

        if (GraficoHerramientas.VerificarDatosObligatoriosParaBackend(fecha, check_seleccionado, id_area)) {
            Backend.ExcelGeneradoSueldos({ tipo: check_seleccionado, fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: $("#chk_incluir_dependencias").is(":checked") })
             .onSuccess(function (resultado) {
                 if (resultado.length > 0) {
                     var nombre_del_documento = "DETALLE_SUELDOS_" + fecha + "_.xlsx";
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



    //DIBUJO DE LAS TABLAS
    DibujarTabla: function (resultado, div_tabla, tabla, tabla_detalle) {
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
        columnas.push(new Columna("SumatoriaSueldo", { generar: function (un_registro) { return GraficoHerramientas.ConvertirAMonedaLocal(un_registro.SumatoriaSueldo) } }));
        columnas.push(new Columna("PromedioSueldo", { generar: function (un_registro) { return GraficoHerramientas.ConvertirAMonedaLocal(un_registro.PrimedioSueldo) } }));
        columnas.push(new Columna("MedianaSueldo", { generar: function (un_registro) { return GraficoHerramientas.ConvertirAMonedaLocal(un_registro.MedianaSueldo) } }));
        columnas.push(new Columna("SumatoriaExtras", { generar: function (un_registro) { return GraficoHerramientas.ConvertirEnBlanco(un_registro.SumatoriaExtras) } }));
        columnas.push(new Columna("PrimedioExtras", { generar: function (un_registro) { return GraficoHerramientas.ConvertirEnBlanco(parseFloat(un_registro.PrimedioExtras).toFixed(2)) } }));
        columnas.push(new Columna("MedianaExtras", { generar: function (un_registro) { return GraficoHerramientas.ConvertirEnBlanco(un_registro.MedianaExtras) } }));
        columnas.push(new Columna('Detalle', {
            generar: function (un_registro) {
                var btn_accion = $('<a>');
                var img = $('<img>');
                img.attr('src', '../Imagenes/detalle.png');
                img.attr('width', '15px');
                img.attr('height', '15px');
                btn_accion.append(img);
                btn_accion.click(function () {
                    _this.VisualizarTablaDetalle(true);
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
        columnas.push(new Columna("Documento", { generar: function (un_registro) { return GraficoHerramientas.ConvertirANumeroConPuntos(un_registro.NroDocumento); } }));
        columnas.push(new Columna("Apellido_Nombre", { generar: function (un_registro) { return (un_registro.Apellido + ", " + un_registro.Nombre) } }));
        columnas.push(new Columna("SueldoBruto", { generar: function (un_registro) { return GraficoHerramientas.ConvertirAMonedaLocal(un_registro.SueldoBruto); } }));
        columnas.push(new Columna("SueldoNeto", { generar: function (un_registro) { return GraficoHerramientas.ConvertirAMonedaLocal(un_registro.SueldoNeto); } }));
        columnas.push(new Columna("ExtrasBruto", { generar: function (un_registro) { return GraficoHerramientas.ConvertirAMonedaLocal(un_registro.ExtrasBruto); } }));
        columnas.push(new Columna("ExtrasNeto", { generar: function (un_registro) { return GraficoHerramientas.ConvertirAMonedaLocal(un_registro.ExtrasNeto); } }));
        columnas.push(new Columna("HsSimples", { generar: function (un_registro) { return GraficoHerramientas.ConvertirEnBlanco(un_registro.HsSimples); } }));
        columnas.push(new Columna("Hs50%", { generar: function (un_registro) { return GraficoHerramientas.ConvertirEnBlanco(un_registro.Hs50); } }));
        columnas.push(new Columna("Hs100%", { generar: function (un_registro) { return GraficoHerramientas.ConvertirEnBlanco(un_registro.Hs100); } }));
        columnas.push(new Columna("Comidas", { generar: function (un_registro) { return GraficoHerramientas.ConvertirEnBlanco(un_registro.Comidas); } }));
        columnas.push(new Columna("UR", { generar: function (un_registro) { return GraficoHerramientas.ConvertirEnBlanco(un_registro.UnidadRetributiva); } }));
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

    FiltrarPersonasParaTablaDetalle: function (criterio, tabla) {
        var _this = this;
        var tabla_final = [];

        if (tabla.length > 0) {
            var titulo = "Tabla de Todos los Sueldos del";
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
            titulo = "Detalle de Sueldos de la Dotación del Área " + criterio;
            //titulo = titulo + " del Área " + localStorage.getItem("alias");
            $('#lb_titulo_tabla_sueldo_detalle').text(titulo);
            _this.VisualizarTablaDetalle(true);
            _this.DibujarTablaDetalle(tabla_final, "div_tabla_sueldo_detalle", "tabla_sueldo_detalle");

        } else {
            _this.VisualizarTablaDetalle(false);
            alertify.error("No hay Datos para la Fila de Resumen Seleccionada");
        }
    },

    BuscadorDeTablaDetalle: function () {
        var options = {
            valueNames: ['Area', 'Documento', 'Apellido_Nombre', 'SueldoBruto', 'SueldoNeto', 'ExtrasBruto', 'ExtrasNeto', 'HsSimples', 'Hs50%', 'Hs100%', 'Comidas', 'UR']
        };
        var featureList = new List('div_tabla_sueldo_detalle', options);
    },

    BuscadorDeTabla: function () {

        var options = {
            valueNames: ['Información', 'Cantidad', 'Porcentaje', 'SumatoriaSueldo', 'PromedioSueldo', 'MedianaSueldo', 'SumatoriaExtras', 'PrimedioExtras', 'MedianaExtras']
        };
        var featureList = new List('div_tabla_sueldo', options);
    },


    VisualizarTablaDetalle: function (visualizar) {
        if (visualizar) {
            $('#tabla_sueldo_detalle').show();
            $('#div_tabla_sueldo_detalle').show();
            $('#search_detalle_sueldo').show();
            $('#div_tabla_detalle_sueldo').show();
            $("#tabla_sueldo_detalle").show();
            $('#btn_mostrar_resumen').show();
            $('#div_tabla_sueldo').hide();
            $("#search_sueldo").hide();
            $("#exportar_datos_sueldo").hide();
            $("#lb_titulo_tabla_sueldo_detalle").show();
            
        } else {
            $('#tabla_sueldo_detalle').hide();
            $('#div_tabla_sueldo_detalle').hide();
            $('#search_detalle_sueldo').hide();
            $('#div_tabla_detalle_sueldo').hide();
            $("#tabla_sueldo_detalle").hide();
            $('#btn_mostrar_resumen').hide();
            $('#div_tabla_sueldo').show();
            $("#search_sueldo").show();
            $("#exportar_datos_sueldo").show();
            $("#lb_titulo_tabla_sueldo_detalle").hide();
        }
    },

    // VISUALIZACIÓN
    OcultarOtrosGraficos: function () {
        $('#div_resultados_sueldos').hide();
        $('#div_filtros_sueldos').show();
        $('#btn_mostrar_resumen').hide();
        $('#div_tabla_sueldo').hide();
        $('#search_sueldo').hide();
        $('#exportar_datos_sueldo').hide();
        $('#tabla_sueldo').hide();
        $('#div_tabla_sueldo_detalle').hide();
        $('#search_detalle_sueldo').hide();
        $('#tabla_sueldo_detalle').hide();
        $('#container_grafico_torta_totales').hide();
        $("#search").hide();
        $('#div_graficos_y_tablas').hide();
        $('#search_detalle').hide();
        $('#div_tabla_detalle').hide();
        $('#div_grafico_de_dotacion').hide();
        $('#div_filtros').hide();

    },

    VisualizarResumenDeSueldos: function (visualizar) {
        if (visualizar) {
            $('#search_sueldo_detalle').hide();
            $('#btn_mostrar_resumen').hide();
            $('#tabla_sueldo_detalle').hide();
            $("#search_detalle_sueldo").hide();
            $("#lb_titulo_tabla_sueldo_detalle").hide();
            $('#div_tabla_sueldo').show();
            $("#search_sueldo").show();
            $("#exportar_datos_sueldo").show();
        }
    },

    VisualizarTablaResumen: function (visualizar) {
        if (visualizar) {
            $('#div_resultados_sueldos').show();
            $('#search_sueldo').show();
            $('#exportar_datos_sueldo').show();
            $("#search_detalle_sueldo").hide();
            $('#div_filtros_sueldos').show();
            $('#div_tabla_sueldo').show();
            $('#tabla_sueldo').show();
        } else {
            $('#search_sueldo').hide();
            $('#exportar_datos_sueldo').hide();
            $("#search_detalle_sueldo").hide();
            $('#div_tabla_sueldo').hide();
            $('#tabla_sueldo').hide();

        }

    }
}
