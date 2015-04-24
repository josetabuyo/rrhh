var PantallaEtapaDeTableroControl = {

    DibujarTabla: function (postulaciones) {
        var _this = this;
        $("#search").show();
        $("#tabla_postulaciones").empty();
        var divGrilla = $('#tabla_postulaciones');

        var columnas = [];
        columnas.push(new Columna("Perfil", { generar: function (una_postulacion) { return una_postulacion.Numero } }));
        columnas.push(new Columna("Descripción de Perfil", { generar: function (una_postulacion) { return una_postulacion.Postulante.Apellido + ", " + una_postulacion.Postulante.Nombre } }));
        columnas.push(new Columna("Comité", { generar: function (una_postulacion) { return una_postulacion.Perfil.Numero } }));
        columnas.push(new Columna("A. Postulados", { generar: function (una_postulacion) { return una_postulacion.Perfil.Nivel } }));
        columnas.push(new Columna("B. Inscriptos", { generar: function (una_postulacion) { return una_postulacion.Perfil.Tipo } }));
        
        this.GrillaDePostulaciones = new Grilla(columnas);
        this.GrillaDePostulaciones.AgregarEstilo("cuerpo_tabla_perfil tr td");
        this.GrillaDePostulaciones.CambiarEstiloCabecera("cabecera_tabla_pantalla_cargos");
        this.GrillaDePostulaciones.SetOnRowClickEventHandler(function (un_perfil) { });


        this.GrillaDePostulaciones.CargarObjetos(postulaciones);
        this.GrillaDePostulaciones.DibujarEn(divGrilla);

        $("#btn_generar_anexo").attr("style", "display:inline");

    },

    BuscadorDeTabla: function () {
        var options = {
            valueNames: ['NroPostulación', 'NroPerfil', 'Nivel', 'Tipo', 'Perfil', 'Estado']
        };

        var featureList = new List('contenedorTabla', options);
    }


}


