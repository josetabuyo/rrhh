var ModificarAreas = {
    //TABLA PARA LOS CONTACTOS
    armarGrillaContacto: function (contactos) {
        var _this = this;
        $('#tabla_contactos').empty();
        _this.contactos = contactos;
        _this.divGrillaContacto = $('#tabla_contactos');
        _this.btn_agregar_contacto = $("#btn_agregar_contacto");
        _this.btn_agregar_contacto.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                path_html: "PanelDetalleDeContacto.htm"
            });
        });

        var columnas = [];

        columnas.push(new Columna("Tipo de Contacto", { generar: function (un_contacto) { return un_contacto.Descripcion } }));
        columnas.push(new Columna("Contacto", { generar: function (un_contacto) { return un_contacto.Dato } }));
        columnas.push(new Columna("Orden", { generar: function (un_contacto) { return un_contacto.Orden } }));
        columnas.push(new Columna('Eliminar Contacto', {
            generar: function (un_contacto) {
                document.getElementById("btn_editar").style.display = 'none';
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_eliminar = contenedorBtnAcciones.find("#btn_eliminar");
                btn_eliminar.click(function () {
                    _this.eliminarContacto(un_contacto);
                });
                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaContactos = new Grilla(columnas);
        this.GrillaContactos.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaContactos.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaContactos.SetOnRowClickEventHandler(function (un_contacto) {
        });

        this.GrillaContactos.CargarObjetos(_this.contactos);
        this.GrillaContactos.DibujarEn(_this.divGrillaContacto);

    },
    eliminarContacto: function (un_contacto) {
        var _this = this;
        alertify.confirm("¿Está seguro que desea eliminar este Contacto?", function (e) {
            if (e) {
                Backend.ejecutarSincronico("EliminarContactoArea", [{ Id: parseInt(un_contacto.Id), TipoDato: parseInt(un_contacto.IdContacto), Dato: un_contacto.Dato, Orden: parseInt(un_contacto.Orden), IdArea: parseInt(area.Id)}]);
            }
        });
    },
    //TABLA PARA LOS ASISTENTES
    armarGrillaAsistente: function (asistentes) {
        var _this = this;

        _this.asistentes = asistentes;
        _this.divGrillaAsistente = $('#tabla_asistentes');
        _this.btn_agregar_asistente = $("#btn_agregar_asistente");

        _this.btn_agregar_asistente.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                path_html: "PanelDetalleDeAsistente.htm",
                metodoDeGuardado: "GuardarAsistenteArea",
                mensajeDeGuardadoExitoso: "El Asistente ha sido guardado exitosamente",
                mensajeDeGuardadoErroneo: "Error al agregar el Asistente",
                alModificar: function (nuevo_asistente) {
                    _this.GrillaAsistentes.BorrarContenido();
                    _this.asistentes.push(nuevo_asistente);
                    _this.GrillaAsistentes.CargarObjetos(_this.asistentes);
                }
            });
        });

        var columnas = [];

        columnas.push(new Columna("Documento", { generar: function (un_asistente) { return un_asistente.Documento } }));
        columnas.push(new Columna("Apellido", { generar: function (un_asistente) { return un_asistente.Apellido } }));
        columnas.push(new Columna("Nombre", { generar: function (un_asistente) { return un_asistente.Nombre } }));
        columnas.push(new Columna("Orden", { generar: function (un_asistente) { return un_asistente.Prioridad_Cargo } }));
        columnas.push(new Columna("Cargo", { generar: function (un_asistente) { return un_asistente.Descripcion_Cargo } }));
        columnas.push(new Columna('Acciones', {
            generar: function (un_asistente) {
                var contenedorBtnAcciones = $("#plantillas .botonera_grilla").clone();
                var btn_editar = contenedorBtnAcciones.find("#btn_editar");
                var btn_eliminarAsistente = contenedorBtnAcciones.find("#btn_eliminarAsistente");

                btn_editar.click(function () {
                    var panel_detalle = new PanelDetalleGenerico({
                        modelo: un_asistente,
                        path_html: "PanelDetalleDeAsistente.htm",
                        metodoDeGuardado: "ActualizarAsistenteArea",
                        mensajeDeGuardadoExitoso: "El Asistente del Área fue actualizado correctamente",
                        mensajeDeGuardadoErroneo: "Error al actualizar el Asistente del Área",
                        alModificar: function (asistente_modificado) {
                            _this.GrillaAsistentes.BorrarContenido();
                            _this.GrillaAsistentes.CargarObjetos(_this.asistentes);
                        }
                    });
                });

                btn_eliminarAsistente.click(function () {
                    _this.eliminarAsistente(un_asistente);
                });

                return contenedorBtnAcciones;
            }
        }
        ));

        this.GrillaAsistentes = new Grilla(columnas);
        this.GrillaAsistentes.AgregarEstilo("cuerpo_tabla_puesto tr td");
        this.GrillaAsistentes.CambiarEstiloCabecera("cabecera_tabla_postular");
        this.GrillaAsistentes.SetOnRowClickEventHandler(function (un_asistente) {
        });

        this.GrillaAsistentes.CargarObjetos(_this.asistentes);
        this.GrillaAsistentes.DibujarEn(_this.divGrillaAsistente);

    },
    eliminarAsistente: function (un_asistente) {
        var _this = this;
        alertify.confirm("¿Está seguro que desea eliminar este registro?", function (e) {
            if (e) {
                Backend.EliminarAsistenteArea(un_asistente)
                    .onSuccess(function (respuesta) {
                        alertify.success("Asistente eliminado correctamente");
                        _this.GrillaAsistentes.QuitarObjeto(_this.divGrillaAsistente, un_asistente);
                        var indice = _this.asistentes.indexOf(un_asistente);
                        _this.asistentes.splice(indice, 1);
                    })
                    .onError(function (error, as, asd) {
                        alertify.error("No se pudo eliminar el Asistente");
                    });
            }
        });
    },
    //Configuracion Inicial
    SettearEventos: function () {
        var _this = this;
        $('#btn_buscarSinAprobacion').click(function () {
            _this.BuscarDatosSinAprobacion();
        });
        $('#btn_buscarDatosOriginales').click(function () {
            $('#btn_buscarDatosOriginales').hide();
            $('#btn_buscarSinAprobacion').show();
            _this.CompletarDatosArea(area_dinamica);
            _this.armarGrillaContacto(area_dinamica);
        });

    },

    CompletarDatosArea: function (area) {
        $("#txt_nombre_apellido").val(area.Responsable.NombreApellido);
        $("#txt_NroDocumento").val(area.Responsable.Documento);
        $("#txt_IdInterna").val(area.Responsable.IdInterna);

        $("#txt_Calle").val(area.DireccionCompleta.Calle);
        $("#txt_Nro").val(area.DireccionCompleta.Numero);
        $("#txt_Piso").val(area.DireccionCompleta.Piso);
        $("#txt_Oficina").val(area.DireccionCompleta.Dto);
        $("#txt_UF").val(area.DireccionCompleta.UF);
        if (area.DireccionCompleta.Localidad != null) {
            $("#txt_Localidad").val(area.DireccionCompleta.Localidad.Nombre);
            $("#txt_CodigoPostal").val(area.DireccionCompleta.Localidad.CodigoPostal);
            $("#txt_Partido").val(area.DireccionCompleta.Localidad.NombrePartido);
            $("#txt_Provincia").val(area.DireccionCompleta.Localidad.NombreProvincia);
        }
    },

    BuscarDatosSinAprobacion: function () {
        var nueva_area = Backend.ejecutarSincronico("BuscarDatosDelAreaSinAprobacion", [area]);
        $('#btn_buscarDatosOriginales').show();
        $('#btn_buscarSinAprobacion').hide();
        this.CompletarDatosArea(nueva_area);
        this.armarGrillaContacto(nueva_area.DatosDeContacto)
    },

    Inicio: function () {
        var _this = this;
        _this.SettearEventos();
        _this.btn_modificar_responsable = $("#btn_modificar_responsable");
        _this.btn_modificar_direccion = $("#btn_modificar_direccion");


        _this.btn_modificar_responsable.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                path_html: "PanelDetalleDeResponsable.htm",
                metodoDeGuardado: "ModificarResponsable",
                modelo: area,
                mensajeDeGuardadoExitoso: "Para modificar los datos del Repsonsable, por favor comuníquese con Recursos Humanos",
                mensajeDeGuardadoErroneo: "Para modificar los datos del Repsonsable, por favor comuníquese con Recursos Humanos"
            });
        });
        _this.btn_modificar_direccion.click(function () {
            var panel_detalle = new PanelDetalleGenerico({
                path_html: "PanelDetalleDeDireccion.htm"

            });
        });
    }

}
