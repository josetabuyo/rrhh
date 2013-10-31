var admin_planilla;
    function cargar_instancias(id_curso) {
        var instancias;
        var accion = $("#accion").val();
        var contenedor = $("#ContenedorInstancia");
        contenedor.html("");
        if (id_curso > 0) {
            if (accion == "c") {
                var etiqueta = $("<label>").text("Instancias");
                etiqueta.attr("class", "label_evaluaciones");
                instancias = $("<select>").attr("id", "Instancias").change(function () {
                    admin_planilla.cargarPlanilla();
                }).get(0);

                instancias.options.length = 0;
                contenedor.append(etiqueta).append($(instancias));
            } else {
                instancias = $("<input>").attr("type", "hidden").attr("id", "Instancias");
                contenedor.append(instancias);
            }
            if (id_curso > 0) {
                var data_post = JSON.stringify({
                    'id_curso': id_curso
                });

                $.ajax({
                    url: "../AjaxWS.asmx/GetInstanciasDeEvaluacion",
                    type: "POST",
                    async: false,
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        if (accion == "c") {
                            if (respuesta.length > 1) {
                                instancias.add(new Option("Seleccione", "-1"));
                                instancias.add(new Option("Todos", 0));
                            }
                            for (var i = 0; i < respuesta.length; i++) {
                                instancias.add(new Option(respuesta[i].Descripcion, respuesta[i].Id));
                            }
                        } else {
                            instancias.val("0");
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });
            }
            admin_planilla.cargarPlanilla();    
        }else{
            admin_planilla.limpiarGrilla();
        }
    }

    var AdministradorDeEvaluaciones = function () {
        var _this = this;
        var pla;
        var planilla_original;
        var readonly = $("#accion").val() == "a";
        var contenedor_grilla = $("#ContenedorPlanilla");
        var btn_guardar = $("#BtnGuardarEvaluaciones");
        var btn_imprimir = $("#BtnImprimir");

        _this.limpiarGrilla = function () {
            contenedor_grilla.html("");
            btn_guardar.hide();
        }

        _this.cargarPlanilla = function () {
            _this.limpiarGrilla();
            var instancias = $("#Instancias").val();
            var cursos = $("#CmbCurso").val();
            if (instancias && instancias != "-1") {
                var data_post = JSON.stringify({
                    'id_curso': cursos,
                    'id_instancia': instancias
                });

                $.ajax({
                    url: "../AjaxWS.asmx/GetPlanillaEvaluaciones",
                    type: "POST",
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        if (respuesta.MensajeError === "") {
                            _this.dibujarGrilla(respuesta);
                            planilla_original = JSON.parse(respuestaJson.d);
                        }
                        else {
                            alertify.alert(respuesta.MensajeError);
                        }
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });
            } else {
                contenedor_grilla.html("");
            }
        };
        _this.guardarPlanilla = function () {

            var evaluaciones = [];
            var calificaciones_no_validas = 0;
            for (var i = 0; i < pla.evaluaciones.length; i++) {
                var ev = pla.evaluaciones[i];
                if (ev.es_valida()) {
                    ev.Calificacion = ev.nota.html.val();
                    evaluaciones.push({ Id: ev.Id,
                        Calificacion: ev.nota.html.val(),
                        DNIAlumno: ev.DNIAlumno,
                        IdCurso: ev.IdCurso,
                        Fecha: ev.fecha.html.val(),
                        IdInstancia: ev.IdInstancia
                    });                  
                } else {
                    calificaciones_no_validas++;
                }


            }
            if (calificaciones_no_validas > 0) {
                alertify.alert("Hay calificaciones mal cargadas, no se puede realizar el guardado");
            } else {

                var data_post = JSON.stringify({
                    "evaluaciones_nuevas": JSON.stringify(evaluaciones),
                    "evaluaciones_originales": JSON.stringify(planilla_original.Evaluaciones)
                });
                $.ajax({
                    url: "../AjaxWS.asmx/GuardarEvaluaciones",
                    type: "POST",
                    data: data_post,
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (respuestaJson) {
                        var respuesta = JSON.parse(respuestaJson.d);
                        if (respuesta.length > 0)
                            _this.MostrarDetalleErrores(respuesta);
                        alertify.alert("Las calificaciones se guardaron correctamente");
                        _this.cargarPlanilla();
                        
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alertify.alert(errorThrown);
                    }
                });
            }

        };
        _this.dibujarGrilla = function (planilla) {
            var columnas = []

            var instancias = $("#Instancias");

            pla = new Planilla(planilla, readonly);

            if (instancias.val() >= 0) {
                columnas.push(new Columna("Nombre", { generar: function (fila) { return fila.alumno; } }));
                for (var i = 0; i < pla.instancias.length; i++) {
                    columnas.push(new Columna(pla.instancias.html(i), new GeneradorCalificacionEvaluacion(pla.instancias[i])));
                }

                var grilla = new Grilla(columnas);

                grilla.AgregarEstilo("tabla_macc");

                grilla.SetOnRowClickEventHandler(function () {
                    return true;
                });
                grilla.CargarObjetos(pla.grilla());
                grilla.DibujarEn(contenedor_grilla);
                if (readonly) {
                    btn_guardar.hide();
                    btn_imprimir.show();
                } else {
                    btn_guardar.show();
                    btn_imprimir.hide();
                }
            }
        }

        _this.MostrarDetalleErrores = function (evaluaciones_con_errores) {
            var mensaje = "Se produjo un error al guardar las siguientes evaluaciones:\n\n";
            
            var alumnos = planilla_original.Alumnos;
            var instancias = planilla_original.Instancias;
            for (var i = 0; i < evaluaciones_con_errores.length; i++) {
                var alumno = Enumerable.From(alumnos)
                                       .Where(function (x) { return x.Documento == evaluaciones_con_errores[i].DNIAlumno }).First();
                var instancia = Enumerable.From(instancias)
                                       .Where(function (x) { return x.Id == evaluaciones_con_errores[i].IdInstancia }).First();

                mensaje += "Alumno: " + alumno.Nombre + " " + alumno.Apellido + " (" + instancia.Descripcion + ")\n";

            }

            alertify.alert(mensaje);
        }

        _this.imprimirPlanilla = function () {
            var w = window.open();

            w.document.write("<link  rel='stylesheet' href='../bootstrap/css/bootstrap.css' type='text/css' />");
            w.document.write("<link  rel='stylesheet' href='../bootstrap/css/bootstrap-responsive.css' type='text/css' />");
            w.document.write("<link  rel='stylesheet' href='../Estilos/Estilos.css' type='text/css'  />");
            w.document.write("<style>div_print{margin:20px;}.text_2caracteres{max-width: 20px;margin-left: 3px;}.text_10caracteres{max-width: 100px;margin-left: 17px;}</style>");
            w.document.write("<div class='div_print'><br>Curso: " + $("#CmbCurso option:selected").text() + "<br><br></div>");
            w.document.write(contenedor_grilla.html());
            w.print();
            //w.close();
        }

    }