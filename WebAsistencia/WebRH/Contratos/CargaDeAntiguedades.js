var botonSeleccionado;
var ContenedorGrilla;
var lista_de_serv_publico;
var lista_de_otros_servicios

Backend.start(function () {
    $(document).ready(function () {

        ContenedorGrilla = $("#ContenedorGrilla");
        $("#ContenedorPersona").empty();

    });
});


$("#btn_Estado").click(function () {
    CargarGrilla("ESTADO");
});
$("#btn_Privado").click(function () {
    CargarGrilla("PRIVADO");
});
$("#btn_AgregarServicio").click(function () {
    if (botonSeleccionado=="ESTADO") {
        window.open("CargaDeAntiguedadesAdmPublica.aspx?legajo=" + $('#legajo').text().trim() + "&" + $('#documento').text().trim() + "&" + "folio=" + "00-018/018");
    }
    if (botonSeleccionado == "PRIVADO") {
        alert("abrir pagina privado");
    }   
});

var LimpiarPantalla = function () {

    botonSeleccionado = null;

    //$('#ContenedorCampos').hide();
    //$("#txtPaseContabilidad").val("");
    //ContenedorGrilla.html("");
    //$("#ContenedorPersona").empty();
    //lista_de_facturas = null;
    //SaldoAcumPendienteAFacturar = 0;
};


var FormatearFecha = function (p_fecha) {
    var fecha_sin_hora = p_fecha.split("T");
    var fecha = fecha_sin_hora[0].split("-");
    return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
};



var CargarGrilla = function (boton) {
    LimpiarPantalla();

    botonSeleccionado = boton;

    var documento = $('#documento').text().trim();
    var legajo = $('#legajo').text().trim();


    if (documento == "") {
        documento = 0;
        legajo = 0;
        alert("Ingrese una persona");
        return;
    }

    //    if (!ValidarUsuario(documento)) {
    //        alert("NO PASA");
    //    };

    if (botonSeleccionado == "ESTADO") {
        ConsultarServicioAdmPublica(documento);
    }

    if (botonSeleccionado == "PRIVADO") {
        ConsultarOtrosServicios(documento);
    }

};


//--------------------- ESTADO ----------------------------------
var ConsultarServicioAdmPublica = function (documento) {
    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    Backend.GetServicios_Adm_Publica_Principal(documento)
    .onSuccess(function (respuesta) {
        lista_de_serv_publico = respuesta;
        DibujarGrillaServPublico();
        spinner.stop();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
        spinner.stop();
        LimpiarPantalla();
    });
};

var DibujarGrillaServPublico = function () {
    var grilla;
    ContenedorGrilla.html("");
    $("#ContenedorPersona").empty();
    
    grilla = new Grilla(
        [
//            new Columna("", { generar: function (consulta) {
//                var check = $("<input type='checkbox' />");
//                if (consulta.estaSeleccionado) check.attr("checked", true);
//                check.click(function () {
//                    if (consulta.estaSeleccionado) {
//                        check.attr("checked", false);
//                        consulta.estaSeleccionado = false;
//                        CalcularFacturasAPagar(consulta);
//                    }
//                    else {
//                        check.attr("checked", true);
//                        consulta.estaSeleccionado = true;
//                        CalcularFacturasAPagar(consulta);
//                        if (MontoMaximoExcedido == 1) {
//                            check.attr("checked", false);
//                            consulta.estaSeleccionado = false;
//                        }
//                    }
//                });
//                return check
//            }
//            }),
            new Columna("Id", { generar: function (consulta) { return consulta.Id; } }),
            new Columna("Ambito", { generar: function (consulta) { return consulta.Ambito.Descripcion; } }),
            new Columna("Jurisdiccion", { generar: function (consulta) { return consulta.Jurisdiccion; } }),
            new Columna("Folio", { generar: function (consulta) { return consulta.Folio; } }),
            new Columna("Caja", { generar: function (consulta) { return consulta.Caja; } }),
            new Columna("Afiliado", { generar: function (consulta) { return consulta.Afiliado; } }),

            new Columna("Ver", { generar: function (consulta) {
                //return consulta.Afiliado; 
                var cont = $('<div>');

                //if (consulta.Id == 0) return cont;

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
                        //checks_activos = ["GraficoPorArea"];
                        //$('#div_tabla_detalle').hide();
                        //$('#div_tabla_informes').hide();
                        //_this.FiltrarPersonasParaTablaDetalle(un_registro.Id, tabla_detalle);
                        window.open("CargaDeAntiguedadesAdmPublica.aspx?legajo=" + $('#legajo').text().trim() + "&" + "folio=" + consulta.Folio);

                        spinner.stop();
                    }, 10);

                });
                cont.append(btn_accion);
                return cont;
                } }),


            ]);

    grilla.CargarObjetos(lista_de_serv_publico);
    grilla.DibujarEn(ContenedorGrilla);

    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
};
//-------------------------------------------------------------------------


//---------------------------- PRIVADO -------------------------------------
var ConsultarOtrosServicios = function (documento) {
    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    Backend.GetOtrosServicios(documento)
    .onSuccess(function (respuesta) {
        lista_de_otros_servicios = respuesta;
        DibujarGrillaOtrosServicios();
        spinner.stop();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
        spinner.stop();
        LimpiarPantalla();
    });
};

var DibujarGrillaOtrosServicios = function () {
    var grilla;
    ContenedorGrilla.html("");
    $("#ContenedorPersona").empty();

    grilla = new Grilla(
        [
    //            new Columna("", { generar: function (consulta) {
    //                var check = $("<input type='checkbox' />");
    //                if (consulta.estaSeleccionado) check.attr("checked", true);
    //                check.click(function () {
    //                    if (consulta.estaSeleccionado) {
    //                        check.attr("checked", false);
    //                        consulta.estaSeleccionado = false;
    //                        CalcularFacturasAPagar(consulta);
    //                    }
    //                    else {
    //                        check.attr("checked", true);
    //                        consulta.estaSeleccionado = true;
    //                        CalcularFacturasAPagar(consulta);
    //                        if (MontoMaximoExcedido == 1) {
    //                            check.attr("checked", false);
    //                            consulta.estaSeleccionado = false;
    //                        }
    //                    }
    //                });
    //                return check
    //            }
    //            }),
            new Columna("Id", { generar: function (consulta) { return consulta.Id; } }),
            new Columna("Institucion", { generar: function (consulta) { return consulta.Institucion; } }),
            new Columna("Domicilio", { generar: function (consulta) { return consulta.Domicilio; } }),
            new Columna("Cargo", { generar: function (consulta) { return consulta.Cargo; } }),
            new Columna("Remunerativo", { generar: function (consulta) { return consulta.Remunerativo; } }),
            new Columna("Fecha_Desde", { generar: function (consulta) { return FormatearFecha(consulta.Fecha_Desde); } }),
            new Columna("Fecha_Hasta", { generar: function (consulta) { return consulta.Fecha_Hasta; } }),
            new Columna("Causa_Egreso", { generar: function (consulta) { return consulta.Causa_Egreso; } }),
            new Columna("Caja", { generar: function (consulta) { return consulta.Caja; } }),
            new Columna("Afiliado", { generar: function (consulta) { return consulta.Afiliado; } }),
            new Columna("Folio", { generar: function (consulta) { return consulta.Folio; } })
            
            ]);


    grilla.CargarObjetos(lista_de_otros_servicios);
    grilla.DibujarEn(ContenedorGrilla);

    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });

};

//----------------------------------------------------------------------