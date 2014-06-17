var ActividadesCapacitacion = {
    mostrar: function (actividad_capacitacion_original, alModificar) {
        var _this = this;
        this.ui = $("#un_div_modal");
        this.ui.find("#contenido_modal").load("ActividadesCapacitacion.htm", function () {
            _this.txt_diploma_certificacion = _this.ui.find("#txt_capacitacion_nombreDiploma");
            _this.txt_diploma_certificacion.val(actividad_capacitacion_original.Asignatura);
            _this.txt_fecha_inicio = _this.ui.find("#txt_capacitacion_fechaInicio");
            _this.txt_fecha_inicio.val(actividad_capacitacion_original.NivelEducativo);
            _this.txt_fecha_fin = _this.ui.find("#txt_capacitacion_fechaFin");
            _this.txt_fecha_fin.val(actividad_capacitacion_original.TipoActividad);
            _this.txt_duracion = _this.ui.find("#txt_capacitacion_duracion");
            _this.txt_duracion.val(actividad_capacitacion_original.CategoriaDocente);
            _this.txt_especialidad = _this.ui.find("#txt_capacitacion_especialidad");
            _this.txt_especialidad.val(actividad_capacitacion_original.CaracterDesignacion);
            _this.txt_establecimiento = _this.ui.find("#txt_capacitacion_establecimiento");
            _this.txt_establecimiento.val(actividad_capacitacion_original.DedicacionDocente);
            _this.cmb_localidad = _this.ui.find("#cmb_capacitacion_localidad");
            _this.cmb_localidad.val(actividad_capacitacion_original.Localidad);
            _this.cmb_pais = _this.ui.find("#cmb_capacitacion_pais");
            _this.cmb_pais.val(actividad_capacitacion_original.Pais);


            //Bt agregar
            _this.add_actividadesCapacitacion = _this.ui.find("#add_actividadesCapacitacion");
            _this.add_actividadesCapacitacion.click(function () {
                //var estudio_modificado = $.extend(true, estudio_original);
                actividad_capacitacion_original.DiplomaDeCertificacion = _this.txt_diploma_certificacion.val();
                actividad_capacitacion_original.Establecimiento = _this.txt_establecimiento.val();
                actividad_capacitacion_original.Especialidad = _this.txt_especialidad.val();
                actividad_capacitacion_original.Duracion = _this.txt_duracion.val();
                actividad_capacitacion_original.FechaInicio = _this.txt_fecha_inicio.val();
                actividad_capacitacion_original.FechaFinalizacion = _this.txt_fecha_fin.val();
                actividad_capacitacion_original.Localidad = _this.cmb_localidad.val();
                actividad_capacitacion_original.Pais = _this.cmb_pais.val();


                var data_post = JSON.stringify({
                    "actividades_cacitacion_nuevas": actividad_capacitacion_original,
                    "actividades_capacitacion_originales": actividad_capacitacion_original
                });
                $.ajax({
                    url: "../AjaxWS.asmx/GuardarCvactividadesCapacitacion",
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

            $('#txt_actividad_docente_fecha_inicio').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
            $('#txt_actividad_docente_fecha_fin').datepicker({
                dateFormat: 'dd/mm/yy',
                onClose: function () {

                }
            });
        });
    },
    armarGrilla: function (actividades_capacitacion) {
        var _this = this;

        contenedorPlanilla = $('#tabla_actividades_capacitacion');

        var columnas = [];

        columnas.push(new Columna("Id", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Id } }));
        columnas.push(new Columna("Diploma De Certificacion", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.DiplomaDeCertificacion } }));
        columnas.push(new Columna("Establecimiento", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Establecimiento } }));
        columnas.push(new Columna("Especialidad", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Especialidad } }));
        columnas.push(new Columna("Duracion", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Duracion } }));
        columnas.push(new Columna("Fecha Inicio", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.FechaInicio } }));
        columnas.push(new Columna("Fecha Fin", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.FechaFinalizacion } }));
        columnas.push(new Columna("Establecimiento", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Establecimiento } }));
        //columnas.push(new Columna("Localidad", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Localidad } }));
        //columnas.push(new Columna("Pais", { generar: function (una_actividad_capacitacion) { return una_actividad_capacitacion.Pais } }));
        columnas.push(new Columna('&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Acciones&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;', { generar: function (una_actividad_capacitacion) {
        var contenedorBtnAcciones = $('<div>');
        var botonEditar = $('<img>');
        botonEditar.addClass('edit-item-btn');
        botonEditar.attr('src', '../Imagenes/edit.png');
        botonEditar.attr('style', 'padding-right:5px;');
        botonEditar.attr('width', '25px');
        botonEditar.attr('height', '25px');

        botonEditar.click(function () {
            ActividadesCapacitacion.mostrar(una_actividad_capacitacion, function (actividad_capacitacion_modificada) {
                PlanillaCvActividadesCapacitacion.BorrarContenido();
                PlanillaCvActividadesCapacitacion.CargarObjetos(actividades_capacitacion);
            });
        });

        contenedorBtnAcciones.append(botonEditar);

        var botonEliminar = $('<img>');
        botonEliminar.addClass('remove-item-btn');
        botonEliminar.attr('src', '../Imagenes/iconos_eliminar.png');
        botonEliminar.attr('width', '25px');
        botonEliminar.attr('height', '25px');

        botonEliminar.click(function () {
            ActividadesCapacitacion.eliminar(una_actividad_capacitacion, function (actividad_capacitacion_eliminada) {
                PlanillaCvActividadesCapacitacion.QuitarObjeto(contenedorPlanilla, actividad_capacitacion_eliminada);
            });
        });

        contenedorBtnAcciones.append(botonEliminar);

        return contenedorBtnAcciones;
    }
    }));


PlanillaCvActividadesCapacitacion = new Grilla(columnas);
PlanillaCvActividadesCapacitacion.AgregarEstilo("table table-striped");
PlanillaCvActividadesCapacitacion.SetOnRowClickEventHandler(function (un_estudio) {
            // panelAlumno.CompletarDatosAlumno(un_alumno);
        });

PlanillaCvActividadesCapacitacion.CargarObjetos(actividades_capacitacion);
PlanillaCvActividadesCapacitacion.DibujarEn(contenedorPlanilla);

    },
    eliminar: function (actividad_docente_a_eliminar, alModificar) {
        // confirm dialog
        alertify.confirm("Está seguro que desea eliminar el antecedente", function (e) {
            if (e) {
                // user clicked "ok"
                var data_post = JSON.stringify({
                    "actividadesCapacitacion_borrar": actividad_docente_a_eliminar
                });
                $.ajax({
                    url: "../AjaxWS.asmx/EliminarCVActividadesCapacitacion",
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

FormatoFecha = function (fecha_string) {
    var fecha = new Date(fecha_string);
    return (fecha.getDate() + 1) + "/" + (fecha.getMonth() + 1) + "/" + fecha.getFullYear();
};