var PanelDeControl = {
    obtenerEstado: function (postulacion) {
        var fecha_comparacion;
        var etapa_seleccionada;

        if (postulacion.Etapas.length > 0) {
            fecha_comparacion = postulacion.Etapas[0].Fecha;
            etapa_seleccionada = postulacion.Etapas[0].Etapa.Descripcion;
            for (var i = 0; i < postulacion.Etapas.length; i++) {
                if (fecha_comparacion < postulacion.Etapas[i].Fecha) {
                    etapa_seleccionada = postulacion.Etapas[i].Etapa.Descripcion;
                }
            }
            return etapa_seleccionada;
        } else {
            return "Error";
        }
    },
    dibujarPostulacion: function (postulacion) {
        var _this = this;
        var pastilla = $('<div>');
        pastilla.addClass("feedPostulacionesAplicadas pastilla_postulaciones");

        var titulo = $('<a>');
        titulo.addClass('subtitulo_postulaciones');
        titulo.attr("href", 'FichaInscripcionCVDeclaJurada.aspx?id=' + postulacion.Id + "&fh=" + postulacion.FechaPostulacion);
        titulo.attr("target", "_blank");
        titulo[0].innerHTML = 'N°: ' + postulacion.Numero + ' (' + ConversorDeFechas.deIsoAFechaEnCriollo(postulacion.FechaPostulacion) + ')' + ' - Estado: ' + this.obtenerEstado(postulacion);


        var eliminar = $('<a>');
        //Sólo se puede eliminar si está en estado Preinscripcion Web
        if (this.obtenerEstado(postulacion) == "Preinscripción web") {
            eliminar.addClass('delete_postulaciones');

            var img = $('<img>');
            img.attr('src', '../Imagenes/icono_eliminar2.png');
            img.attr('width', '20px');
            img.attr('height', '20px');
            eliminar.append(img);

            eliminar.click(function () {
                var mensaje = "¿Está seguro que desea eliminar su postulación al puesto: " + postulacion.Perfil.Denominacion + "?";
                alertify.confirm("", mensaje, 
                    function () {
                        // user clicked "ok"
                        Backend.EliminarPostulacionPorUsuario(postulacion).onSuccess(function () {
                            _this.armarPostulaciones($.grep(_this.postulaciones, function (p) {
                                return p !== postulacion;
                            }));
                        });
                    }, 
                    function (){
                        alertify.error("No se ha eliminado la Postulación");
                    }
                );
            });
        };

        var sub = $('<hr>');
        sub.addClass("SubrayadoPostulaciones degrade");

        var contenido = $('<p>');
        // contenido[0].innerHTML = postulaciones[i].Puesto.Denominacion;
        contenido[0].innerHTML = postulacion.Perfil.Denominacion;
        pastilla.append(titulo);
        pastilla.append(eliminar);
        pastilla.append(sub);
        pastilla.append(contenido);

        _this.divGrilla.append(pastilla);
    },
    armarPostulaciones: function (postulaciones) {
        var _this = this;
        this.postulaciones = postulaciones;
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
        this.divGrilla.empty();
        if (postulaciones.length > 0) {

            for (var i = 0; i < postulaciones.length; i++) {
                this.dibujarPostulacion(postulaciones[i]);
            }
        }
        else {
            var pastilla = $('<div>');
            pastilla.addClass("feedPostulacionesAplicadas pastilla_postulaciones");

            var titulo = $('<div>');
            titulo.addClass('mensaje_postulaciones');
            titulo[0].innerHTML = 'No posee postulaciones vigentes';
            pastilla.append(titulo);
            _this.divGrilla.append(pastilla);
        }
    }
}


