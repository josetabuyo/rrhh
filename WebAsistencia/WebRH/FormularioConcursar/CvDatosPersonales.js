
var CvDatosPersonales = {
    completarDatos: function (datos_personales) {
        var _this = this;
        this.ui = $("#contenedor_datosPersonales");
        $("#cuil").mask("99-99999999-9");

        RH_FORMS.bindear(this.ui, Repositorio, datos_personales)

        _this.txt_nombre = _this.ui.find("#nombre");
        _this.txt_apellido = _this.ui.find("#apellido");
        _this.txt_cuil = _this.ui.find("#cuil");
        _this.cmb_lugar_nac = _this.ui.find("#cmb_lugar_nacimiento");
        _this.txt_fechaNac = _this.ui.find("#txt_fechaNac");
        _this.txt_dni = _this.ui.find("#txt_documento");
        _this.cmb_tipoDocumento = _this.ui.find("#cmb_tipoDocumento");

        _this.txt_nombre.val(datos_personales.Nombre);
        _this.txt_apellido.val(datos_personales.Apellido);
        _this.txt_cuil.val(datos_personales.Cuil);
        _this.cmb_lugar_nac.val(datos_personales.LugarDeNacimiento);

        _this.txt_fechaNac.datepicker();
        _this.txt_fechaNac.datepicker('option', 'dateFormat', 'dd/mm/yy');
        _this.txt_fechaNac.datepicker('setDate', ConversorDeFechas.deIsoAFechaEnCriollo(datos_personales.FechaNacimiento));

       
        _this.txt_dni.val(parseInt(datos_personales.Dni));

        if (datos_personales.TieneLegajo == "Tiene legajo") {
            _this.txt_nombre[0].disabled = true;
            _this.txt_apellido[0].disabled = true;
            _this.txt_cuil[0].disabled = true;
            _this.cmb_lugar_nac[0].disabled = true;
            _this.txt_fechaNac[0].disabled = true;
            _this.txt_dni[0].disabled = true;
            $("#contenedor_datos_legajos").find('select').prop('disabled', true);
            //_this.cmb_tipoDocumento.desactivar();
            //_this.cmb_sexo.desactivar();
            //_this.cmb_estadoCivil.desactivar();
            //_this.cmb_nacionalidad.desactivar();
            //_this.cmb_tipoDocumento.desactivar();
        }

        //DomicilioPersonal
        _this.txt_domicilio_personal_calle = _this.ui.find("#txt_calle1");
        _this.txt_domicilio_personal_numero = _this.ui.find("#txt_numero1");
        _this.txt_domicilio_personal_piso = _this.ui.find("#txt_piso1");
        _this.txt_domicilio_personal_dto = _this.ui.find("#txt_dto1");
        _this.txt_domicilio_personal_cp = _this.ui.find("#txt_cp1");

        _this.txt_domicilio_personal_calle.val(datos_personales.DomicilioPersonal.Calle);
        _this.txt_domicilio_personal_numero.val(parseInt(datos_personales.DomicilioPersonal.Numero));
        _this.txt_domicilio_personal_piso.val((datos_personales.DomicilioPersonal.Piso));
        _this.txt_domicilio_personal_dto.val(datos_personales.DomicilioPersonal.Depto);
        _this.txt_domicilio_personal_cp.val(parseInt(datos_personales.DomicilioPersonal.Cp));

        //DomicilioLaboral
        _this.txt_domicilio_legal_calle = _this.ui.find("#text_calle2");
        _this.txt_domicilio_legal_numero = _this.ui.find("#txt_numero2");
        _this.txt_domicilio_legal_piso = _this.ui.find("#txt_piso2");
        _this.txt_domicilio_legal_dto = _this.ui.find("#txt_dto2");
        _this.txt_domicilio_legal_cp = _this.ui.find("#txt_cp2");
        _this.txt_domicilio_legal_Telefono = _this.ui.find("#txt_telefono");
        _this.txt_domicilio_legal_Telefono2 = _this.ui.find("#txt_telefono2");
        _this.txt_domicilio_legal_Email = _this.ui.find("#txt_email");

        _this.txt_domicilio_legal_calle.val(datos_personales.DomicilioLegal.Calle);
        _this.txt_domicilio_legal_numero.val(parseInt(datos_personales.DomicilioLegal.Numero));
        _this.txt_domicilio_legal_piso.val((datos_personales.DomicilioLegal.Piso));
        _this.txt_domicilio_legal_dto.val(datos_personales.DomicilioLegal.Depto);
        _this.txt_domicilio_legal_cp.val(parseInt(datos_personales.DomicilioLegal.Cp));
        _this.txt_domicilio_legal_Telefono.val(datos_personales.DomicilioLegal.Telefono);
        _this.txt_domicilio_legal_Telefono2.val(datos_personales.DomicilioLegal.Telefono2);
        _this.txt_domicilio_legal_Email.val(datos_personales.DomicilioLegal.Email);

        //Bt guardar
        _this.add_datosPersonales = _this.ui.find("#btn_guardar_datosPersonales");
        _this.add_datosPersonales.click(function () {
//            datos_personales_nuevo.Cuil = _this.txt_cuil.val().replace(/\-/g, '');


            if ($("#contenedor_datosPersonales").esValido()) {
                var datos_personales_nuevo = {};
                var domicilioPersonal_nuevo = {};
                var domicilioLegal_nuevo = {};
                datos_personales_nuevo.Nombre = _this.txt_nombre.val();
                datos_personales_nuevo.Apellido = _this.txt_apellido.val();
                datos_personales_nuevo.Cuil = _this.txt_cuil.val().replace(/\-/g, '');

                datos_personales_nuevo.LugarDeNacimiento = _this.cmb_lugar_nac.val();
                datos_personales_nuevo.FechaNacimiento = _this.txt_fechaNac.val();
                datos_personales_nuevo.Dni = parseInt(_this.txt_dni.val());

                domicilioPersonal_nuevo.Id = datos_personales.DomicilioPersonal.Id;
                domicilioPersonal_nuevo.Calle = _this.txt_domicilio_personal_calle.val();
                domicilioPersonal_nuevo.Numero = parseInt(_this.txt_domicilio_personal_numero.val());
                domicilioPersonal_nuevo.Piso = parseInt(_this.txt_domicilio_personal_piso.val());
                domicilioPersonal_nuevo.Depto = _this.txt_domicilio_personal_dto.val();
                domicilioPersonal_nuevo.Cp = parseInt(_this.txt_domicilio_personal_cp.val());

                domicilioLegal_nuevo.Id = datos_personales.DomicilioLegal.Id;
                domicilioLegal_nuevo.Calle = _this.txt_domicilio_legal_calle.val();
                domicilioLegal_nuevo.Numero = parseInt(_this.txt_domicilio_legal_numero.val());
                domicilioLegal_nuevo.Piso = parseInt(_this.txt_domicilio_legal_piso.val());
                domicilioLegal_nuevo.Depto = _this.txt_domicilio_legal_dto.val();
                domicilioLegal_nuevo.Cp = parseInt(_this.txt_domicilio_legal_cp.val());

                datos_personales_nuevo.Telefono = _this.txt_domicilio_legal_Telefono.val();
                datos_personales_nuevo.Telefono2 = _this.txt_domicilio_legal_Telefono2.val();
                datos_personales_nuevo.Email = _this.txt_domicilio_legal_Email.val();

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
            }//fin validador
        });

    }

}
