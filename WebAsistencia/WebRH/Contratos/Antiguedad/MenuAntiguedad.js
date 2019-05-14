
Backend.start(function () {
    $(document).ready(function () {

        alert(sessionStorage.getItem("nombre") + " " + (sessionStorage.getItem("apellido")) + "|" + (sessionStorage.getItem("documento")) + "|" + (sessionStorage.getItem("legajo")) );        

        CargarGrillaServicios();
    });
});

$("#btn_Estado").click(function () {
    $('#cajaDatosExpLaboral').show();
    $('#tituloExpLaboral').html("Servicio de Administración Pública");
    

});
$("#btn_Privado").click(function () {
    $('#cajaDatosExpLaboral').show();
    $('#tituloExpLaboral').html("Servicio de Administración Privada");
});


    var CargarGrillaServicios = function () {
        //LimpiarPantalla();
        //var documento = $('#documento').text().trim();
        //var legajo = $('#legajo').text().trim();
        //if (documento == "") {
        //    documento = 0;
        //    legajo = 0;
        //    alert("Ingrese una persona");
        //    return;
        //}

        var documento = sessionStorage.getItem("documento");
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



