var PaginaReporteAlumnos = function (options) {
    this.o = options;
    var _this = this;
    //    var titulo_fechadesde;
    //    var titulo_fechahasta;


    //***********************COMBOS***********************//
    this.o.cmbCombo.change(function (e) {

        respuesta = JSON.parse($('#alumnosJSONSeleccionados').val());
        busqueda = $("#accion").val();
        var idSeleccionado = _this.o.cmbCombo.find('option:selected').val();

        if (idSeleccionado == -1) {
            queryResult = respuesta;
        } else {

            if (busqueda == "modalidad") {
                var queryResult = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.Modalidad.Id == idSeleccionado }).ToArray();
            }
            else if (busqueda == "organismo") {

                var queryResult = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.Organismo == idSeleccionado }).ToArray();
            }
            else if (busqueda == "ciclo") {

                var queryResult = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.CicloCursado == idSeleccionado }).ToArray();
            }


        };
        _this.o.planillaAlumnosDisponibles.BorrarContenido();
        ArmarGrilla(queryResult);

    });

    this.o.planillaAlumnosDisponibles = new Grilla(
        [
            new Columna("Documento", { generar: function (un_alumno) { return un_alumno.Documento; } }),
			new Columna("Nombre", { generar: function (un_alumno) { return un_alumno.Nombre; } }),
			new Columna("Apellido", { generar: function (un_alumno) { return un_alumno.Apellido; } }),
			new Columna("Modalidad", { generar: function (un_alumno) { return un_alumno.Modalidad.Descripcion; } })
		]);

};


//***********************BÚSQUEDAS***********************//
PaginaReporteAlumnos.prototype.PrimeraBusqueda = function () {
    _this = this;
    var respuesta = _this.o.alumnos;
    Buscar(_this.o.tipoBusqueda);
};

//PaginaReporteAlumnos.prototype.
BuscarPorAlumnos = function () {

    busqueda = $("#accion").val();
    fechadesde = FechaDesde($("#idFechaDesde").val());
    fechahasta = FechaHasta($("#idFechaHasta").val());

    titulo_fechadesde = TituloFechaDesde(fechadesde);
    titulo_fechahasta = TituloFechaHasta(fechahasta);


    var data_post = JSON.stringify({
        fecha_desde: fechadesde,
        fecha_hasta: fechahasta
    });

    $.ajax({
        url: "../AjaxWS.asmx/ReporteAlumnos",
        type: "POST",
        data: data_post,
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        success: function (respuestaJson) {
            var respuesta = JSON.parse(respuestaJson.d);
            $("#alumnosJSONSeleccionados").val(respuestaJson.d);
            ArmarGrilla(respuesta);

            if (busqueda == "modalidad") {
            ArmarGraficoPorModalidad(respuesta, fechadesde, fechahasta);
            }
            else if (busqueda == "organismo"){
             ArmarGraficoPorOrganismo(respuesta, fechadesde, fechahasta);
         }
         else if (busqueda == "ciclo") {
             ArmarGraficoPorCiclo(respuesta, fechadesde, fechahasta);
            }
            
           
        },

        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alertify.alert(errorThrown);
        }
    });
};


var Buscar = function (busqueda) {

    if (busqueda == "modalidad") {

        BuscarPorAlumnos();

    } else if (busqueda == "organismo") {

        BuscarPorAlumnos();

    } else if (busqueda == "ciclo") {

        BuscarPorAlumnos();

    } else if (busqueda == "materia") {



    }

}

//***********************ARMADO DE GRÁFICOS***********************//
var ArmarGraficoPorOrganismo = function (respuesta, fechadesde, fechahasta) {

    //1 - Obtengo Valores para el Gráfico
    var nro_total = respuesta.length;
    var nro_mds = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.Organismo == 1 }).ToArray().length;
    var nro_msal = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.Organismo == 2 }).ToArray().length;
    var nro_fines = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.Organismo == 3 }).ToArray().length;

    titulo_accion = 'Distribución de los Alumnos por Organismo - Total: ';
    titulo = titulo_accion + nro_total + "<br/>" + TituloFechaDesde(fechadesde) + TituloFechaHasta(fechahasta);


    if (nro_total == 0) {

        GraficoVacio(titulo);
    }
    else {
        GraficoPorOrganismo(titulo, nro_mds, nro_msal, nro_fines);
    }

};

var ArmarGraficoPorModalidad = function (respuesta, fechadesde, fechahasta) {

    //1 - Obtengo Valores para el Gráfico
    var nro_total = respuesta.length;
    var nro_cens = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.Modalidad.Id == 1 }).ToArray().length;
    var nro_puro = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.Modalidad.Id == 2 }).ToArray().length;
    

    titulo_accion = 'Distribución de los Alumnos por Modalidad - Total: ';
    titulo = titulo_accion + nro_total + "<br/>" + TituloFechaDesde(fechadesde) + TituloFechaHasta(fechahasta);


    if (nro_total == 0) {

        GraficoVacio(titulo);
    }
    else {
        GraficoPorModalidad(titulo, nro_cens, nro_puro);
    }

};


var ArmarGraficoPorCiclo = function (respuesta, fechadesde, fechahasta) {

    //1 - Obtengo Valores para el Gráfico
    var nro_total = respuesta.length;
    var nro_sinciclo = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.CicloCursado == 1 }).ToArray().length;
    var nro_primero = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.CicloCursado == 2 }).ToArray().length;
    var nro_segundo = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.CicloCursado == 3 }).ToArray().length;
    var nro_tercero = Enumerable.From(respuesta)
                                          .Where(function (x) { return x.CicloCursado == 4 }).ToArray().length;

    titulo_accion = 'Distribución de los Alumnos por Ciclo - Total: ';
    titulo = titulo_accion + nro_total + "<br/>" + TituloFechaDesde(fechadesde) + TituloFechaHasta(fechahasta);


    if (nro_total == 0) {

        GraficoVacio(titulo);
    }
    else {
        GraficoPorCiclo(titulo, nro_sinciclo, nro_primero, nro_segundo, nro_tercero);
    }

};


//***********************GRÁFICOS***********************//
var GraficoVacio = function (titulo) {

    //2 - Armo el Dibujo con los Valores
    $('#dibujo_grafico').highcharts({
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false
        },
        title: {
            text: titulo
        },
        series: [{
            type: 'pie',
            name: 'Porcentaje de Alumnos',
            data: []
        }]
    });
};

var GraficoPorOrganismo = function (titulo, nro_mds, nro_msal, nro_fines) {

    //2 - Armo el Dibujo con los Valores
    $('#dibujo_grafico').highcharts({
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false
        },
        title: {
            text: titulo
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
                    ['Fines: Cantidad: ' + nro_fines + ' - Porcentaje', nro_fines],
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

};


var GraficoPorModalidad = function (titulo, nro_cens, nro_puro) {

    //2 - Armo el Dibujo con los Valores
    $('#dibujo_grafico').highcharts({
        chart: {
            plotBackgroundColor: null,
            plotBorderWidth: null,
            plotShadow: false
        },
        title: {
            text: titulo
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
                    ['Puro: ' + nro_puro + ' - Porcentaje', nro_puro],
                        {
                          name: 'CENS: ' + nro_cens + ' - Porcentaje',
                          y: nro_cens,
                          sliced: true,
                          selected: true
                        },
                 ]
        }]
    });

};


 var GraficoPorCiclo = function (titulo, nro_sinciclo, nro_primero, nro_segundo, nro_tercero) {

              //2 - Armo el Dibujo con los Valores
              $('#dibujo_grafico').highcharts({
                  chart: {
                      plotBackgroundColor: null,
                      plotBorderWidth: null,
                      plotShadow: false
                  },
                  title: {
                      text: titulo
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
                    ['Sin Ciclo: Cantidad: ' + nro_sinciclo + ' - Porcentaje', nro_sinciclo],
                    ['1°: ' + nro_primero + ' - Porcentaje', nro_primero],
                     ['2°: ' + nro_segundo + ' - Porcentaje', nro_segundo],
                        {
                            name: '3°: ' + nro_tercero + ' - Porcentaje',
                            y: nro_tercero,
                            sliced: true,
                            selected: true
                        },
                 ]
                  }]
              });

          };

//***********************ARMADO DE GRILLA***********************//
var ArmarGrilla = function (respuesta) {

    BorrarContenido();
    _this.o.planillaAlumnosDisponibles.BorrarContenido();
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
};

var BorrarContenido = function () {
    //Borro la Grilla para construirla de nuevo con los nuevos datos de la BD
    $('#grillaAlumnosDisponibles').html('');

    //Genero nuevamente el campo de búsqueda
    $('#grillaAlumnosDisponibles').html(
                                            '<div class="input-append" style="clear:both;">' +
                                            '<input type="text" id="search" class="search" style="float:right; margin-bottom:10px;" placeholder="Filtrar Alumnos" /> ' +
                                            '</div>'
                                            );

}

//***********************PARÁMETROS***********************//
var FechaDesde = function (fechadesde) {

    if (fechadesde == '') {
        fechadesde = FechaMinima();
    }

    return fechadesde;
};

var FechaHasta = function (fechahasta) {
    if (fechahasta == '') {
        fechahasta = FechaMaxima();
    }
    return fechahasta;

};

var TituloFechaDesde = function (fechadesde) {

    var titulo_fechadesde = " Desde: " + fechadesde;
    if (fechadesde == FechaMinima()) {
        titulo_fechadesde = "";
    }
    return titulo_fechadesde;

};

var TituloFechaHasta = function (fechahasta) {

    var titulo_fechahasta = " Hasta: " + fechahasta;
    if (fechahasta == FechaMaxima()) {
        titulo_fechahasta = "";
    }
    return titulo_fechahasta;

};

var FechaMinima = function () {
    return '01/01/1900'
};

var FechaMaxima = function () {
    return '31/12/9999'
};