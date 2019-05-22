
var lista_de_servicio;
var pServicio;


Backend.start(function () {
    $(document).ready(function () {

        alert(sessionStorage.getItem("nombre") + " " + (sessionStorage.getItem("apellido")) + "|" + (sessionStorage.getItem("documento")) + "|" + (sessionStorage.getItem("legajo")) );        

        CargarGrillaServicios();
        lista_de_servicio = [];

        $("#txtNroFolio").focusout(function () {
            $("#txtNroFolio").val(pad($("#txtNroFolio").val(), 2));
        });

        $("#txtNroFolioDesde").focusout(function () {
            $("#txtNroFolioDesde").val(pad($("#txtNroFolioDesde").val(), 3));
        });

        $("#txtNroFolioHasta").focusout(function () {
            $("#txtNroFolioHasta").val(pad($("#txtNroFolioHasta").val(), 3));
        });

       completarComboAmbitos();
       completarComboCargo();

        ContenedorGrillaServicios = $("#ContenedorGrillaServicios");
        $("#ContenedorGrillaServicios").empty();

        //ConsultarServicioAdmPublica();

    });
});


////--- CARGAR COMBOS -----------------------------------------------------------------------------
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
////--- CARGAR COMBOS -----------------------------------------------------------------------------

function pad(str, max) {
    str = str.toString();
    return str.length < max ? pad("0" + str, max) : str;
}

var PanelFechas = function (cfg) {
    var self = this;
    this.cfg = cfg;

    cfg.inputFechaDesde.datepicker({
        dateFormat: "dd/mm/yy",
        onSelect: function (date) {
            self.cfg.inputFechaDesde.change();
            self.cfg.inputFechaDesde.blur();
            FechaDesde = date;
        }
    });

    cfg.inputFechaHasta.datepicker({
        dateFormat: "dd/mm/yy",
        onSelect: function (date) {
            self.cfg.inputFechaHasta.change();
            self.cfg.inputFechaHasta.blur();
            FechaHasta = date;
        }
    });
}

function toDateYYYYMMDD(dateStr) {
    var parts = dateStr.split("/")
    return parts[2] + "-" + parts[1] + "-" + parts[0] + "T00:00:00.000"
}

var FormatearFecha = function (p_fecha) {
    var fecha_sin_hora = p_fecha.split("T");
    var fecha = fecha_sin_hora[0].split("-");
    return fecha[2] + "/" + fecha[1] + "/" + fecha[0];
};


$("#btn_Estado").click(function () {
    $('#cajaDatosExpLaboral').show();
    $('#tituloExpLaboral').html("Servicio de Administración Pública");
    pServicio = "PUBLICO";
});

$("#btn_Privado").click(function () {
    $('#cajaDatosExpLaboral').show();
    $('#tituloExpLaboral').html("Servicio de Administración Privada");
    pServicio = "PRIVADO";
});

//------------ GUARDAR ---------------------------------
$("#btnGuardarExpLaboral").click(function () {

    if (ValidarDatos("GUARDAR") == false) {
        return;
    }

    if (lista_de_exp_laboral.length == 0) {
        alertify.alert("Debe agregar un organismo a la lista");
        return;
    };


    //var ServPublico = {};
    //ServPublico.Ambito = {};
    //ServPublico.Ambito.Id = parseInt($("#cmbAmbitos").val());
    //ServPublico.Ambito.Descripcion = $("#cmbAmbitos option:selected").text();
    //ServPublico.Jurisdiccion = $('#txtJurisdiccion').val();


    //if ($("#rdRemuneradoSI").prop("checked") == true) {
    //    ServPublico.Remunerativo = true;
    //}
    //else {
    //    ServPublico.Remunerativo = false;
    //}

    //ServPublico.Folio = $('#NroFolio').val() + "-" + $('#NroFolioDesde').val() + "/" + $('#NroFolioHasta').val();
    //ServPublico.Id_Interna = parseInt(pLegajo);
    //ServPublico.Doc_Titular = parseInt(pDocumento);
    //ServPublico.Caja = $('#txtCaja').val();
    //ServPublico.Afiliado = $('#txtNroAfiliacion').val();

    //if ($("#DarDeBaja").prop("checked") == true) {
    //    ServPublico.DatoDeBaja = true;
    //}
    //else {
    //    ServPublico.DatoDeBaja = false;
    //}

    //if ($("#rdTipoDocumentoCTR").prop("checked") == true) {
    //    ServPublico.Ctr_Cert = true;
    //}
    //if ($("#rdTipoDocumentoCER").prop("checked") == true) {
    //    ServPublico.Ctr_Cert = false;
    //}
    //if ($("#rdTipoDocumentoOTR").prop("checked") == true) {
    //    ServPublico.Ctr_Cert = null;
    //}

    //ServPublico.Causa_Egreso = $('#txtCausaEgreso').val();

    //var d = new Date();
    //var dFecha = d.getDate() + "/" + (d.getMonth() + 1) + "/" + d.getFullYear();
    //ServPublico.Fecha_Carga = toDateYYYYMMDD(dFecha); //ConversorDeFechas.deIsoAFechaEnCriollo(dFecha);
    //ServPublico.Usuario = pUsuarioLogueado;

    
    //spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

    //Backend.Alta_Servicios_Administracion(lista_de_serv_publico, ServPublico, pServicio)
    //    .onSuccess(function (respuesta) {
    //        alertify.success("Datos guardados con éxito");
    //        spinner.stop();
    //        LimpiarPantalla();
    //    })
    //    .onError(function (error, as, asd) {
    //        alertify.alert("Error al guardar los servicios");
    //        spinner.stop();
    //    });


    $('#cajaDatosExpLaboral').hide();
});
//------------ GUARDAR ---------------------------------


//------------ AGREGAR ITEM A LA LISTA DE ORGANISMOS ---------------------------------
$("#btn_Agregar").click(function () {

    if (ValidarDatos("AGREGAR") == false) {
        return;
    }

    var Servicio = {};
    Servicio.Cargo = {};
    Servicio.Cargo.Id = parseInt($("#cmbCargo").val());
    Servicio.Cargo.Descripcion = $("#cmbCargo option:selected").text();
    Servicio.Organismo = $('#txtOrganismo').val();
    Servicio.Fecha_Desde = toDateYYYYMMDD($("#txtFechaDesde").val()) //$("#txtFechaDesde").val(); //$.datepicker.parseDate('dd/mm/yy', $("#txtFechaDesde").val());
    Servicio.Fecha_Hasta = toDateYYYYMMDD($("#txtFechaHasta").val()) //$("#txtFechaHasta").val(); //$.datepicker.parseDate('dd/mm/yy', $("#txtFechaHasta").val());
    Servicio.Domicilio = $('#txtDomicilio').val();

    lista_de_servicio.push(Servicio);
    DibujarGrillaServicios();

    $("#txtOrganismo").val(null);
    $("#cmbCargo").val(0);
    $("#txtFechaDesde").val(null);
    $("#txtFechaHasta").val(null);
    $("#txtDomicilio").val(null);

});
//------------ AGREGAR ITEM A LA LISTA DE ORGANISMOS ---------------------------------



    var CargarGrillaServicios = function () {
        //LimpiarPantalla();
        
        var documento = sessionStorage.getItem("documento");
        if (documento == "") {
            alert("Ingrese una persona");
            return;
        }

        ConsultarExperienciaLaboral(documento);
    };


    var ConsultarExperienciaLaboral = function (documento) {
        spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

        Backend.GetExperienciaLaboral_Principal(documento)
            .onSuccess(function (respuesta) {
                lista_de_exp_laboral = respuesta;
                DibujarGrillaServPublico();
                spinner.stop();
            })
            .onError(function (error, as, asd) {
                alertify.alert("", error);
                spinner.stop();
                LimpiarPantalla();
            });
    };



    //---------- GRILLA ADM. EXP. LABORAL --------------------------------
    var DibujarGrillaServPublico = function () {
        var grilla;
        ContenedorGrilla = $("#tabla_Exp_Laboral");
        ContenedorGrilla.html("");
        
        grilla = new Grilla(
            [
                new Columna("Id", { generar: function (consulta) { return consulta.Id; } }),
                new Columna("Ambito", { generar: function (consulta) { return consulta.Ambito.Descripcion; } }),
                new Columna("Jurisdiccion", { generar: function (consulta) { return consulta.Jurisdiccion; } }),
                new Columna("Folio", { generar: function (consulta) { return consulta.Folio; } }),
                new Columna("Fecha Desde", { generar: function (consulta) { return ConversorDeFechas.deIsoAFechaEnCriollo(consulta.Fecha_Desde); } }),
                new Columna("Fecha Hasta", { generar: function (consulta) { return ConversorDeFechas.deIsoAFechaEnCriollo(consulta.Fecha_Hasta); } }),

                new Columna("Accion", {
                    generar: function (consulta) {
                        var cont = $('<div>');
                        var btn_accion = $('<a>');
                        var img = $('<img>');
                        img.attr('src', '../../Imagenes/detalle.png');
                        img.attr('width', '15px');
                        img.attr('height', '15px');
                        btn_accion.attr('style', 'display:inline-block');
                        btn_accion.append(img);
                        btn_accion.click(function () {
                            var spinner = new Spinner({ scale: 3 });
                            spinner.spin($("html")[0]);
                            setTimeout(function () {
                                spinner.stop();

                                alert("Mostrar pantalla de datos para cargar FOLIO: " + consulta.Folio + " - EXP. LABORAL");
                                $('#cajaDatosExpLaboral').show();

                                //window.open("CargaDeAntiguedadesAdmPublicaPrivada.aspx?legajo=" + $('#legajo').text().trim() + "&documento=" + $('#documento').text().trim() + "&folio=" + consulta.Folio + "&servicio=" + botonSeleccionado);
                            }, 10);
                        });
                        cont.append(btn_accion);
                        return cont;
                    }
                }),
            ]);

        grilla.CargarObjetos(lista_de_exp_laboral);
        grilla.DibujarEn(ContenedorGrilla);

        grilla.SetOnRowClickEventHandler(function () {
            return true;
        });
    };
    //---------- GRILLA ADM. EXP. LABORAL --------------------------------




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




var DibujarGrillaServicios = function () {
    var grilla;
    ContenedorGrillaServicios.html("");
    $("#ContenedorServicios").empty();

    grilla = new Grilla(
        [
            new Columna("Organismo", { generar: function (consulta) { return consulta.Organismo; } }),
            new Columna("Cargo", { generar: function (consulta) { return consulta.Cargo.Descripcion; } }),
            new Columna("Desde", { generar: function (consulta) { return FormatearFecha(consulta.Fecha_Desde); } }),
            new Columna("Hasta", { generar: function (consulta) { return FormatearFecha(consulta.Fecha_Hasta); } }),
            new Columna("Domicilio", { generar: function (consulta) { return consulta.Domicilio; } }),
            
            new Columna("Eliminar", {
                generar: function (consulta) {
                    //return consulta.Afiliado; 
                    var cont = $('<div>');
                    //if (consulta.Id == 0) return cont;
                    var btn_accion = $('<a>');
                    var img = $('<img>');
                    img.attr('src', '../../Imagenes/eliminar.png');
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
                                lista_de_servicio.splice(lista_de_servicio.index(), 1)
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

    grilla.CargarObjetos(lista_de_servicio);
    grilla.DibujarEn(ContenedorGrillaServicios);

    grilla.SetOnRowClickEventHandler(function () {
        return true;
    });
};
