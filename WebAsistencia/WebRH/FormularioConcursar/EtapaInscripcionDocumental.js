var PantallaEtapaDeInscripcion = {

    HabilitarBuscarComite: function () {
        if ($('#id_comite').val() == "") {
            $('#id_perfil').prop("disabled", true);
            $('#btn_filtrar').prop("disabled", true);
        } else {
            $('#id_perfil').prop("disabled", false);
            $('#btn_filtrar').prop("disabled", false);
            this.BuscarPreInscriptos();
        }

    },

    BuscarPreInscriptos: function () {
        var id_comite = $('#id_comite').val();
        var _this = this;
        Backend.BuscarPostulacionesDePreInscriptos(id_comite)
        .onSuccess(function (postulaciones) {
            if (postulaciones.length == 0) {
                alertify.alert('No se encontraron resultados');
            } else {
                //        buscar todos los titulares y seplentes del comité y listarlos - Continuar
                $('#comite_titular').text(postulaciones[0].Perfil.Comite.Integrantes[0].Apellido);

                _this.DibujarTabla(postulaciones);
                _this.BuscadorDeTabla();
                _this.CargarComboPerfiles(postulaciones);

            }
            _this.postulaciones = postulaciones;
        });
    },

    DibujarTabla: function (postulaciones) {
        var _this = this;

        var ultima_posicion = postulaciones[0].Etapas.length - 1;
        var id_etapa_actual = postulaciones[0].Etapas[ultima_posicion].Etapa.Id;

        $("#search").show();
        $("#tabla_postulaciones").empty();
        var divGrilla = $('#tabla_postulaciones');

        var columnas = [];
        columnas.push(new Columna("NroPostulación", { generar: function (una_postulacion) { return una_postulacion.Numero } }));
        columnas.push(new Columna("Postulante", { generar: function (una_postulacion) { return una_postulacion.Postulante.Apellido + ", " + una_postulacion.Postulante.Nombre } }));
        columnas.push(new Columna("NroPerfil", { generar: function (una_postulacion) { return una_postulacion.Perfil.Numero } }));
        columnas.push(new Columna("Nivel", { generar: function (una_postulacion) { return una_postulacion.Perfil.Nivel } }));
        columnas.push(new Columna("Tipo", { generar: function (una_postulacion) { return una_postulacion.Perfil.Tipo } }));
        columnas.push(new Columna("Perfil", { generar: function (una_postulacion) { return una_postulacion.Perfil.Denominacion } }));
        columnas.push(new Columna("Estado", { generar: function (una_postulacion) {
            var ultima_posicion = una_postulacion.Etapas.length - 1;
            return una_postulacion.Etapas[ultima_posicion].Etapa.Descripcion;
        }
        }));
        columnas.push(new Columna('Inscribir', {
            generar: function (una_postulacion) {
                var input = $('<input>');
                input.attr('type', 'checkbox');
                input.attr('class', 'check');
                return input;
            }
        }));

        this.GrillaDePostulaciones = new Grilla(columnas);
        this.GrillaDePostulaciones.AgregarEstilo("cuerpo_tabla_perfil tr td");
        this.GrillaDePostulaciones.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
        this.GrillaDePostulaciones.SetOnRowClickEventHandler(function (un_perfil) { });


        this.GrillaDePostulaciones.CargarObjetos(postulaciones);
        this.GrillaDePostulaciones.DibujarEn(divGrilla);

        var check_gral = $('<input>');
        check_gral.attr('id', 'check_gral');
        check_gral.attr('type', 'checkbox');
        //check_gral.attr('onclick', 'checkTodos();');

        check_gral.click(function () {
            _this.MarcarCheckboxGral();
        });

        $('#btn_generar_anexo').click(function () {
            _this.CambiarEstadoPostulacion(id_etapa_actual);
        })

        $("#txt_marcar_todos").html('Marcar todos: ');
        $("#txt_marcar_todos").append(check_gral);

        $("#btn_generar_anexo").attr("style", "display:inline");

    },


    FiltrarPorPerfil: function () {
        var postulaciones = this.postulaciones;
        var postulaciones_filtradas = [];
        if ($('#id_perfil').val() === "Todos") {
            postulaciones_filtradas = this.postulaciones;
        } else {
            for (var i = 0; i < postulaciones.length; i++) {
                if ((postulaciones[i].Perfil.Numero + " - " + postulaciones[i].Perfil.Denominacion).replace(/\s/g, '') === $('#id_perfil').val().replace(/\s/g, '')) {
                    postulaciones_filtradas.push(postulaciones[i]);
                }
            }
        }

        this.DibujarTabla(postulaciones_filtradas);

    },

    CambiarEstadoPostulacion: function (id_etapa) {
        var postulaciones = [];

        $(".check").each(function () {
            if ($(this)[0].checked == true) {
                var postulacion = {};
                postulacion.Id = $(this).parent().parent()[0].cells[0].innerHTML;

                postulaciones.push(postulacion);
            }
        });

        if (postulaciones.length > 0) {
            Backend.PasarEtapaAPostulaciones(postulaciones, id_etapa)
             .onSuccess(function (resultado) {
                 if (resultado == true) {
                     alertify.alert('Las postulaciones pasaron a la etapa de Admisión');
                 } else {
                     alertify.alert('Hubo un error en el guardado. ');
                 }

                 //location.reload();
             })
            .onError(function (error) {
                alertify.error(error.statusText);
            });
        } else {
            alertify.alert('No ha seleccionado a nadie del listado.');
        }




    },

    BuscadorDeTabla: function () {
        var options = {
            valueNames: ['NroPostulación', 'NroPerfil', 'Nivel', 'Tipo', 'Perfil', 'Estado']
        };

        var featureList = new List('contenedorTabla', options);
    },

    CargarComboPerfiles: function (postulaciones) {

        $("#id_perfil").append("<option>Todos</option>")
        var perfiles = [];

        for (var i = 0; i < postulaciones.length; i++) {
            var texto_perfil = postulaciones[i].Perfil.Numero + " - " + postulaciones[i].Perfil.Denominacion;
            perfiles.push(texto_perfil);
            if (jQuery.inArray(texto_perfil, perfiles) !== -1) {
                $("#id_perfil").append("<option>" + texto_perfil + "</option>");
            }

        }
    },

    MarcarCheckboxGral: function () {
        if ($('#check_gral')[0].checked == true) {
            $(".check").each(function () {
                $(this).prop('checked', true);
            });
        } else {
            $(".check").each(function () {
                $(this).prop('checked', false);
            });
        }
    }

}


