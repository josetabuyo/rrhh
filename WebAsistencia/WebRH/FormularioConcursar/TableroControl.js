var PantallaEtapaDeTableroControl = {

    InicializarPantalla: function (tablero) {
        var _this = this;
        _this.tablero = tablero;
        _this.DibujarTabla(tablero);
    },

    DibujarTabla: function (tablero) {
        var _this = this;
        $("#tabla_postulaciones").empty();
        var divGrilla = $('#tabla_postulaciones');

        var columnas = [];
        //columnas.push(new Columna("Perfil", { generar: function (un_tablero) { return un_tablero.IdPerfil } }));
        columnas.push(new Columna("DescDePerfil", { generar: function (un_tablero) { return un_tablero.DescripcionPerfil } }));
        columnas.push(new Columna("Comite", { generar: function (un_tablero) { return un_tablero.NumeroComite } }));
        columnas.push(new Columna("A. Postulados", { generar: function (un_tablero) { return un_tablero.Postulados } }));
        columnas.push(new Columna("B. Inscriptos", { generar: function (un_tablero) { return un_tablero.Inscriptos } }));

        this.GrillaDePostulaciones = new Grilla(columnas);
        this.GrillaDePostulaciones.AgregarEstilo("cuerpo_tabla_perfil tr td");
        this.GrillaDePostulaciones.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
        this.GrillaDePostulaciones.SetOnRowClickEventHandler(function (un_tablero) { });


        this.GrillaDePostulaciones.CargarObjetos(tablero);
        this.GrillaDePostulaciones.DibujarEn(divGrilla);
        _this.BuscadorDeTabla();
        $("#btn_generar_anexo").attr("style", "display:inline");

    },

    BuscadorDeTabla: function () {
        var options = {
            valueNames: ['Perfil', 'Postulacion', 'DNI', 'Nombre', 'Apellido']
        };

        var featureList = new List('contenedorTabla', options);
    },



    FiltrarPorComite: function () {
        var tablero = this.tablero;
        var tablero_filtrado = [];
        var comite = $('#filtrar_comite').val();
        if (comite === "") {
            tablero_filtrado = tablero;
        } else {
            for (var i = 0; i < tablero.length; i++) {
                if (tablero[i].NumeroComite == comite) {
                    tablero_filtrado.push(tablero[i]);
                };
            };
        };
        this.DibujarTabla(tablero_filtrado);
    },
    traerPostulaciones: function () {
        var _this = this;
        Backend.TraerReporteDePostulaciones()
                .onSuccess(function (postulacionesArray) {

                    var postulaciones = JSON.parse(postulacionesArray);
                    
                    $("#tabla_postulaciones").empty();
                    var divGrilla = $('#tabla_postulaciones');

                    var columnas = [];

                    columnas.push(new Columna("Perfil", { generar: function (un_tablero) { return un_tablero.nombrePerfil } }));
                    columnas.push(new Columna("Postulacion", { generar: function (un_tablero) { return un_tablero.numero } }));
                    columnas.push(new Columna("Fecha", { generar: function (un_tablero) { return ConversorDeFechas.deIsoAFechaEnCriollo(un_tablero.fechaInscripcion) } }));
                    columnas.push(new Columna("DNI", { generar: function (un_tablero) { return un_tablero.documento } }));
                    columnas.push(new Columna("Nombre", { generar: function (un_tablero) { return un_tablero.nombre } }));
                    columnas.push(new Columna("Apellido", { generar: function (un_tablero) { return un_tablero.apellido } }));
                    columnas.push(new Columna("Informes GDE", { generar: function (un_tablero) {
                        var informesConcatenados = '';
                        for (var i = 0; i < un_tablero.informes.length; i++) {
                            informesConcatenados += '<b>Informe ' + (i+1) + ':</b> ' + un_tablero.informes[i] + '. ';
                        }
                        return informesConcatenados


                    }
                    }));

                    this.GrillaDePostulaciones = new Grilla(columnas);
                    this.GrillaDePostulaciones.AgregarEstilo("cuerpo_tabla_perfil tr td");
                    this.GrillaDePostulaciones.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
                    this.GrillaDePostulaciones.SetOnRowClickEventHandler(function (un_tablero) { });


                    this.GrillaDePostulaciones.CargarObjetos(postulaciones);
                    this.GrillaDePostulaciones.DibujarEn(divGrilla);
                    _this.BuscadorDeTabla();

                })
            .onError(function (e) {

            });

    }
}


