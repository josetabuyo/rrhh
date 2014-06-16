var ActividadesDocentes = {
    mostrar: function (actividad_docente_original, alModificar) {
        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("ActividadesDocentes.htm", function () {
            _this.txt_asignatura = _this.ui.find("#txt_asignatura");
            _this.txt_asignatura.val(actividad_docente_original.Asignatura);
            _this.nivel_educativo = _this.ui.find("#nivel_educativo");
            _this.nivel_educativo.val(actividad_docente_original.NivelEducativo);
            _this.tipo_actividad = _this.ui.find("#tipo_actividad");
            _this.tipo_actividad.val(actividad_docente_original.TipoActividad);
            _this.categoria_docente = _this.ui.find("#categoria_docente");
            _this.categoria_docente.val(actividad_docente_original.CategoriaDocente);
            _this.caracter_designacion = _this.ui.find("#caracter_designacion");
            _this.caracter_designacion.val(actividad_docente_original.CaracterDesignacion);
            _this.dedicacion_docente = _this.ui.find("#dedicacion_docente");
            _this.dedicacion_docente.val(actividad_docente_original.DedicacionDocente);
            _this.carga_horaria = _this.ui.find("#actividad_docente_carga_horaria");
            _this.carga_horaria.val(actividad_docente_original.CargaHoraria);
            _this.fecha_inicio = _this.ui.find("#fecha_inicio");
            _this.fecha_inicio.val(actividad_docente_original.FechaInicio);
            _this.fecha_fin = _this.ui.find("#fecha_fin");
            _this.fecha_fin.val(actividad_docente_original.FechaFin);
            _this.establecimiento = _this.ui.find("#establecimiento");
            _this.establecimiento.val(actividad_docente_original.Establecimiento);
            _this.cmb_actividad_docente_localidad = _this.ui.find("#cmb_actividad_docente_localidad");
            _this.cmb_actividad_docente_localidad.val(actividad_docente_original.Localidad);
            _this.cmb_actividad_docente_pais = _this.ui.find("#cmb_actividad_docente_pais");
            _this.cmb_actividad_docente_pais.val(actividad_docente_original.Pais);

            //Bt agregar
            _this.add_actividadesDocentes = _this.ui.find("#add_actividadesDocentes");
            _this.add_actividadesDocentes.click(function () {
                //var estudio_modificado = $.extend(true, estudio_original);
                actividad_docente_original.Asignatura = _this.txt_asignatura.val();
                actividad_docente_original.NivelEducativo = _this.nivel_educativo.val();
                actividad_docente_original.TipoActividad = _this.tipo_actividad.val();
                actividad_docente_original.CategoriaDocente = _this.categoria_docente.val();
                actividad_docente_original.CaracterDesignacion = _this.caracter_designacion.val();
                actividad_docente_original.DedicacionDocente = _this.dedicacion_docente.val();
                actividad_docente_original.CargaHoraria = _this.dedicacion_docente.val();
                actividad_docente_original.FechaInicio = _this.fecha_inicio.val();
                actividad_docente_original.FechaFinalizacion = _this.fecha_fin.val();
                actividad_docente_original.Establecimiento = _this.establecimiento.val();
                actividad_docente_original.Localidad = _this.cmb_actividad_docente_localidad.val();
                actividad_docente_original.Pais = _this.cmb_actividad_docente_pais.val();


                var data_post = JSON.stringify({
                    "docencias_nuevas": actividad_docente_original,
                    "docencias_originales": actividad_docente_original
                });
                $.ajax({
                    url: "../AjaxWS.asmx/GuardarCvActividadesDocentes",
                    type: "POST",
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        alertify.alert("Los datos fueron guardados correctamente");
                        alModificar(respuesta);
                        $(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });
            });

            var link_trucho = $("<a href='#un_div_modal'></a>");
            link_trucho.leanModal({ top: 300, closeButton: ".modal_close_concursar" });
            link_trucho.click();

            $('#actividad_docente_fecha_inicio').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
            $('#actividad_docente_fecha_fin').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
        });
    },
    armarGrilla: function (actividades_docentes) {
        var _this = this;

        //var actividades_docentes = JSON.parse(actividades_docentes);

        contenedorPlanilla = $('#tabla_actividades_docentes');

        var columnas = [];

    columnas.push(new Columna("Id", { generar: function (una_actividad_docente) { return una_actividad_docente.Id } }));
    columnas.push(new Columna("Asignatura", { generar: function (una_actividad_docente) { return una_actividad_docente.Asignatura } }));
    columnas.push(new Columna("Nivel Educativo", { generar: function (una_actividad_docente) { return una_actividad_docente.NivelEducativo } }));
    columnas.push(new Columna("Tipo de Actividad", { generar: function (una_actividad_docente) { return una_actividad_docente.TipoActividad } }));
    columnas.push(new Columna("Categoría Docente", { generar: function (una_actividad_docente) { return una_actividad_docente.CategoriaDocente } }));
    //columnas.push(new Columna("Caracter de Designación", { generar: function (una_actividad_docente) { return una_actividad_docente.CaracterDesignación } }));
    //columnas.push(new Columna("Dedicación Docente", { generar: function (una_actividad_docente) { return una_actividad_docente.DedicacionDocente } }));
    columnas.push(new Columna("Fecha Inicio", { generar: function (una_actividad_docente) { return una_actividad_docente.FechaInicio } }));
    columnas.push(new Columna("Fecha Fin", { generar: function (una_actividad_docente) { return una_actividad_docente.FechaFin } }));
    columnas.push(new Columna("Establecimiento", { generar: function (una_actividad_docente) { return una_actividad_docente.Establecimiento } }));
    //columnas.push(new Columna("Localidad", { generar: function (una_actividad_docente) { return una_actividad_docente.Localidad } }));
    //columnas.push(new Columna("Pais", { generar: function (una_actividad_docente) { return una_actividad_docente.Pais } }));
    columnas.push(new Columna('&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Acciones&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;', { generar: function (una_actividad_docente) {
        var contenedorBtnAcciones = $('<div>');
        var botonEditar = $('<img>');
        botonEditar.addClass('edit-item-btn');
        botonEditar.attr('src', '../Imagenes/edit.png');
        botonEditar.attr('style', 'padding-right:5px;');
        botonEditar.attr('width', '25px');
        botonEditar.attr('height', '25px');

        botonEditar.click(function () {
            ActividadesDocentes.mostrar(una_actividad_docente, function (actididad_docente_modificada) {
                PlanillaCvActividadesDocentes.BorrarContenido();
                PlanillaCvActividadesDocentes.CargarObjetos(actividades_docentes);
            });
        });

        contenedorBtnAcciones.append(botonEditar);

        var botonEliminar = $('<img>');
        botonEliminar.addClass('remove-item-btn');
        botonEliminar.attr('src', '../Imagenes/iconos_eliminar.png');
        botonEliminar.attr('width', '25px');
        botonEliminar.attr('height', '25px');

        botonEliminar.click(function () {
            ActividadesDocentes.eliminar(una_actividad_docente, function (actividad_docente_eliminada) {
                PlanillaCvActividadesDocentes.QuitarObjeto(contenedorPlanilla, actividad_docente_eliminada);
            });
        });

        contenedorBtnAcciones.append(botonEliminar);

        return contenedorBtnAcciones;
    }
    }));


    PlanillaCvActividadesDocentes = new Grilla(columnas);
    PlanillaCvActividadesDocentes.AgregarEstilo("table table-striped");
    PlanillaCvActividadesDocentes.SetOnRowClickEventHandler(function (un_estudio) {
            // panelAlumno.CompletarDatosAlumno(un_alumno);
        });

    PlanillaCvActividadesDocentes.CargarObjetos(actividades_docentes);
    PlanillaCvActividadesDocentes.DibujarEn(contenedorPlanilla);

    },
    eliminar: function (actividad_docente_a_eliminar, alModificar) {
        // confirm dialog
        alertify.confirm("Está seguro que desea eliminar el antecedente", function (e) {
            if (e) {
                // user clicked "ok"
                var data_post = JSON.stringify({
                    "actividadesDocentes_borrar": actividad_docente_a_eliminar
                });
                $.ajax({
                    url: "../AjaxWS.asmx/EliminarCVActividadesDocentes",
                    type: "POST",
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        alertify.success("Antecedente Academico eliminado correctamente");
                        //alertify.alert("Los datos fueron guardados correctamente");
                        alModificar(respuesta);
                        //$(".modal_close_concursar").click();
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });
            } else {
                // user clicked "cancel"
                alertify.error("No se puedo eliminar el antecedente");
            }
        });



    }
}