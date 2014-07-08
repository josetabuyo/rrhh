using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;

namespace General.Repositorios
{
    public class RepositorioDeCurriculum : IRepositorioDeCurriculum
    {
        protected IConexionBD conexion_bd;
        protected List<CurriculumVitae> lista_cv;
        protected CvDatosPersonales _cvDatosPersonales;
        protected List<CvEstudios> _cvAntecedentesAcademicos;
        protected List<CvCertificadoDeCapacitacion> _cvCapacitacion;
        protected List<CvDocencia> _cvDocencia;
        protected CvEventoAcademico _cvEventoAcademico;
        protected CvPublicaciones _cvPublicacion;
        protected CvMatricula _cvMatricula;
        protected CvInstitucionesAcademicas _cvInstitucion;
        protected CvExperienciaLaboral _cvExperiencia;


        public RepositorioDeCurriculum(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
            this.lista_cv = new List<CurriculumVitae>();
            this._cvAntecedentesAcademicos = new List<CvEstudios>();
            this._cvDocencia = new List<CvDocencia>();
            this._cvCapacitacion = new List<CvCertificadoDeCapacitacion>();

            //FC a borrar cuando traiga los datos de la base
            string fechaIngreso = new DateTime(2014, 12, 12).ToShortDateString();
            string fechaEgreso = new DateTime(2014, 12, 13).ToShortDateString();
            //var un_estudio = new CvEstudios(1, "Contador", "UBA", "Te dije contador", fechaIngreso,fechaEgreso, "CABA", "Argentina");
            //this._cvAntecedentesAcademicos.Add(un_estudio);


        }

        public void ActualizarCV(CurriculumVitae cv)
        {
        }


        public CurriculumVitae GetCV(int documento)
        {
            var parametros = new Dictionary<string, object>();
            //var estudios = new List<CvEstudios>();
            //var docencias = new List<CvDocencia>();

            parametros.Add("@NroDocumento", documento);
            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_GetCurriculumVitae", parametros);

            CurriculumVitae cv = new CurriculumVitaeNull();

            tablaCVs.Rows.ForEach(row =>
            cv = new CurriculumVitae(
                new CvDatosPersonales(documento, row.GetString("Nombre"), row.GetString("Apellido"), row.GetSmallintAsInt("Sexo", 0), row.GetSmallintAsInt("EstadoCivil", 0),
                    row.GetString("Cuil", ""), row.GetString("LugarNacimiento", ""), row.GetSmallintAsInt("Nacionalidad", 0), row.GetDateTime("FechaNacimiento", DateTime.Today).ToString("dd/MM/yyyy"), row.GetSmallintAsInt("TipoDocumento", 0),
                    new CvDomicilio(row.GetInt("DomPers_Id", 0), row.GetString("DomPers_Calle", ""), row.GetInt("DomPers_Numero", 0), row.GetString("DomPers_Piso", ""), row.GetString("DomPers_Depto", ""),
                        row.GetInt("DomPers_Localidad", 0), row.GetSmallintAsInt("DomPers_CodigoPostal", 0), row.GetSmallintAsInt("DomPers_IdProvincia", 0)),
                    new CvDomicilio(row.GetInt("DomLab_Id", 0), row.GetString("DomLab_Calle", ""), row.GetInt("DomLab_Numero", 0), row.GetString("DomLab_Piso", ""), row.GetString("DomLab_Depto", ""),
                        row.GetInt("DomLab_Localidad", 0), row.GetSmallintAsInt("DomLab_CodigoPostal", 0), row.GetSmallintAsInt("DomLab_IdProvincia", 0)), row.GetString("TieneLegajo"))));


            //CORTE DE CONTROL PARA ANTECEDENTES ACADEMICOS
            // CorteDeControlAntecedentesAcademicos(tablaCVs, cv);

            //CORTE DE CONTROL PARA CERTIFICADOS DE CAPACITACION
            //CorteDeControlCertificadosDeCapacitacion(tablaCVs, cv);

            //CORTE DE CONTROL PARA ACTIVIDADES DOCENTES
            //CorteDeControlActividadesDocentes(tablaCVs, cv);

            //CORTE DE CONTROL PARA MATRICULAS
            //CorteDeControlMatriculas(tablaCVs, cv);

            //CORTE DE CONTROL PARA PUBLICACIONES
            //CorteDeControlPublicaciones(tablaCVs, cv);

            //CORTE DE CONTROL PARA INSTITUCIONES ACADEMICAS
            //CorteDeControlInstituciones(tablaCVs, cv);

            //CORTE DE CONTROL PARA EXPERIENCIAS LABORALES
            //CorteDeControlExperienciasLaborales(tablaCVs, cv);

            //CORTE DE CONTROL PARA IDIOMA
            //CorteDeControlIdioma(tablaCVs, cv);

            //CORTE DE CONTROL PARA COMPETENCIA INFORMATICA
            //CorteDeControlCompetenciaInformatica(tablaCVs, cv);

            //CORTE DE CONTROL PARA OTRAS CAPACIDADES
            //CorteDeControlOtrasCapacidades(tablaCVs, cv);

            if (tablaCVs.Rows.First().GetString("TieneCurriculum") == "Tiene curriculum")
            {
                cv.TieneCv = true;
            }
            else
            {
                cv.TieneCv = false;
            }
            return cv;

        }

        #region CortesDeControl
        private void CorteDeControlAntecedentesAcademicos(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //1.- Controlo que haya al menos 1 resultado
            if (!(tablaCVs.Rows[0].GetObject("IdAntecedentesAcademicos") is DBNull))
            {

                //2.- Creo el estudio anterior por primera vez
                var estudioAnterior = GetAntecedenteAcademicosFromDataRow(tablaCVs.Rows[0]);

                var estudio = estudioAnterior;

                if (estudio.Id != 0)
                {
                    cv.AgregarEstudio(estudio);

                }

                foreach (var row in tablaCVs.Rows)
                {
                    if (!(row.GetObject("IdAntecedentesAcademicos") is DBNull))
                    {

                        //3.- Comparo el estudio anterior con la estudio actual. Si son distitnas creo una nueva y la asigno a la anterior. Si es la misma voy al paso 4
                        if (estudioAnterior.Id != row.GetInt("IdAntecedentesAcademicos", 0))
                        {
                            estudio = GetAntecedenteAcademicosFromDataRow(row);
                            if (estudio.Id != 0)
                            {
                                cv.AgregarEstudio(estudio);
                                estudioAnterior = estudio;
                            }
                        }
                    }
                }
            }
        }

        private void CorteDeControlCertificadosDeCapacitacion(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //1.- Controlo que haya al menos 1 resultado
            if (!(tablaCVs.Rows[0].GetObject("IdCertificadoCapacitacion") is DBNull))
            {

                //2.- Creo el certificado anterior por primera vez
                var certificadoAnterior = GetCertificadoDeCapacitacionFromDataRow(tablaCVs.Rows[0]);

                var certificado = certificadoAnterior;

                if (certificado.Id != 0)
                {
                    cv.AgregarCertificadoDeCapacitacion(certificado);

                }

                foreach (var row in tablaCVs.Rows)
                {
                    if (!(row.GetObject("IdCertificadoCapacitacion") is DBNull))
                    {

                        //3.- Comparo el certificado anterior con la certificado actual. Si son distitnas creo una nueva y la asigno a la anterior. Si es la misma voy al paso 4
                        if (certificadoAnterior.Id != row.GetInt("IdCertificadoCapacitacion", 0))
                        {
                            certificado = GetCertificadoDeCapacitacionFromDataRow(row);
                            if (certificado.Id != 0)
                            {
                                cv.AgregarCertificadoDeCapacitacion(certificado);
                                certificadoAnterior = certificado;
                            }
                        }
                    }
                }
            }
        }

        private void CorteDeControlActividadesDocentes(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //1.- Controlo que haya al menos 1 resultado
            if (!(tablaCVs.Rows[0].GetObject("IdAntecedentesDeDocencia") is DBNull))
            {

                //2.- Creo la docencia anterior por primera vez
                var docenciaAnterior = GetActividadesDocentesFromDataRow(tablaCVs.Rows[0]);

                var docencia = docenciaAnterior;

                if (docencia.Id != 0)
                {
                    cv.AgregarDocencia(docencia);

                }

                foreach (var row in tablaCVs.Rows)
                {
                    if (!(row.GetObject("IdAntecedentesDeDocencia") is DBNull))
                    {

                        //3.- Comparo la docencia anterior con la docencia actual. Si son distitnas creo una nueva y la asigno a la anterior. Si es la misma voy al paso 4
                        if (docenciaAnterior.Id != row.GetInt("IdAntecedentesDeDocencia", 0))
                        {
                            docencia = GetActividadesDocentesFromDataRow(row);
                            if (docencia.Id != 0)
                            {
                                cv.AgregarDocencia(docencia);
                                docenciaAnterior = docencia;
                            }
                        }
                    }
                }
            }
        }

        private void CorteDeControlEventosAcademicos(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //CORTE DE CONTROL PARA EVENTOS ACADEMICOS
            //1.- Controlo que haya al menos 1 resultado
            if (!(tablaCVs.Rows[0].GetObject("EventosAcademicosId") is DBNull))
            {

                //2.- Creo el evento anterior por primera vez
                var eventoAnterior = GetEventosAcademicosFromDataRow(tablaCVs.Rows[0]);

                var evento = eventoAnterior;

                if (evento.Id != 0)
                {
                    cv.AgregarEventoAcademico(evento);

                }

                foreach (var row in tablaCVs.Rows)
                {
                    if (!(row.GetObject("EventosAcademicosId") is DBNull))
                    {

                        if (eventoAnterior.Id != row.GetInt("EventosAcademicosId", 0))
                        {
                            evento = GetEventosAcademicosFromDataRow(row);
                            if (evento.Id != 0)
                            {
                                cv.AgregarEventoAcademico(evento);
                                eventoAnterior = evento;
                            }


                        }
                    }
                }
            }
        }

        private void CorteDeControlOtrasCapacidades(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //CORTE DE CONTROL PARA OTRAS CAPACIDADES
            //1.- Controlo que haya al menos 1 resultado
            if (!(tablaCVs.Rows[0].GetObject("CapacidadesPersonalesId") is DBNull))
            {
                //2.- Creo la capacidad anterior por primera vez
                var capacidadAnterior = GetOtraCapacidadFromDataRow(tablaCVs.Rows[0]);

                var capacidad = capacidadAnterior;

                if (!(tablaCVs.Rows[0].GetObject("CapacidadesPersonalesId") is DBNull))
                {
                    cv.AgregarCapacidadPersonal(capacidad);

                }

                foreach (var row in tablaCVs.Rows)
                {
                    if (!(row.GetObject("CapacidadesPersonalesId") is DBNull))
                    {
                        if (capacidadAnterior.Id != row.GetSmallintAsInt("CapacidadesPersonalesId"))
                        {
                            capacidad = GetOtraCapacidadFromDataRow(row);
                            cv.AgregarCapacidadPersonal(capacidad);
                            capacidadAnterior = capacidad;
                        }
                    }
                }
            }
        }

        private void CorteDeControlMatriculas(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //1.- Controlo que haya al menos 1 resultado
            if (!(tablaCVs.Rows[0].GetObject("IdMatricula") is DBNull))
            {

                //2.- Creo la matricula anterior por primera vez
                var matriculaAnterior = GetMatriculaFromDataRow(tablaCVs.Rows[0]);

                var matricula = matriculaAnterior;

                if (matricula.Id != 0)
                {
                    cv.AgregarMatricula(matricula);

                }

                foreach (var row in tablaCVs.Rows)
                {
                    if (!(row.GetObject("IdMatricula") is DBNull))
                    {

                        //3.- Comparo la matricula anterior con la matricula actual. Si son distitnas creo una nueva y la asigno a la anterior. Si es la misma voy al paso 4
                        if (matriculaAnterior.Id != row.GetInt("IdMatricula", 0))
                        {
                            matricula = GetMatriculaFromDataRow(row);
                            if (matricula.Id != 0)
                            {
                                cv.AgregarMatricula(matricula);
                                matriculaAnterior = matricula;
                            }
                        }
                    }
                }
            }
        }

        private void CorteDeControlPublicaciones(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //1.- Controlo que haya al menos 1 resultado
            if (!(tablaCVs.Rows[0].GetObject("IdPublicacion") is DBNull))
            {

                //2.- Creo la publicacion anterior por primera vez
                var publicacionAnterior = GetPublicacionFromDataRow(tablaCVs.Rows[0]);

                var publicacion = publicacionAnterior;

                if (publicacion.Id != 0)
                {
                    cv.AgregarPublicacion(publicacion);

                }

                foreach (var row in tablaCVs.Rows)
                {
                    if (!(row.GetObject("IdPublicacion") is DBNull))
                    {

                        //3.- Comparo la publicacion anterior con la publicacion actual. Si son distitnas creo una nueva y la asigno a la anterior. Si es la misma voy al paso 4
                        if (publicacionAnterior.Id != row.GetInt("IdPublicacion", 0))
                        {
                            publicacion = GetPublicacionFromDataRow(row);
                            if (publicacion.Id != 0)
                            {
                                cv.AgregarPublicacion(publicacion);
                                publicacionAnterior = publicacion;
                            }
                        }
                    }
                }
            }
        }

        private void CorteDeControlInstituciones(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //1.- Controlo que haya al menos 1 resultado
            if (!(tablaCVs.Rows[0].GetObject("IdInstitucion") is DBNull))
            {

                //2.- Creo la institucion anterior por primera vez
                var institucionAnterior = GetInstitucionFromDataRow(tablaCVs.Rows[0]);

                var institucion = institucionAnterior;

                if (institucion.Id != 0)
                {
                    cv.AgregarInstitucionAcademica(institucion);

                }

                foreach (var row in tablaCVs.Rows)
                {
                    if (!(row.GetObject("IdInstitucion") is DBNull))
                    {

                        //3.- Comparo la institucion anterior con la institucion actual. Si son distitnas creo una nueva y la asigno a la anterior. Si es la misma voy al paso 4
                        if (institucionAnterior.Id != row.GetInt("IdInstitucion", 0))
                        {
                            institucion = GetInstitucionFromDataRow(row);
                            if (institucion.Id != 0)
                            {
                                cv.AgregarInstitucionAcademica(institucion);
                                institucionAnterior = institucion;
                            }
                        }
                    }
                }
            }
        }

        private void CorteDeControlExperienciasLaborales(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //1.- Controlo que haya al menos 1 resultado
            if (!(tablaCVs.Rows[0].GetObject("IdExperienciaLaboral") is DBNull))
            {

                //2.- Creo la experiencia anterior por primera vez
                var experienciaAnterior = GetExperienciaFromDataRow(tablaCVs.Rows[0]);

                var experiencia = experienciaAnterior;

                if (experiencia.Id != 0)
                {
                    cv.AgregarExperienciaLaboral(experiencia);

                }

                foreach (var row in tablaCVs.Rows)
                {
                    if (!(row.GetObject("IdExperienciaLaboral") is DBNull))
                    {

                        //3.- Comparo la experiencia anterior con la experiencia actual. Si son distitnas creo una nueva y la asigno a la anterior. Si es la misma voy al paso 4
                        if (experienciaAnterior.Id != row.GetInt("IdExperienciaLaboral", 0))
                        {
                            experiencia = GetExperienciaFromDataRow(row);
                            if (experiencia.Id != 0)
                            {
                                cv.AgregarExperienciaLaboral(experiencia);
                                experienciaAnterior = experiencia;
                            }
                        }
                    }
                }
            }
        }

        private void CorteDeControlIdioma(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //1.- Controlo que haya al menos 1 resultado
            if (!(tablaCVs.Rows[0].GetObject("IdIdioma") is DBNull))
            {

                //2.- Creo la idioma anterior por primera vez
                var idiomaAnterior = GetIdiomaFromDataRow(tablaCVs.Rows[0]);

                var idioma = idiomaAnterior;

                if (idioma.Id != 0)
                {
                    cv.AgregarIdioma(idioma);

                }

                foreach (var row in tablaCVs.Rows)
                {
                    if (!(row.GetObject("IdIdioma") is DBNull))
                    {

                        //3.- Comparo la idioma anterior con la idioma actual. Si son distitnas creo una nueva y la asigno a la anterior. Si es la misma voy al paso 4
                        if (idiomaAnterior.Id != row.GetInt("IdIdioma", 0))
                        {
                            idioma = GetIdiomaFromDataRow(row);
                            if (idioma.Id != 0)
                            {
                                cv.AgregarIdioma(idioma);
                                idiomaAnterior = idioma;
                            }
                        }
                    }
                }
            }
        }

        private void CorteDeControlCompetenciaInformatica(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //1.- Controlo que haya al menos 1 resultado
            if (!(tablaCVs.Rows[0].GetObject("IdCompetenciaInformatica") is DBNull))
            {

                //2.- Creo la competencia anterior por primera vez
                var competenciaAnterior = GetCompetenciaFromDataRow(tablaCVs.Rows[0]);

                var competencia = competenciaAnterior;

                if (competencia.Id != 0)
                {
                    cv.AgregarCompetenciaInformatica(competencia);

                }

                foreach (var row in tablaCVs.Rows)
                {
                    if (!(row.GetObject("IdCompetenciaInformatica") is DBNull))
                    {

                        //3.- Comparo la competencia anterior con la competencia actual. Si son distitnas creo una nueva y la asigno a la anterior. Si es la misma voy al paso 4
                        if (competenciaAnterior.Id != row.GetInt("IdCompetenciaInformatica", 0))
                        {
                            competencia = GetCompetenciaFromDataRow(row);
                            if (competencia.Id != 0)
                            {
                                cv.AgregarCompetenciaInformatica(competencia);
                                competenciaAnterior = competencia;
                            }
                        }
                    }
                }
            }
        }


        private CvEstudios GetAntecedenteAcademicosFromDataRow(RowDeDatos row)
        {
            return new CvEstudios(row.GetInt("IdAntecedentesAcademicos", 0), row.GetString("AntecedentesAcademicosTitulo", ""), row.GetString("AntecedentesAcademicosEstablecimiento", ""),
                                   row.GetString("AntecedentesAcademicosEspecialidad", ""), row.GetDateTime("AntecedentesAcademicosFechaIngreso", DateTime.Today).ToShortDateString(),
                                   row.GetDateTime("AntecedentesAcademicosFechaEgreso", DateTime.Today).ToShortDateString(), row.GetString("AntecedentesAcademicosLocalidad", ""),
                                   row.GetString("AntecedentesAcademicosPais", ""));

        }

        private CvCertificadoDeCapacitacion GetCertificadoDeCapacitacionFromDataRow(RowDeDatos row)
        {
            return new CvCertificadoDeCapacitacion(row.GetInt("IdCertificadoCapacitacion", 0),
                                                   row.GetString("CertificadoDiploma", ""),
                                                   row.GetString("CertificadoEstablecimiento", ""),
                                                   row.GetString("CertificadoEspecialidad", ""),
                                                   row.GetString("CertificadoDuracion", ""),
                                                   row.GetDateTime("CertificadoFechaInicio", DateTime.Today),
                                                   row.GetDateTime("CertificadoFechaFinalizacion", DateTime.Today),
                                                   row.GetString("CertificadoLocalidad", ""),
                                                   row.GetString("CertificadoPais", ""));

        }

        private CvDocencia GetActividadesDocentesFromDataRow(RowDeDatos row)
        {
            return new CvDocencia(row.GetInt("IdAntecedentesDeDocencia", 0), row.GetString("AntecedentesDeDocenciaAsignatura", ""), row.GetString("AntecedentesDeDocenciaNivelEducativo", ""),
                                   row.GetString("AntecedentesDeDocenciaTipoActividad", ""), row.GetString("AntecedentesDeDocenciaCategoriaDocente", ""), row.GetString("AntecedentesDeDocenciaCaracterDesignacion", ""), row.GetString("AntecedentesDeDocenciaDedicacionDocente", ""), row.GetString("AntecedentesDeDocenciaCargaHoraria", ""),
                                   row.GetDateTime("AntecedentesDeDocenciaFechaInicio", DateTime.Today),
                                   row.GetDateTime("AntecedentesDeDocenciaFechaFinalizacion", DateTime.Today), row.GetString("AntecedentesDeDocenciaEstablecimiento", ""),
                                   row.GetString("AntecedentesDeDocenciaLocalidad", ""), row.GetString("AntecedentesDeDocenciaPais", ""));
        }

        private CvMatricula GetMatriculaFromDataRow(RowDeDatos row)
        {
            return new CvMatricula(row.GetInt("IdMatricula", 0), row.GetString("MatriculaNumero", ""),
                                   row.GetString("MatriculaExpedidoPor", ""),
                                   row.GetString("MatriculaSituacionActual", ""),
                                   row.GetDateTime("MatriculaFechaObtencion", DateTime.Today));
        }

        private CvPublicaciones GetPublicacionFromDataRow(RowDeDatos row)
        {
            return new CvPublicaciones(row.GetInt("IdPublicacion", 0), row.GetString("PublicacionTitulo", ""),
                                   row.GetString("PublicacionEditorial", ""),
                                   row.GetString("PublicacionHojas", ""),
                                   row.GetBoolean("PublicacionCopia"),
                                   row.GetDateTime("PublicacionFecha", DateTime.Today));
        }

        private CvInstitucionesAcademicas GetInstitucionFromDataRow(RowDeDatos row)
        {
            return new CvInstitucionesAcademicas(row.GetInt("IdInstitucion", 0),
                                   row.GetString("InstitucionInstitucion", ""),
                                   row.GetString("InstitucionCaracterEntidad", ""),
                                   row.GetString("InstitucionCargos", ""),
                                   row.GetInt("InstitucionAfiliados", 0),
                                   row.GetString("InstitucionCategoriaActual", ""),
                                   row.GetDateTime("InstitucionFechaAfiliacion", DateTime.Today),
                                   row.GetDateTime("InstitucionFecha", DateTime.Today),
                                   row.GetDateTime("InstitucionFechaInicio", DateTime.Today),
                                   row.GetDateTime("InstitucionFechaFin", DateTime.Today),
                                   row.GetString("InstitucionLocalidad", ""),
                                   row.GetString("InstitucionPais", ""));
        }

        private CvExperienciaLaboral GetExperienciaFromDataRow(RowDeDatos row)
        {
            return new CvExperienciaLaboral(row.GetInt("IdExperienciaLaboral", 0),
                                            row.GetString("ExperienciaLaboralPuestoOcupado", ""),
                                            row.GetString("ExperienciaLaboralMotivoDesvinculacion", ""),
                                            row.GetString("ExperienciaLaboralNombreEmpleador", ""),
                                            row.GetBoolean("ExperienciaLaboralPersonasACargo"),
                                            row.GetString("ExperienciaLaboralTipoEmpresa", ""),
                                            row.GetString("ExperienciaLaboralActividad", ""),
                                            row.GetDateTime("ExperienciaLaboralInicio", DateTime.Today),
                                            row.GetDateTime("ExperienciaLaboralFin", DateTime.Today),
                                            row.GetString("ExperienciaLaboralLocalidad", ""),
                                            row.GetString("ExperienciaLaboralPais", ""));
        }

        private CvIdiomas GetIdiomaFromDataRow(RowDeDatos row)
        {
            return new CvIdiomas(row.GetInt("IdIdioma", 0),
                                row.GetString("IdiomaDiploma", ""),
                                row.GetString("IdiomaEstablecimiento", ""),
                                row.GetString("IdiomaIdioma", ""),
                                row.GetString("IdiomaLectura", ""),
                                row.GetString("IdiomaEscritura", ""),
                                row.GetString("IdiomaOral", ""),
                                row.GetDateTime("IdiomaFechaObtencion", DateTime.Today),
                //row.GetDateTime("IdiomaFechaFin", DateTime.Today),
                                row.GetString("IdiomaLocalidad", ""),
                                row.GetString("IdiomaPais", ""));
        }

        private CvCompetenciasInformaticas GetCompetenciaFromDataRow(RowDeDatos row)
        {
            return new CvCompetenciasInformaticas(row.GetInt("IdCompetenciaInformatica", 0),
                                row.GetString("CompetenciaDiploma", ""),
                                row.GetString("CompetenciaEstablecimiento", ""),
                                row.GetString("CompetenciaTipoInformatica", ""),
                                row.GetString("CompetenciaConocimiento", ""),
                                row.GetString("CompetenciaNivel", ""),
                                row.GetString("CompetenciaLocalidad", ""),
                                row.GetString("CompetenciaPais", ""),
                                row.GetDateTime("CompetenciaFechaObtencion", DateTime.Today));
        }

        private CvEventoAcademico GetEventosAcademicosFromDataRow(RowDeDatos row)
        {
            return new CvEventoAcademico(
                row.GetInt("EventosAcademicosId", 0),
                row.GetString("EventosAcademicosDenominacion", ""),
                row.GetString("EventosAcademicosTipoDeEvento", ""),
                row.GetString("EventosAcademicosCaracterDeParticipacion", ""),
                row.GetDateTime("EventosAcademicosFechaInicio", DateTime.Today),
                row.GetDateTime("EventosAcademicosFechaFin", DateTime.Today),
                row.GetString("EventosAcademicosDuracion", ""),
                row.GetString("EventosAcademicosInstitucion", ""),
                row.GetString("EventosAcademicosLocalidad", ""),
                row.GetString("EventosAcademicosPais", ""));

        }

        private CvCapacidadPersonal GetOtraCapacidadFromDataRow(RowDeDatos row)
        {
            return new CvCapacidadPersonal(row.GetInt("CapacidadesPersonalesId", -1), row.GetInt("CapacidadesPersonalesTipo", -1), row.GetString("CapacidadesPersonalesDetalle", ""));
        }



        # endregion

        #region CvDatosPersonales
        public void GuardarCVDatosPersonales(CvDatosPersonales datosPersonales, Usuario usuario)
        {

            var parametros = new Dictionary<string, object>();
            var cv = this.GetCV(datosPersonales.Dni);

            //Si la persona existe en Leg => Datos_Personales no se debe poder modificar ni DatosPersonales ni DatosPersonalesAdicionales
            //El domicilio al entrar x primera vez no deberia verlos los del Legajo, asiq hago un insert la primera vez

            //Si todavia no tiene CV
            if (cv.TieneCv == false)
            {
                //Si no es empleado
                if (cv.DatosPersonales.TieneLegajo == "No tiene legajo")
                {
                    //insertar en CV_DatosPersonales
                    parametros = CompletarDatosPersonales(datosPersonales, parametros, usuario);

                    conexion_bd.Ejecutar("dbo.CV_Ins_DatosPersonalesNoEmpleados1ravez", parametros);
                }
                //Si es empleado 

                //insert de CV
                parametros = new Dictionary<string, object>();
                parametros.Add("@Dni", datosPersonales.Dni);
                parametros.Add("@usuario", usuario.Id);
                conexion_bd.Ejecutar("dbo.CV_Ins_Curriculum", parametros);

                //insertar en GEN_Domicilios y CV_Domicilio el DomicilioPersonal
                parametros = CompletarDatosDomicilios(datosPersonales.DomicilioPersonal, parametros, 1, usuario);
                parametros.Add("@Dni", datosPersonales.Dni);
                conexion_bd.Ejecutar("dbo.CV_Ins_Domicilio", parametros);

                //insertar en GEN_Domicilios y CV_Domicilio el DomicilioLaboral
                parametros = CompletarDatosDomicilios(datosPersonales.DomicilioLegal, parametros, 2, usuario);
                parametros.Add("@Dni", datosPersonales.Dni);
                conexion_bd.Ejecutar("dbo.CV_Ins_Domicilio", parametros);

            }
            else
            {
                if (cv.DatosPersonales.TieneLegajo == "No tiene legajo") //Si ya tiene CV y no es Empleado
                {
                    //modificar el CV para no empleados
                    parametros = CompletarDatosPersonales(datosPersonales, parametros, usuario);

                    conexion_bd.Ejecutar("dbo.CV_Upd_DatosPersonalesNoEmpleados", parametros);
                }

                //update GEN_Domicilios del domicilio personal
                parametros = CompletarDatosDomicilios(datosPersonales.DomicilioPersonal, parametros, 1, usuario);
                parametros.Add("@idDomicilio", datosPersonales.DomicilioPersonal.Id);
                conexion_bd.Ejecutar("dbo.CV_Upd_Domicilio", parametros);

                //update en GEN_Domicilios del domicilio laboral
                parametros = CompletarDatosDomicilios(datosPersonales.DomicilioLegal, parametros, 2, usuario);
                parametros.Add("@idDomicilio", datosPersonales.DomicilioLegal.Id);
                conexion_bd.Ejecutar("dbo.CV_Upd_Domicilio", parametros);

            }

            //this._cvDatosPersonales = datosPersonales;
            //this.lista_cv.Add(cv);
        }

        private Dictionary<string, object> CompletarDatosDomicilios(CvDomicilio domicilio, Dictionary<string, object> parametros, int tipo, Usuario usuario)
        {
            parametros = new Dictionary<string, object>();

            parametros.Add("@DomicilioCalle", domicilio.Calle);
            parametros.Add("@DomicilioNumero", domicilio.Numero);
            parametros.Add("@DomicilioPiso", domicilio.Piso);
            parametros.Add("@DomicilioDepto", domicilio.Depto);
            parametros.Add("@DomicilioCp", domicilio.Cp);
            parametros.Add("@DomicilioLocalidad", 1);
            parametros.Add("@DomicilioProvincia", domicilio.Provincia);
            parametros.Add("@DomicilioTelefono", "");
            parametros.Add("@DomicilioCorreo_Electronico", "");
            parametros.Add("@Correo_Electronico_MDS", "");
            parametros.Add("@DomicilioTelefono2", "");
            parametros.Add("@DomicilioTipo", tipo);
            parametros.Add("@Usuario", usuario.Id);

            return parametros;
        }

        private Dictionary<string, object> CompletarDatosPersonales(CvDatosPersonales datosPersonales, Dictionary<string, object> parametros, Usuario usuario)
        {
            parametros = new Dictionary<string, object>();

            parametros.Add("@Dni", datosPersonales.Dni);
            parametros.Add("@Apellido", datosPersonales.Apellido);
            parametros.Add("@Nombre", datosPersonales.Nombre);
            parametros.Add("@Cuil", datosPersonales.Cuil);
            parametros.Add("@EstadoCivil", datosPersonales.EstadoCivil);
            parametros.Add("@FechaNacimiento", datosPersonales.FechaNacimiento);
            parametros.Add("@LugarDeNacimiento", datosPersonales.LugarDeNacimiento);
            parametros.Add("@Nacionalidad", datosPersonales.Nacionalidad);
            parametros.Add("@TipoDocumento", datosPersonales.TipoDocumento);
            parametros.Add("@Sexo", datosPersonales.Sexo);
            parametros.Add("@Usuario", usuario.Id);

            return parametros;
        }

        #endregion CvDatosPersonales

        #region CvAntecedentesAcademicos
        public CvEstudios GuardarCvAntecedentesAcademicos(CvEstudios antecedentesAcademicos_nuevo, Usuario usuario)
        {

            var parametros = ParametrosDeAntecedentesAcademicos(antecedentesAcademicos_nuevo, usuario);
            parametros.Add("@idPersona", usuario.Owner.Id);

            var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_AntecedentesAcademicos", parametros);
            antecedentesAcademicos_nuevo.Id = int.Parse(id.ToString());

            return antecedentesAcademicos_nuevo;
        }

        public CvEstudios ActualizarCvAntecedentesAcademicos(CvEstudios antecedentesAcademicos_nuevo, Usuario usuario)
        {
            //var baja = CrearBaja(usuario);

            var parametros = ParametrosDeAntecedentesAcademicos(antecedentesAcademicos_nuevo, usuario);
            parametros.Add("@idAntecedente", antecedentesAcademicos_nuevo.Id);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_ActividadesAcademicas", parametros);

            this._cvAntecedentesAcademicos.Remove(antecedentesAcademicos_nuevo);

            return antecedentesAcademicos_nuevo;

        }

        public CvEstudios EliminarCVAntecedentesAcademicos(CvEstudios antecedentesAcademicos_nuevo, Usuario usuario)
        {
            var baja = CrearBaja(usuario);

            var parametros = ParametrosDeAntecedentesAcademicos(antecedentesAcademicos_nuevo, usuario);
            parametros.Add("@idBaja", baja);
            parametros.Add("@idAntecedente", antecedentesAcademicos_nuevo.Id);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_ActividadesAcademicas", parametros);
            //this._cvAntecedentesAcademicos.Remove(antecedentesAcademicos_nuevo);
            return antecedentesAcademicos_nuevo;
        }

        private Dictionary<string, object> ParametrosDeAntecedentesAcademicos(CvEstudios antecedentesAcademicos_nuevo, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Titulo", antecedentesAcademicos_nuevo.Titulo);
            parametros.Add("@Establecimiento", antecedentesAcademicos_nuevo.Establecimiento);
            parametros.Add("@Especialidad", antecedentesAcademicos_nuevo.Especialidad);
            parametros.Add("@FechaIngreso", antecedentesAcademicos_nuevo.FechaIngreso);
            parametros.Add("@FechaEgreso", antecedentesAcademicos_nuevo.FechaEgreso);
            parametros.Add("@Localidad", antecedentesAcademicos_nuevo.Localidad);
            parametros.Add("@Pais", antecedentesAcademicos_nuevo.Pais);
            parametros.Add("@Usuario", usuario.Id);

            return parametros;

        }
        #endregion

        #region CvCertificadosDeCapacitacion
        public CvCertificadoDeCapacitacion GuardarCvActividadesCapacitacion(CvCertificadoDeCapacitacion certificados_capacitacion_nuevo, Usuario usuario)
        {
            //deberia ser el mismo sp y tabla que antecedentes
            var parametros = ParametrosDeAntecedentesDocencia(certificados_capacitacion_nuevo, usuario, 0);
            parametros.Add("@idPersona", usuario.Owner.Id);

            var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_AntecedentesAcademicos", parametros);
            certificados_capacitacion_nuevo.Id = int.Parse(id.ToString());

            return certificados_capacitacion_nuevo;
        }

        public CvCertificadoDeCapacitacion ActualizarCvCapacidades(CvCertificadoDeCapacitacion capacidades_nuevo, Usuario usuario)
        {
            var parametros = ParametrosDeAntecedentesDocencia(capacidades_nuevo, usuario, 0);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_ActividadesAcademicas", parametros);

            return capacidades_nuevo;
        }

        public CvCertificadoDeCapacitacion EliminarCvActividadesCapacitacion(CvCertificadoDeCapacitacion capacitacion_nuevo, Usuario usuario)
        {
            var baja = CrearBaja(usuario);

            var parametros = ParametrosDeAntecedentesDocencia(capacitacion_nuevo, usuario, baja);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_ActividadesCapacitacion", parametros);

            return capacitacion_nuevo;
        }



        private Dictionary<string, object> ParametrosDeAntecedentesDocencia(CvCertificadoDeCapacitacion capacidades_nuevo, Usuario usuario, int baja)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Titulo", capacidades_nuevo.DiplomaDeCertificacion);
            parametros.Add("@Establecimiento", capacidades_nuevo.Establecimiento);
            parametros.Add("@Especialidad", capacidades_nuevo.Especialidad);
            parametros.Add("@Duracion", capacidades_nuevo.Duracion);
            parametros.Add("@FechaIngreso", capacidades_nuevo.FechaInicio);
            parametros.Add("@FechaEgreso", capacidades_nuevo.FechaFinalizacion);
            parametros.Add("@Localidad", capacidades_nuevo.Localidad);
            parametros.Add("@Pais", capacidades_nuevo.Pais);
            parametros.Add("@Usuario", usuario.Id);
            parametros.Add("@Baja", baja);

            return parametros;

        }
        #endregion CvCertificadosDeCapacitacion

        #region CvAntecedentesDocentes
        public CvDocencia GuardarCvActividadesDocentes(CvDocencia docencia_nuevo, Usuario usuario)
        {
            var parametros = ParametrosDeAntecedentesDocencia(docencia_nuevo, usuario);
            parametros.Add("@idPersona", usuario.Owner.Id);

            var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_ActividadesDocentes", parametros);
            docencia_nuevo.Id = int.Parse(id.ToString());

            return docencia_nuevo;
        }

        public CvDocencia ActualizarCvActividadesDocencia(CvDocencia docencia_nuevo, Usuario usuario)
        {
            var parametros = ParametrosDeAntecedentesDocencia(docencia_nuevo, usuario);
            parametros.Add("@IdDocencia", docencia_nuevo.Id);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_ActividadesDocentes", parametros);

            return docencia_nuevo;
        }

        public CvDocencia EliminarCvActividadesDocentes(CvDocencia docencia_nuevo, Usuario usuario)
        {
            var baja = CrearBaja(usuario);

            var parametros = ParametrosDeAntecedentesDocencia(docencia_nuevo, usuario);
            parametros.Add("@IdDocencia", docencia_nuevo.Id);
            parametros.Add("@Baja", baja);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_ActividadesDocentes", parametros);

            return docencia_nuevo;
        }

        private Dictionary<string, object> ParametrosDeAntecedentesDocencia(CvDocencia docencia_nuevo, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Asignatura", docencia_nuevo.Asignatura);
            parametros.Add("@CaracterDesignacion", docencia_nuevo.CaracterDesignacion);
            parametros.Add("@CargaHoraria", docencia_nuevo.CargaHoraria);
            parametros.Add("@CategoriaDocente", docencia_nuevo.CategoriaDocente);
            parametros.Add("@DedicacionDocente", docencia_nuevo.DedicacionDocente);
            parametros.Add("@Establecimiento", docencia_nuevo.Establecimiento);
            parametros.Add("@NivelEducativo", docencia_nuevo.NivelEducativo);
            parametros.Add("@TipoActividad", docencia_nuevo.TipoActividad);
            parametros.Add("@FechaInicio", docencia_nuevo.FechaInicio);
            parametros.Add("@FechaFinalizacion", docencia_nuevo.FechaFinalizacion);
            parametros.Add("@Localidad", docencia_nuevo.Localidad);
            parametros.Add("@Pais", docencia_nuevo.Pais);
            parametros.Add("@Usuario", usuario.Id);


            return parametros;

        }
        #endregion

        #region CvEventosAcademicos

        public CvEventoAcademico GuardarCvEventoAcademico(CvEventoAcademico eventoAcademico_nuevo, Usuario usuario)
        {
            return eventoAcademico_nuevo;
        }

        public CvEventoAcademico ActualizarCvEventoAcademico(CvEventoAcademico evento_nuevo, Usuario usuario)
        {
            return evento_nuevo;
        }

        public CvEventoAcademico EliminarCvEventosAcademicos(CvEventoAcademico evento_academico_nuevo, Usuario usuario)
        {
            var baja = CrearBaja(usuario);

            var parametros = ParametrosDeEventosAcademicos(evento_academico_nuevo, usuario, baja);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_EventosAcademicos", parametros);

            return evento_academico_nuevo;
        }

        private Dictionary<string, object> ParametrosDeEventosAcademicos(CvEventoAcademico evento_academico_nuevo, Usuario usuario, int baja)
        {
            return new Dictionary<string, object>(); //Le toca a Fer :P
        }

        #endregion CvEventosAcademicos

        #region CvPublicaciones
        public CvPublicaciones GuardarCvPublicacionesTrabajos(CvPublicaciones publicacion_nueva, Usuario usuario)
        {
            var parametros = ParametrosDePublicaciones(publicacion_nueva, usuario);
            parametros.Add("@idPersona", usuario.Owner.Id);

            var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_Publicaciones", parametros);
            publicacion_nueva.Id = int.Parse(id.ToString());

            return publicacion_nueva;
        }

        public CvPublicaciones ActualizarCvPublicaciones(CvPublicaciones publicacion_nueva, Usuario usuario)
        {
            var parametros = ParametrosDePublicaciones(publicacion_nueva, usuario);
            parametros.Add("@IdPublicacion", publicacion_nueva.Id);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_Publicaciones", parametros);

            return publicacion_nueva;
        }

        public CvPublicaciones EliminarCvPublicacionesTrabajos(CvPublicaciones publicacion_nueva, Usuario usuario)
        {
            var baja = CrearBaja(usuario);

            var parametros = ParametrosDePublicaciones(publicacion_nueva, usuario);
            parametros.Add("@IdPublicacion", publicacion_nueva.Id);
            parametros.Add("@Baja", baja);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_Publicaciones", parametros);

            return publicacion_nueva;
        }

        private Dictionary<string, object> ParametrosDePublicaciones(CvPublicaciones publicacion_nueva, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@CantidadHojas", publicacion_nueva.CantidadHojas);
            parametros.Add("@DatosEditorial", publicacion_nueva.DatosEditorial);
            parametros.Add("@DisponeCopia", publicacion_nueva.DisponeCopia);
            parametros.Add("@Titulo", publicacion_nueva.Titulo);
            parametros.Add("@FechaPublicacion", publicacion_nueva.FechaPublicacion);
            parametros.Add("@Usuario", usuario.Id);


            return parametros;

        }
        #endregion

        #region CvMatriculas
        public CvMatricula GuardarCvMatriculas(CvMatricula matricula_nueva, Usuario usuario)
        {
            var parametros = ParametrosDeMatricula(matricula_nueva, usuario);
            parametros.Add("@idPersona", usuario.Owner.Id);

            var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_Matriculas", parametros);
            matricula_nueva.Id = int.Parse(id.ToString());

            return matricula_nueva;
        }

        public CvMatricula ActualizarCvMatriculas(CvMatricula matricula_nueva, Usuario usuario)
        {
            var parametros = ParametrosDeMatricula(matricula_nueva, usuario);
            parametros.Add("@IdMatricula", matricula_nueva.Id);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_Matriculas", parametros);

            return matricula_nueva;
        }

        public CvMatricula EliminarCvMatriculas(CvMatricula matricula_nueva, Usuario usuario)
        {
            var baja = CrearBaja(usuario);

            var parametros = ParametrosDeMatricula(matricula_nueva, usuario);
            parametros.Add("@IdMatricula", matricula_nueva.Id);
            parametros.Add("@Baja", baja);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_Matriculas", parametros);

            return matricula_nueva;
        }

        private Dictionary<string, object> ParametrosDeMatricula(CvMatricula matricula_nueva, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@ExpedidaPor", matricula_nueva.ExpedidaPor);
            parametros.Add("@Numero", matricula_nueva.Numero);
            parametros.Add("@SituacionActual", matricula_nueva.SituacionActual);
            parametros.Add("@FechaInscripcion", matricula_nueva.FechaInscripcion);
            parametros.Add("@Usuario", usuario.Id);


            return parametros;

        }
        #endregion

        #region CvInstituciones
        public CvInstitucionesAcademicas GuardarCvInstituciones(CvInstitucionesAcademicas institucion_nueva, Usuario usuario)
        {
            var parametros = ParametrosDeInstituciones(institucion_nueva, usuario);
            parametros.Add("@idPersona", usuario.Owner.Id);

            var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_Instituciones", parametros);
            institucion_nueva.Id = int.Parse(id.ToString());

            return institucion_nueva;
        }

        public CvInstitucionesAcademicas ActualizarCvInstituciones(CvInstitucionesAcademicas institucion_nueva, Usuario usuario)
        {
            var parametros = ParametrosDeInstituciones(institucion_nueva, usuario);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_Instituciones", parametros);
            parametros.Add("@IdInstitucion", institucion_nueva.Id);

            return institucion_nueva;
        }

        public CvInstitucionesAcademicas EliminarCvInstitucionesAcademicas(CvInstitucionesAcademicas institucion_nueva, Usuario usuario)
        {
            var baja = CrearBaja(usuario);

            var parametros = ParametrosDeInstituciones(institucion_nueva, usuario);
            parametros.Add("@IdInstitucion", institucion_nueva.Id);
            parametros.Add("@Baja", baja);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_Instituciones", parametros);

            return institucion_nueva;
        }

        private Dictionary<string, object> ParametrosDeInstituciones(CvInstitucionesAcademicas institucion_nueva, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@CaracterEntidad", institucion_nueva.CaracterEntidad);
            parametros.Add("@CargosDesempeniados", institucion_nueva.CargosDesempeniados);
            parametros.Add("@CategoriaActual", institucion_nueva.CategoriaActual);
            parametros.Add("@Fecha", institucion_nueva.Fecha);
            parametros.Add("@FechaDeAfiliacion", institucion_nueva.FechaDeAfiliacion);
            parametros.Add("@FechaInicio", institucion_nueva.FechaInicio);
            parametros.Add("@FechaFin", institucion_nueva.FechaFin);
            parametros.Add("@Institucion", institucion_nueva.Institucion);
            parametros.Add("@NumeroAfiliado", institucion_nueva.NumeroAfiliado);
            parametros.Add("@Localidad", institucion_nueva.Localidad);
            parametros.Add("@Pais", institucion_nueva.Pais);
            parametros.Add("@Usuario", usuario.Id);


            return parametros;

        }
        #endregion

        #region CvExperiencias
        public CvExperienciaLaboral GuardarCvExperiencias(CvExperienciaLaboral experiencia_nueva, Usuario usuario)
        {
            var parametros = ParametrosDeExperiencias(experiencia_nueva, usuario);
            parametros.Add("@idPersona", usuario.Owner.Id);

            var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_Experiencias", parametros);
            experiencia_nueva.Id = int.Parse(id.ToString());

            return experiencia_nueva;
        }

        public CvExperienciaLaboral ActualizarCvExperiencias(CvExperienciaLaboral experiencia_nueva, Usuario usuario)
        {
            var parametros = ParametrosDeExperiencias(experiencia_nueva, usuario);
            parametros.Add("@IdExperienciaLaboral", experiencia_nueva.Id);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_Experiencias", parametros);

            return experiencia_nueva;
        }

        public CvExperienciaLaboral EliminarCvExperienciaLaboral(CvExperienciaLaboral experiencia_nueva, Usuario usuario)
        {
            var baja = CrearBaja(usuario);

            var parametros = ParametrosDeExperiencias(experiencia_nueva, usuario);
            parametros.Add("@IdExperienciaLaboral", experiencia_nueva.Id);
            parametros.Add("@Baja", baja);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_Experiencias", parametros);

            return experiencia_nueva;
        }

        private Dictionary<string, object> ParametrosDeExperiencias(CvExperienciaLaboral experiencia_nueva, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Actividad", experiencia_nueva.Actividad);
            parametros.Add("@MotivoDesvinculacion", experiencia_nueva.MotivoDesvinculacion);
            parametros.Add("@NombreEmpleador", experiencia_nueva.NombreEmpleador);
            parametros.Add("@PersonasACargo", experiencia_nueva.PersonasACargo);
            parametros.Add("@PuestoOcupado", experiencia_nueva.PuestoOcupado);
            parametros.Add("@TipoEmpresa", experiencia_nueva.TipoEmpresa);
            parametros.Add("@FechaInicio", experiencia_nueva.FechaInicio);
            parametros.Add("@FechaFin", experiencia_nueva.FechaFin);
            parametros.Add("@Localidad", experiencia_nueva.Localidad);
            parametros.Add("@Pais", experiencia_nueva.Pais);
            parametros.Add("@Usuario", usuario.Id);

            return parametros;

        }
        #endregion

        #region CvIdiomasExtranjeros


        public CvIdiomas GuardarCvIdiomaExtranjero(CvIdiomas idioma_extranjero_nuevo, Usuario usuario)
        {

            var parametros = ParametrosDelIdioma(idioma_extranjero_nuevo, usuario);
            parametros.Add("@idPersona", usuario.Owner.Id);

            //DESCOMENTAR CUANDO ESTÉ HECHO EL SP
            //var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_Idiomas", parametros);
            //idioma_extranjero_nuevo.Id = int.Parse(id.ToString());

            return idioma_extranjero_nuevo;
        }

        public CvIdiomas ActualizarCvIdiomaExtranjero(CvIdiomas idioma_extranjero_modificado, Usuario usuario)
        {
            var parametros = ParametrosDelIdioma(idioma_extranjero_modificado, usuario);
            parametros.Add("@IdIdioma", idioma_extranjero_modificado.Id);
            //DESCOMENTAR CUANDO ESTÉ HECHO EL SP
            //    conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_Idioma", parametros);

            return idioma_extranjero_modificado;
        }

        public bool EliminarCvIdiomaExtranjero(int id_capacidad, Usuario usuario)
        {
            var id_baja = CrearBaja(usuario);

            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdIdioma", id_capacidad);
            parametros.Add("@Usuario", usuario.Id);
            parametros.Add("@Baja", id_baja);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_Idioma", parametros);

            return true;
        }


        private Dictionary<string, object> ParametrosDelIdioma(CvIdiomas idioma_nuevo, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Diploma", idioma_nuevo.Diploma);
            parametros.Add("@Escritura", idioma_nuevo.Escritura);
            parametros.Add("@Establecimiento", idioma_nuevo.Establecimiento);
            parametros.Add("@FechaObtencion", idioma_nuevo.FechaObtencion);
            parametros.Add("@Idioma", idioma_nuevo.Idioma);
            parametros.Add("@Lectura", idioma_nuevo.Lectura);
            parametros.Add("@Oral", idioma_nuevo.Oral);
            parametros.Add("@Localidad", idioma_nuevo.Localidad);
            parametros.Add("@Pais", idioma_nuevo.Pais);
            parametros.Add("@Usuario", usuario.Id);


            return parametros;

        }
        # endregion

        #region CvCapacidadesPersonales/OtrasCapacidades

        public CvCapacidadPersonal GuardarCvOtraCapacidad(CvCapacidadPersonal capacidad_personal_nueva, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdPersona", usuario.Owner.Id);
            parametros.Add("@Tipo", capacidad_personal_nueva.Tipo);
            parametros.Add("@Detalle", capacidad_personal_nueva.Detalle);
            parametros.Add("@Usuario", usuario.Id);

            var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_CapacidadesPersonales", parametros);
            capacidad_personal_nueva.Id = int.Parse(id.ToString());
            return capacidad_personal_nueva;
        }

        public CvCapacidadPersonal ActualizarCvOtraCapacidad(CvCapacidadPersonal capacidad_personal_modificada, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id", capacidad_personal_modificada.Id);
            parametros.Add("@Tipo", capacidad_personal_modificada.Tipo);
            parametros.Add("@Detalle", capacidad_personal_modificada.Detalle);
            parametros.Add("@Usuario", usuario.Id);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_CapacidadesPersonales", parametros);
            return capacidad_personal_modificada;
        }

        public bool EliminarCvOtraCapacidad(int id_capacidad, Usuario usuario)
        {
            var id_baja = CrearBaja(usuario);

            var parametros = new Dictionary<string, object>();
            parametros.Add("@Id", id_capacidad);
            parametros.Add("@Usuario", usuario.Id);
            parametros.Add("@Baja", id_baja);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_CapacidadesPersonales", parametros);

            return true;
        }

        //public List<CvCapacidadPersonal> GetCvCapacidadesPersonales(int documento)
        //{
        //    var capacidades_personales = new List<CvCapacidadPersonal>()
        //                       {
        //                           new CvCapacidadPersonal(1, 1, "Simpatico")
        //                       };

        //    return capacidades_personales;
        //}

        #endregion CvCapacidadesPersonales/OtrasCapacidades

        #region CvCompetenciasInformaticas
        public CvCompetenciasInformaticas GuardarCompetenciasInformaticas(CvCompetenciasInformaticas competencia_informatica, Usuario usuario)
        {
            var parametros = ParametrosDeCompetenciasInformaticas(competencia_informatica, usuario);
            parametros.Add("@idPersona", usuario.Owner.Id);

            var id = conexion_bd.EjecutarEscalar("dbo.CV_Ins_CompetenciasInformaticas", parametros);
            competencia_informatica.Id = int.Parse(id.ToString());

            return competencia_informatica;
        }

        public CvCompetenciasInformaticas ActualizarCvCompetenciaInformatica(CvCompetenciasInformaticas competencia, Usuario usuario)
        {
            var parametros = ParametrosDeCompetenciasInformaticas(competencia, usuario);
            parametros.Add("@IdCompetenciaInformatica", competencia.Id);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_CompetenciasInformaticas", parametros);

            return competencia;
        }

        public CvCompetenciasInformaticas EliminarCvCompetenciasInformaticas(CvCompetenciasInformaticas competencia, Usuario usuario)
        {
            var baja = CrearBaja(usuario);

            var parametros = ParametrosDeCompetenciasInformaticas(competencia, usuario);
            parametros.Add("@IdCompetenciaInformatica", competencia.Id);
            parametros.Add("@Baja", baja);

            conexion_bd.EjecutarSinResultado("dbo.CV_Upd_Del_CompetenciasInformaticas", parametros);

            return competencia;
        }

        private Dictionary<string, object> ParametrosDeCompetenciasInformaticas(CvCompetenciasInformaticas competencia, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Conocimiento", competencia.Conocimiento);
            parametros.Add("@Diploma", competencia.Diploma);
            parametros.Add("@Establecimiento", competencia.Establecimiento);
            parametros.Add("@FechaObtencion", competencia.FechaObtencion);
            parametros.Add("@Nivel", competencia.Nivel);
            parametros.Add("@TipoInformatica", competencia.TipoInformatica);
            parametros.Add("@Localidad", competencia.Localidad);
            parametros.Add("@Pais", competencia.Pais);
            parametros.Add("@Usuario", usuario.Id);

            return parametros;
        }


        #endregion CvCompetenciasInformaticas





        #region GETS
        public List<CvEstudios> GetCvEstudios(int documento)
        {

            return this._cvAntecedentesAcademicos;
        }

        public List<CvCertificadoDeCapacitacion> GetCvCertificadoDeCapacitacion(int documento)
        {
            var certificados_de_capacitaciones = new List<CvCertificadoDeCapacitacion>()
                               {
                                   new CvCertificadoDeCapacitacion(1, "Arquitecto Java", "Oracle", "Java", "2 años",  new DateTime(2012, 01, 13), new DateTime(2014, 03, 10), "CABA", "Argentina" )
                               };

            return certificados_de_capacitaciones;
        }

        public List<CvCompetenciasInformaticas> GetCvCompetenciasInformaticas(int documento)
        {
            var compotencias_informaticas = new List<CvCompetenciasInformaticas>()
                               {
                                   new CvCompetenciasInformaticas(1, "Administrador de Base de Datos", "Sigma", "Base de Datos", "Senior",  "Avanzado" , "CABA", "Argentina", new DateTime(2013, 11, 15) )
                               };

            return compotencias_informaticas;
        }


        public CvDatosPersonales GetCvDatosPersonales(int documento)
        {
            var domicilio = new CvDomicilio(1, "Pedro Morán", 1234, "7", "A", 1, 1419, 2);
            var datos_personales = new CvDatosPersonales(31369852, "Roberto", "Moreno", 1, 1, "20-31369852-7", "Buenos Aires", 1, new DateTime(1985, 07, 23).ToShortDateString(), 1, domicilio, domicilio, "Tiene legajo");
            //return datos_personales;
            return this._cvDatosPersonales;
        }


        public List<CvDocencia> GetCvDocencia(int documento)
        {
            var docencia = new List<CvDocencia>()
                               {
                                   new CvDocencia("Matemática Discreta", "Universitario", "Docencia", "Profesor Titular",  "Jefe de Cátedra" , "Dedicación Exclusiva", "40 horas semanales", new DateTime(2005, 03, 01), new DateTime(2009, 12, 01), "Universidad Tecnológica Nacional", "CABA", "Argentina")
                               };

            return docencia;
        }

        public List<CvDomicilio> GetCvDomicilio(int documento)
        {
            var domicilio = new List<CvDomicilio>()
                               {
                                   new CvDomicilio(1,"Pedro Morán", 1234, "7", "A", 1, 1419, 2)
                               };

            return domicilio;
        }

        public List<CvEventoAcademico> GetCvEventoAcademico(int documento)
        {
            var evento_academico = new List<CvEventoAcademico>()
                               {
                                   new CvEventoAcademico(1, "Encuentro Nacional Docente", "Congreso Nacional", "Expositor", new DateTime(2008, 02, 07), new DateTime(2008, 02, 11), "4 Jornadas",  "Joaquín V. González", "CABA", "Argentina")
                               };

            return evento_academico;
        }

        public List<CvExperienciaLaboral> GetCvExperienciaLaboral(int documento)
        {
            var experiencia_laboral = new List<CvExperienciaLaboral>()
                               {
                                   new CvExperienciaLaboral(1,"Analista Oracle", "Renuncia", "Accenture S.A", false, "Privada", "Consultoría", new DateTime(2001, 07, 07), new DateTime(2004, 12, 21), "CABA", "Argentina")
                               };

            return experiencia_laboral;
        }

        public List<CvIdiomas> GetCvIdiomas(int documento)
        {
            var idiomas = new List<CvIdiomas>()
                               {
                                   new CvIdiomas(1,"CAF Certification", "Cultural Inglesa Pueyrredón", "Inglés", "Avanzado", "Avanzado","Avanzado", new DateTime(1999, 01, 07), "CABA", "Argentina"),
                                   new CvIdiomas(1,"International French Language", "CUI", "Francés", "Avanzado", "Intermedio","Intermedio", new DateTime(2002, 04, 27), "CABA", "Argentina")
                               };

            return idiomas;
        }

        public List<CvInstitucionesAcademicas> GetCvInstitucionesAcademicas(int documento)
        {
            var instituciones_academicas = new List<CvInstitucionesAcademicas>()
                               {
                                   new CvInstitucionesAcademicas(1, "Universidad Tecnológica Nacional", "Pública", "Docente", 1234, "Jefe de Cátedra", new DateTime(1992, 08, 17), new DateTime(1993, 01, 17), new DateTime(1992, 04, 21), new DateTime(2011, 09, 29), "CABA", "Argentina")
                               };

            return instituciones_academicas;
        }

        public List<CvMatricula> GetCvMatricula(int documento)
        {
            var matricula = new List<CvMatricula>()
                               {
                                   new CvMatricula(1,"3217/14", "Gobierno de la ciudad de Buenos Aires", "Vigente", new DateTime(1990, 09, 07))
                               };

            return matricula;
        }

        public List<CvPublicaciones> GetCvPublicaciones(int documento)
        {
            var publicaciones = new List<CvPublicaciones>()
                               {
                                   new CvPublicaciones(1,"Factorizaciones", "Santillana", "377", true, new DateTime(2001, 11, 11))
                               };

            return publicaciones;
        }
        #endregion

        private int CrearBaja(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Motivo", "");
            parametros.Add("@IdUsuario", usuario.Id);

            int id = int.Parse(conexion_bd.EjecutarEscalar("dbo.CV_Ins_Bajas", parametros).ToString());

            return id;
        }

    }
}
