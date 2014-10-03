var PantallaRegistro = {
    abrir: function () {
        var _this = this;
        this.ui = $("#registrarse_dialog");

        this.ui.load("RegistroPostular/PantallaRegistro.htm", function () {
            _this.panel_paso_1 = $("#panel_paso_1");
            _this.panel_paso_2 = $("#panel_paso_2");
            _this.panel_paso_3 = $("#panel_paso_3");
            _this.abrir = function () {
                _this.mostrar();
            };
            _this.mostrar();
        });

        this.proveedor_ajax = new ProveedorAjax();
    },

     recuperar: function () {
         var _this = this;
         this.ui = $("#recuperar_dialog");

         this.ui.load("RegistroPostular/PantallaRegistro.htm", function () {
                _this.panel_paso_1 = $("#panel_paso_1");
                _this.panel_paso_2 = $("#panel_paso_2");
                _this.panel_paso_3 = $("#panel_paso_3");
                _this.recuperar = function () {
                    _this.mostrarRecupero();
                };
                _this.mostrarRecupero();
            });
            
            this.proveedor_ajax = new ProveedorAjax();
    },

    mostrar: function () {
        vex.dialog.open({
            message: "Ingrese su DNI",
            input: this.ui,
            buttons: [
                ]
        });
        this.ui.limpiarValidaciones();
        this.paso1();
    },

    mostrarRecupero: function () {
        vex.dialog.open({
            message: "Ingrese el Mail con el cual se ha registrado",
            input: this.ui,
            buttons: [
                ]
        });
        this.ui.limpiarValidaciones();
        this.paso3();
    },

    paso1: function () {
        var _this = this;
        this.btn_validar = $("#btn_validar");
        this.txt_numero_documento = $("#txt_numero_documento");
        this.txt_numero_documento.val("");
        this.panel_paso_1.show();
        this.panel_paso_2.hide();
        this.panel_paso_3.hide();
        this.btn_validar.click(function () {
            if (_this.panel_paso_1.esValido()) {
                _this.proveedor_ajax.postearAUrl({ url: "BuscarPersonas",
                    data: { 
                        criterio: JSON.stringify({
                                        Documento: parseInt(_this.txt_numero_documento.val())
                                        //se quita el buscar con legajo para que busque todos los inscriptos
                                        //ConLegajo: true
                                    })
                    },
                    success: function (personas) {
                        if (personas.length > 0) {
                            alertify.alert("El documento ingresado ya está registrado, inicie sesión con el usuario asignado. Si no los recuerda, utilice la opción: '¿Olvidó sus datos?' o comuníquese con <br/> Recursos Humanos.");
                            return;
                        }
                        _this.paso2();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {

                    }
                });
            }
        });
    },
    paso2: function () {
        var _this = this;
        this.panel_paso_2.show();
        this.panel_paso_1.hide();
        this.panel_paso_3.hide();
        $(".vex-dialog-message").text("Complete sus datos");
        this.lbl_numero_documento = $("#lbl_numero_documento");
        this.lbl_numero_documento.text("");
        this.txt_nombre = $("#txt_nombre");
        this.txt_nombre.val("");
        this.txt_apellido = $("#txt_apellido");
        this.txt_apellido.val("");
        this.txt_email = $("#txt_email");
        this.txt_email.val("");
        this.btn_registrarse = $("#btn_registrarse");

        this.lbl_numero_documento.text(this.txt_numero_documento.val());

        this.btn_registrarse.click(function () {
            var controles_ = true;

            if (_this.panel_paso_2.esValido()) {
                _this.proveedor_ajax.postearAUrl({ url: "RegistrarNuevoUsuario",
                    data: {
                        aspirante: {
                            Documento: _this.txt_numero_documento.val(),
                            Nombre: _this.txt_nombre.val(),
                            Apellido: _this.txt_apellido.val(),
                            Email: _this.txt_email.val()
                        }
                    },
                    success: function () {
                        alertify.alert("Se le ha enviado un mail con su nombre de usuario y contraseña", function(){
                            vex.closeAll();
                        });
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert("El mail con el que intenta registrarse ya existe. Si no recuerda sus datos, utilice la opción '¿Olvidó sus datos?' o comuníquese con <br/> Recursos Humanos.");
                    }
                });
            }
        });
    },

    paso3: function () {
        var _this = this;
        this.panel_paso_3.show();
        this.panel_paso_1.hide();
        this.panel_paso_2.hide();
        this.btn_recuperar = $("#btn_recuperar");
        this.txt_mail_registro = $("#txt_mail_recupero");
        this.txt_mail_registro.val("");
        this.btn_recuperar.click(function () {
            if (_this.panel_paso_3.esValido()) {
                _this.proveedor_ajax.postearAUrl({ url: "RecuperarUsuario",
                    data: { 
                        criterio: JSON.stringify({
                            Mail: _this.txt_mail_registro.val()
                                    })
                    },
                    success: function (ejeucion_ok) {
                        if (!ejeucion_ok) {
                            alertify.alert("No es posible recuperar sus datos. Contáctese con Recursos Humanos");
                            return;
                        }
                        alertify.alert("Se ha enviado un mail a dicho correo, para que pueda recuperar sus datos de acceso.");
                        vex.closeAll();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                    }
                });
            }
        });
    } 

};

