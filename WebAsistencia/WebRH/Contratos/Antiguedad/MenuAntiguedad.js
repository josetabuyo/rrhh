
Backend.start(function () {
    $(document).ready(function () {

        //alert("Entro"); //GERMAN
        alert(sessionStorage.getItem("nombre") + " " + (sessionStorage.getItem("apellido")) + "|" + (sessionStorage.getItem("documento")) + "|" + (sessionStorage.getItem("legajo")) );        

        CargarGrillaServicios();
    });
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
        ConsultarServicioAdmPublica(documento);
        ConsultarServicioAdmPrivada(documento);
    };


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


    var ConsultarServicioAdmPrivada = function (documento) {
        spinner = new Spinner({ scale: 2 }).spin($("body")[0]);

        Backend.GetServicios_Adm_Privada_Principal(documento)
            .onSuccess(function (respuesta) {
                lista_de_serv_privada = respuesta;
                DibujarGrillaServPrivado();
                spinner.stop();
            })
            .onError(function (error, as, asd) {
                alertify.alert("", error);
                spinner.stop();
                LimpiarPantalla();
            });
    };



    //---------- GRILLA ADM. PUBLICA --------------------------------
    var DibujarGrillaServPublico = function () {
        var grilla;
        ContenedorGrilla = $("#tabla_Serv_Adm_Publico");
        ContenedorGrilla.html("");
        
        grilla = new Grilla(
            [
                new Columna("Id", { generar: function (consulta) { return consulta.Id; } }),
                new Columna("Ambito", { generar: function (consulta) { return consulta.Ambito.Descripcion; } }),
                new Columna("Jurisdiccion", { generar: function (consulta) { return consulta.Jurisdiccion; } }),
                new Columna("Folio", { generar: function (consulta) { return consulta.Folio; } }),
                new Columna("Caja", { generar: function (consulta) { return consulta.Caja; } }),
                new Columna("Afiliado", { generar: function (consulta) { return consulta.Afiliado; } }),

                new Columna("Modif.", {
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
                                alert("Mostrar pantalla de datos para cargar FOLIO: " + consulta.Folio + " - ADM PUBLICA");
                                //window.open("CargaDeAntiguedadesAdmPublicaPrivada.aspx?legajo=" + $('#legajo').text().trim() + "&documento=" + $('#documento').text().trim() + "&folio=" + consulta.Folio + "&servicio=" + botonSeleccionado);
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
    //---------- GRILLA ADM. PUBLICA --------------------------------


    //---------- GRILLA ADM. PRIVADA --------------------------------
    var DibujarGrillaServPrivado = function () {
        var grilla;
        ContenedorGrilla = $("#tabla_Serv_Adm_Privada");
        ContenedorGrilla.html("");
        
        grilla = new Grilla(
            [
                new Columna("Id", { generar: function (consulta) { return consulta.Id; } }),
                new Columna("Ambito", { generar: function (consulta) { return consulta.Ambito.Descripcion; } }),
                new Columna("Razon Social", { generar: function (consulta) { return consulta.Organismo; } }),
                new Columna("Folio", { generar: function (consulta) { return consulta.Folio; } }),
                new Columna("Caja", { generar: function (consulta) { return consulta.Caja; } }),
                new Columna("Afiliado", { generar: function (consulta) { return consulta.Afiliado; } }),

                new Columna("Modif.", {
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
                                //window.open("CargaDeAntiguedadesAdmPublicaPrivada.aspx?legajo=" + $('#legajo').text().trim() + "&documento=" + $('#documento').text().trim() + "&folio=" + consulta.Folio + "&servicio=" + botonSeleccionado);
                                spinner.stop();
                                alert("Mostrar pantalla de datos para cargar FOLIO: " + consulta.Folio + " - ADM PRIVADA");
                            }, 10);

                        });
                        cont.append(btn_accion);
                        return cont;
                    }
                }),
            ]);

        grilla.CargarObjetos(lista_de_serv_privada);
        grilla.DibujarEn(ContenedorGrilla);

        grilla.SetOnRowClickEventHandler(function () {
            return true;
        });

    };
    //---------- GRILLA ADM. PRIVADA --------------------------------



