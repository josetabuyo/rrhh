var CvDatosPersonales = {
    completarDatos: function (datosPersonales) {
        var _this = this;

        var datos_personales = JSON.parse(datosPersonales);

        this.ui = $("#contenedor_datos_personales");
        _this.txt_nombre = _this.ui.find("#nombre");
        _this.txt_nombre.val(datos_personales.Nombre);
        _this.txt_apellido = _this.ui.find("#apellido");
        _this.txt_apellido.val(datos_personales.Apellido);
        _this.cmb_sexo = _this.ui.find("#cmb_sexo");
        _this.cmb_sexo.val(datos_personales.Sexo);
        _this.cmb_estadoCivil = _this.ui.find("#cmb_estadoCivil");
        _this.cmb_estadoCivil.val(datos_personales.EstadoCivil);
        _this.txt_cuil = _this.ui.find("#cuil");
        _this.txt_cuil.val(datos_personales.Cuil);
        _this.cmb_lugar_nac = _this.ui.find("#cmb_lugar_nacimiento");
        _this.cmb_lugar_nac.val(datos_personales.LugarDeNacimiento);
        _this.txt_fechaNac = _this.ui.find("#txt_fechaNac");
        _this.txt_fechaNac.val(datos_personales.FechaNacimiento);
        _this.cmb_nacionalidad = _this.ui.find("#cmb_nacionalidad");
        _this.cmb_nacionalidad.val(datos_personales.Nacionalidad);
        _this.cmb_tipoDocumento = _this.ui.find("#cmb_tipoDocumento");
        _this.cmb_tipoDocumento.val(datos_personales.TipoDocumento);
        _this.txt_dni = _this.ui.find("#txt_documento");
        _this.txt_dni.val(datos_personales.Dni);

        //DomicilioPersonal
        _this.txt_domicilio1_calle = _this.ui.find("#txt_calle1");
        _this.txt_domicilio1_calle.val(datos_personales.Domicilio.Calle);
        _this.txt_domicilio1_numero = _this.ui.find("#txt_numero1");
        _this.txt_domicilio1_numero.val(datos_personales.Domicilio.Numero);
        _this.txt_domicilio1_piso = _this.ui.find("#txt_piso1");
        _this.txt_domicilio1_piso.val(datos_personales.Domicilio.Piso);
        _this.txt_domicilio1_dto = _this.ui.find("#txt_dto1");
        _this.txt_domicilio1_dto.val(datos_personales.Domicilio.Depto);
        _this.txt_domicilio1_localidad = _this.ui.find("#txt_localidad1");
        _this.txt_domicilio1_localidad.val(datos_personales.Domicilio.Localidad);
        _this.txt_domicilio1_cp = _this.ui.find("#txt_cp1");
        _this.txt_domicilio1_cp.val(datos_personales.Domicilio.Cp);
        _this.txt_domicilio1_provincia = _this.ui.find("#cmb_provincia1");
        _this.txt_domicilio1_provincia.val(datos_personales.Domicilio.Provincia);


        //DomiciolioLaboral


    }
   
}