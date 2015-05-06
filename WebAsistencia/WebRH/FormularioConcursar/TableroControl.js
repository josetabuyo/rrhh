var PantallaEtapaDeTableroControl = {

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
            valueNames: ['DescDePerfil', 'Comite']
        };

        var featureList = new List('contenedorTabla', options);
    }

}


