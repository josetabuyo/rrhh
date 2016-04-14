var GraficoSueldos = {
    Inicializar: function () {
        var _this = this;

        $('#txt_fecha_desde').datepicker();
        $('#txt_fecha_desde').datepicker('option', 'dateFormat', 'dd/mm/yy');
        $('#txt_fecha_desde').datepicker("setDate", new Date());

        localStorage.removeItem("alias");
        localStorage.removeItem("idArea");

        $('#btn_buscar_sueldo').click(function () {
            _this.BuscarDatos();
        });      
    },


    BuscarDatos: function () {
        var _this = this;
        var buscar = true;

        var fecha = $('#txt_fecha_desde_sueldo').val();
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
                _this.GraficoYTabla(fecha, id_area, $("#chk_incluir_dependencias").is(":checked"), "div_tabla_detalle_sueldo", "tabla_detalle_sueldo");
            }

        } else {
            console.log("No soporta localStorage"); // No soporta Storage
        }

    },

    GraficoYTabla: function (fecha, id_area, incluir_dependencias, div_tabla, tabla) {
        var _this = this;
        $('#div_resultados_sueldos').show();
        var sueldos = Backend.ejecutarSincronico("GetReporteSueldosPorArea", [fecha, parseInt(id_area), incluir_dependencias]);
        if (sueldos != null) {
           // _this.VisualizarContenido(true);
            _this.DibujarTablaDetalle(sueldos, div_tabla, tabla);
            _this.BuscadorDeTabla();

        } else {
            _this.VisualizarContenido(false);
            alertify.error("No hay Personal en el Área seleccionada para la generación del Gráfico");
        }
    },
   

    DibujarTablaDetalle: function (resultado, div_tabla, tabla) {
        var _this = this;
        $("#" + tabla).empty();
        $("#search").show();
        $("#exportar_datos").show();
        var divGrilla = $('#' + tabla);
        var tabla = resultado;

        var columnas = [];

        columnas.push(new Columna("Sueldo Bruto", { generar: function (un_registro) { return un_registro.SueldoBruto } }));
        columnas.push(new Columna("Sueldo Neto", { generar: function (un_registro) { return un_registro.SueldoNeto } }));
        columnas.push(new Columna("Xtras Bruto", { generar: function (un_registro) { return un_registro.XtrasBruto } }));
        columnas.push(new Columna("Xtras Neto", { generar: function (un_registro) { return un_registro.XtrasNeto } }));
        columnas.push(new Columna("SAC Bruto", { generar: function (un_registro) { return un_registro.SACBruto } }));
        columnas.push(new Columna("SAC Neto", { generar: function (un_registro) { return un_registro.SACNeto } }));
        columnas.push(new Columna("Hs Simples", { generar: function (un_registro) { return un_registro.HsSimples } }));
        columnas.push(new Columna("Hs 50%", { generar: function (un_registro) { return un_registro.Hs50 } }));
        columnas.push(new Columna("Hs 100%", { generar: function (un_registro) { return un_registro.Hs100 } }));
        columnas.push(new Columna("Comidas", { generar: function (un_registro) { return un_registro.Comidas } }));
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
    
    BuscadorDeTablaDetalle: function () {

        var options = {
            valueNames: ['Sueldo Bruto', 'Sueldo Neto', 'Xtras Bruto', 'Xtras Neto', 'SAC Bruto', 'SAC Neto', 'Hs Simples', 'Hs 50%', 'Hs 100%', 'Comidas']
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
//                case "6":
//                    a.download = "DOTACION_RANGO_ETARIO_" + fecha + "_.xlsx";

                    break;

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
    }

}
