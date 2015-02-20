var FichaDeclaracionJurada = {
    armarFicha: function () {
        var _this = this;
        var curriculum = JSON.parse($('#curriculum').val());

        var postulacion = getVarsUrl();

        var proveedor_ajax = new ProveedorAjax();

        proveedor_ajax.postearAUrl({ url: "GetPostulacionById",
            data: {
                idpostulacion: parseInt(postulacion.id)
            },
            success: function (respuesta) {

                //alertify.alert("El id de la postulacion es: " + respuesta.Id);
                _this.dibujarPuesto(respuesta);
                _this.dibujarCV(curriculum);

            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                alertify.alert("Error en la postulacion seleccionada.");
            }
        }); //FIN AJAX
    },
    dibujarPuesto: function (postulacion) {
        var _this = this;
        //var curriculum = JSON.parse($('#curriculum').val());
        _this.postulacion_numero = $("#num_postulacion");
        _this.postulacion_numero.text(postulacion.Numero);
        _this.puesto_numero = $("#numero_puesto");
        _this.puesto_numero.text(postulacion.Perfil.Numero);
        _this.puesto_convocatoria = $("#puesto_tipo");
        _this.puesto_convocatoria.text(postulacion.Perfil.Tipo);
        _this.puesto_denominacion = $("#puesto_denominacion");
        _this.puesto_denominacion.text(postulacion.Perfil.Denominacion);
        _this.puesto_agrupamiento = $("#puesto_agrupamiento");
        _this.puesto_agrupamiento.text(postulacion.Perfil.Agrupamiento);
        _this.puesto_nivel = $("#puesto_nivel");
        _this.puesto_nivel.text(postulacion.Perfil.Nivel);
        _this.puesto_secretaria = $("#puesto_jefatura");
        _this.puesto_secretaria.text("Secretaria");

        _this.motivo_postulacion = $("#motivo_postulacion");
        _this.motivo_postulacion.text(postulacion.Motivo);


    },
    dibujarCV: function (curriculum) {
        var _this = this;

        _this.cv_apellido = $("#cv_apellido");
        _this.cv_apellido.text(curriculum.DatosPersonales.Apellido + ', ');
        _this.cv_nombre = $("#cv_nombre");
        _this.cv_nombre.text(curriculum.DatosPersonales.Nombre);

        _this.cv_dni = $("#cv_dni");
        _this.cv_dni.text(curriculum.DatosPersonales.Dni);
        _this.cv_estadoCivil = $("#cv_estadoCivil");
        Backend.BuscarEstadosCiviles({ Id: curriculum.DatosPersonales.EstadoCivil })
            .onSuccess(function (estadoCivil) {
                _this.cv_estadoCivil.text(estadoCivil[0].Descripcion);
            });

        _this.cv_fechaNac = $("#cv_fechNac");
        _this.cv_fechaNac.text(curriculum.DatosPersonales.FechaNacimiento);
        _this.cv_lugarNac = $("#cv_lugarNac");
        //_this.cv_lugarNac.text(Repositorio.buscar("LugarDeNacimiento", { Id: curriculum.DatosPersonales.LugarDeNacimiento }, function (lugarDeNacimiento) { lugarDeNacimiento[0].Descripcion }));
        _this.cv_nac = $("#cv_nac");
        Backend.BuscarNacionalidades({ Id: curriculum.DatosPersonales.Nacionalidad })
            .onSuccess(function (nacionalidad) {
                _this.cv_nac.text(nacionalidad[0].Descripcion);
            });
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
            _this.dibujarTitulo(_this.caja_antecedentes_academicos, "Antecedentes Academicos");
            _this.dibujarSubtitulo(_this.caja_antecedentes_academicos, "TITULOS EDUCATIVOS - Comience con el Título del mas alto nivel alcanzado hasta el título secundario obtenido. Para cada uno repita el siguiente esquema:");

            for (var i = 0; i < curriculum.CvEstudios.length; i++) {

                _this.p_titulo = _this.dibujarDatos('Titulos Obtenido: ');
                _this.span_titulo = $('<span>');
                _this.span_titulo.text(curriculum.CvEstudios[i].Titulo);

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
                _this.span_pais.text(curriculum.CvEstudios[i].Pais);

                _this.p_especialidad = _this.dibujarDatos('Especialidad: ');
                _this.span_especialidad = $('<span>');
                _this.span_especialidad.text(curriculum.CvEstudios[i].Especialidad);


                _this.p_titulo.append(_this.span_titulo);
                _this.p_anio_ingreso.append(_this.span_anio_ingreso);
                _this.p_anio.append(_this.span_anio);
                _this.p_establecimiento.append(_this.span_establecimiento);
                _this.p_localidad.append(_this.span_localidad);
                _this.p_pais.append(_this.span_pais);
                _this.p_especialidad.append(_this.span_especialidad);


                _this.titulos_educativos.append(_this.p_titulo);
                _this.titulos_educativos.append(_this.p_anio_ingreso);
                _this.titulos_educativos.append(_this.p_anio);
                _this.titulos_educativos.append(_this.p_establecimiento);
                _this.titulos_educativos.append(_this.p_localidad);
                _this.titulos_educativos.append(_this.p_pais);
                _this.titulos_educativos.append(_this.p_especialidad);

            }

            _this.caja_antecedentes_academicos.append(_this.titulos_educativos);

            //CV Certificados de Capacitacion
            if (curriculum.CvCertificadosDeCapacitacion.length > 0) {
                _this.dibujarSubtitulo(_this.caja_antecedentes_academicos, "Otras Certificaciones / Actividades de Capacitación (incluye becas, pasantías o similares). Ordénelos de acuerdo con el grado de mayor a menor relevancia que Ud. le asigne con relación al cargo postulado. Para uno repita el siguiente esquema:");

                for (var i = 0; i < curriculum.CvCertificadosDeCapacitacion.length; i++) {
                    _this.p_diploma = _this.dibujarDatos('Diploma/Certificación: ');
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
                    _this.span_duracion.text(curriculum.CvCertificadosDeCapacitacion[i].Duracion);

                    _this.p_establecimiento = _this.dibujarDatos('Establecimiento: ');
                    _this.span_establecimiento = $('<span>');
                    _this.span_establecimiento.text(curriculum.CvCertificadosDeCapacitacion[i].Establecimiento);

                    _this.p_localidad = _this.dibujarDatos('Localidad: ');
                    _this.span_localidad = $('<span>');
                    _this.span_localidad.text(curriculum.CvCertificadosDeCapacitacion[i].Localidad);

                    _this.p_pais = _this.dibujarDatos('País: ');
                    _this.span_pais = $('<span>');
                    _this.span_pais.text(curriculum.CvCertificadosDeCapacitacion[i].Pais);

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
            _this.dibujarSubtitulo(_this.caja_actividades_docentes, "Actividad Docente - ordénelos según el grado de mayor o menor relevancia respecto al perfil del cargo postulado. Para cada uno consigne los datos del siguiente esquema");

            for (var i = 0; i < curriculum.CvDocencias.length; i++) {
                _this.p_asignatura = _this.dibujarDatos('Asignatura: ');
                _this.span_asignatura = $('<span>');
                _this.span_asignatura.text(curriculum.CvDocencias[i].Asignatura);

                _this.p_nivel = _this.dibujarDatos('Nivel Educativo: ');
                _this.span_nivel = $('<span>');
                _this.span_nivel.text(curriculum.CvDocencias[i].NivelEducativo);

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
                _this.span_pais.text(curriculum.CvDocencias[i].Pais);

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
                _this.titulos_educativos.append(_this.p_localidad);
                _this.titulos_educativos.append(_this.p_pais);
                _this.titulos_educativos.append(_this.p_anio_inicio);
                _this.titulos_educativos.append(_this.p_anio_finalizacion);
            }

            _this.caja_actividades_docentes.append(_this.titulos_educativos);
        }

        //CV EVENTOS ACADEMICOS
        if (curriculum.CvEventosAcademicos.length > 0) {
            _this.caja_eventos_academicos = $('#caja_eventos_academicos');
            _this.caja_eventos_academicos.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_eventos_academicos, "Eventos Academicos");
            _this.dibujarSubtitulo(_this.caja_eventos_academicos, "Eventos Academicos");

            for (var i = 0; i < curriculum.CvEventosAcademicos.length; i++) {
                _this.p = _this.dibujarDatos('Año: ');
                _this.span = $('<span>');
                var institucion = Backend.ejecutarSincronico("BuscarInstitucionesEventosAcademicos", [{ Id: curriculum.CvEventosAcademicos[i].Institucion}])[0];
                _this.span.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvEventosAcademicos[i].FechaFinalizacion) + ' - ' +
                                institucion.Descripcion + ' - ' +
                                curriculum.CvEventosAcademicos[i].Denominacion);
                _this.p.append(_this.span);
                _this.titulos_educativos.append(_this.p);
            }

            _this.caja_eventos_academicos.append(_this.titulos_educativos);
        }

        //CV PUBLICACIONES
        if (curriculum.CvPublicaciones.length > 0) {
            _this.caja_publicaciones = $('#caja_publicaciones');
            _this.caja_publicaciones.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_publicaciones, "Publicaciones");
            _this.dibujarSubtitulo(_this.caja_publicaciones, "Publicaciones o Trabajos de Investigación");

            for (var i = 0; i < curriculum.CvPublicaciones.length; i++) {
                _this.p_anio = _this.dibujarDatos('Año: ');
                _this.span = $('<span>');
                _this.span.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvPublicaciones[i].FechaPublicacion) + ' - ' +
                                curriculum.CvPublicaciones[i].Titulo + ' - ' +
                                curriculum.CvPublicaciones[i].DatosEditorial);
                _this.p_anio.append(_this.span);
                _this.titulos_educativos.append(_this.p_anio);
            }

            _this.caja_publicaciones.append(_this.titulos_educativos);
        }

        //CV Matriculas
        if (curriculum.CvMatricula.length > 0) {
            _this.caja_matriculas = $('#caja_matriculas');
            _this.caja_matriculas.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_matriculas, "Matriculas");
            _this.dibujarSubtitulo(_this.caja_matriculas, "Matricula Profesional");

            for (var i = 0; i < curriculum.CvMatricula.length; i++) {
                _this.p = _this.dibujarDatos('Numero: ');
                _this.span = $('<span>');
                _this.span.text(curriculum.CvMatricula[i].Numero + ' - ' +
                                curriculum.CvMatricula[i].ExpedidaPor + ' - ' +
                                curriculum.CvMatricula[i].SituacionActual);
                _this.p.append(_this.span);
                _this.titulos_educativos.append(_this.p);
            }

            _this.caja_matriculas.append(_this.titulos_educativos);
        }

        //CV Instituciones Academicas
        if (curriculum.CvInstitucionesAcademicas.length > 0) {
            _this.caja_instituciones = $('#caja_instituciones');
            _this.caja_instituciones.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_instituciones, "Instituciones Academicas");
            _this.dibujarSubtitulo(_this.caja_instituciones, "Pertenencia a Instituciones Académicas o Profesionales Relevantes");

            for (var i = 0; i < curriculum.CvInstitucionesAcademicas.length; i++) {
                _this.p = _this.dibujarDatos('Detalle: ');
                _this.span = $('<span>');
                _this.span.text(curriculum.CvInstitucionesAcademicas[i].Institucion + ' - ' +
                                curriculum.CvInstitucionesAcademicas[i].CaracterEntidad + ' - ' +
                                curriculum.CvInstitucionesAcademicas[i].CargosDesempeniados);
                _this.p.append(_this.span);
                _this.titulos_educativos.append(_this.p);
            }

            _this.caja_instituciones.append(_this.titulos_educativos);
        }

        //CV EXPERIENCIAS LABORALES
        if (curriculum.CvExperienciaLaboral.length > 0) {
            _this.caja_experiencias_laborales = $('#caja_experiencias_laborales');
            _this.caja_experiencias_laborales.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_experiencias_laborales, "Experiencias Laborales");
            _this.dibujarSubtitulo(_this.caja_experiencias_laborales, "Ocupaciones");

            for (var i = 0; i < curriculum.CvExperienciaLaboral.length; i++) {
                _this.p = _this.dibujarDatos(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvExperienciaLaboral[i].FechaInicio) + ' al ' + ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvExperienciaLaboral[i].FechaFin) + ': ');
                _this.span = $('<span>');
                _this.span.text(curriculum.CvExperienciaLaboral[i].PuestoOcupado + ' - ' +
                                curriculum.CvExperienciaLaboral[i].NombreEmpleador);
                _this.p.append(_this.span);
                _this.titulos_educativos.append(_this.p);
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
                _this.dibujarSubtitulo(_this.caja_otras_aptitudes, "Idiomas Extranjeros");

                for (var i = 0; i < curriculum.CvIdiomas.length; i++) {
                    _this.p = _this.dibujarDatos(curriculum.CvIdiomas[i].Idioma + ': ');
                    _this.span = $('<span>');
                    _this.span.text(curriculum.CvIdiomas[i].Diploma);
                    _this.p.append(_this.span);
                    _this.titulos_educativos.append(_this.p);
                }

                _this.caja_otras_aptitudes.append(_this.titulos_educativos);
            }


            if (curriculum.CvCompetenciasInformaticas.length > 0) {

                //Construyo los datos
                //_this.dibujarTitulo(_this.caja_competencias_informaticas, "Competencias Informáticas");
                _this.dibujarSubtitulo(_this.caja_otras_aptitudes, "Competencias Informáticas");

                for (var i = 0; i < curriculum.CvCompetenciasInformaticas.length; i++) {
                    _this.p = _this.dibujarDatos(curriculum.CvCompetenciasInformaticas[i].Conocimiento + ': ');
                    _this.span = $('<span>');
                    _this.span.text(curriculum.CvCompetenciasInformaticas[i].Diploma + ' - ' + curriculum.CvCompetenciasInformaticas[i].Detalle + ' - ' +
                                curriculum.CvCompetenciasInformaticas[i].Establecimiento);
                    _this.p.append(_this.span);
                    _this.titulos_educativos.append(_this.p);
                }

                _this.caja_otras_aptitudes.append(_this.titulos_educativos);

            }

            if (curriculum.CvCapacidadesPersonales.length > 0) {

                //Construyo los datos
                //_this.dibujarTitulo(_this.caja_otras_capacidades, "Capacidades Personales");
                _this.dibujarSubtitulo(_this.caja_otras_aptitudes, "Otras capacidades");

                for (var i = 0; i < curriculum.CvCapacidadesPersonales.length; i++) {
                    _this.p = _this.dibujarDatos('Detalle: ');
                    _this.span = $('<span>');
                    _this.span.text(curriculum.CvCapacidadesPersonales[i].Detalle);
                    _this.p.append(_this.span);
                    _this.titulos_educativos.append(_this.p);
                }

                _this.caja_otras_aptitudes.append(_this.titulos_educativos);
            }


        } //FIN OTRAS APTITUDES

    },
    dibujarTitulo: function (contenedor, titulo) {
        var _this = this;

        _this.titulo = $('<p>');
        _this.titulo.addClass("titulos degrade ");
        _this.titulo.text(titulo);

        contenedor.append(_this.titulo);

    },
    dibujarSubtitulo: function (contenedor, subtitulo) {
        var _this = this;
        _this.titulos_educativos = $('<div>');
        _this.titulos_educativos.addClass("tit-pos");

        _this.subtitulo = $('<p>');
        _this.subtitulo.addClass("sub-titulos");
        _this.subtitulo.text(subtitulo);

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
        _this.span.addClass("atributos");
        _this.span.text(label);
        _this.p.append(_this.span);

        return _this.p;
    }

    /*
    <div class="tit-pos">
    <p class="sub-titulos">Otras Certificaciones / Actividades de Capacitación</p>
    <hr class="lineas-subraya"/>
    <p class="general"><span class="atributos">- Año de Egreso: 2014 </span>- <span>Centro Cultural Matienzo - Curso Intensivo: Del Guión a la Actuación</p>
    <p class="general"><span class="atributos">- Año de Egreso: 2010 </span>- <span>Sindicato de Cinematografía Argentina - Centro de Formación Profesional - Curso Completo de Edición
    </div>
    */



}


 function getVarsUrl() {
          var url = location.search.replace("?", "");
          var arrUrl = url.split("&");
          var urlObj = {};
          for (var i = 0; i < arrUrl.length; i++) {
              var x = arrUrl[i].split("=");
              urlObj[x[0]] = x[1]
          }
          return urlObj;
      }



