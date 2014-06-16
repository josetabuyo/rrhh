var CvDatosPersonales = {
    completarDatos: function (datos_personales) {
        var _this = this;

       // var datos_personales = JSON.parse(datosPersonales);
        
        this.ui = $("#contenedor_datosPersonales");
        _this.txt_nombre = _this.ui.find("#nombre");
        _this.txt_apellido = _this.ui.find("#apellido");
        _this.cmb_sexo = _this.ui.find("#cmb_sexo");
        _this.cmb_estadoCivil = _this.ui.find("#cmb_estadoCivil");
        _this.txt_cuil = _this.ui.find("#cuil");
        _this.cmb_lugar_nac = _this.ui.find("#cmb_lugar_nacimiento");
        _this.txt_fechaNac = _this.ui.find("#txt_fechaNac");
        _this.cmb_nacionalidad = _this.ui.find("#cmb_nacionalidad");
        _this.cmb_tipoDocumento = _this.ui.find("#cmb_tipoDocumento");
        _this.txt_dni = _this.ui.find("#txt_documento");

        _this.txt_nombre.val(datos_personales.Nombre);
        _this.txt_apellido.val(datos_personales.Apellido);
        _this.cmb_sexo.val(datos_personales.Sexo);
        _this.cmb_estadoCivil.val(datos_personales.EstadoCivil);
        _this.txt_cuil.val(datos_personales.Cuil);
        _this.cmb_lugar_nac.val(datos_personales.LugarDeNacimiento);
        _this.txt_fechaNac.val(datos_personales.FechaNacimiento);
        _this.cmb_nacionalidad.val(datos_personales.Nacionalidad);
        _this.cmb_tipoDocumento.val(datos_personales.TipoDocumento);
        _this.txt_dni.val(parseInt(datos_personales.Dni));

        //DomicilioPersonal
        _this.txt_domicilio_personal_calle = _this.ui.find("#txt_calle1");
        _this.txt_domicilio_personal_numero = _this.ui.find("#txt_numero1");
        _this.txt_domicilio_personal_piso = _this.ui.find("#txt_piso1");
        _this.txt_domicilio_personal_dto = _this.ui.find("#txt_dto1");
        _this.txt_domicilio_personal_localidad = _this.ui.find("#txt_localidad1");
        _this.txt_domicilio_personal_cp = _this.ui.find("#txt_cp1");
        _this.txt_domicilio_personal_provincia = _this.ui.find("#cmb_provincia1");

        _this.txt_domicilio_personal_calle.val(datos_personales.DomicilioPersonal.Calle);
        _this.txt_domicilio_personal_numero.val(parseInt(datos_personales.DomicilioPersonal.Numero));
        _this.txt_domicilio_personal_piso.val(parseInt(datos_personales.DomicilioPersonal.Piso));
        _this.txt_domicilio_personal_dto.val(datos_personales.DomicilioPersonal.Depto);
        _this.txt_domicilio_personal_localidad.val(datos_personales.DomicilioPersonal.Localidad);
        _this.txt_domicilio_personal_cp.val(parseInt(datos_personales.DomicilioPersonal.Cp));
        _this.txt_domicilio_personal_provincia.val(datos_personales.DomicilioPersonal.Provincia);


        //DomicilioLaboral
        _this.txt_domicilio_legal_calle = _this.ui.find("#text_calle2");
        _this.txt_domicilio_legal_numero = _this.ui.find("#txt_numero2");
        _this.txt_domicilio_legal_piso = _this.ui.find("#txt_piso2");
        _this.txt_domicilio_legal_dto = _this.ui.find("#txt_dto2");
        _this.txt_domicilio_legal_localidad = _this.ui.find("#txt_localidad2");
        _this.txt_domicilio_legal_cp = _this.ui.find("#txt_cp2");
        _this.txt_domicilio_legal_provincia = _this.ui.find("#cmb_provincia2");
        _this.txt_domicilio_legal_telefonoFijo = _this.ui.find("#txt_telefonoFijo");
        _this.txt_domicilio_legal_telefonoCelular = _this.ui.find("#txt_telefonoCelular");
        _this.txt_domicilio_legal_mail = _this.ui.find("#txt_email");

        _this.txt_domicilio_legal_calle.val(datos_personales.DomicilioLegal.Calle);
        _this.txt_domicilio_legal_numero.val(parseInt(datos_personales.DomicilioLegal.Numero));
        _this.txt_domicilio_legal_piso.val(parseInt(datos_personales.DomicilioLegal.Piso));
        _this.txt_domicilio_legal_dto.val(datos_personales.DomicilioLegal.Depto);
        _this.txt_domicilio_legal_localidad.val(datos_personales.DomicilioLegal.Localidad);
        _this.txt_domicilio_legal_cp.val(parseInt(datos_personales.DomicilioLegal.Cp));
        _this.txt_domicilio_legal_provincia.val(datos_personales.DomicilioLegal.Provincia);
        _this.txt_domicilio_legal_telefonoFijo.val(datos_personales.DomicilioLegal.TelefonoFijo);
        _this.txt_domicilio_legal_telefonoCelular.val(datos_personales.DomicilioLegal.TelefonoCelular);
        _this.txt_domicilio_legal_mail.val(datos_personales.DomicilioLegal.Mail);

        //Bt gaurdar
        _this.add_datosPersonales = _this.ui.find("#btn_guardar_datosPersonales");
        _this.add_datosPersonales.click(function () {
            var datos_personales_nuevo = {};
            var domicilioPersonal_nuevo = {};
            var domicilioLegal_nuevo = {};
            datos_personales_nuevo.Nombre = _this.txt_nombre.val();
            datos_personales_nuevo.Apellido = _this.txt_apellido.val();
            datos_personales_nuevo.Sexo = _this.cmb_sexo.val();
            //datos_personales_nuevo.NivelEducat
            datos_personales_nuevo.EstadoCivil = _this.cmb_estadoCivil.val();
            datos_personales_nuevo.Cuil = _this.txt_cuil.val();
            datos_personales_nuevo.LugarDeNacimiento = _this.cmb_lugar_nac.val();
            datos_personales_nuevo.FechaNacimiento = _this.txt_fechaNac.val();
            datos_personales_nuevo.Nacionalidad = _this.cmb_nacionalidad.val();
            datos_personales_nuevo.TipoDocumento = _this.cmb_tipoDocumento.val();
            datos_personales_nuevo.Dni = parseInt(_this.txt_dni.val());

            domicilioPersonal_nuevo.Calle = _this.txt_domicilio_personal_calle.val();
            domicilioPersonal_nuevo.Numero = parseInt(_this.txt_domicilio_personal_numero.val());
            domicilioPersonal_nuevo.Piso = parseInt(_this.txt_domicilio_personal_piso.val());
            domicilioPersonal_nuevo.Depto = _this.txt_domicilio_personal_dto.val();
            domicilioPersonal_nuevo.Localidad = _this.txt_domicilio_personal_localidad.val();
            domicilioPersonal_nuevo.Cp = parseInt(_this.txt_domicilio_personal_cp.val());
            domicilioPersonal_nuevo.Provincia = _this.txt_domicilio_personal_provincia.val();

            domicilioLegal_nuevo.Calle = _this.txt_domicilio_legal_calle.val();
            domicilioLegal_nuevo.Numero = parseInt(_this.txt_domicilio_legal_numero.val());
            domicilioLegal_nuevo.Piso = parseInt(_this.txt_domicilio_legal_piso.val());
            domicilioLegal_nuevo.Depto = _this.txt_domicilio_legal_dto.val();
            domicilioLegal_nuevo.Localidad = _this.txt_domicilio_legal_localidad.val();
            domicilioLegal_nuevo.Cp = parseInt(_this.txt_domicilio_legal_cp.val());
            domicilioLegal_nuevo.Provincia = _this.txt_domicilio_legal_provincia.val();
            //domicilioLegal_nuevo.TelefonoFijo = _this.txt_domicilio_legal_telefonoFijo.val();
            //domicilioLegal_nuevo.TelefonoCelular = _this.txt_domicilio_legal_telefonoCelular.val();
            //domicilioLegal_nuevo.Mail = _this.txt_domicilio_legal_mail.val();

            datos_personales_nuevo.DomicilioPersonal = domicilioPersonal_nuevo;
            datos_personales_nuevo.DomicilioLegal = domicilioLegal_nuevo;

            var data_post = JSON.stringify({
                "datosPersonales_nuevos": datos_personales_nuevo,
                "datosPersonales_originales": datos_personales
            });
            $.ajax({
                url: "../AjaxWS.asmx/GuardarCVDatosPersonales",
                type: "POST",
                data: data_post,
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (respuestaJson) {
                    var respuesta = JSON.parse(respuestaJson.d);
                    alertify.success("Datos Personales guardados correctamente");
                    //alModificar(respuesta);
                    $(".modal_close_concursar").click();
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alertify.alert(errorThrown);
                }
            });
        });

    }
    
}