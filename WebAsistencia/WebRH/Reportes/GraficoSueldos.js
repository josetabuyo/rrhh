var checks_activos = [8];
var filtro;
var spinner;


var GraficoSueldos = {
    Inicializar: function () {
        var _this = this;

        $('#txt_fecha_desde_sueldo').datepicker();
        $('#txt_fecha_desde_sueldo').datepicker('option', 'dateFormat', 'dd/mm/yy');
        $('#txt_fecha_desde_sueldo').datepicker("setDate", new Date());

        localStorage.removeItem("alias");
        localStorage.removeItem("idArea");
        $('#cb_SinAgrupar').prop('checked', true);

        $('#btn_buscar_sueldo').click(function () {
            _this.BuscarDatos();

        });

        $('#btn_mostrar_resumen').click(function () {
            $('#search_sueldo_detalle').hide();
            $('#btn_mostrar_resumen').hide();
            $('#tabla_sueldo_detalle').hide();
            $("#search_detalle_sueldo").hide();
            $('#div_tabla_sueldo').show();

        });

        $('.filtros_sueldo').change(function () {
            $('.filtros_sueldo').each(function () {
                this.checked = false;
                checks_activos = [];
            });
            $('#tabla_sueldo_detalle').hide();
            $('#btn_mostrar_resumen').hide();
            $('#div_tabla_sueldo_detalle').hide();

            this.checked = true;

            filtro = this.dataset.filtro;
            var nombre = this.name;
            var lastChar = nombre.substr(nombre.length - 1);
            checks_activos.push(lastChar);

            _this.BuscarDatos();

            $('#titulo_grafico').html("Dotación por " + this.nextElementSibling.innerHTML);

        });

    },

    FormatearNumero: function (numero) {
        if (numero == null) {
            return "";
        }
        var _this = this;
        if (numero == 0) return "";
        return '$' + _this.FormatearConPunto(numero.toFixed(2).toString().replace(".", ","));
    },

    FormatearABlanco: function (numero) {
        if (numero == 0) return "";
        return numero;
    },

    FormatearConPunto: function (n) {

        if (n == null) {
            return "";
        }

        n = n.toString()
        while (true) {
            var n2 = n.replace(/(\d)(\d{3})($|,|\.)/g, '$1.$2$3')
            if (n == n2) break
            n = n2
        }
        return n;
    },

    BuscarDatos: function () {
        var _this = this;
        var buscar = true;
        $('#div_resultados_sueldos').show();
        $('#div_filtros_sueldos').show();

        $('#div_tabla_sueldo').show();
        $('#search_sueldo').show();
        $('#exportar_datos_sueldo').show();
        $('#tabla_sueldo').show();


        var fecha = $('#txt_fecha_desde_sueldo').val();
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
                _this.GraficoYTabla(fecha, id_area, $("#chk_incluir_dependencias").is(":checked"), "div_tabla_sueldo", "tabla_sueldo");
            }

        } else {
            console.log("No soporta localStorage"); // No soporta Storage
        }

    },

    GraficoYTabla: function (fecha, id_area, incluir_dependencias, div_tabla, tabla) {
        var _this = this;
        $('#div_resultados_sueldos').show();
        $('#search_sueldo').show();
        $('#exportar_datos_sueldo').show();
        $("#search_detalle_sueldo").hide();
        var spinner = new Spinner({ scale: 3 });
        var tipo = checks_activos.slice(-1)[0];
        spinner.spin($("html")[0]);

        Backend.GetReporteSueldosPorArea({ tipo: parseInt(tipo), fecha: fecha, id_area: parseInt(id_area), incluir_dependencias: incluir_dependencias })
            .onSuccess(function (grafico) {
                var sueldos = grafico.tabla_detalle;
                var resultado = grafico.tabla_resumen;
                var tabla_detalle = grafico.tabla_detalle;
                if (sueldos.length > 0) {
                    // _this.VisualizarContenido(true);
                    _this.DibujarTabla(resultado, div_tabla, tabla, tabla_detalle);
                    //_this.DibujarTablaDetalle(sueldos, div_tabla, tabla);
                    _this.BuscadorDeTabla();

                } else {
                    _this.VisualizarContenido(false);
                    $("#exportar_datos_sueldo").hide();
                    alertify.error("No hay Personal en el Área seleccionada para la generación del Gráfico");
                    _this.DibujarTabla(resultado, div_tabla, tabla, tabla_detalle);
                }
                spinner.stop();
            })
            .onError(function () {
                alertify.error("No hay Personal en el Área seleccionada para la generación del Gráfico");
                spinner.stop();
            })
    },

    DibujarTabla: function (resultado, div_tabla, tabla, tabla_detalle) {
        var _this = this;
        $("#" + tabla).empty();
        $("#search_sueldo").show();


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
        columnas.push(new Columna("SumatoriaSueldo", { generar: function (un_registro) { return _this.FormatearNumero(un_registro.SumatoriaSueldo) } }));
        columnas.push(new Columna("PromedioSueldo", { generar: function (un_registro) { return _this.FormatearNumero(un_registro.PrimedioSueldo) } }));
        columnas.push(new Columna("MedianaSueldo", { generar: function (un_registro) { return _this.FormatearNumero(un_registro.MedianaSueldo) } }));
        columnas.push(new Columna("SumatoriaExtras", { generar: function (un_registro) { return _this.FormatearABlanco(un_registro.SumatoriaExtras) } }));
        columnas.push(new Columna("PrimedioExtras", { generar: function (un_registro) { return _this.FormatearABlanco(parseFloat(un_registro.PrimedioExtras).toFixed(2)) } }));
        columnas.push(new Columna("MedianaExtras", { generar: function (un_registro) { return _this.FormatearABlanco(un_registro.MedianaExtras) } }));
        columnas.push(new Columna('Detalle', {
            generar: function (un_registro) {
                var btn_accion = $('<a>');
                var img = $('<img>');
                img.attr('src', '../Imagenes/detalle.png');
                img.attr('width', '15px');
                img.attr('height', '15px');
                btn_accion.append(img);
                btn_accion.click(function () {
                    $('#div_tabla_sueldo_detalle').show();
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
        $("#search_detalle_sueldo").show();
        var divGrilla = $('#' + tabla);
        var tabla = resultado;

        var columnas = [];

        columnas.push(new Columna("Area", { generar: function (un_registro) { return un_registro.Area } }));
        columnas.push(new Columna("Documento", { generar: function (un_registro) { return _this.FormatearConPunto(un_registro.NroDocumento); } }));
        columnas.push(new Columna("Apellido_Nombre", { generar: function (un_registro) { return (un_registro.Apellido + ", " + un_registro.Nombre) } }));
        //columnas.push(new Columna("Nombre", { generar: function (un_registro) { return un_registro.Nombre } }));
        columnas.push(new Columna("SueldoBruto", { generar: function (un_registro) { return _this.FormatearNumero(un_registro.SueldoBruto); } }));
        columnas.push(new Columna("SueldoNeto", { generar: function (un_registro) { return _this.FormatearNumero(un_registro.SueldoNeto); } }));
        columnas.push(new Columna("ExtrasBruto", { generar: function (un_registro) { return _this.FormatearNumero(un_registro.ExtrasBruto); } }));
        columnas.push(new Columna("ExtrasNeto", { generar: function (un_registro) { return _this.FormatearNumero(un_registro.ExtrasNeto); } }));
        //columnas.push(new Columna("SAC Bruto", { generar: function (un_registro) { return un_registro.SACBruto } }));
        //columnas.push(new Columna("SAC Neto", { generar: function (un_registro) { return un_registro.SACNeto } }));
        columnas.push(new Columna("HsSimples", { generar: function (un_registro) { return _this.FormatearABlanco(un_registro.HsSimples); } }));
        columnas.push(new Columna("Hs50%", { generar: function (un_registro) { return _this.FormatearABlanco(un_registro.Hs50); } }));
        columnas.push(new Columna("Hs100%", { generar: function (un_registro) { return _this.FormatearABlanco(un_registro.Hs100); } }));
        columnas.push(new Columna("Comidas", { generar: function (un_registro) { return _this.FormatearABlanco(un_registro.Comidas); } }));
        columnas.push(new Columna("UR", { generar: function (un_registro) { return _this.FormatearABlanco(un_registro.UnidadRetributiva); } }));
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
        $('#search_sueldo_detalle').show();
        $('#btn_mostrar_resumen').show();
        $('#div_tabla_sueldo').hide();



        if (tabla.length > 0) {
            var titulo = "Tabla de Toda la Dotación del Área";
            if (criterio == "Total") {
                tabla_final = tabla;
            } else {
                switch (parseInt(checks_activos[0])) {
                    case 8:
                        titulo = "Dotación de " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].Area == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                    case 9:
                        titulo = "Dotación de " + criterio;
                        for (var i = 0; i < tabla.length; i++) {
                            if (tabla[i].NombresubSecretaria == criterio) {
                                tabla_final.push(tabla[i]);
                            }
                        }
                        break;
                    case 0:
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
            $('#lb_titulo_tabla_sueldo_detalle').text(titulo);
            _this.VisualizarContenido(true);
            $("#div_tabla_sueldo_detalle").show();
            $("#tabla_sueldo_detalle").show();
            _this.DibujarTablaDetalle(tabla_final, "div_tabla_sueldo_detalle", "tabla_sueldo_detalle");

        } else {
            _this.VisualizarContenido(false);
            alertify.error("No hay Reportes para los parámetros seleccionados");
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
            a.download = "RECIBOS_DE_SUELDO_" + fecha + "_.xlsx";

            document.body.appendChild(a)
            a.click();
            document.body.removeChild(a)


        }

    }

}
