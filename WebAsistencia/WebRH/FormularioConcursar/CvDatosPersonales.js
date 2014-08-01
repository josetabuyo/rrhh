jQuery(function ($) {
    $("#cuil").mask("99-99999999-9");

});


var CvDatosPersonales = {
    completarDatos: function (datos_personales) {
        var _this = this;
        this.ui = $("#contenedor_datosPersonales");

        _this.txt_nombre = _this.ui.find("#nombre");
        _this.txt_apellido = _this.ui.find("#apellido");
        _this.txt_cuil = _this.ui.find("#cuil");
        _this.cmb_lugar_nac = _this.ui.find("#cmb_lugar_nacimiento");
        _this.txt_fechaNac = _this.ui.find("#txt_fechaNac");
        _this.txt_dni = _this.ui.find("#txt_documento");
        _this.cmb_tipoDocumento = _this.ui.find("#cmb_tipoDocumento");

        _this.cmb_sexo = new SuperCombo({
            ui: _this.ui.find("#cmb_sexo"),
            nombre_repositorio: "Sexos",
            id_item_seleccionado: datos_personales.Sexo
        });

        _this.cmb_estadoCivil = new SuperCombo({
            ui: _this.ui.find("#cmb_estadoCivil"),
            nombre_repositorio: "EstadosCiviles",
            id_item_seleccionado: datos_personales.EstadoCivil
        });

        _this.cmb_nacionalidad = new SuperCombo({
            ui: _this.ui.find("#cmb_nacionalidad"),
            nombre_repositorio: "Nacionalidades",
            id_item_seleccionado: datos_personales.Nacionalidad
        });

        _this.cmb_tipoDocumento = new SuperCombo({
            ui: _this.ui.find("#cmb_tipoDocumento"),
            nombre_repositorio: "TiposDeDocumento",
            id_item_seleccionado: datos_personales.TipoDocumento
        });

        _this.txt_nombre.val(datos_personales.Nombre);
        _this.txt_apellido.val(datos_personales.Apellido);
        _this.txt_cuil.val(datos_personales.Cuil);
        _this.cmb_lugar_nac.val(datos_personales.LugarDeNacimiento);
        _this.txt_fechaNac.val(datos_personales.FechaNacimiento);
        _this.txt_dni.val(parseInt(datos_personales.Dni));

        if (datos_personales.TieneLegajo == "Tiene legajo") {
            _this.txt_nombre[0].disabled = true;
            _this.txt_apellido[0].disabled = true;
            _this.txt_cuil[0].disabled = true;
            _this.cmb_lugar_nac[0].disabled = true;
            _this.txt_fechaNac[0].disabled = true;
            _this.txt_dni[0].disabled = true;
            _this.cmb_tipoDocumento.desactivar();
            _this.cmb_sexo.desactivar();
            _this.cmb_estadoCivil.desactivar();
            _this.cmb_nacionalidad.desactivar();
            _this.cmb_tipoDocumento.desactivar();
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

        _this.cmb_domicilio_personal_localidad = new SuperCombo({
            ui: _this.ui.find("#cmb_localidad1"),
            nombre_repositorio: "Localidades",
            filtro: { provincia: datos_personales.DomicilioPersonal.Provincia },
            campo_descripcion: "Nombre",
            id_item_seleccionado: datos_personales.DomicilioPersonal.Localidad
        });

        _this.cmb_domicilio_personal_provincia = new SuperCombo({
            ui: _this.ui.find("#cmb_provincia1"),
            nombre_repositorio: "Provincias",
            campo_descripcion: "Nombre",
            id_item_seleccionado: datos_personales.DomicilioPersonal.Provincia,
            al_seleccionar: function (id_provincia) {
                _this.cmb_domicilio_personal_localidad.cambiarFiltro({ provincia: id_provincia });
            }
        });

        //DomicilioLaboral
        _this.txt_domicilio_legal_calle = _this.ui.find("#text_calle2");
        _this.txt_domicilio_legal_numero = _this.ui.find("#txt_numero2");
        _this.txt_domicilio_legal_piso = _this.ui.find("#txt_piso2");
        _this.txt_domicilio_legal_dto = _this.ui.find("#txt_dto2");
        _this.txt_domicilio_legal_cp = _this.ui.find("#txt_cp2");
        _this.txt_domicilio_legal_telefonoFijo = _this.ui.find("#txt_telefonoFijo");
        _this.txt_domicilio_legal_telefonoCelular = _this.ui.find("#txt_telefonoCelular");
        _this.txt_domicilio_legal_mail = _this.ui.find("#txt_email");


        _this.txt_domicilio_legal_calle.val(datos_personales.DomicilioLegal.Calle);
        _this.txt_domicilio_legal_numero.val(parseInt(datos_personales.DomicilioLegal.Numero));
        _this.txt_domicilio_legal_piso.val((datos_personales.DomicilioLegal.Piso));
        _this.txt_domicilio_legal_dto.val(datos_personales.DomicilioLegal.Depto);
        _this.txt_domicilio_legal_cp.val(parseInt(datos_personales.DomicilioLegal.Cp));
        _this.txt_domicilio_legal_telefonoFijo.val(datos_personales.DomicilioLegal.TelefonoFijo);
        _this.txt_domicilio_legal_telefonoCelular.val(datos_personales.DomicilioLegal.TelefonoCelular);
        _this.txt_domicilio_legal_mail.val(datos_personales.DomicilioLegal.Mail);

        _this.cmb_domicilio_legal_localidad = new SuperCombo({
            ui: _this.ui.find("#cmb_localidad2"),
            nombre_repositorio: "Localidades",
            filtro: { provincia: datos_personales.DomicilioLegal.Provincia },
            campo_descripcion: "Nombre",
            id_item_seleccionado: datos_personales.DomicilioLegal.Localidad
        });

        _this.cmb_domicilio_legal_provincia = new SuperCombo({
            ui: _this.ui.find("#cmb_provincia2"),
            nombre_repositorio: "Provincias",
            campo_descripcion: "Nombre",
            id_item_seleccionado: datos_personales.DomicilioLegal.Provincia,
            al_seleccionar: function (id_provincia) {
                _this.cmb_domicilio_legal_localidad.cambiarFiltro({ provincia: id_provincia });
            }
        });

        //Bt guardar
        _this.add_datosPersonales = _this.ui.find("#btn_guardar_datosPersonales");
        _this.add_datosPersonales.click(function () {
            var datos_personales_nuevo = {};
            var domicilioPersonal_nuevo = {};
            var domicilioLegal_nuevo = {};
            datos_personales_nuevo.Nombre = _this.txt_nombre.val();
            datos_personales_nuevo.Apellido = _this.txt_apellido.val();
            datos_personales_nuevo.Sexo = _this.cmb_sexo.idItemSeleccionado();
            //datos_personales_nuevo.NivelEducat
            datos_personales_nuevo.EstadoCivil = _this.cmb_estadoCivil.idItemSeleccionado();
            datos_personales_nuevo.Cuil = _this.txt_cuil.val().replace(/\-/g, '');
            datos_personales_nuevo.LugarDeNacimiento = _this.cmb_lugar_nac.val();
            datos_personales_nuevo.FechaNacimiento = _this.txt_fechaNac.val();
            datos_personales_nuevo.Nacionalidad = _this.cmb_nacionalidad.idItemSeleccionado();
            datos_personales_nuevo.TipoDocumento = _this.cmb_tipoDocumento.idItemSeleccionado();
            datos_personales_nuevo.Dni = parseInt(_this.txt_dni.val());

            domicilioPersonal_nuevo.Id = datos_personales.DomicilioPersonal.Id;
            domicilioPersonal_nuevo.Calle = _this.txt_domicilio_personal_calle.val();
            domicilioPersonal_nuevo.Numero = parseInt(_this.txt_domicilio_personal_numero.val());
            domicilioPersonal_nuevo.Piso = parseInt(_this.txt_domicilio_personal_piso.val());
            domicilioPersonal_nuevo.Depto = _this.txt_domicilio_personal_dto.val();
            domicilioPersonal_nuevo.Cp = parseInt(_this.txt_domicilio_personal_cp.val());
            domicilioPersonal_nuevo.Provincia = _this.cmb_domicilio_personal_provincia.idItemSeleccionado();
            domicilioPersonal_nuevo.Localidad = _this.cmb_domicilio_personal_localidad.idItemSeleccionado();

            domicilioLegal_nuevo.Id = datos_personales.DomicilioLegal.Id;
            domicilioLegal_nuevo.Calle = _this.txt_domicilio_legal_calle.val();
            domicilioLegal_nuevo.Numero = parseInt(_this.txt_domicilio_legal_numero.val());
            domicilioLegal_nuevo.Piso = parseInt(_this.txt_domicilio_legal_piso.val());
            domicilioLegal_nuevo.Depto = _this.txt_domicilio_legal_dto.val();
            domicilioLegal_nuevo.Cp = parseInt(_this.txt_domicilio_legal_cp.val());
            domicilioLegal_nuevo.Provincia = _this.cmb_domicilio_legal_provincia.idItemSeleccionado();
            domicilioLegal_nuevo.Localidad = _this.cmb_domicilio_legal_localidad.idItemSeleccionado();

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