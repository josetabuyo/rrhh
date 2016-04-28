grafico_de_dotacion = 1;

var GraficoDotacion = {

    Inicializar: function () {
        var _this = this;
        HerramientasGraficos.SettearValoresDeInicio($('#txt_fecha_desde'), grafico_de_dotacion);
        HerramientasGraficos.IniciarNuevoGrafico();
        HerramientasGraficos.SettearChecks($('.filtros'), "Dotación por ", grafico_de_dotacion, $('#cb1'), "Género");
        _this.SettearBotonesDelMenu(_this);
    },

    SettearBotonesDelMenu: function (_this) {
        $('#btn_genero').click(function () {
            armarGraficoDesdeMenu("Genero", 1, "Dotación por " + this.innerHTML);
            $('#cb1')[0].checked = true;
        });
        $('#btn_nivel').click(function () {
            armarGraficoDesdeMenu("Nivel", 2, "Dotación por " + this.innerHTML);
            $('#cb2')[0].checked = true;
        });
        $('#btn_estudios').click(function () {
            armarGraficoDesdeMenu("Estudios", 3, "Dotación por " + this.innerHTML);
            $('#cb3')[0].checked = true;
        });
        $('#btn_plantas').click(function () {
            armarGraficoDesdeMenu("Plantas", 4, "Dotación por " + this.innerHTML);
            $('#cb4')[0].checked = true;
        });
        $('#btn_areas').click(function () {
            armarGraficoDesdeMenu("Areas", 5, "Dotación por " + this.innerHTML);
            $('#cb5')[0].checked = true;
        });
        $('#btn_secretarias').click(function () {
            armarGraficoDesdeMenu("Secreatarías", 6, "Dotación por " + this.innerHTML);
            $('#cb6')[0].checked = true;
        });
        $('#btn_subsecretarias').click(function () {
            armarGraficoDesdeMenu("SubSecretarías", 7, "Dotación por " + this.innerHTML);
            $('#cb7')[0].checked = true;
        });

        function armarGraficoDesdeMenu(mi_filtro, tipo, texto) {

            HerramientasGraficos.OcultarOtrosGraficos(grafico_de_dotacion);
            checks_activos = [];
            filtro = mi_filtro;
            checks_activos.push(tipo);

            HerramientasGraficos.BuscarDatos($('#txt_fecha_desde'), grafico_de_dotacion);
            
            $('#titulo_grafico').html(texto);
            $('.filtros').each(function () {
                this.checked = false;
            });
        };
    },

    BuscarDatos: function (tipo, fecha, id_area, filtro, alias) {
        var _this = this;

        $('#div_tabla_detalle').hide();

        _this.GraficoYTabla(tipo, fecha, id_area, $("#chk_incluir_dependencias").is(":checked"), "Dotación por " + filtro + " del Área " + alias, "container_grafico_torta_totales", "div_tabla_resultado_totales", "tabla_resultado_totales");


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
                default:
                    break;
            }
            document.body.appendChild(a)
            a.click();
            document.body.removeChild(a)
        }
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
            a.download = "DETALLE_SUELDOS_" + fecha + "_.xlsx";

            document.body.appendChild(a)
            a.click();
            document.body.removeChild(a)


        }

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
                    $("#btn_excel").show();
                    _this.ArmarGrafico(resultado, titulo, div_grafico);
                    _this.DibujarTabla(resultado, div_tabla, tabla, tabla_detalle);
                    _this.BuscadorDeTabla();

                } else {
                    _this.VisualizarContenido(false);
                    $('#div_graficos_y_tablas').hide();
                    $("#btn_excel").hide();
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

    ConvertirFecha: function (fecha) {
        var dia = fecha.substring(8, 10);
        var mes = fecha.substring(5, 7);
        var anio = fecha.substring(0, 4);
        return dia + "/" + mes + "/" + anio;
    },

    VisualizarContenido: function (visualizar) {
        if (visualizar) {
            $('#container_grafico_torta_totales').show();
        }


    }

}
