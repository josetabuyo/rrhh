var GestionDeTareas = {
    init: function () {

    },
    getTareasParaGestion: function () {
        var _this_original = this;
        Backend.getTicketsPorFuncionalidad()
                    .onSuccess(function (tareas) {

                        var _this = this;

                        $("#tablaTareas").empty();

                        var divGrilla_tareas = $("#tablaTareas");

                        var columnas_tareas = [];

                        columnas_tareas.push(new Columna("#", { generar: function (una_tarea) { return una_tarea.id } }));
                        columnas_tareas.push(new Columna("Fecha Creación", { generar: function (una_tarea) { return ConversorDeFechas.deIsoAFechaEnCriollo(una_tarea.fechaCreacion) } }));
                        //columnas_tareas.push(new Columna("Titulo", { generar: function (una_tarea) { return una_tarea.tipoAlerta.titulo } }));
                        columnas_tareas.push(new Columna("Descripcion", { generar: function (una_tarea) { return una_tarea.tipoTicket.descripcion } }));
                        columnas_tareas.push(new Columna("Creador", { generar: function (una_tarea) { return una_tarea.usuarioCreador.Owner.Apellido + ', ' + una_tarea.usuarioCreador.Owner.Nombre } }));
                        //columnas_tareas.push(new Columna("Tipo de Tarea", { generar: function (una_tarea) { return una_tarea.tipoTarea.descripcion } }));
                        //columnas_tareas.push(new Columna("Estado", { generar: function (una_tarea) { return una_tarea.estado } }));
                        columnas_tareas.push(new Columna('Detalle', {
                            generar: function (una_tarea) {
                                var btn_accion = $('<a>');
                                var img = $('<img>');
                                img.attr('src', '../Imagenes/detalle.png');
                                img.attr('width', '15px');
                                img.attr('height', '15px');
                                btn_accion.append(img);
                                btn_accion.click(function () {
                                    _this_original.MostrarDetalleDeTarea(una_tarea);
                                });
                                return btn_accion;
                            }
                        }));

                        _this.divGrilla_tareas = new Grilla(columnas_tareas);
                        _this.divGrilla_tareas.CambiarEstiloCabecera("estilo_tabla_portal");
                        _this.divGrilla_tareas.SetOnRowClickEventHandler(function (una_tarea) { });
                        _this.divGrilla_tareas.CargarObjetos(tareas);
                        _this.divGrilla_tareas.DibujarEn(divGrilla_tareas);

                        $('.table-hover').removeClass("table-hover");

                        var options = {
                            valueNames: ['Titulo', 'Descripcion', 'Creador']
                        };

                        var featureList = new List('tareas', options);
                    })
                    .onError(function (e) {

                    });
    },
    MostrarDetalleDeTarea: function (tarea) {
        var _this = this;
        //        localStorage.setItem("idTarea", tarea.id);
        //        localStorage.setItem("documento", tarea.usuarioCreador.Owner.Documento);
        //        localStorage.setItem("nombre", tarea.usuarioCreador.Owner.Nombre);
        //        localStorage.setItem("apellido", tarea.usuarioCreador.Owner.Apellido);
        //        localStorage.setItem("idUsuarioCreador", tarea.usuarioCreador.Id);
        //        localStorage.setItem("fecha", tarea.fechaCreacion);

        // $("#pantalla_detalle_alerta").load(tarea.tipoAlerta.urlComponente, { detalle: detalleTarea }, function () {

        vex.defaultOptions.className = 'vex-theme-os';
        vex.open({
            afterOpen: function ($vexContent) {
                $vexContent.load(window.location.origin + '/' + tarea.tipoTicket.urlComponente, function () {
                    Componente.start(tarea.id, $vexContent);
                });

                return $vexContent;
            },
            css: {
                'padding-top': "4%",
                'padding-bottom': "0%",
                'background-color': "rgb(249, 248, 248)"
            },
            contentCSS: {
                width: "80%",
                height: "80%"
            }
        });

    }


}