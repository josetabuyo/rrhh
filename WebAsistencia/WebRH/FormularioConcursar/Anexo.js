var Anexo = {
    armarAnexo: function () {
        var _this = this;
        var curriculum = JSON.parse($('#curriculum').val());

        var postulacion = JSON.parse($('#postulacion').val()); // getVarsUrl();

        _this.completar(postulacion, curriculum);
        Curriculum.dibujarCV(curriculum);
        //_this.dibujarCV(curriculum);

    },
    completar: function (postulacion, curriculum) {
        var _this = this;
        _this.postulacion_numero = $("#num_postulacion");
        _this.postulacion_numero.text(postulacion.Numero);
        _this.puesto_convocatoria = $("#puesto_tipo");
        _this.puesto_convocatoria.text(postulacion.Perfil.Tipo);
        _this.puesto_denominacion = $("#puesto_denominacion");
        _this.puesto_denominacion.text(postulacion.Perfil.Denominacion);
        _this.puesto_agrupamiento = $("#puesto_agrupamiento");
        _this.puesto_agrupamiento.text(postulacion.Perfil.Agrupamiento);
        _this.puesto_nivel = $("#nivel_escalafonario");
        _this.puesto_nivel.text(postulacion.Perfil.Nivel);
        _this.puesto_secretaria = $("#nivel_jefatura");
        _this.puesto_secretaria.text("");

        _this.jurisdiccion = $("#jurisdiccion");
        _this.jurisdiccion.text("Ministerio de Desarrollo Social de la Nación");
        _this.secretaria = $("#secretaria");
        _this.secretaria.text("");
        _this.direccion = $("#direccion");
        _this.direccion.text("");
        _this.domicilio_lugar_de_trabajo = $("#domicilio_lugar_de_trabajo");
        _this.domicilio_lugar_de_trabajo.text("Av 9 de Julio");
        _this.apellido_y_nombre = $("#apellido_y_nombre");
        _this.apellido_y_nombre.text(curriculum.DatosPersonales.Nombre + ' ' + curriculum.DatosPersonales.Apellido);
        _this.documento = $("#documento");
        _this.documento.text('DNI ' + curriculum.DatosPersonales.Dni);
        _this.domicilio_personal = $("#domicilio_personal");

        //var localidadPersonal = Backend.ejecutarSincronico("BuscarLocalidades", [{ Id: curriculum.DatosPersonales.DomicilioPersonal.Localidad}])[0];
        var provinciaPersonal = Backend.ejecutarSincronico("BuscarProvincias", [{ Id: curriculum.DatosPersonales.DomicilioPersonal.Provincia}])[0];

        _this.domicilio_personal.text(curriculum.DatosPersonales.DomicilioPersonal.Calle + ' ' + curriculum.DatosPersonales.DomicilioPersonal.Numero
                                        + '. ' + provinciaPersonal.Nombre);
        _this.domicilio_legal = $("#domicilio_legal");


        var localidadLegal = Backend.ejecutarSincronico("BuscarLocalidades", [{ Id: curriculum.DatosPersonales.DomicilioLegal.Localidad}])[0];
        var provinciaLegal = Backend.ejecutarSincronico("BuscarProvincias", [{ Id: curriculum.DatosPersonales.DomicilioLegal.Provincia}])[0];

        if (!localidadLegal) {
            localidadLegal = {};
            localidadLegal.Nombre =  'Sin Localidad';
        }

        if (!provinciaLegal) {
            provinciaLegal = {};
            provinciaLegal.Nombre = 'Sin Provincia';
        }

        _this.domicilio_legal.text("DOMICILIO: " + curriculum.DatosPersonales.DomicilioLegal.Calle + ' ' + curriculum.DatosPersonales.DomicilioLegal.Numero + '. C (' + curriculum.DatosPersonales.DomicilioLegal.Cp + ') ' +
                                    localidadLegal.Nombre + ' ' + provinciaLegal.Nombre);

        _this.telefono = $("#telefono");
        _this.telefono.text(curriculum.DatosPersonales.DatosDeContacto.Telefono);
        _this.mail = $("#mail");
        $("#correo_electronico").append(' ' + curriculum.DatosPersonales.DatosDeContacto.Email);
        //_this.mail.text(curriculum.DatosPersonales.DatosDeContacto.Email);
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



