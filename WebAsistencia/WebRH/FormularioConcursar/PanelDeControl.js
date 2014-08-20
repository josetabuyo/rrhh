var PanelDeControl = {
    armarPostulaciones: function (postulaciones) {
        var _this = this;

        //_this.divListado = $('#listado_puestos');
        _this.divGrilla = $('#tabla_postulaciones');

        /* var columnas = [];

        columnas.push(new Columna("Puesto", { generar: function (una_postulacion) { return una_postulacion.Puesto.Denominacion } }));
        columnas.push(new Columna("Fecha", { generar: function (una_postulacion) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_postulacion.FechaPostulacion) } }));
        
        this.GrillaDePostulaciones = new Grilla(columnas);
        this.GrillaDePostulaciones.AgregarEstilo("table table-striped");
        this.GrillaDePostulaciones.SetOnRowClickEventHandler(function (una_postulacion) {
        window.location.href = 'FichaInscripcionCVDeclaJurada.aspx?id=' + una_postulacion.Id;
        });

        this.GrillaDePostulaciones.CargarObjetos(postulaciones);
        this.GrillaDePostulaciones.DibujarEn(_this.divGrilla);

       
        var listado_de_pastillas = "";*/

        for (var i = 0; i < postulaciones.length; i++) {
            var pastilla = $('<div>');
            pastilla.addClass("feedPostulacionesAplicadas pastilla_postulaciones");

            var titulo = $('<a>');
            titulo.addClass('subtitulo_postulaciones');
            titulo.attr("href", 'FichaInscripcionCVDeclaJurada.aspx?id=' + postulaciones[i].Id)
            titulo[0].innerHTML = ConversorDeFechas.deIsoAFechaEnCriollo(postulaciones[i].FechaPostulacion);
            //titulo[0].puesto = postulaciones[i].Puesto;


            /*titulo.click(function (e) {
            window.location.href = 'FichaInscripcionCVDeclaJurada.aspx?id=' + titulo[0].puesto.Id;
                    
            });*/
            var sub = $('<hr>');
            sub.addClass("SubrayadoPostulaciones degrade");

            var contenido = $('<p>');
            contenido[0].innerHTML = postulaciones[i].Puesto.Denominacion;

            pastilla.append(titulo);
            pastilla.append(sub);
            pastilla.append(contenido);

            _this.divGrilla.append(pastilla);
        }
    }
}


