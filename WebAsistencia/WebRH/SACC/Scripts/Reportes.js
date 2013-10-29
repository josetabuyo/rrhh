var PaginaReporteAlumnos = function (options) {
    this.o = options;
    var _this = this;

    this.o.botonModalidad.click(function () {
        _this.BuscarPorModalidad();
    });

    this.o.cmbCombo.change(function (e) {
        var idSeleccionado = _this.o.cmbCombo.find('option:selected').val();

        if (idSeleccionado == -1) {
            queryResult = _this.o.alumnos;
        } else {


            var queryResult = Enumerable.From(_this.o.alumnos)
                                          .Where(function (x) { return x.Organismo == idSeleccionado }).ToArray();
        };


        _this.o.planillaAlumnosDisponibles.BorrarContenido();
        _this.o.planillaAlumnosDisponibles.CargarObjetos(queryResult);
        _this.o.planillaAlumnosDisponibles.DibujarEn(_this.o.contenedorAlumnosDisponibles);

        //Estilos para ver coloreada la grilla en Internet Explorer
        $("tbody tr:even").css('background-color', '#E6E6FA');
        $("tbody tr:odd").css('background-color', '#9CB3D6 ');


        var options = {
            valueNames: ['Documento', 'Nombre', 'Apellido', 'Modalidad']
        };


        var featureListAlumnosDisponibles = new List('grillaAlumnosDisponibles', options);

    });

    this.o.planillaAlumnosDisponibles = new Grilla(
        [
            new Columna("Documento", { generar: function (un_alumno) { return un_alumno.Documento; } }),
			new Columna("Nombre", { generar: function (un_alumno) { return un_alumno.Nombre; } }),
			new Columna("Apellido", { generar: function (un_alumno) { return un_alumno.Apellido; } }),
			new Columna("Modalidad", { generar: function (un_alumno) { return un_alumno.Modalidad.Descripcion; } })
		]);

};


PaginaReporteAlumnos.prototype.BuscarPorModalidad = function () {
    var data_post = JSON.stringify({
        fecha_desde: $("#idFechaDesde").val(),
        fecha_hasta: $("#idFechaHasta").val()
    });
    _this = this;
    $.ajax({
        url: "../AjaxWS.asmx/ReporteAlumnosDeCursosConFecha",
        type: "POST",
        data: data_post,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);

            _this.o.planillaAlumnosDisponibles.AgregarEstilo("tabla_macc");
            _this.o.planillaAlumnosDisponibles.CargarObjetos(respuesta);
            _this.o.planillaAlumnosDisponibles.DibujarEn(_this.o.contenedorAlumnosDisponibles);

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
};



PaginaReporteAlumnos.prototype.BuscarPorOrganismo = function () {

    _this = this;
    $.ajax({
        url: "../AjaxWS.asmx/ReporteAlumnosPorOrganismo",
        type: "POST",
        data: "",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);

            _this.o.planillaAlumnosDisponibles.AgregarEstilo("tabla_macc");
            _this.o.planillaAlumnosDisponibles.CargarObjetos(respuesta);
            _this.o.planillaAlumnosDisponibles.DibujarEn(_this.o.contenedorAlumnosDisponibles);

            //Estilos para ver coloreada la grilla en Internet Explorer
            $("tbody tr:even").css('background-color', '#E6E6FA');
            $("tbody tr:odd").css('background-color', '#9CB3D6 ');


            var options = {
                valueNames: ['Documento', 'Nombre', 'Apellido', 'Modalidad']
            };


            var featureListAlumnosDisponibles = new List('grillaAlumnosDisponibles', options);

            //GRAFICO
            //1 - Obtengo Valores para el Gráfico
            var nro_total = respuesta.length;
            var nro_mds = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.Organismo == 1 }).ToArray().length;
            var nro_msal = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.Organismo == 2 }).ToArray().length;
            var nro_fines = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.Organismo == 3 }).ToArray().length;
            
            //2 - Armo el Dibujo con los Valores
            $('#dibujo_grafico').highcharts({
                    chart: {
                        plotBackgroundColor: null,
                        plotBorderWidth: null,
                        plotShadow: false
                    },
                    title: {
                        text: 'Distribución de los Alumnos por Organismo - Total: ' + nro_total
                    },
                    tooltip: {
                        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
                    },
                    plotOptions: {
                        pie: {
                            allowPointSelect: true,
                            cursor: 'pointer',
                            dataLabels: {
                                enabled: true,
                                color: '#000000',
                                connectorColor: '#000000',
                                format: '{point.name}: {point.percentage:.1f} %'
                            }
                        }
                    },
                    series: [{
                        type: 'pie',
                        name: 'Porcentaje de Alumnos',
                        data: [
                                 ['Fines: Cantidad: ' + nro_fines + ' - Porcentaje' , nro_fines],
                                 ['MSAL: ' + nro_msal + ' - Porcentaje', nro_msal],
                                {
                                    name: 'MDS: ' + nro_mds + ' - Porcentaje',
                                    y: nro_mds,
                                    sliced: true,
                                    selected: true
                                },
                            ]
                        }]
                });
                    },

        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
};
