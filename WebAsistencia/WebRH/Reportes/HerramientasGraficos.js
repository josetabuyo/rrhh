var checks_activos = [1];
var filtro;
var spinner;

var HerramientasGraficos = {

    SettearValoresDeInicio: function (fecha, tipo_busqueda) {
        var _this = this;
        fecha.datepicker();
        fecha.datepicker('option', 'dateFormat', 'dd/mm/yy');
        fecha.datepicker("setDate", new Date());

        $('#btn_salir_menu').click(function () {
            $('#showTop').click();
        });
        $('#btn_armarGrafico').click(function () {
            _this.BuscarDatos(fecha, tipo_busqueda);
        });
        $('#btn_excel').click(function () {
            _this.BuscarExcel(tipo_busqueda);
        });
    },

    IniciarNuevoGrafico: function () {
        localStorage.removeItem("alias");
        localStorage.removeItem("idArea");
        //Para que no rompa la librería por si la página se cargó anteriormente
        if (window.Highcharts) {
            window.Highcharts = null;
        }
    },

    SettearChecks: function (grupo_checks, titulo, tipo_busqueda, check_por_default, nombre_check_por_default, fecha) {
        var _this = this;
        check_por_default.prop('checked', true);
        filtro = nombre_check_por_default;
        grupo_checks.change(function () {
            grupo_checks.each(function () {
                this.checked = false;
                checks_activos = [];
                $('#div_tabla_detalle').hide();
            });
            this.checked = true;

            filtro = this.dataset.filtro;
            var nombre = this.name;
            var lastChar = nombre.substr(nombre.length - 1);
            checks_activos.push(lastChar);

            _this.BuscarDatos(fecha, tipo_busqueda);

            $('#titulo_grafico').html(titulo + this.nextElementSibling.innerHTML);

        });
    },

    OcultarOtrosGraficos: function (tipo_busqueda) {
        if (tipo_busqueda == 1) {
            $('#div_resultados_sueldos').hide();
            $('#div_filtros_sueldos').hide();
            $('#btn_mostrar_resumen').hide();
            $('#div_tabla_sueldo').hide();
            $('#search_sueldo').hide();
            $('#exportar_datos_sueldo').hide();
            $('#tabla_sueldo').hide();
            $('#div_tabla_sueldo_detalle').hide();
            $('#search_detalle_sueldo').hide();
            $('#tabla_sueldo_detalle').hide();
            $('#div_grafico_de_dotacion').show();
            $('#div_filtros').show();
            $('#div_graficos_y_tablas').hide();
            $('#div_filtros_rango_etareo').hide();
        }

    },

    BuscarDatos: function (fecha, tipo_busqueda) {
        var _this = this;
        var buscar = true;
        _this.OcultarOtrosGraficos(tipo_busqueda);
        var tipo = checks_activos.slice(-1)[0];
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

        } else {
            console.log("No soporta localStorage"); // No soporta Storage
        }

        if (buscar) {
            if (tipo_busqueda == 1) {
                GraficoDotacion.BuscarDatos(tipo, fecha.val(), id_area, filtro, alias);
            }
        }
    },

    BuscarExcel: function (tipo_busqueda) {
        if (tipo_busqueda == 1) {
            GraficoDotacion.BuscarExcel();
        }
    }



}
