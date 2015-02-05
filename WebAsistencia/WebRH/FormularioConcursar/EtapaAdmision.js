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
                _this.CargarIntegrantesComite(postulaciones[0]);
                _this.DibujarTabla(postulaciones);
                _this.BuscadorDeTabla();
                _this.CargarComboPerfiles(postulaciones);

            }
            _this.postulaciones = postulaciones;
        });
    },

    CargarIntegrantesComite: function (postulacion) {
        var integrantes = postulacion.Perfil.Comite.Integrantes;
        var titulares = "";
        var suplentes = "";
        for (var i = 0; i < integrantes.length; i++) {
            if (integrantes[i].EsTitular) {
                titulares = titulares + integrantes[i].Apellido + ", " + integrantes[i].Nombre + " - ";
            } else {
                suplentes = titulares + integrantes[i].Apellido + ", " + integrantes[i].Nombre + " - ";
            }
        };

        $('#comite_titular').text(titulares.substring(0, titulares.length - 2));
        $('#comite_suplente').text(suplentes.substring(0, suplentes.length - 2));

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
                    _this.CambiarEstadoPostulacion(una_postulacion);
                });

                return btn_accion;
            }
        }));

        this.GrillaDePostulaciones = new Grilla(columnas);
        this.GrillaDePostulaciones.AgregarEstilo("cuerpo_tabla_perfil tr td");
        this.GrillaDePostulaciones.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
        this.AgregarEstilosEstado();
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

    AgregarEstilosEstado: function (){
    
    },

    BuscadorDeTabla: function () {
        var options = {
            valueNames: ['NroPostulación', 'NroPerfil', 'Nivel', 'Tipo', 'Perfil', 'Estado']
        };

        var featureList = new List('contenedorTabla', options);
    },

    EstadoDeLaEtapa: function (una_postulacion) {

        //This will sort your array
        function OrdenarPorFechas(etapa1, etapa2) {
            var etapa1 = etapa1.Fecha;
            var etapa2 = etapa2.Fecha;
            return ((etapa1 < etapa2) ? -1 : ((etapa1 > etapa2) ? 1 : 0));
        }

        una_postulacion.Etapas.sort(OrdenarPorFechas);

        return una_postulacion.Etapas[una_postulacion.Etapas.length - 1].Etapa.Descripcion
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


