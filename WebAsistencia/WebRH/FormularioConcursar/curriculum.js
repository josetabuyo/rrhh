var Curriculum = {

    dibujarCV: function (curriculum) {
        var _this = this;

        _this.cv_apellido = $("#cv_apellido");
        _this.cv_apellido.text(curriculum.DatosPersonales.Apellido + ', ');
        _this.cv_nombre = $("#cv_nombre");
        _this.cv_nombre.text(curriculum.DatosPersonales.Nombre);

        _this.cv_dni = $("#cv_dni");
        _this.cv_dni.text(curriculum.DatosPersonales.Dni);
        _this.cv_estadoCivil = $("#cv_estadoCivil");
        var estadoCivil = Backend.ejecutarSincronico("BuscarEstadosCiviles", [{ Id: curriculum.DatosPersonales.EstadoCivil}])[0];
        _this.cv_estadoCivil.text(estadoCivil.Descripcion);

        _this.cv_fechaNac = $("#cv_fechNac");
        _this.cv_fechaNac.text(curriculum.DatosPersonales.FechaNacimiento);
        _this.cv_lugarNac = $("#cv_lugarNac");
        var lugarNacimiento = Backend.ejecutarSincronico("BuscarNacionalidades", [{ Id: curriculum.DatosPersonales.Nacionalidad}])[0];
        _this.cv_lugarNac.text(lugarNacimiento.Descripcion);

        _this.cv_nac = $("#cv_nac");
        var nacionalidad = Backend.ejecutarSincronico("BuscarNacionalidades", [{ Id: curriculum.DatosPersonales.Nacionalidad}])[0];
        _this.cv_nac.text(nacionalidad.Descripcion);

        //_this.cv_nac.text(Repositorio.buscar("Nacionalidades", { Id: curriculum.DatosPersonales.Nacionalidad }, function (nacionalidad) { nacionalidad[0].Descripcion }));
        _this.cv_domPersonal = $("#cv_domPersonal");

        //var localidadPersonal = Backend.ejecutarSincronico("BuscarLocalidades", [{ Id: curriculum.DatosPersonales.DomicilioPersonal.Localidad}])[0];
        var provinciaPersonal = Backend.sync.BuscarProvincias({ Id: curriculum.DatosPersonales.DomicilioPersonal.Provincia })[0];


        _this.cv_domPersonal.text(curriculum.DatosPersonales.DomicilioPersonal.Calle + ' - ' + curriculum.DatosPersonales.DomicilioPersonal.Numero + ' - ' +
                                 curriculum.DatosPersonales.DomicilioPersonal.Piso + ' ' +
                                 curriculum.DatosPersonales.DomicilioPersonal.Depto + ' - ' +
                                 provinciaPersonal.Nombre);

        _this.cv_domLegal = $("#cv_domLegal");

        var localidadLegal = Backend.sync.BuscarLocalidades({ Id: curriculum.DatosPersonales.DomicilioLegal.Localidad })[0];
        if (localidadLegal == undefined) {
            localidadLegal = {};
            localidadLegal.Nombre = "No específico";
        }
        var provinciaLegal = Backend.sync.BuscarProvincias({ Id: curriculum.DatosPersonales.DomicilioLegal.Provincia })[0];

        _this.cv_domLegal.text(curriculum.DatosPersonales.DomicilioLegal.Calle + ' - ' + curriculum.DatosPersonales.DomicilioLegal.Numero + ' - ' +
                                 curriculum.DatosPersonales.DomicilioLegal.Piso + ' ' +
                                 curriculum.DatosPersonales.DomicilioLegal.Depto + ' - ' + localidadLegal.Nombre + ' ' +
                                 provinciaLegal.Nombre);
        _this.cv_telefono = $("#cv_telefono");
        _this.cv_telefono.text(curriculum.DatosPersonales.DatosDeContacto.Telefono);
        _this.cv_mail = $("#cv_mail");
        _this.cv_mail.text(curriculum.DatosPersonales.DatosDeContacto.Email);


        //DIBUJAR CUERPO DEL CV
        //CvEstudios
        if (curriculum.CvEstudios.length > 0) {
            _this.caja_antecedentes_academicos = $('#caja_antecedentes_academicos');
            _this.caja_antecedentes_academicos.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_antecedentes_academicos, "Antecedentes Académicos");
            _this.dibujarSubtitulo(_this.caja_antecedentes_academicos, "TÍTULOS EDUCATIVOS - ", "Comience con el Título del mas alto nivel alcanzado hasta el título secundario obtenido. Para cada uno repita el siguiente esquema.");

            for (var i = 0; i < curriculum.CvEstudios.length; i++) {

                _this.p_titulo = _this.dibujarDatos('Título Obtenido: ');
                _this.span_titulo = $('<span>');
                _this.span_titulo.text(curriculum.CvEstudios[i].Titulo);

                _this.p_nivel = _this.dibujarDatos('Nivel: ');
                _this.span_nivel = $('<span>');
                var estudio = Backend.ejecutarSincronico("BuscarNivelesDeEstudio", [{ Id: curriculum.CvEstudios[i].Nivel}])[0];
                _this.span_nivel.text(estudio.Descripcion);

                _this.p_anio_ingreso = _this.dibujarDatos('Año de ingreso: ');
                _this.span_anio_ingreso = $('<span>');
                _this.span_anio_ingreso.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvEstudios[i].FechaIngreso));

                _this.p_anio = _this.dibujarDatos('Año de egreso: ');
                _this.span_anio = $('<span>');
                _this.span_anio.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvEstudios[i].FechaEgreso));

                _this.p_establecimiento = _this.dibujarDatos('Establecimiento: ');
                _this.span_establecimiento = $('<span>');
                _this.span_establecimiento.text(curriculum.CvEstudios[i].Establecimiento);

                _this.p_localidad = _this.dibujarDatos('Localidad: ');
                _this.span_localidad = $('<span>');
                _this.span_localidad.text(curriculum.CvEstudios[i].Localidad);

                _this.p_pais = _this.dibujarDatos('País: ');
                _this.span_pais = $('<span>');
                var pais = Backend.ejecutarSincronico("BuscarPaises", [{ Id: curriculum.CvEstudios[i].Pais}])[0];
                _this.span_pais.text(pais.Descripcion);

                _this.p_especialidad = _this.dibujarDatos('Especialidad: ');
                _this.span_especialidad = $('<span>');
                _this.span_especialidad.text(curriculum.CvEstudios[i].Especialidad);


                _this.p_titulo.append(_this.span_titulo);
                _this.p_nivel.append(_this.span_nivel);
                _this.p_anio_ingreso.append(_this.span_anio_ingreso);
                _this.p_anio.append(_this.span_anio);
                _this.p_establecimiento.append(_this.span_establecimiento);
                _this.p_localidad.append(_this.span_localidad);
                _this.p_pais.append(_this.span_pais);
                _this.p_especialidad.append(_this.span_especialidad);


                _this.titulos_educativos.append(_this.p_titulo);
                _this.titulos_educativos.append(_this.p_nivel);
                _this.titulos_educativos.append(_this.p_anio_ingreso);
                _this.titulos_educativos.append(_this.p_anio);
                _this.titulos_educativos.append(_this.p_establecimiento);
                _this.titulos_educativos.append(_this.p_localidad);
                _this.titulos_educativos.append(_this.p_pais);
                _this.titulos_educativos.append(_this.p_especialidad);

                var hr = $("<hr> ");
                hr.attr("style", "width:100%;");
                _this.titulos_educativos.append(hr);
                //var espaciado = $("<br />");
                //_this.titulos_educativos.append(espaciado);

            }

            _this.caja_antecedentes_academicos.append(_this.titulos_educativos);

            var espaciado = $("<br />");
            _this.caja_antecedentes_academicos.append(espaciado);

            //CV Certificados de Capacitacion
            if (curriculum.CvCertificadosDeCapacitacion.length > 0) {
                _this.dibujarSubtitulo(_this.caja_antecedentes_academicos, "Otras Certificaciones / Actividades de Capacitación ", "(incluye becas, pasantías o similares). Ordénelos de acuerdo con el grado de mayor a menor relevancia que Ud. le asigne con relación al cargo postulado. Para uno repita el siguiente esquema.");

                for (var i = 0; i < curriculum.CvCertificadosDeCapacitacion.length; i++) {
                    _this.p_diploma = _this.dibujarDatos('Diploma / Certificado: ');
                    _this.span_diploma = $('<span>');
                    _this.span_diploma.text(curriculum.CvCertificadosDeCapacitacion[i].DiplomaDeCertificacion);

                    _this.p_anio_ingreso = _this.dibujarDatos('Fecha de Inicio: ');
                    _this.span_anio_ingreso = $('<span>');
                    _this.span_anio_ingreso.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvCertificadosDeCapacitacion[i].FechaInicio));

                    _this.p_anio_egreso = _this.dibujarDatos('Fecha de Finalización: ');
                    _this.span_anio_egreso = $('<span>');
                    _this.span_anio_egreso.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvCertificadosDeCapacitacion[i].FechaFinalizacion));

                    _this.p_duracion = _this.dibujarDatos('Duración: ');
                    _this.span_duracion = $('<span>');
                    var unidadTiempo = Backend.ejecutarSincronico("BuscarUnidadesTiempo", [{ Id: curriculum.CvCertificadosDeCapacitacion[i].UnidadTiempo}])[0];
                    _this.span_duracion.text(curriculum.CvCertificadosDeCapacitacion[i].Duracion + ' ' + unidadTiempo.Descripcion);

                    _this.p_establecimiento = _this.dibujarDatos('Establecimiento: ');
                    _this.span_establecimiento = $('<span>');
                    _this.span_establecimiento.text(curriculum.CvCertificadosDeCapacitacion[i].Establecimiento);

                    _this.p_localidad = _this.dibujarDatos('Localidad: ');
                    _this.span_localidad = $('<span>');
                    _this.span_localidad.text(curriculum.CvCertificadosDeCapacitacion[i].Localidad);

                    _this.p_pais = _this.dibujarDatos('País: ');
                    _this.span_pais = $('<span>');
                    var pais = Backend.ejecutarSincronico("BuscarPaises", [{ Id: curriculum.CvCertificadosDeCapacitacion[i].Pais}])[0];
                    _this.span_pais.text(pais.Descripcion);

                    _this.p_especialidad = _this.dibujarDatos('Especialidad: ');
                    _this.span_especialidad = $('<span>');
                    _this.span_especialidad.text(curriculum.CvCertificadosDeCapacitacion[i].Especialidad);

                    _this.p_diploma.append(_this.span_diploma);
                    _this.p_anio_ingreso.append(_this.span_anio_ingreso);
                    _this.p_anio_egreso.append(_this.span_anio_egreso);
                    _this.p_duracion.append(_this.span_duracion);
                    _this.p_establecimiento.append(_this.span_establecimiento);
                    _this.p_localidad.append(_this.span_localidad);
                    _this.p_pais.append(_this.span_pais);
                    _this.p_especialidad.append(_this.span_especialidad);

                    _this.titulos_educativos.append(_this.p_diploma);
                    _this.titulos_educativos.append(_this.p_anio_ingreso);
                    _this.titulos_educativos.append(_this.p_anio_egreso);
                    _this.titulos_educativos.append(_this.p_duracion);
                    _this.titulos_educativos.append(_this.p_establecimiento);
                    _this.titulos_educativos.append(_this.p_localidad);
                    _this.titulos_educativos.append(_this.p_pais);
                    _this.titulos_educativos.append(_this.p_especialidad);

                    var hr = $("<hr> ");
                    hr.attr("style", "width:100%;");
                    _this.titulos_educativos.append(hr);
                    //var espaciado = $("<br />");
                    //_this.titulos_educativos.append(espaciado);
                }

                _this.caja_antecedentes_academicos.append(_this.titulos_educativos);

            }
        }

        //CV DOCENCIAS
        if (curriculum.CvDocencias.length > 0) {
            _this.caja_actividades_docentes = $('#caja_actividades_decentes');
            _this.caja_actividades_docentes.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_actividades_docentes, "Actividades Docentes");
            _this.dibujarSubtitulo(_this.caja_actividades_docentes, "Actividad Docente ", "- ordénelos según el grado de mayor o menor relevancia respecto al perfil del cargo postulado. Para cada uno consigne los datos del siguiente esquema.");

            for (var i = 0; i < curriculum.CvDocencias.length; i++) {
                _this.p_asignatura = _this.dibujarDatos('Asignatura: ');
                _this.span_asignatura = $('<span>');
                _this.span_asignatura.text(curriculum.CvDocencias[i].Asignatura);

                _this.p_nivel = _this.dibujarDatos('Nivel Educativo: ');
                _this.span_nivel = $('<span>');
                var nivel_docencia = Backend.ejecutarSincronico("BuscarNivelesDeDocencia", [{ Id: curriculum.CvDocencias[i].NivelEducativo}])[0];
                _this.span_nivel.text(nivel_docencia.Descripcion);

                _this.p_actividad = _this.dibujarDatos('Tipo de Actividad: ');
                _this.span_actividad = $('<span>');
                _this.span_actividad.text(curriculum.CvDocencias[i].TipoActividad);

                _this.p_categoria = _this.dibujarDatos('Categoria Docente: ');
                _this.span_categoria = $('<span>');
                _this.span_categoria.text(curriculum.CvDocencias[i].CategoriaDocente);

                _this.p_caracter = _this.dibujarDatos('Caracter Designación: ');
                _this.span_caracter = $('<span>');
                _this.span_caracter.text(curriculum.CvDocencias[i].CaracterDesignacion);

                _this.p_dedicacion = _this.dibujarDatos('Dedicación Docente: ');
                _this.span_dedicacion = $('<span>');
                _this.span_dedicacion.text(curriculum.CvDocencias[i].DedicacionDocente);

                _this.p_carga = _this.dibujarDatos('Carga horaria: ');
                _this.span_carga = $('<span>');
                _this.span_carga.text(curriculum.CvDocencias[i].CargaHoraria);

                _this.p_establecimiento = _this.dibujarDatos('Establecimiento: ');
                _this.span_establecimiento = $('<span>');
                _this.span_establecimiento.text(curriculum.CvDocencias[i].Establecimiento);

                _this.p_localidad = _this.dibujarDatos('Localidad: ');
                _this.span_localidad = $('<span>');
                _this.span_localidad.text(curriculum.CvDocencias[i].Localidad);

                _this.p_pais = _this.dibujarDatos('País: ');
                _this.span_pais = $('<span>');
                var pais = Backend.ejecutarSincronico("BuscarPaises", [{ Id: curriculum.CvDocencias[i].Pais}])[0];
                _this.span_pais.text(pais.Descripcion);

                _this.p_anio_inicio = _this.dibujarDatos('Fecha de Inicio: ');
                _this.span_inicio = $('<span>');
                _this.span_inicio.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvDocencias[i].FechaInicio));

                _this.p_anio_finalizacion = _this.dibujarDatos('Fecha Finalización: ');
                _this.span_finalizacion = $('<span>');
                _this.span_finalizacion.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvDocencias[i].FechaFinalizacion));



                _this.p_nivel.append(_this.span_nivel);
                _this.p_asignatura.append(_this.span_asignatura);
                _this.p_actividad.append(_this.span_actividad);
                _this.p_categoria.append(_this.span_categoria);
                _this.p_caracter.append(_this.span_caracter);
                _this.p_dedicacion.append(_this.span_dedicacion);
                _this.p_carga.append(_this.span_carga);
                _this.p_establecimiento.append(_this.span_establecimiento);
                _this.p_localidad.append(_this.span_localidad);
                _this.p_pais.append(_this.span_pais);
                _this.p_anio_inicio.append(_this.span_inicio);
                _this.p_anio_finalizacion.append(_this.span_finalizacion);

                _this.titulos_educativos.append(_this.p_nivel);
                _this.titulos_educativos.append(_this.p_asignatura);
                _this.titulos_educativos.append(_this.p_actividad);
                _this.titulos_educativos.append(_this.p_categoria);
                _this.titulos_educativos.append(_this.p_caracter);
                _this.titulos_educativos.append(_this.p_dedicacion);
                _this.titulos_educativos.append(_this.p_carga);
                _this.titulos_educativos.append(_this.p_establecimiento);
                _this.titulos_educativos.append(_this.p_anio_inicio);
                _this.titulos_educativos.append(_this.p_anio_finalizacion);
                _this.titulos_educativos.append(_this.p_localidad);
                _this.titulos_educativos.append(_this.p_pais);


                var hr = $("<hr> ");
                hr.attr("style", "width:100%;");
                _this.titulos_educativos.append(hr);
                var espaciado = $("<br />");
                _this.titulos_educativos.append(espaciado);
            }

            _this.caja_actividades_docentes.append(_this.titulos_educativos);
        }

        //CV EVENTOS ACADEMICOS
        if (curriculum.CvEventosAcademicos.length > 0) {
            _this.caja_eventos_academicos = $('#caja_eventos_academicos');
            _this.caja_eventos_academicos.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_eventos_academicos, "Eventos Academicos");
            _this.dibujarSubtitulo(_this.caja_eventos_academicos, "Eventos Academicos ", "(Participación en conferencias, paneles o mesas redondas, congresos, jornadas, simposios, seminarios u otros cientificos o técnicos): Ordenelos según el grado de mayor o menor relevancia respecto al perfil del cargo postulado. Para cada uno consigne los datos del siguiente esquema.");


            for (var i = 0; i < curriculum.CvEventosAcademicos.length; i++) {

                _this.p_participacion = _this.dibujarDatos('Caracter de Participación: ');
                _this.span_participacion = $('<span>');
                var participacion = Backend.ejecutarSincronico("BuscarCaracterParticipacionEvento", [{ Id: curriculum.CvEventosAcademicos[i].CaracterDeParticipacion}])[0];
                _this.span_participacion.text(participacion.Descripcion);

                _this.p_tipo = _this.dibujarDatos('Tipo de Evento: ');
                _this.span_tipo = $('<span>');
                var tipo_evento = Backend.ejecutarSincronico("BuscarTiposEventosAcademicos", [{ Id: curriculum.CvEventosAcademicos[i].TipoDeEvento}])[0];
                _this.span_tipo.text(tipo_evento.Descripcion);

                _this.p_denominacion = _this.dibujarDatos('Denominación: ');
                _this.span_denominacion = $('<span>');
                _this.span_denominacion.text(curriculum.CvEventosAcademicos[i].Denominacion);

                _this.p_descripcion = _this.dibujarDatos('Descripción: ');
                _this.span_descripcion = $('<span>');
                _this.span_descripcion.text(curriculum.CvEventosAcademicos[i].Descripcion);

                _this.p_duracion = _this.dibujarDatos('Duración: ');
                _this.span_duracion = $('<span>');
                var unidadTiempo = Backend.ejecutarSincronico("BuscarUnidadesTiempo", [{ Id: curriculum.CvEventosAcademicos[i].UnidadTiempo}])[0];
                _this.span_duracion.text(curriculum.CvEventosAcademicos[i].Duracion + ' ' + unidadTiempo.Descripcion);

                _this.p_institucion = _this.dibujarDatos('Institución: ');
                _this.span_institucion = $('<span>');
                var institucion = Backend.ejecutarSincronico("BuscarInstitucionesEventosAcademicos", [{ Id: curriculum.CvEventosAcademicos[i].Institucion}])[0];
                _this.span_institucion.text(institucion.Descripcion);

                _this.p_inicio = _this.dibujarDatos('Fecha Inicio: ');
                _this.span_inicio = $('<span>');
                _this.span_inicio.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvEventosAcademicos[i].FechaInicio));

                _this.p_finalizacion = _this.dibujarDatos('Fecha Finalización: ');
                _this.span_finalizacion = $('<span>');
                _this.span_finalizacion.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvEventosAcademicos[i].FechaFinalizacion));

                _this.p_localidad = _this.dibujarDatos('Localidad: ');
                _this.span_localidad = $('<span>');
                _this.span_localidad.text(curriculum.CvEventosAcademicos[i].Localidad);

                _this.p_pais = _this.dibujarDatos('País: ');
                _this.span_pais = $('<span>');
                var pais = Backend.ejecutarSincronico("BuscarPaises", [{ Id: curriculum.CvEventosAcademicos[i].Pais}])[0];
                _this.span_pais.text(pais.Descripcion);



                _this.p_participacion.append(_this.span_participacion);
                _this.p_tipo.append(_this.span_tipo);
                _this.p_denominacion.append(_this.span_denominacion);
                _this.p_descripcion.append(_this.span_descripcion);
                _this.p_duracion.append(_this.span_duracion);
                _this.p_institucion.append(_this.span_institucion);
                _this.p_inicio.append(_this.span_inicio);
                _this.p_finalizacion.append(_this.span_finalizacion);
                _this.p_localidad.append(_this.span_localidad);
                _this.p_pais.append(_this.span_pais);


                _this.titulos_educativos.append(_this.p_participacion);
                _this.titulos_educativos.append(_this.p_tipo);
                _this.titulos_educativos.append(_this.p_denominacion);
                _this.titulos_educativos.append(_this.p_descripcion);
                _this.titulos_educativos.append(_this.p_duracion);
                _this.titulos_educativos.append(_this.p_institucion);
                _this.titulos_educativos.append(_this.p_inicio);
                _this.titulos_educativos.append(_this.p_finalizacion);
                _this.titulos_educativos.append(_this.p_localidad);
                _this.titulos_educativos.append(_this.p_pais);

                var hr = $("<hr> ");
                hr.attr("style", "width:100%;");
                _this.titulos_educativos.append(hr);
                var espaciado = $("<br />");
                _this.titulos_educativos.append(espaciado);
            }

            _this.caja_eventos_academicos.append(_this.titulos_educativos);
        }

        //CV PUBLICACIONES
        if (curriculum.CvPublicaciones.length > 0) {
            _this.caja_publicaciones = $('#caja_publicaciones');
            _this.caja_publicaciones.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_publicaciones, "Publicaciones");
            _this.dibujarSubtitulo(_this.caja_publicaciones, "Publicaciones o Trabajos de Investigación: ", "Ordénelos según el grado de mayor o menor relevancia respecto al perfil del cargo postulado. Para cada uno consigne los datos del siguiente esquema.");

            for (var i = 0; i < curriculum.CvPublicaciones.length; i++) {

                _this.p_titulo = _this.dibujarDatos('Título: ');
                _this.span_titulo = $('<span>');
                _this.span_titulo.text(curriculum.CvPublicaciones[i].Titulo);

                _this.p_descripcion = _this.dibujarDatos('Descripción: ');
                _this.span_descripcion = $('<span>');
                _this.span_descripcion.text(curriculum.CvPublicaciones[i].Descripcion);

                _this.p_editorial = _this.dibujarDatos('Datos de Editorial: ');
                _this.span_editorial = $('<span>');
                _this.span_editorial.text(curriculum.CvPublicaciones[i].DatosEditorial);

                _this.p_hojas = _this.dibujarDatos('Cantidad de hojas: ');
                _this.span_hojas = $('<span>');
                _this.span_hojas.text(curriculum.CvPublicaciones[i].CantidadHojas);

                _this.p_anio = _this.dibujarDatos('Fecha Publicación: ');
                _this.span_anio = $('<span>');
                _this.span_anio.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvPublicaciones[i].FechaPublicacion));




                _this.p_titulo.append(_this.span_titulo);
                _this.p_descripcion.append(_this.span_descripcion);
                _this.p_editorial.append(_this.span_editorial);
                _this.p_hojas.append(_this.span_hojas);
                _this.p_anio.append(_this.span_anio);

                _this.titulos_educativos.append(_this.p_titulo);
                _this.titulos_educativos.append(_this.p_descripcion);
                _this.titulos_educativos.append(_this.p_editorial);
                _this.titulos_educativos.append(_this.p_hojas);
                _this.titulos_educativos.append(_this.p_anio);

                var hr = $("<hr> ");
                hr.attr("style", "width:100%;");
                _this.titulos_educativos.append(hr);
                var espaciado = $("<br />");
                _this.titulos_educativos.append(espaciado);
            }

            _this.caja_publicaciones.append(_this.titulos_educativos);
        }

        //CV Matriculas
        if (curriculum.CvMatricula.length > 0) {
            _this.caja_matriculas = $('#caja_matriculas');
            _this.caja_matriculas.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_matriculas, "Matrículas");
            _this.dibujarSubtitulo(_this.caja_matriculas, "Matrícula Profesional");

            for (var i = 0; i < curriculum.CvMatricula.length; i++) {

                _this.p_descripcion = _this.dibujarDatos('Descripción: ');
                _this.span_descripcion = $('<span>');
                _this.span_descripcion.text(curriculum.CvMatricula[i].Descripcion);

                _this.p_expedida = _this.dibujarDatos('Expedida por: ');
                _this.span_expedida = $('<span>');
                _this.span_expedida.text(curriculum.CvMatricula[i].ExpedidaPor);

                _this.p_numero = _this.dibujarDatos('Número: ');
                _this.span_numero = $('<span>');
                _this.span_numero.text(curriculum.CvMatricula[i].Numero);

                _this.p_situacion = _this.dibujarDatos('Situación actual: ');
                _this.span_situacion = $('<span>');
                _this.span_situacion.text(curriculum.CvMatricula[i].SituacionActual);

                _this.p_fecha = _this.dibujarDatos('Fecha De Incripción: ');
                _this.span_fecha = $('<span>');
                _this.span_fecha.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvMatricula[i].FechaInscripcion));

                _this.p_descripcion.append(_this.span_descripcion);
                _this.p_expedida.append(_this.span_expedida);
                _this.p_numero.append(_this.span_numero);
                _this.p_situacion.append(_this.span_situacion);
                _this.p_fecha.append(_this.span_fecha);

                _this.titulos_educativos.append(_this.p_descripcion);
                _this.titulos_educativos.append(_this.p_expedida);
                _this.titulos_educativos.append(_this.p_numero);
                _this.titulos_educativos.append(_this.p_situacion);
                _this.titulos_educativos.append(_this.p_fecha);

                var hr = $("<hr> ");
                hr.attr("style", "width:100%;");
                _this.titulos_educativos.append(hr);
                var espaciado = $("<br />");
                _this.titulos_educativos.append(espaciado);
            }

            _this.caja_matriculas.append(_this.titulos_educativos);
        }

        //CV Instituciones Academicas
        if (curriculum.CvInstitucionesAcademicas.length > 0) {
            _this.caja_instituciones = $('#caja_instituciones');
            _this.caja_instituciones.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_instituciones, "Instituciones Academicas");
            _this.dibujarSubtitulo(_this.caja_instituciones, "Pertenencia a Instituciones Académicas o Profesionales Relevantes: ", "Ordénelos según el grado de mayor o menor relevancia respecto al perfil del cargo postulado. Para cada uno de los datos del siguiente esquema.");

            for (var i = 0; i < curriculum.CvInstitucionesAcademicas.length; i++) {


                _this.p_institucion = _this.dibujarDatos('Institución: ');
                _this.span_institucion = $('<span>');
                _this.span_institucion.text(curriculum.CvInstitucionesAcademicas[i].Institucion);

                _this.p_caracter = _this.dibujarDatos('Caracter de Entidad: ');
                _this.span_caracter = $('<span>');
                _this.span_caracter.text(curriculum.CvInstitucionesAcademicas[i].CaracterEntidad);

                _this.p_cargos = _this.dibujarDatos('Cargos Desempeñados: ');
                _this.span_cargos = $('<span>');
                _this.span_cargos.text(curriculum.CvInstitucionesAcademicas[i].CargosDesempeniados);

                _this.p_categoria = _this.dibujarDatos('Categoría Actual: ');
                _this.span_categoria = $('<span>');
                _this.span_categoria.text(curriculum.CvInstitucionesAcademicas[i].CategoriaActual);

                _this.p_descricpion = _this.dibujarDatos('Descripción: ');
                _this.span_descripcion = $('<span>');
                _this.span_descripcion.text(curriculum.CvInstitucionesAcademicas[i].Descripcion);

                _this.p_fecha = _this.dibujarDatos('Fecha: ');
                _this.span_fecha = $('<span>');
                _this.span_fecha.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvInstitucionesAcademicas[i].Fecha));

                _this.p_numero = _this.dibujarDatos('Número de afiliado: ');
                _this.span_numero = $('<span>');
                _this.span_numero.text(curriculum.CvInstitucionesAcademicas[i].NumeroAfiliado);

                _this.p_fecha_afiliacion = _this.dibujarDatos('Fecha de Afiliación: ');
                _this.span_fecha_afiliacion = $('<span>');
                _this.span_fecha_afiliacion.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvInstitucionesAcademicas[i].FechaDeAfiliacion));

                _this.p_fecha_inicio = _this.dibujarDatos('Fecha Inicio: ');
                _this.span_fecha_inicio = $('<span>');
                _this.span_fecha_inicio.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvInstitucionesAcademicas[i].FechaInicio));

                _this.p_fecha_fin = _this.dibujarDatos('Fecha Finalización: ');
                _this.span_fecha_fin = $('<span>');
                _this.span_fecha_fin.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvInstitucionesAcademicas[i].FechaFin));

                _this.p_localidad = _this.dibujarDatos('Localidad: ');
                _this.span_localidad = $('<span>');
                _this.span_localidad.text(curriculum.CvInstitucionesAcademicas[i].Localidad);

                _this.p_pais = _this.dibujarDatos('País: ');
                _this.span_pais = $('<span>');
                var pais = Backend.ejecutarSincronico("BuscarPaises", [{ Id: curriculum.CvInstitucionesAcademicas[i].Pais}])[0];
                _this.span_pais.text(pais.Descripcion);

                _this.p_institucion.append(_this.span_institucion);
                _this.p_caracter.append(_this.span_caracter);
                _this.p_cargos.append(_this.span_cargos);
                _this.p_categoria.append(_this.span_categoria);
                _this.p_descricpion.append(_this.span_descripcion);
                _this.p_fecha.append(_this.span_fecha);
                _this.p_numero.append(_this.span_numero);
                _this.p_fecha_afiliacion.append(_this.span_fecha_afiliacion);
                _this.p_fecha_inicio.append(_this.span_fecha_inicio);
                _this.p_fecha_fin.append(_this.span_fecha_fin);
                _this.p_localidad.append(_this.span_localidad);
                _this.p_pais.append(_this.span_pais);

                _this.titulos_educativos.append(_this.p_institucion);
                _this.titulos_educativos.append(_this.p_caracter);
                _this.titulos_educativos.append(_this.p_cargos);
                _this.titulos_educativos.append(_this.p_categoria);
                _this.titulos_educativos.append(_this.p_descricpion);
                _this.titulos_educativos.append(_this.p_fecha);
                _this.titulos_educativos.append(_this.p_numero);
                _this.titulos_educativos.append(_this.p_fecha_afiliacion);
                _this.titulos_educativos.append(_this.p_fecha_inicio);
                _this.titulos_educativos.append(_this.p_fecha_fin);
                _this.titulos_educativos.append(_this.p_localidad);
                _this.titulos_educativos.append(_this.p_pais);

                var hr = $("<hr> ");
                hr.attr("style", "width:100%;");
                _this.titulos_educativos.append(hr);
                var espaciado = $("<br />");
                _this.titulos_educativos.append(espaciado);
            }

            _this.caja_instituciones.append(_this.titulos_educativos);
        }

        //CV EXPERIENCIAS LABORALES
        if (curriculum.CvExperienciaLaboral.length > 0) {
            _this.caja_experiencias_laborales = $('#caja_experiencias_laborales');
            _this.caja_experiencias_laborales.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_experiencias_laborales, "Experiencias Laborales");
            _this.dibujarSubtitulo(_this.caja_experiencias_laborales, "Ocupaciones: ", "Consignar las experiencias laborales relevantes a las ocupaciones, comenzando por la mas reciente. Para cada una de ellas registre los datos del siguiente esquema.");


            for (var i = 0; i < curriculum.CvExperienciaLaboral.length; i++) {

                _this.p_actividad = _this.dibujarDatos('Actividad: ');
                _this.span_actividad = $('<span>');
                _this.span_actividad.text(curriculum.CvExperienciaLaboral[i].Actividad);

                _this.p_ambito = _this.dibujarDatos('Ámbito Laboral: ');
                _this.span_ambito = $('<span>');
                var ambito = Backend.ejecutarSincronico("BuscarAmbitosLaborales", [{ Id: curriculum.CvExperienciaLaboral[i].AmbitoLaboral}])[0];
                _this.span_ambito.text(ambito.Descripcion);

                _this.p_descripcion = _this.dibujarDatos('Descripción: ');
                _this.span_descripcion = $('<span>');
                _this.span_descripcion.text(curriculum.CvExperienciaLaboral[i].Descripcion);

                _this.p_puesto = _this.dibujarDatos('Puesto Ocupado: ');
                _this.span_puesto = $('<span>');
                _this.span_puesto.text(curriculum.CvExperienciaLaboral[i].PuestoOcupado);

                _this.p_empleador = _this.dibujarDatos('Nombre del Empleador: ');
                _this.span_empleador = $('<span>');
                _this.span_empleador.text(curriculum.CvExperienciaLaboral[i].NombreEmpleador);

                _this.p_sector = _this.dibujarDatos('Sector: ');
                _this.span_sector = $('<span>');
                _this.span_sector.text(curriculum.CvExperienciaLaboral[i].Sector);

                _this.p_tipo_empresa = _this.dibujarDatos('Tipo de Empresa: ');
                _this.span_tipo_empresa = $('<span>');
                _this.span_tipo_empresa.text(curriculum.CvExperienciaLaboral[i].TipoEmpresa);

                _this.p_desvinculacion = _this.dibujarDatos('Motivo de Desvinculación: ');
                _this.span_desvinculacion = $('<span>');
                _this.span_desvinculacion.text(curriculum.CvExperienciaLaboral[i].MotivoDesvinculacion);

                _this.p_cargo = _this.dibujarDatos('Personas a cargo: ');
                _this.span_cargo = $('<span>');
                _this.span_cargo.text(curriculum.CvExperienciaLaboral[i].PersonasACargo);

                _this.p_inicio = _this.dibujarDatos('Fecha de Inicio: ');
                _this.span_inicio = $('<span>');
                _this.span_inicio.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvExperienciaLaboral[i].FechaInicio));

                _this.p_fin = _this.dibujarDatos('Fecha de Finaliación: ');
                _this.span_fin = $('<span>');
                _this.span_fin.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvExperienciaLaboral[i].FechaFin));

                _this.p_localidad = _this.dibujarDatos('Localidad: ');
                _this.span_localidad = $('<span>');
                _this.span_localidad.text(curriculum.CvExperienciaLaboral[i].Localidad);

                _this.p_pais = _this.dibujarDatos('País: ');
                _this.span_pais = $('<span>');
                var pais = Backend.ejecutarSincronico("BuscarPaises", [{ Id: curriculum.CvExperienciaLaboral[i].Pais}])[0];
                _this.span_pais.text(pais.Descripcion);

                _this.p_actividad.append(_this.span_actividad);
                _this.p_ambito.append(_this.span_ambito);
                _this.p_descripcion.append(_this.span_descripcion);
                _this.p_puesto.append(_this.span_puesto);
                _this.p_empleador.append(_this.span_empleador);
                _this.p_sector.append(_this.span_sector);
                _this.p_tipo_empresa.append(_this.span_tipo_empresa);
                _this.p_desvinculacion.append(_this.span_desvinculacion);
                _this.p_cargo.append(_this.span_cargo);
                _this.p_inicio.append(_this.span_inicio);
                _this.p_fin.append(_this.span_fin);
                _this.p_localidad.append(_this.span_localidad);
                _this.p_pais.append(_this.span_pais);

                _this.titulos_educativos.append(_this.p_actividad);
                _this.titulos_educativos.append(_this.p_ambito);
                _this.titulos_educativos.append(_this.p_descripcion);
                _this.titulos_educativos.append(_this.p_puesto);
                _this.titulos_educativos.append(_this.p_empleador);
                _this.titulos_educativos.append(_this.p_sector);
                _this.titulos_educativos.append(_this.p_tipo_empresa);
                _this.titulos_educativos.append(_this.p_desvinculacion);
                _this.titulos_educativos.append($('<br />'));
                _this.titulos_educativos.append(_this.p_cargo);
                _this.titulos_educativos.append(_this.p_inicio);
                _this.titulos_educativos.append(_this.p_fin);
                _this.titulos_educativos.append(_this.p_localidad);
                _this.titulos_educativos.append(_this.p_pais);

                var hr = $("<hr> ");
                hr.attr("style", "width:100%;");
                _this.titulos_educativos.append(hr);
                var espaciado = $("<br />");
                _this.titulos_educativos.append(espaciado);
            }

            _this.caja_experiencias_laborales.append(_this.titulos_educativos);
        }

        //CV OTRAS APTITUDES (IDIOMA + COMPET INFORMATICA + OTRAS CAPACIDADES)
        if (curriculum.CvIdiomas.length > 0 || curriculum.CvCompetenciasInformaticas.length > 0 || curriculum.CvCapacidadesPersonales.length > 0) {
            _this.caja_otras_aptitudes = $('#caja_otras_aptitudes');
            _this.caja_otras_aptitudes.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_otras_aptitudes, "Otras capacidades");
            if (curriculum.CvIdiomas.length > 0) {
                _this.dibujarSubtitulo(_this.caja_otras_aptitudes, "Idiomas Extranjeros: ", "Consigne su nivel de competencia para cada idioma declarado. Si tiene certificación de Institución habilitada indíquela y consigne el certificado obtenido y la fecha de obtención.");


                for (var i = 0; i < curriculum.CvIdiomas.length; i++) {

                    _this.p_idioma = _this.dibujarDatos('Idioma: ');
                    _this.span_idioma = $('<span>');
                    _this.span_idioma.text(curriculum.CvIdiomas[i].Idioma);

                    _this.p_diploma = _this.dibujarDatos('Diploma: ');
                    _this.span_diploma = $('<span>');
                    _this.span_diploma.text(curriculum.CvIdiomas[i].Diploma);

                    _this.p_descripcion = _this.dibujarDatos('Descripción: ');
                    _this.span_descripcion = $('<span>');
                    _this.span_descripcion.text(curriculum.CvIdiomas[i].Descripcion);

                    _this.p_establecimiento = _this.dibujarDatos('Establecimiento: ');
                    _this.span_establecimiento = $('<span>');
                    _this.span_establecimiento.text(curriculum.CvIdiomas[i].Establecimiento);

                    _this.p_fecha = _this.dibujarDatos('Fecha Obtención: ');
                    _this.span_fecha = $('<span>');
                    _this.span_fecha.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvIdiomas[i].FechaObtencion));

                    _this.p_escritura = _this.dibujarDatos('Escritura: ');
                    _this.span_escritura = $('<span>');
                    var escritura = Backend.ejecutarSincronico("BuscarNivelesDeIdioma", [{ Id: curriculum.CvIdiomas[i].Escritura}])[0];
                    _this.span_escritura.text(escritura.Descripcion);

                    _this.p_lectura = _this.dibujarDatos('Lectura: ');
                    _this.span_lectura = $('<span>');
                    var lectura = Backend.ejecutarSincronico("BuscarNivelesDeIdioma", [{ Id: curriculum.CvIdiomas[i].Lectura}])[0];
                    _this.span_lectura.text(lectura.Descripcion);

                    _this.p_oral = _this.dibujarDatos('Oral: ');
                    _this.span_oral = $('<span>');
                    var oral = Backend.ejecutarSincronico("BuscarNivelesDeIdioma", [{ Id: curriculum.CvIdiomas[i].Oral}])[0];
                    _this.span_oral.text(oral.Descripcion);

                    _this.p_localidad = _this.dibujarDatos('Localidad: ');
                    _this.span_localidad = $('<span>');
                    _this.span_localidad.text(curriculum.CvIdiomas[i].Localidad);

                    _this.p_pais = _this.dibujarDatos('País: ');
                    _this.span_pais = $('<span>');
                    var pais = Backend.ejecutarSincronico("BuscarPaises", [{ Id: curriculum.CvIdiomas[i].Pais}])[0];
                    _this.span_pais.text(pais.Descripcion);


                    _this.p_idioma.append(_this.span_idioma);
                    _this.p_diploma.append(_this.span_diploma);
                    _this.p_descripcion.append(_this.span_descripcion);
                    _this.p_establecimiento.append(_this.span_establecimiento);
                    _this.p_fecha.append(_this.span_fecha);
                    _this.p_escritura.append(_this.span_escritura);
                    _this.p_lectura.append(_this.span_lectura);
                    _this.p_oral.append(_this.span_oral);
                    _this.p_localidad.append(_this.span_localidad);
                    _this.p_pais.append(_this.span_pais);

                    _this.titulos_educativos.append(_this.p_idioma);
                    _this.titulos_educativos.append(_this.p_diploma);
                    _this.titulos_educativos.append(_this.p_descripcion);
                    _this.titulos_educativos.append(_this.p_establecimiento);
                    _this.titulos_educativos.append(_this.p_fecha);
                    _this.titulos_educativos.append(_this.p_escritura);
                    _this.titulos_educativos.append(_this.p_lectura);
                    _this.titulos_educativos.append(_this.p_oral);
                    _this.titulos_educativos.append(_this.p_localidad);
                    _this.titulos_educativos.append(_this.p_pais);

                    var hr = $("<hr> ");
                    hr.attr("style", "width:100%;");
                    _this.titulos_educativos.append(hr);
                    var espaciado = $("<br />");
                    _this.titulos_educativos.append(espaciado);
                }

                _this.caja_otras_aptitudes.append(_this.titulos_educativos);
            }


            if (curriculum.CvCompetenciasInformaticas.length > 0) {

                //Construyo los datos
                //_this.dibujarTitulo(_this.caja_competencias_informaticas, "Competencias Informáticas");
                _this.dibujarSubtitulo(_this.caja_otras_aptitudes, "Competencias Informáticas: ", "Consigne aquellas que pueda hacer un uso normal o superior. Si tiene certificación de institución, identifiquela y consigne el certificado obtenido y la fecha de obtención.");

                for (var i = 0; i < curriculum.CvCompetenciasInformaticas.length; i++) {

                    // _this.contenedor1 = $('<div>');
                    // _this.contenedor1.addClass('contenedor_cv');
                    // _this.contenedor2 = $('<div>');
                    // _this.contenedor2.addClass('contenedor_cv');

                    _this.p_conocimiento = _this.dibujarDatos('Conocimiento: ');
                    _this.span_conocimiento = $('<span>');
                    var conocimiento = Backend.ejecutarSincronico("BuscarConocimientoCompetenciaInformatica", [{ Id: curriculum.CvCompetenciasInformaticas[i].Conocimiento}])[0];
                    _this.span_conocimiento.text(conocimiento.Descripcion);

                    _this.p_descripcion = _this.dibujarDatos('Descripción: ');
                    _this.span_descripcion = $('<span>');
                    _this.span_descripcion.text(curriculum.CvCompetenciasInformaticas[i].Descripcion);

                    _this.p_detalle = _this.dibujarDatos('Detalle: ');
                    _this.span_detalle = $('<span>');
                    _this.span_detalle.text(curriculum.CvCompetenciasInformaticas[i].Detalle);

                    _this.p_diploma = _this.dibujarDatos('Diploma: ');
                    _this.span_diploma = $('<span>');
                    _this.span_diploma.text(curriculum.CvCompetenciasInformaticas[i].Diploma);

                    _this.p_tipo = _this.dibujarDatos('Tipo de Informática: ');
                    _this.span_tipo = $('<span>');
                    var tipo = Backend.ejecutarSincronico("BuscarTiposCompetenciaInformatica", [{ Id: curriculum.CvCompetenciasInformaticas[i].TipoInformatica}])[0];
                    _this.span_tipo.text(tipo.Descripcion);

                    _this.p_nivel = _this.dibujarDatos('Nivel: ');
                    _this.span_nivel = $('<span>');
                    var nivel = Backend.ejecutarSincronico("BuscarNivelCompetenciaInformatica", [{ Id: curriculum.CvCompetenciasInformaticas[i].Nivel}])[0];
                    _this.span_nivel.text(nivel.Descripcion);

                    _this.p_fecha = _this.dibujarDatos('Fecha de Obtención: ');
                    _this.span_fecha = $('<span>');
                    _this.span_fecha.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvCompetenciasInformaticas[i].FechaObtencion));

                    _this.p_establecimiento = _this.dibujarDatos('Establecimiento: ');
                    _this.span_establecimiento = $('<span>');
                    _this.span_establecimiento.text(curriculum.CvCompetenciasInformaticas[i].Establecimiento);

                    _this.p_localidad = _this.dibujarDatos('Localidad: ');
                    _this.span_localidad = $('<span>');
                    _this.span_localidad.text(curriculum.CvCompetenciasInformaticas[i].Localidad);

                    _this.p_pais = _this.dibujarDatos('País: ');
                    _this.span_pais = $('<span>');
                    var pais = Backend.ejecutarSincronico("BuscarPaises", [{ Id: curriculum.CvCompetenciasInformaticas[i].Pais}])[0];
                    _this.span_pais.text(pais.Descripcion);

                    _this.p_conocimiento.append(_this.span_conocimiento);
                    _this.p_descripcion.append(_this.span_descripcion);
                    _this.p_detalle.append(_this.span_detalle);
                    _this.p_diploma.append(_this.span_diploma);
                    _this.p_tipo.append(_this.span_tipo);
                    _this.p_nivel.append(_this.span_nivel);
                    _this.p_fecha.append(_this.span_fecha);
                    _this.p_establecimiento.append(_this.span_establecimiento);
                    _this.p_localidad.append(_this.span_localidad);
                    _this.p_pais.append(_this.span_pais);

                    _this.titulos_educativos.append(_this.p_conocimiento);
                    _this.titulos_educativos.append(_this.p_descripcion);
                    _this.titulos_educativos.append(_this.p_detalle);
                    _this.titulos_educativos.append(_this.p_diploma);
                    _this.titulos_educativos.append(_this.p_tipo);
                    _this.titulos_educativos.append(_this.p_nivel);
                    _this.titulos_educativos.append(_this.p_fecha);
                    _this.titulos_educativos.append(_this.p_establecimiento);
                    _this.titulos_educativos.append(_this.p_localidad);
                    _this.titulos_educativos.append(_this.p_pais);

                    var hr = $("<hr> ");
                    hr.attr("style", "width:100%;");
                    _this.titulos_educativos.append(hr);
                    var espaciado = $("<br />");
                    _this.titulos_educativos.append(espaciado);
                }

                _this.caja_otras_aptitudes.append(_this.contenedor1);
                _this.caja_otras_aptitudes.append(_this.contenedor2);

            }

            if (curriculum.CvCapacidadesPersonales.length > 0) {

                //Construyo los datos
                //_this.dibujarTitulo(_this.caja_otras_capacidades, "Capacidades Personales");
                _this.dibujarSubtitulo(_this.caja_otras_aptitudes, "Otras capacidades: ", "para cada uno de los tipos de capacidades citadas a continuación, indique el ámbito laboral o académico en el que las ha usado.");

                for (var i = 0; i < curriculum.CvCapacidadesPersonales.length; i++) {



                    _this.p_detalle = _this.dibujarDatos('Detalle: ');
                    _this.span_detalle = $('<span>');
                    _this.span_detalle.text(curriculum.CvCapacidadesPersonales[i].Detalle);

                    _this.p_descripcion = _this.dibujarDatos('Descripción: ');
                    _this.span_descripcion = $('<span>');
                    _this.span_descripcion.text(curriculum.CvCapacidadesPersonales[i].Descripcion);

                    _this.p_detalle.append(_this.span_detalle);
                    _this.p_descripcion.append(_this.span_descripcion);

                    _this.titulos_educativos.append(_this.p_detalle);
                    _this.titulos_educativos.append(_this.p_descripcion);

                    var hr = $("<hr> ");
                    hr.attr("style", "width:100%;");
                    _this.titulos_educativos.append(hr);
                    var espaciado = $("<br />");
                    _this.titulos_educativos.append(espaciado);
                }

                _this.caja_otras_aptitudes.append(_this.titulos_educativos);
            }


        } //FIN OTRAS APTITUDES

    },
    dibujarTitulo: function (contenedor, titulo) {
        var _this = this;

        _this.titulo = $('<p>');
        _this.titulo.addClass("titulos degrade");
        _this.titulo.text(titulo);

        contenedor.append(_this.titulo);

    },
    dibujarSubtitulo: function (contenedor, subtitulo, descripcion) {
        var _this = this;
        _this.titulos_educativos = $('<div>');
        _this.titulos_educativos.addClass("tit-pos");

        _this.subtitulo = $('<p>');
        _this.subtitulo.addClass("sub-titulos");
        _this.subtitulo.text(subtitulo);

        _this.descripcion = $('<span>');
        _this.descripcion.addClass("sub-titulos-descripcion");
        _this.descripcion.text(descripcion);

        _this.subtitulo.append(_this.descripcion);
        _this.titulos_educativos.append(_this.subtitulo);


        _this.linea = $('<hr>');
        _this.linea.addClass("lineas-subraya");

        _this.titulos_educativos.append(_this.linea);

        contenedor.append(_this.titulos_educativos);
    },
    dibujarDatos: function (label) {
        var _this = this;
        _this.p = $('<p>');
        _this.p.addClass("general");
        _this.span = $('<span>');
        _this.span.addClass("atributos labels_cv");
        _this.span.text(label);
        _this.p.append(_this.span);

        return _this.p;
    }
}





