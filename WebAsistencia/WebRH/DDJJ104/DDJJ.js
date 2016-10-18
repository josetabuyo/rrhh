
var lista_areas_del_usuario;

var ContenedorGrilla;
var mesSeleccionado;
var anioSeleccionado;
var spinner;

Backend.start(function () {
    $(document).ready(function () {
        $('#cmbMeses').hide();
       // spinner = new Spinner({ scale: 2 }).spin($("body")[0]);
        ContenedorGrilla = $("#ContenedorGrilla");
        completarComboMeses();
        //getAreasDDJJ();
    });
});

var completarComboMeses = function () {
    var meses = $('#cmbMeses');
    meses.html("");
    Backend.GetMeses()
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            item = new Option(respuesta[i].NombreMes + ' - ' + respuesta[i].Anio, respuesta[i].Mes + '-' + respuesta[i].Anio);
            $(item).html(respuesta[i].NombreMes + ' - ' + respuesta[i].Anio);
            meses.append(item);
        }
        meses.change(function () {
            ContenedorGrilla.html("");
            $("#ContenedorPersona").empty();

            spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

            mesSeleccionado = parseInt($("#cmbMeses").val().split("-")[0]);
            anioSeleccionado = parseInt($("#cmbMeses").val().split("-")[1]);
            
            getAreasDDJJ(function () {
                ContenedorGrilla.html("");
                DibujarGrillaDDJJ();
                spinner.stop();                 
            });            
        });

        meses.change();
        meses.show();
        
    })
    .onError(function (error, as, asd) {
        alertify.alert(error);
    });
}


var getAreasDDJJ = function (callback) {
    Backend.GetAreasParaDDJJ104(mesSeleccionado, anioSeleccionado, 0)
    .onSuccess(function (respuesta) {
        lista_areas_del_usuario = respuesta;
        callback();
        //completarComboMeses();
    })
    .onError(function (error, as, asd) {
        alertify.alert(error);
    });
}

var DibujarGrillaDDJJ = function () {
    var grilla;

    $("#ContenedorPersona").empty();
    grilla = new Grilla(
        [
            new Columna("Area", { generar: function (un_area) { return un_area.Nombre; } }),
//			new Columna("Cant. Personas", {
//			    generar: function (un_area) {
//			        return contarPersonasDelArea(un_area);
//			    }
//			}),
            new Columna("Estado", {
                generar: function (un_area) {
                    var dec_jurada = un_area.DDJJ; //_.findWhere(un_area.DDJJ, { Mes: mesSeleccionado, Anio: anioSeleccionado });
                    var estado;
                    if (!dec_jurada) estado = 0;
                    else estado = dec_jurada.Estado;
                    return GetDescripcionEstado(estado);
                }
            }),
            new Columna("", new GeneradorBotones()),
		]);

    grilla.CargarObjetos(lista_areas_del_usuario);
    grilla.DibujarEn(ContenedorGrilla);
    BuscardoAreas();


    $("#DivBotonExcel").empty();
    var divBtnExportarExcel = $("#DivBotonExcel")
    botonExcel = $("<input type='button'>");
    botonExcel.val("Exportar a Excel");
    botonExcel.click(function () {
        BuscarExcel(mesSeleccionado, anioSeleccionado, 0);
    });
    divBtnExportarExcel.append(botonExcel);


    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
}

var contarPersonasDelArea = function (un_area) {
    var cant_personas = un_area.Personas.length;
    _.forEach(un_area.AreasInformalesDependientes, function (area_informal) {
        cant_personas += area_informal.Personas.length + 4; ///Sumo 4 por el encabezado de cada Area informal
    })

    return cant_personas;
};

var GeneradorBotones = function () {
    this.generar = function (un_area) {
        var dec_jurada = un_area.DDJJ; //_.findWhere(un_area.DDJJ, { Mes: mesSeleccionado, Anio: anioSeleccionado });
        var estado;
        if (!dec_jurada) estado = 0;
        else estado = dec_jurada.Estado;

        var ContenedorBotones = $("<div>");
        var boton;

        //if (un_area.CantidadPersonas > 0) {

            var botonConsultar;
            botonConsultar = $("<input type='button'>");
            botonConsultar.val("Consultar");
            botonConsultar.click(function () { ConsultarDDJJ(un_area.Id, $("#ContenedorPersona")) });

            ContenedorBotones.append(botonConsultar);

            switch (estado) {
                case 0:
                    boton = $("<input type='button'>");
                    boton.val("Generar e Imprimir");
                    boton.click(function () {
                        Generar_e_ImprimirDDJJ(un_area.Id);
                    });
                    break;
                case 1:
                    boton = $("<input type='button'>");
                    boton.val("Imprimir");
                    boton.click(function () {
                        ImprimirDDJJ(un_area.Id);
                    });
                    break;
            }
        //}

        ContenedorBotones.append(boton);

        return ContenedorBotones;
    };
}


var GetDescripcionEstado = function (estado) {
    switch (estado) {
        case 0:
            return 'Sin Generar'
            break;
        case 1:
            return 'Impresa no recepcionada'
            break;
        case 2:
            return 'Recepcionada'
            break;
    }
};


var DibujarFormularioDDJJ104 = function (un_area) {

    var vista_ddjj_imprimir = $("<div style='page-break-before: always;'>");

    DibujarGrillaPersonas(un_area, vista_ddjj_imprimir, true);

    //    var area;
    //    var mes;
    //    var anio;
    //    var direccion;
    //    var dependencia;
    //    var leyenda;
    //    var nroDDJJ104;
    //    var nroidDDJJ;

    //    botonImprimir = $("<input type='button'>");
    //    botonImprimir.val("Imprimir");
    //    botonImprimir.click(ImprimirPorImpresora());

    //    area = p_listaImprimir_DDJJ[0].Area.Nombre;
    //    mes = p_listaImprimir_DDJJ[0].Mes;
    //    anio = p_listaImprimir_DDJJ[0].Anio;
    //    direccion = p_listaImprimir_DDJJ[0].Area.Direccion;
    //    dependencia = p_listaImprimir_DDJJ[0].Area.Dependencias[0].Nombre;
    //    leyenda = p_listaImprimir_DDJJ[0].LeyendaPorAnio;
    //    nroDDJJ = "NRO DDJJ: " + p_listaImprimir_DDJJ[0].IdDDJJ;
    //    idDDJJ = p_listaImprimir_DDJJ[0].IdDDJJ;


    var w = window.open("../DDJJ104/Impresion/ImpresionDDJJ104.aspx");

    w.onload = function () {
        var pantalla_impresion = $(w.document);
        var t = w.document.getElementById("PanelImpresion");

        var mesddjj = w.document.getElementById("MesDDJJ104");
        var anioddjj = w.document.getElementById("AnioDDJJ104");
        var areaddjj = w.document.getElementById("AreaDDJJ104");
        var areadireccionddjj = w.document.getElementById("AreaDireccionDDJJ104");
        var areadependenciaddjj = w.document.getElementById("AreaDependenciaDDJJ104");
        var leyendaporanioddjj = w.document.getElementById("LeyendaPorAnioDDJJ104");
        var nroDDJJ104 = w.document.getElementById("NroDDJJ104");
        var nroidDDJJ = w.document.getElementById("IdDDJJ104");

        Backend.GetLeyendaAnio(anioSeleccionado)
        .onSuccess(function (respuesta) {
            $(leyendaporanioddjj).html(respuesta);
        })
        .onError(function (error, as, asd) {
            alertify.alert("error al obtener leyenda del año");
        });

        $(areaddjj).html(un_area.Nombre);
        $(mesddjj).html(NombreMes(mesSeleccionado));
        $(anioddjj).html(anioSeleccionado);
        $(areadireccionddjj).html(un_area.Direccion);
        //$(areadependenciaddjj).html(un_area.AreaSuperior.Nombre);
        $(areadireccionddjj).html(un_area.Direccion);
        var ddjj = un_area.DDJJ; //_.findWhere(un_area.DDJJ, { Anio: anioSeleccionado, Mes: mesSeleccionado });
        // pantalla_impresion.find("#nroddjj104").html("DDJJ Nro " + ddjj.Id);
        //pantalla_impresion.find("#nroddjj104").JsBarcode(ddjj.Id, { width: 1, height: 25 });
        //pantalla_impresion.find("#nroddjj104").barcode("DDJJ," + leftPad(ddjj.Id, 4) + anioSeleccionado, "code128", {
        pantalla_impresion.find("#nroddjj104").barcode("FRHDDJJ104," + ddjj.Id, "code128", {
            showHRI: true,
            height: 30,
            width: 100
        });
        $(nroidDDJJ).html(ddjj.Id);
        pantalla_impresion.find("#fecha").html("Buenos Aires " + ConversorDeFechas.deIsoAFechaEnCriollo(ddjj.FechaGeneracion));


        $(t).html(vista_ddjj_imprimir.html());
    }

    // w.document.write("<link  rel='stylesheet' href='../bootstrap/css/bootstrap.css' type='text/css' />");
    // w.document.write("<link  rel='stylesheet' href='../bootstrap/css/bootstrap-responsive.css' type='text/css' />");
    // w.document.write("<link  rel='stylesheet' href='../Estilos/Estilos.css' type='text/css'  />");
    //    w.document.write("<div class='div_print'><br/>Area: " + area + "<br/><br/></div>");
    // w.document.write(ContenedorPlanilla.html());
    // w.print();
    //w.close();
}

//FUNCION QUE COMPLETAS CON 0 A LA IZQUIERDA
//function leftPad(number, targetLength) {
//    var output = number + '';
//    while (output.length < targetLength) {
//        output = '0' + output;
//    }
//    return output;
//}

var ConsultarDDJJ = function (idArea) {

    $("#ContenedorPersona").empty();
    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    Backend.GetAreasParaDDJJ104(mesSeleccionado, anioSeleccionado, idArea)
    .onSuccess(function (respuesta) {
        DibujarGrillaPersonas(respuesta[0], $("#ContenedorPersona", false));
        spinner.stop();
    })
    .onError(function (error, as, asd) {
        alertify.alert(error);
    });

    

};

//var GenerarDDJJ = function (idArea) {
//    Backend.GenerarDDJJ104(idArea, mesSeleccionado, anioSeleccionado)
//    .onSuccess(function (respuesta) {
//        if (respuesta) {
//            alertify.alert("Se genero correctamente");
//            ContenedorGrilla.html("");
//            getAreasDDJJ();
//        }
//    })
//    .onError(function (error, as, asd) {
//        alertify.alert(error);
//    });
//};

var Generar_e_ImprimirDDJJ = function (idArea) {

    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    //Backend.GetAreasParaDDJJ104(mesSeleccionado, anioSeleccionado, idArea)
    //.onSuccess(function (respuesta) {

    Backend.GenerarDDJJ104(idArea, mesSeleccionado, anioSeleccionado)
        .onSuccess(function (ddjj) {
            if (ddjj) {
                //un_area.DDJJ.push(ddjj);
                //respuesta[0].DDJJ = ddjj;
                ImprimirDDJJ(idArea);

                ContenedorGrilla.html("");
                $("#ContenedorPersona").empty();

                
                getAreasDDJJ(function () {
                    ContenedorGrilla.html("");
                    DibujarGrillaDDJJ();
                    spinner.stop();
                });
            }
        })
        .onError(function (error, as, asd) {
        alertify.alert(error);
        });
    //})
    //.onError(function (error, as, asd) {
    //    alertify.alert(error);
    //});
};


var ImprimirDDJJ = function (idArea) {
    Backend.GetAreasParaDDJJ104(mesSeleccionado, anioSeleccionado, idArea)
    .onSuccess(function (respuesta) {
        DibujarFormularioDDJJ104(respuesta[0]);
    })
    .onError(function (error, as, asd) {
        alertify.alert(error);
    });
};


var DibujarGrillaPersonas = function (un_area, contenedor_grilla, es_impresion) {
    //Maximo por hoja solo con el 1er encabezado entran 56 personas.
    //Si hay otra area entran 52 personas porque el encabezado cuenta 4 personas mas.
    var personas_pagina_1 = 43; //40;
    var personas_pagina_mayor_que_1 = 62; //60;
    var personas_calculo_por_hoja = 56; //esto es porque cuento los espacios para completar la hoja
    var cantidad_de_persona_por_hoja = personas_pagina_1;
    var cantidad_de_filas_por_cabecera = 4;
    var contador_de_registros_por_pagina = 0;
    var contador_de_paginas = 1;

    var cantidad_total_de_personas = contarPersonasDelArea(un_area);
    var cantidad_restantes_de_personas = cantidad_total_de_personas - cantidad_de_persona_por_hoja;
    var cantidad_total_de_hojas = Math.ceil(cantidad_restantes_de_personas / personas_calculo_por_hoja) +1;


    //IMPRIMIR AREAS FORMALES
    contenedor_grilla.empty();
    contenedor_grilla.append($("<br/>"));

    if (es_impresion) {
        contenedor_grilla.append($("<div class='nombre_area_informal'><b>" + un_area.Nombre + "<b/>" + " (Pag: " + contador_de_paginas + "/" + cantidad_total_de_hojas + ")</div>"));
    } else {
        contenedor_grilla.append($("<div class='nombre_area_informal'><b>" + un_area.Nombre + "<b/></div>"));
    }

    grilla = new Grilla(
        [
            new Columna("APELLIDO Y NOMBRE", { generar: function (una_persona) { return una_persona.Apellido + ", " + una_persona.Nombre; } }),
			new Columna("CUIL/CUIT", { generar: function (una_persona) { return una_persona.Cuit; } }),
            new Columna("ESCALAFON O MODALIDAD DE CONTRATACION", { generar: function (una_persona) { return una_persona.Categoria.split("#")[1]; } }),
            new Columna("NIVEL O CATEGORIA", { generar: function (una_persona) { return una_persona.Categoria.split("#")[0]; } }),
		]);

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

    //IMPRIMIR AREAS INFORMALES
    un_area.AreasInformalesDependientes.forEach(function (area_informal) {

        if ((contador_de_registros_por_pagina + cantidad_de_filas_por_cabecera) >= cantidad_de_persona_por_hoja) {
            contador_de_registros_por_pagina = contador_de_registros_por_pagina + cantidad_de_filas_por_cabecera;
            contenedor_grilla.append($("<br />"));
            contenedor_grilla.append($("<br />"));
        }
        else {
            contenedor_grilla.append($("<br/>"));
            contenedor_grilla.append($("<div class='nombre_area_informal'><b>" + area_informal.Nombre + "<b/></div>"));
            var grilla_area_informal = new Grilla(
            [
                new Columna("APELLIDO Y NOMBRE", { generar: function (una_persona) { return una_persona.Apellido + ", " + una_persona.Nombre; } }),
			    new Columna("CUIL/CUIT", { generar: function (una_persona) { return una_persona.Cuit; } }),
                new Columna("ESCALAFON O MODALIDAD DE CONTRATACION", { generar: function (una_persona) { return una_persona.Categoria.split("#")[1]; } }),
                new Columna("NIVEL O CATEGORIA", { generar: function (una_persona) { return una_persona.Categoria.split("#")[0]; } }),
		    ]);
        }

        if (es_impresion) {
            contador_de_registros_por_pagina = contador_de_registros_por_pagina + cantidad_de_filas_por_cabecera;
            if (area_informal.Personas.length > 0) {
                for (var i = 0; i < area_informal.Personas.length; i++) {

                    //CONTROLO PARA HACER EL SALTO DE PAGINA
                    if (contador_de_registros_por_pagina >= cantidad_de_persona_por_hoja) {
                        cantidad_de_persona_por_hoja = personas_pagina_mayor_que_1;
                        contador_de_paginas = contador_de_paginas + 1;
                        if (grilla_area_informal != null) {
                            grilla_area_informal.DibujarEn(contenedor_grilla);
                        }
                        contenedor_grilla.append($("<br />"));
                        contenedor_grilla.append($("<br />"));
                        contenedor_grilla.append($("<br />"));
                        contenedor_grilla.append($("<br />"));
                        //contenedor_grilla.append($("<br />"));
                        //contenedor_grilla.append($("<br/>"));

                        contenedor_grilla.append($("<div class='nombre_area_informal'><b>" + area_informal.Nombre + " (continuación)" + "<b/>" + "(Pag: " + contador_de_paginas + "/" + cantidad_total_de_hojas + ")</div>"));
                        grilla_area_informal = new Grilla(
                    [
                        new Columna("APELLIDO Y NOMBRE", { generar: function (una_persona) { return una_persona.Apellido + ", " + una_persona.Nombre; } }),
			            new Columna("CUIL/CUIT", { generar: function (una_persona) { return una_persona.Cuit; } }),
                        new Columna("ESCALAFON O MODALIDAD DE CONTRATACION", { generar: function (una_persona) { return una_persona.Categoria.split("#")[1]; } }),
                        new Columna("NIVEL O CATEGORIA", { generar: function (una_persona) { return una_persona.Categoria.split("#")[0]; } }),
		            ]);
                        contador_de_registros_por_pagina = cantidad_de_filas_por_cabecera;
                    }
                    //FIN SALTO DE PAGINA

                    var obj = area_informal.Personas[i];
                    grilla_area_informal.CargarObjeto(obj);
                    contador_de_registros_por_pagina = contador_de_registros_por_pagina + 1;
                }
            }
        }

        else {
            grilla_area_informal.CargarObjetos(area_informal.Personas);
        }
        grilla_area_informal.DibujarEn(contenedor_grilla);
        grilla_area_informal.SetOnRowClickEventHandler(function () {
            return true;
        });
    });
}


function BuscardoAreas() {

    var options = {
        valueNames: ['Area', 'Estado']
    };
    var featureList = new List('grilla', options);
};


function NombreMes(num) {
    switch (num) {
        case 1: return "enero";
        case 2: return "febrero";
        case 3: return "marzo";
        case 4: return "abril";
        case 5: return "mayo";
        case 6: return "junio";
        case 7: return "julio";
        case 8: return "agosto";
        case 9: return "septiembre";
        case 10: return "octubre";
        case 11: return "noviembre";
        case 12: return "diciembre";
    }

    return "";
}



 function BuscarExcel (mesSeleccionado, anioSeleccionado, idArea) {
        var _this = this;

        if (mesSeleccionado == null) {
            return;
        }

        var resultado = Backend.ejecutarSincronico("ExcelDDJJ104", [{ mes: parseInt(mesSeleccionado), anio: parseInt(anioSeleccionado), id_area: parseInt(idArea)}]);

        if (resultado.length > 0) {

            var a = window.document.createElement('a');

            a.href = "data:application/vnd.ms-excel;base64," + resultado;

            a.download = "Areas_DDJJ104_" + mesSeleccionado + anioSeleccionado + "_.xlsx";
            

            // Append anchor to body.
            document.body.appendChild(a)
            a.click();


            // Remove anchor from body
            document.body.removeChild(a)


        }
        //   _this.GraficoYTabla(tipo, fecha, id_area, "Dotación por Nivel del Área aaa", "container_grafico_torta_totales", "div_tabla_resultado_totales", "tabla_resultado_totales");
    }
