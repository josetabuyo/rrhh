var EtapaInscripcionDocumental = {
    mostrarPostulacion: function (postulacion) {
        var _this = this;

        /* var postulacion = getVarsUrl();

        var proveedor_ajax = new ProveedorAjax();

        proveedor_ajax.postearAUrl({ url: "GetPostulacionById",
        data: {
        idpostulacion: parseInt(postulacion.id)
        },
        success: function (respuesta) {

        //alertify.alert("El id de la postulacion es: " + respuesta.Id);
        _this.dibujarPuesto(respuesta);
        _this.dibujarCV(curriculum);

        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
        alertify.alert("Error en la postulacion seleccionada.");
        }
        }); //FIN AJAX*/

        var nombre_perfil = $("#nombre_perfil");
        nombre_perfil[0].innerHTML = postulacion.Puesto.Denominacion;

         
        if (postulacion.Puesto.DocumentacionRequerida.length > 0) {
            var div_caja_foliables = $('#detalle_foliables');
            for (var i = 0; i < postulacion.Puesto.DocumentacionRequerida.length; i++) {
                var descripcion_foliable = $('<p>');
                descripcion_foliable.text(postulacion.Puesto.DocumentacionRequerida[i].Descripcion);

                div_caja_foliables.append(descripcion_foliable);
            }

        }

    }
}





