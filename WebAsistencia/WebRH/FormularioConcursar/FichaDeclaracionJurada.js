var FichaDeclaracionJurada = {
    armarFicha: function () {
        var _this = this;
        var curriculum = JSON.parse($('#curriculum').val());

        var postulacion = getVarsUrl();

        var proveedor_ajax = new ProveedorAjax();

        proveedor_ajax.postearAUrl({ url: "GetPostulacionById",
            data: {
                idpostulacion: parseInt(postulacion.id)
            },
            success: function (respuesta) {

                //alertify.alert("", "El id de la postulacion es: " + respuesta.Id);
                _this.dibujarPuesto(respuesta);
                Curriculum.dibujarCV(curriculum);
                //_this.dibujarCV(curriculum);

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert("", "Error en la postulacion seleccionada.");
            }
        }); //FIN AJAX
    },
    dibujarPuesto: function (postulacion) {
        var _this = this;
        //var curriculum = JSON.parse($('#curriculum').val());
        _this.postulacion_numero = $("#num_postulacion");
        _this.postulacion_numero.text(postulacion.Numero);
        _this.puesto_numero = $("#numero_puesto");
        _this.puesto_numero.text(postulacion.Perfil.Numero);
        _this.puesto_convocatoria = $("#puesto_tipo");
        _this.puesto_convocatoria.text(postulacion.Perfil.Tipo);
        _this.puesto_denominacion = $("#puesto_denominacion");
        _this.puesto_denominacion.text(postulacion.Perfil.Denominacion);
        _this.puesto_agrupamiento = $("#puesto_agrupamiento");
        _this.puesto_agrupamiento.text(postulacion.Perfil.Agrupamiento);
        _this.puesto_nivel = $("#puesto_nivel");
        _this.puesto_nivel.text(postulacion.Perfil.Nivel);
        _this.puesto_secretaria = $("#puesto_jefatura");
        _this.puesto_secretaria.text("Secretaria");

        for (var i = 0; i < postulacion.NumerosDeInformeGDE.length; i++) {
            $("#num_informes").append(postulacion.NumerosDeInformeGDE[i] + ', ');
        }
       

        _this.motivo_postulacion = $("#motivo_postulacion");
        _this.motivo_postulacion.text(postulacion.Motivo);


    }

}


 function getVarsUrl() {
          var url = location.search.replace("?", "");
          var arrUrl = url.split("&");
          var urlObj = {};
          for (var i = 0; i < arrUrl.length; i++) {
              var x = arrUrl[i].split("=");
              urlObj[x[0]] = x[1]
          }
          return urlObj;
      }



