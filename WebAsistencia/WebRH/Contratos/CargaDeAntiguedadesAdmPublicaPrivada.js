
var valores;
var pLegajo;
var pDocumento;
var pFolio;
var pServicio;
var pUsuarioLogueado;
var ambitoIdSeleccionado;
var ambitoDescripSeleccionado;
var cargoIdSeleccionado;
var cargoDescripSeleccionado;

var ContenedorGrilla;
var lista_de_serv_publico;


Backend.start(function () {
    $(document).ready(function () {

        var valores = getParametrosURL();
        pLegajo = valores['legajo'];
        pDocumento = valores['documento'];
        pFolio = valores['folio'];
        pServicio = valores['servicio'];

        if (pServicio == "PUBLICO")
            $('#lblTitulo').val("Carga de Servicio de Administracion Publico");

        if (pServicio == "PRIVADO") {
            $('#lblTitulo').val("Carga de Servicio de Administracion Privado");
        };

        
        $("#NroFolio").focusout(function () {
            $("#NroFolio").val(pad($("#NroFolio").val(),2));
        });

        $("#NroFolioDesde").focusout(function () {
            $("#NroFolioDesde").val(pad($("#NroFolioDesde").val(), 3));
        });

        $("#NroFolioHasta").focusout(function () {
            $("#NroFolioHasta").val(pad($("#NroFolioHasta").val(), 3));
        });


        completarComboAmbitos();
        completarComboCargo();
        GetUsuario();


        ContenedorGrilla = $("#ContenedorGrilla");
        $("#ContenedorServicios").empty();

        ConsultarServicioAdmPublica();
    });
});


function pad(str, max) {
    str = str.toString();
    return str.length < max ? pad("0" + str, max) : str;
}

function getParametrosURL() {
    // url
    var loc = document.location.href;
    // si existe el signo ?
    if (loc.indexOf('?') > 0) {
        var getString = loc.split('?')[1];
        var GET = getString.split('&');
        var get = {};
        for (var i = 0, l = GET.length; i < l; i++) {
            var tmp = GET[i].split('=');
            get[tmp[0]] = unescape(decodeURI(tmp[1]));
        }
        return get;
    }
}


var GetUsuario = function () {
    Backend.GetUsuarioLogueado()
    .onSuccess(function (respuesta) {
        pUsuarioLogueado = respuesta.Id;
        spinner.stop();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
        spinner.stop();
    });
}


var PanelFechas = function (cfg) {
    var self = this;
    this.cfg = cfg;

    cfg.inputFechaDesde.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) {
            self.cfg.inputFechaDesde.change();
            self.cfg.inputFechaDesde.blur();
            FechaDesde = date;
        }
    });

    cfg.inputFechaHasta.datepicker({ dateFormat: "dd/mm/yy",
        onSelect: function (date) {
            self.cfg.inputFechaHasta.change();
            self.cfg.inputFechaHasta.blur();
            FechaHasta = date;
        }
    });
}

$("#btn_Agregar").click(function () {

    if (ValidarDatos("AGREGAR") == false) {
        return;
    }

    var ServPublico = {};
    ServPublico.Cargo = {};
    ServPublico.Cargo.Id = parseInt($("#cmbCargo").val());
    ServPublico.Cargo.Descripcion = $("#cmbCargo option:selected").text();
    ServPublico.Organismo = $('#txtOrganismo').val();
    ServPublico.Fecha_Desde = toDateYYYYMMDD($("#txtFechaDesde").val()) //$("#txtFechaDesde").val(); //$.datepicker.parseDate('dd/mm/yy', $("#txtFechaDesde").val());
    ServPublico.Fecha_Hasta = toDateYYYYMMDD($("#txtFechaHasta").val()) //$("#txtFechaHasta").val(); //$.datepicker.parseDate('dd/mm/yy', $("#txtFechaHasta").val());
    ServPublico.Domicilio = $('#txtDomicilio').val();


    //    ServPublico.Ambito = {};
    //    ServPublico.Ambito.Id = parseInt($("#cmbAmbitos").val());
    //    ServPublico.Ambito.Descripcion = $("#cmbAmbitos option:selected").text();
    //    ServPublico.Jurisdiccion = $('#txtJurisdiccion').val();

    //    
    //    if ($("#rdRemuneradoSI").prop("checked") == true) {
    //        ServPublico.Remunerativo = true;
    //    }
    //    else {
    //        ServPublico.Remunerativo = false;
    //    }

    //    ServPublico.Folio = $('#NroFolio').val() + "-" + $('#NroFolioDesde').val() + "/" + $('#NroFolioHasta').val();
    //    ServPublico.Id_Interna = parseInt(pLegajo);
    //    ServPublico.Doc_Titular = parseInt(pDocumento);
    //    ServPublico.Caja = $('#txtCaja').val();
    //    ServPublico.Afiliado = $('#txtNroAfiliacion').val();

    //    if ($("#chkNoImprime").checked) {
    //        ServPublico.datonoimprime = true;
    //    }
    //    else {
    //        ServPublico.datonoimprime = false;
    //    }

    //    if ($("#DarDeBaja").prop("checked") == true) {
    //        ServPublico.DatoDeBaja = true;
    //    }
    //    else {
    //        ServPublico.DatoDeBaja = false;
    //    }

    //    if ($("#rdTipoDocumentoCTR").prop("checked") == true) {
    //        ServPublico.Ctr_Cert = true;
    //    }
    //    if ($("#rdTipoDocumentoCER").prop("checked") == true) {
    //        ServPublico.Ctr_Cert = false;
    //    }
    //    if ($("#rdTipoDocumentoOTR").prop("checked") == true) {
    //        ServPublico.Ctr_Cert = null;
    //    }

    //ServPublico.Domicilio = null;
    //ServPublico.Institucion = null;

    //    var d = new Date();
    //    var dFecha = d.getDate() + "/" + (d.getMonth() + 1) + "/" + d.getFullYear();
    //    ServPublico.Fecha_Carga = toDateYYYYMMDD(dFecha); //ConversorDeFechas.deIsoAFechaEnCriollo(dFecha);

    //    ServPublico.Usuario = pUsuarioLogueado;

    //ServPublico.Causa_Egreso = $('#txtCausaEgreso').val();

    //lista_de_serv_publico.append(ServPublico);
    lista_de_serv_publico.push(ServPublico);
    DibujarGrillaServPublico();



    $("#txtOrganismo").val(null);
    $("#cmbCargo").val(0);
    $("#txtFechaDesde").val(null);
    $("#txtFechaHasta").val(null);
    $("#txtDomicilio").val(null);
    
   
});





$("#btn_Guardar").click(function () {
    //var aa = ServPublico;

    if (ValidarDatos("GUARDAR") == false) {
        return;
    }

    if (lista_de_serv_publico.length == 0) {
        alertify.alert("Debe agregar un organismo a la lista");
        return;
    };


    //-------------------------------------------------
    var ServPublico = {};
    ServPublico.Ambito = {};
    ServPublico.Ambito.Id = parseInt($("#cmbAmbitos").val());
    ServPublico.Ambito.Descripcion = $("#cmbAmbitos option:selected").text();
    ServPublico.Jurisdiccion = $('#txtJurisdiccion').val();


    if ($("#rdRemuneradoSI").prop("checked") == true) {
        ServPublico.Remunerativo = true;
    }
    else {
        ServPublico.Remunerativo = false;
    }

    ServPublico.Folio = $('#NroFolio').val() + "-" + $('#NroFolioDesde').val() + "/" + $('#NroFolioHasta').val();
    ServPublico.Id_Interna = parseInt(pLegajo);
    ServPublico.Doc_Titular = parseInt(pDocumento);
    ServPublico.Caja = $('#txtCaja').val();
    ServPublico.Afiliado = $('#txtNroAfiliacion').val();

    if ($("#DarDeBaja").prop("checked") == true) {
        ServPublico.DatoDeBaja = true;
    }
    else {
        ServPublico.DatoDeBaja = false;
    }

    if ($("#rdTipoDocumentoCTR").prop("checked") == true) {
        ServPublico.Ctr_Cert = true;
    }
    if ($("#rdTipoDocumentoCER").prop("checked") == true) {
        ServPublico.Ctr_Cert = false;
    }
    if ($("#rdTipoDocumentoOTR").prop("checked") == true) {
        ServPublico.Ctr_Cert = null;
    }

    ServPublico.Causa_Egreso = $('#txtCausaEgreso').val();

    var d = new Date();
    var dFecha = d.getDate() + "/" + (d.getMonth() + 1) + "/" + d.getFullYear();
    ServPublico.Fecha_Carga = toDateYYYYMMDD(dFecha); //ConversorDeFechas.deIsoAFechaEnCriollo(dFecha);
    ServPublico.Usuario = pUsuarioLogueado;

    //-----------------------------------------



    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    Backend.Alta_Servicios_Administracion(lista_de_serv_publico, ServPublico, pServicio)
    .onSuccess(function (respuesta) {
        alertify.success("Datos guardados con éxito");
        //lista_de_serv_publico = respuesta;
        //CargarPantalla(lista_de_serv_publico);
        //DibujarGrillaServPublico();
        spinner.stop();
        LimpiarPantalla();
    })
    .onError(function (error, as, asd) {
        alertify.alert("Error al guardar los servicios");
        spinner.stop();
        //LimpiarPantalla();
    });

});



function ValidarDatos(accion) {
    
        if (accion == "AGREGAR") {
            if ($("#txtOrganismo").val() == "") {
                alertify.alert("Debe cargar el organismo");
                return false;
            };

            if ($("#cmbCargo").val() == 0) {
                alertify.alert("Debe cargar el cargo");
                return false;
            };

            if ($("#txtFechaDesde").val() == 0) {
                alertify.alert("Debe cargar la fecha desde");
                return false;
            };

            if ($("#txtFechaHasta").val() == 0) {
                alertify.alert("Debe cargar la fecha hasta");
                return false;
            };

            if ($("#txtFechaDesde").val() > $("#txtFechaHasta").val()) {
                alertify.alert("La fecha desde no puede ser mayor a la fecha hasta");
                return false;
            };

            if ($("#txtDomicilio").val() == "") {
                alertify.alert("Debe cargar el domicilio");
                return false;
            };
        } 
        else {

            if ($("#cmbAmbitos").val() == 0) {
                alertify.alert("Debe cargar el ambito");
                return false;
            };

            if ($("#NroFolio").val() == 0) {
                alertify.alert("Debe cargar el numero de folio");
                return false;
            };

            if ($("#NroFolioDesde").val() == 0) {
                alertify.alert("Debe cargar el numero de folio desde");
                return false;
            };

            if ($("#NroFolioHasta").val() == 0) {
                alertify.alert("Debe cargar el numero de folio hasta");
                return false;
            };

            if ($("#NroFolioDesde").val() > $("#NroFolioHasta").val()) {
                alertify.alert("El nro de folio desde no puede ser mayor al nro hasta");
                return false;
            };

            if (pServicio == "PUBLICO") {
                if ($("#txtJurisdiccion").val() == "") {
                    alertify.alert("Debe cargar la Jurisdiccion");
                    return false;
                };
            };

            if ($("#txtCaja").val() == "") {
                alertify.alert("Debe cargar la Caja");
                return false;
            };

            if ($("#txtNroAfiliacion").val() == "") {
                alertify.alert("Debe cargar el numero de afiliacion");
                return false;
            };

            if (($("#rdRemuneradoSI").prop("checked") == false) && ($("#rdRemuneradoNO").prop("checked") == false)) {
                alertify.alert("Debe cargar la opcion de remunerado");
                return false;
            };


            if (($("#rdTipoDocumentoCTR").prop("checked") == false) && ($("#rdTipoDocumentoCER").prop("checked") == false) && ($("#rdTipoDocumentoOTR").prop("checked") == false)) {
                alertify.alert("Debe cargar el tipo de documento");
                return false;
            };

        }
        

        //if (lista_de_serv_publico.length == 0) {
        //alertify.alert("Debe agregar un organismo");
        //return false;
        //};

        //$("#chkNoImprime").prop("checked", true);
        //$("#DarDeBaja").prop("checked", true);
        //if (("#txtCausaEgreso").val() == 0) {
        //}

    return true;
};





var FormatearFecha = function (p_fecha) {
        var fecha_sin_hora = p_fecha.split("T");
        var fecha = fecha_sin_hora[0].split("-");
        return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
};


function toDateYYYYMMDD(dateStr) {
    var parts = dateStr.split("/")
    return parts[2] + "-" + parts[1] + "-" + parts[0] + "T00:00:00.000"
}


var GetFolio = function (folio, dato) {

    if (dato == 1) {
        var nro = folio.split("-");
        return nro[0];
    }

    if (dato == 2) {
        var nro = folio.split("-");
        var dh = nro[1].split("/");
        return dh[0];
    }

    if (dato == 3) {
        var nro = folio.split("-");
        var dh = nro[1].split("/");
        return dh[1];
    }
};


//function getRadioButtonSelectedValue(ctrl) {
//    for (i = 0; i < ctrl.length; i++)
//        if (ctrl[i].checked) return ctrl[i].value;
//}
//OR
//function getCheckedRadio() {
//    var radioButtons = document.getElementsByName("RadioButtonList1");
//    for (var x = 0; x < radioButtons.length; x++) {
//        if (radioButtons[x].checked) {
//            alert("You checked " + radioButtons[x].id + " which has the value " + radioButtons[x].value);
//        }
//    }
//}



var completarComboAmbitos = function () {
    var ambitos = $('#cmbAmbitos');
    ambitos.html("");
    Backend.GetAmbitos()
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            //item = new Option(respuesta[i].id + ' - ' + respuesta[i].descripcion, respuesta[i].id + '-' + respuesta[i].descripcion);
            item = new Option(respuesta[i].descripcion, respuesta[i].id);
            $(item).html(respuesta[i].descripcion);
            ambitos.append(item);
        }
        ambitos.change(function () {
            ambitoIdSeleccionado = parseInt($("#cmbAmbitos").val().split("-")[0]);
            ambitoDescripSeleccionado = parseInt($("#cmbAmbitos").val().split("-")[1]);

            //alert(ambitoIdSeleccionado);
            //alert(ambitoDescripSeleccionado);

        });

        ambitos.change();
        ambitos.show();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
    });
}


var completarComboCargo = function () {
    var cargo = $('#cmbCargo');
    cargo.html("");
    Backend.GetCargos()
    .onSuccess(function (respuesta) {
        for (var i = 0; i < respuesta.length; i++) {
            //item = new Option(respuesta[i].id + ' - ' + respuesta[i].descripcion, respuesta[i].id + '-' + respuesta[i].descripcion);
            item = new Option(respuesta[i].descripcion, respuesta[i].id);
            $(item).html(respuesta[i].descripcion);
            cargo.append(item);
        }
        cargo.change(function () {
            cargoIdSeleccionado = parseInt($("#cmbCargo").val().split("-")[0]);
            cargoDescripSeleccionado = parseInt($("#cmbCargo").val().split("-")[1]);

            //alert(cargoIdSeleccionado);
            //alert(cargoDescripSeleccionado);

        });

        cargo.change();
        cargo.show();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
    });
}


//---------------------- CARGAR GRILLA -------------------------------------

var ConsultarServicioAdmPublica = function (documento) {
    spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    Backend.GET_Servicios_Adm_Detalles(pLegajo, pFolio, pServicio)
    .onSuccess(function (respuesta) {
        lista_de_serv_publico = respuesta;
        CargarPantalla(lista_de_serv_publico);
        DibujarGrillaServPublico();
        spinner.stop();
    })
    .onError(function (error, as, asd) {
        alertify.alert("", error);
        spinner.stop();
        //LimpiarPantalla();
    });
};

var CargarPantalla = function (ListaDeDatos) {

    if (ListaDeDatos.length > 0) {

        if (pServicio == "PRIVADO") {
            $("#cmbAmbitos").val(6).change();
            $("#cmbAmbitos").attr('disabled', true);
        }
        else {
            $("#cmbAmbitos").val(lista_de_serv_publico[0].Ambito.Id).change();
            $("#cmbAmbitos").attr('disabled', false);
        }
        $('#NroFolio').val(pad((GetFolio(lista_de_serv_publico[0].Folio, 1)).trim(), 2));
        $('#NroFolioDesde').val(pad((GetFolio(lista_de_serv_publico[0].Folio, 2)).trim(), 3));
        $('#NroFolioHasta').val(pad((GetFolio(lista_de_serv_publico[0].Folio, 3)).trim(),3));
        $('#txtJurisdiccion').val(lista_de_serv_publico[0].Jurisdiccion);
        $('#txtCaja').val(lista_de_serv_publico[0].Caja);
        $('#txtNroAfiliacion').val(lista_de_serv_publico[0].Afiliado);

        if (lista_de_serv_publico[0].Remunerativo) {
            $("#rdRemuneradoSI").prop("checked", true);
        }
        else {
            $("#rdRemuneradoNO").prop("checked", true);
        }

        if (lista_de_serv_publico[0].Ctr_Cert == true) {
            $("#rdTipoDocumentoCTR").prop("checked", true);
        }
        else {
            if (lista_de_serv_publico[0].Ctr_Cert == false) {
                $("#rdTipoDocumentoCER").prop("checked", true);
            }
            else {
                $("#rdTipoDocumentoOTR").prop("checked", true);
            }
        }

        $('#txtCausaEgreso').val(lista_de_serv_publico[0].Causa_Egreso);

        //        if (lista_de_serv_publico[0].datonoimprime == true) {
        //            $("#chkNoImprime").prop("checked", true);
        //        }

        if (lista_de_serv_publico[0].DatoDeBaja == true) {
            $("#DarDeBaja").prop("checked", true);
        }
    }


    if (pFolio == "0") {
        LimpiarPantalla();
    }
};


var LimpiarPantalla = function () {

    $("#cmbAmbitos").val(ambitoIdSeleccionado);
    $('#NroFolio').val(00);
    $('#NroFolioDesde').val(000);
    $('#NroFolioHasta').val(000);
    $('#txtJurisdiccion').val(null);
    $('#txtCaja').val(null);
    $('#txtNroAfiliacion').val(null);

    $("#rdRemuneradoSI").prop("checked", false);
    $("#rdRemuneradoNO").prop("checked", false);

    $("#rdTipoDocumentoCTR").prop("checked", false);
    $("#rdTipoDocumentoCER").prop("checked", false);
    $("#rdTipoDocumentoOTR").prop("checked", false);

    $('#txtCausaEgreso').val(null);
    //$("#chkNoImprime").prop("checked", false);
    $("#DarDeBaja").prop("checked", false);

    $("#txtOrganismo").val(null);
    $("#cmbCargo").val(cargoIdSeleccionado);
    $("#txtFechaDesde").val(null);
    $("#txtFechaHasta").val(null);
    $("#txtDomicilio").val(null);

    //$("#chkNoImprime").prop("checked", false);
    $("#DarDeBaja").prop("checked", false);
    $("#txtCausaEgreso").val(null);

    lista_de_serv_publico.length == 0;
};


var DibujarGrillaServPublico = function () {
    var grilla;
    ContenedorGrilla.html("");
    $("#ContenedorServicios").empty();

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
            new Columna("Organismo", { generar: function (consulta) { return consulta.Organismo; } }),
            new Columna("Cargo", { generar: function (consulta) { return consulta.Cargo.Descripcion; } }),
            new Columna("Desde", { generar: function (consulta) { return FormatearFecha(consulta.Fecha_Desde); } }),
            new Columna("Hasta", { generar: function (consulta) { return FormatearFecha(consulta.Fecha_Hasta); } }),
            new Columna("Domicilio", { generar: function (consulta) { return consulta.Domicilio; } }),


            new Columna("Eliminar", { generar: function (consulta) {
                //return consulta.Afiliado; 
                var cont = $('<div>');

                //if (consulta.Id == 0) return cont;

                var btn_accion = $('<a>');
                var img = $('<img>');
                img.attr('src', '../Imagenes/eliminar.png');
                img.attr('width', '15px');
                img.attr('height', '15px');
                btn_accion.attr('style', 'display:inline-block');
                btn_accion.append(img);
                btn_accion.click(function () {
                    var spinner = new Spinner({ scale: 3 });
                    spinner.spin($("html")[0]);

                    setTimeout(function () {
                        //window.open("CargaDeAntiguedadesAdmPublica.aspx?legajo=" + $('#legajo').text().trim() + "&" + "folio=" + consulta.Folio);
                        alertify.confirm("Eliminar Cargo", "¿Desea eliminar el cargo " + consulta.Cargo.Descripcion + " entre las fechas " + FormatearFecha(consulta.Fecha_Desde) + " y " + FormatearFecha(consulta.Fecha_Hasta) + " ?", function () {
                            //ACEPTO
                            lista_de_serv_publico.splice(lista_de_serv_publico.index(), 1)
                            alertify.success("OK - Borrar");
                        }, function () {
                            //CANCELA
                            alertify.success("Eliminación cancelada");
                        }).setting('labels', { 'ok': 'Aceptar', 'cancel': 'Cancelar' });

                        spinner.stop();
                    }, 10);

                });
                cont.append(btn_accion);
                return cont;
            } 
            }),

        ]);

    grilla.CargarObjetos(lista_de_serv_publico);
    grilla.DibujarEn(ContenedorGrilla);

    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
};

//----------------------------------------------------------------------------------