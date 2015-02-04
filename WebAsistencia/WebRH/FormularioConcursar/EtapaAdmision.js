var PantallaEtapaDeAdmision = {

    HabilitarBuscarComite: function () {
        if ($('#id_comite').val() == "") {
            $('#id_perfil').prop("disabled", true);
            $('#btn_filtrar').prop("disabled", true);
        } else {
            $('#id_perfil').prop("disabled", false);
            $('#btn_filtrar').prop("disabled", false);
            this.BuscarInscriptos();
        }

    },

    BuscarInscriptos: function () {
        var id_comite = $('#id_comite').val();
        var _this = this;
        Backend.BuscarPostulacionesDeInscriptos(id_comite)
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
        $("#search").show();
        $("#tabla_postulaciones").empty();
        var divGrilla = $('#tabla_postulaciones');

        var columnas = [];
        columnas.push(new Columna("NroPostulación", { generar: function (una_postulacion) { return una_postulacion.Numero } }));
        columnas.push(new Columna("Postulante", { generar: function (una_postulacion) { return una_postulacion.IdPersona } }));
        columnas.push(new Columna("NroPerfil", { generar: function (una_postulacion) { return una_postulacion.Perfil.Numero } }));
        columnas.push(new Columna("Nivel", { generar: function (una_postulacion) { return una_postulacion.Perfil.Nivel } }));
        columnas.push(new Columna("Tipo", { generar: function (una_postulacion) { return una_postulacion.Perfil.Tipo } }));
        columnas.push(new Columna("Perfil", { generar: function (una_postulacion) { return una_postulacion.Perfil.Denominacion } }));
        columnas.push(new Columna("Estado", { generar: function (una_postulacion) { return _this.EstadoDeLaEtapa(una_postulacion) } }));


        columnas.push(new Columna('Cambiar', {
            generar: function (una_postulacion) {
                var btn_accion = $('<a>');
                var img = $('<img>');
                img.attr('src', '../Imagenes/cambiar.png');
                img.attr('width', '25px');
                img.attr('height', '25px');
                btn_accion.append(img);
                btn_accion.click(function () {
                    CambiarEstadoPostulacion(una_postulacion);
                });

                return btn_accion;
            }
        }));

        this.GrillaDePostulaciones = new Grilla(columnas);
        this.GrillaDePostulaciones.AgregarEstilo("cuerpo_tabla_perfil tr td");
        this.GrillaDePostulaciones.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
        this.GrillaDePostulaciones.SetOnRowClickEventHandler(function (un_perfil) { });


        this.GrillaDePostulaciones.CargarObjetos(postulaciones);
        this.GrillaDePostulaciones.DibujarEn(divGrilla);

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

    CambiarEstadoPostulacion: function (una_postulacion) {

    },

    BuscadorDeTabla: function () {
        var options = {
            valueNames: ['NroPostulación', 'NroPerfil', 'Nivel', 'Tipo', 'Perfil', 'Estado']
        };

        var featureList = new List('contenedorTabla', options);
    },

    EstadoDeLaEtapa: function (una_postulacion) {

        return "Sin Dictamen";
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
    }

}


