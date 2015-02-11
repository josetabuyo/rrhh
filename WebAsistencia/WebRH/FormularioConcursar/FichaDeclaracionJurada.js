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
        _this.cv_telefono.text(curriculum.DatosPersonales.Telefono);
        _this.cv_mail = $("#cv_mail");
        _this.cv_mail.text(curriculum.DatosPersonales.Email);


        //DIBUJAR CUERPO DEL CV
        //CvEstudios
        if (curriculum.CvEstudios.length > 0) {
            _this.caja_antecedentes_academicos = $('#caja_antecedentes_academicos');
            _this.caja_antecedentes_academicos.addClass('antec-academ posicion fondo_form');

            //Construyo los datos
            _this.dibujarTitulo(_this.caja_antecedentes_academicos, "Antecedentes Academicos");
            _this.dibujarSubtitulo(_this.caja_antecedentes_academicos, "Titulos Educativos");

            for (var i = 0; i < curriculum.CvEstudios.length; i++) {
                _this.p = _this.dibujarDatos('Año de egreso: ');
                _this.span = $('<span>');
                _this.span.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvEstudios[i].FechaEgreso) + ' - ' +
                                curriculum.CvEstudios[i].Establecimiento + ' - ' +
                                curriculum.CvEstudios[i].Titulo);
                _this.p.append(_this.span);
                _this.titulos_educativos.append(_this.p);
            }

            _this.caja_antecedentes_academicos.append(_this.titulos_educativos);

            //CV Certificados de Capacitacion
            if (curriculum.CvCertificadosDeCapacitacion.length > 0) {
                _this.dibujarSubtitulo(_this.caja_antecedentes_academicos, "Otras Certificaciones / Actividades de Capacitación");

                for (var i = 0; i < curriculum.CvCertificadosDeCapacitacion.length; i++) {
                    _this.p = _this.dibujarDatos('Año de egreso: ');
                    _this.span = $('<span>');
                    _this.span.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvCertificadosDeCapacitacion[i].FechaFinalizacion) + ' - ' +
                                curriculum.CvCertificadosDeCapacitacion[i].DiplomaDeCertificacion);
                    _this.p.append(_this.span);
                    _this.titulos_educativos.append(_this.p);
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
            _this.dibujarSubtitulo(_this.caja_actividades_docentes, "Actividad Docente");

            for (var i = 0; i < curriculum.CvDocencias.length; i++) {
                _this.p = _this.dibujarDatos('Año: ');
                _this.span = $('<span>');
                _this.span.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvDocencias[i].FechaFinalizacion) + ' - ' +
                                curriculum.CvDocencias[i].Establecimiento + ' - ' +
                                curriculum.CvDocencias[i].Asignatura);
                _this.p.append(_this.span);
                _this.titulos_educativos.append(_this.p);
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
                _this.p = _this.dibujarDatos('Año: ');
                _this.span = $('<span>');
                _this.span.text(ConversorDeFechas.deIsoAFechaEnCriollo(curriculum.CvPublicaciones[i].FechaPublicacion) + ' - ' +
                                curriculum.CvPublicaciones[i].Titulo + ' - ' +
                                curriculum.CvPublicaciones[i].DatosEditorial);
                _this.p.append(_this.span);
                _this.titulos_educativos.append(_this.p);
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



