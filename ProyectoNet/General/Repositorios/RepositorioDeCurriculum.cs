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
        protected CvEventoAcademico _cvEventoAcademico;
        protected CvPublicaciones _cvPublicacion;
        protected CvMatricula _cvMatricula;
        protected CvInstitucionesAcademicas _cvInstitucion;
        protected CvExperienciaLaboral _cvExperiencia;

        public RepositorioDeCurriculum(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
            this.lista_cv = new List<CurriculumVitae>();

        }

        public void ActualizarCV(CurriculumVitae cv)
        {
        }

        public CurriculumVitae GetCV(int idPersona, DateTime fechaDeVersion)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPersona", idPersona);
            parametros.Add("@fechaDeVersion", fechaDeVersion);
            return GetCV(parametros);
        }

        public CurriculumVitae GetCV(int idPersona)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idPersona", idPersona);
            return GetCV(parametros);
        }

        private CurriculumVitae GetCV(Dictionary<string, object> parametros)
        {
            var tablaCVs = conexion_bd.Ejecutar("dbo.CV_GetCurriculumVitae", parametros);

            CurriculumVitae cv = new CurriculumVitaeNull();

            tablaCVs.Rows.ForEach((row) => {
                var domi = new CvDomicilio(row.GetInt("DomPers_Id", 0), row.GetString("DomPers_Calle", ""), row.GetInt("DomPers_Numero", 0), row.GetString("DomPers_Piso", ""), row.GetString("DomPers_Depto", ""),
                            row.GetInt("DomPers_Localidad", 0), row.GetSmallintAsInt("DomPers_CodigoPostal", 0), row.GetSmallintAsInt("DomPers_IdProvincia", 0));
                var domi2 = new CvDomicilio(row.GetInt("DomLab_Id", 0), row.GetString("DomLab_Calle", ""), row.GetInt("DomLab_Numero", 0), row.GetString("DomLab_Piso", ""), row.GetString("DomLab_Depto", ""),
                            row.GetInt("DomLab_Localidad", 0), row.GetSmallintAsInt("DomLab_CodigoPostal", 0), row.GetSmallintAsInt("DomLab_IdProvincia", 0));
                var contacto = new DatosDeContacto(row.GetString("DomPers_Telefono", ""), row.GetString("DomPers_Telefono2", ""), row.GetString("DomPers_Email", ""));

                var cuil = row.GetString("Cuil", "00");
                var lugar_nacimiento = row.GetString("LugarNacimiento", "");
                var nac = row.GetSmallintAsInt("Nacionalidad", 0);
                var fecha_nac = row.GetDateTime("FechaNacimiento", DateTime.Today).ToString("dd/MM/yyyy");
                var tipo_doc = row.GetSmallintAsInt("TipoDocumento", 0);
                var nro_documento = row.GetInt("NroDocumento", 0);
                var nombre = row.GetString("Nombre", "");
                var apellido = row.GetString("Apellido", "");
                var sexo = row.GetSmallintAsInt("Sexo", 1);
                var estado_civil = row.GetSmallintAsInt("EstadoCivil", 0);
                
                cv = new CurriculumVitae(
                    new CvDatosPersonales(nro_documento, nombre, apellido, sexo, estado_civil,
                        cuil, lugar_nacimiento, nac, fecha_nac, tipo_doc,
                        domi,
                        domi2, row.GetString("TieneLegajo", ""),
                        contacto));
            });
                   

            //CORTE DE CONTROL PARA EVENTOS ACADEMICOS
            CorteDeControlEventosAcademicos(tablaCVs, cv);

            //CORTE DE CONTROL PARA ANTECEDENTES ACADEMICOS
             CorteDeControlAntecedentesAcademicos(tablaCVs, cv);

            //CORTE DE CONTROL PARA CERTIFICADOS DE CAPACITACION
            CorteDeControlCertificadosDeCapacitacion(tablaCVs, cv);

            //CORTE DE CONTROL PARA ACTIVIDADES DOCENTES
            CorteDeControlActividadesDocentes(tablaCVs, cv);

            //CORTE DE CONTROL PARA MATRICULAS
            CorteDeControlMatriculas(tablaCVs, cv);

            //CORTE DE CONTROL PARA PUBLICACIONES
            CorteDeControlPublicaciones(tablaCVs, cv);

            //CORTE DE CONTROL PARA INSTITUCIONES ACADEMICAS
            CorteDeControlInstituciones(tablaCVs, cv);

            //CORTE DE CONTROL PARA EXPERIENCIAS LABORALES
            CorteDeControlExperienciasLaborales(tablaCVs, cv);

            //CORTE DE CONTROL PARA IDIOMA
            CorteDeControlIdioma(tablaCVs, cv);

            //CORTE DE CONTROL PARA COMPETENCIA INFORMATICA
            CorteDeControlCompetenciaInformatica(tablaCVs, cv);

            //CORTE DE CONTROL PARA OTRAS CAPACIDADES
            CorteDeControlOtrasCapacidades(tablaCVs, cv);

            if (tablaCVs.Rows.Any(row => row.GetString("TieneCurriculum", "") == "Tiene curriculum"))
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
            var lista = ArmarFilas(tablaCVs, "IdAntecedentesAcademicos", "AntecedentesAcademicosBaja");

            if (lista.Count > 0)
            {
                var items_anonimos = (from RowDeDatos dRow in lista
                                        select new //CvAntecedentesAcademicos ()
                                        {
                                            Id = dRow.GetInt("IdAntecedentesAcademicos", 0),
                                            Titulo = dRow.GetString("AntecedentesAcademicosTitulo", string.Empty),
                                            IdTitulo = dRow.GetInt("AntecedentesAcademicosIdTitulo", 0),
                                            Nivel = dRow.GetSmallintAsInt("AntecedentesAcademicosNivel", 0),
                                            Anios = dRow.GetSmallintAsInt("AntecedentesAcademicosAnios", 0),
                                            Establecimiento = dRow.GetString("AntecedentesAcademicosEstablecimiento", string.Empty),
                                            Especialidad = dRow.GetString("AntecedentesAcademicosEspecialidad", string.Empty),
                                            FechaIngreso = dRow.GetDateTime("AntecedentesAcademicosFechaIngreso", new DateTime(1, 1, 1, 0, 0, 0)),
                                            FechaEgreso = dRow.GetDateTime("AntecedentesAcademicosFechaEgreso", new DateTime(1,1,1,0,0,0)),
                                            Localidad = dRow.GetString("AntecedentesAcademicosLocalidad", string.Empty),
                                            Pais = dRow.GetSmallintAsInt("AntecedentesAcademicosPais", 9),
                                            Precedente = dRow.GetInt("AntAcadPrecedente", 0),
                                            Baja = dRow.GetInt("AntecedentesAcademicosBaja", 0)
                                        }).Distinct().ToList();

                items_anonimos.RemoveAll(e => items_anonimos.Any(prev => prev.Precedente == e.Id));
                items_anonimos.RemoveAll(e => e.Baja != 0);

                items_anonimos.Select(a => new CvEstudios(a.Id, a.Titulo, a.IdTitulo, a.Nivel, a.Anios, a.Establecimiento,
                                                                    a.Especialidad, a.FechaIngreso, a.FechaEgreso,
                                                                    a.Localidad, a.Pais)).ToList().ForEach(ev => cv.AgregarEstudio(ev));

            }
        }

        private void CorteDeControlCertificadosDeCapacitacion(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            var lista = ArmarFilas(tablaCVs, "IdCertificadoCapacitacion", "CertificadoBaja");

            if (lista.Count > 0)
            {
                var items_anonimos = (from RowDeDatos dRow in lista
                                              select new 
                                              {
                                                  Id = dRow.GetInt("IdCertificadoCapacitacion", 0),
                                                  Diploma = dRow.GetString("CertificadoDiploma", string.Empty),
                                                  Establecimiento = dRow.GetString("CertificadoEstablecimiento", string.Empty),
                                                  Especialidad = dRow.GetString("CertificadoEspecialidad", string.Empty),
                                                  Duracion = dRow.GetString("CertificadoDuracion", string.Empty),
                                                  FechaInicio = dRow.GetDateTime("CertificadoFechaInicio", new DateTime(1, 1, 1, 0, 0, 0)),
                                                  FechaFinalizacion = dRow.GetDateTime("CertificadoFechaFinalizacion", new DateTime(1, 1, 1, 0, 0, 0)),
                                                  Localidad = dRow.GetString("CertificadoLocalidad", string.Empty),
                                                  Pais = dRow.GetSmallintAsInt("CertificadoPais", 9),
                                                  Precedente = dRow.GetInt("CertificadoPrecedente", 0),
                                                  Baja = dRow.GetInt("CertificadoBaja", 0),
                                                  unidadTiempo = dRow.GetSmallintAsInt("UnidadTiempo", 0)

                                              }).Distinct().ToList();

                items_anonimos.RemoveAll(e => items_anonimos.Any(prev => prev.Precedente == e.Id));
                items_anonimos.RemoveAll(e => e.Baja != 0);

                items_anonimos.Select(c => new CvCertificadoDeCapacitacion(c.Id, c.Diploma, c.Establecimiento, c.Especialidad, c.Duracion,
                                                c.FechaInicio, c.FechaFinalizacion, c.Localidad, c.Pais, c.unidadTiempo)).ToList().ForEach(cert => cv.AgregarCertificadoDeCapacitacion(cert));

            }
            
        }

        private void CorteDeControlActividadesDocentes(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            var lista = ArmarFilas(tablaCVs, "IdAntecedentesDeDocencia", "AntecedentesDeDocenciaBaja");

            if (lista.Count > 0)
            {
                var items_anonimos = (from RowDeDatos dRow in lista
                                             select new //CvAntecedentesAcademicos ()
                                             {
                                                 Id = dRow.GetInt("IdAntecedentesDeDocencia", 0),
                                                 Asignatura = dRow.GetString("AntecedentesDeDocenciaAsignatura", string.Empty),
                                                 NivelEducativo = dRow.GetSmallintAsInt("AntecedentesDeDocenciaNivelEducativo", 0),
                                                 TipoActividad = dRow.GetString("AntecedentesDeDocenciaTipoActividad", string.Empty),
                                                 CategoriaDocente = dRow.GetString("AntecedentesDeDocenciaCategoriaDocente", string.Empty),
                                                 CaracterDesignacion = dRow.GetString("AntecedentesDeDocenciaCaracterDesignacion", string.Empty),
                                                 DedicacionDocente = dRow.GetString("AntecedentesDeDocenciaDedicacionDocente", string.Empty),
                                                 CargaHoraria = dRow.GetString("AntecedentesDeDocenciaCargaHoraria", string.Empty),
                                                 Establecimiento = dRow.GetString("AntecedentesDeDocenciaEstablecimiento", string.Empty),
                                                 FechaInicio = dRow.GetDateTime("AntecedentesDeDocenciaFechaInicio"),
                                                 FechaFinalizacion = dRow.GetDateTime("AntecedentesDeDocenciaFechaFinalizacion", new DateTime(1, 1, 1, 0, 0, 0)),
                                                 Localidad = dRow.GetString("AntecedentesDeDocenciaLocalidad", string.Empty),
                                                 Pais = dRow.GetSmallintAsInt("AntecedentesDeDocenciaPais", 9),
                                                 Precedente = dRow.GetInt("AntecedentesDeDocenciaPrecedente", 0),
                                                 Baja = dRow.GetInt("AntecedentesDeDocenciaBaja", 0)
                                             }).Distinct().ToList();

                items_anonimos.RemoveAll(e => items_anonimos.Any(prev => prev.Precedente == e.Id));
                items_anonimos.RemoveAll(e => e.Baja != 0);

                items_anonimos.Select(d => new CvDocencia(d.Id, d.Asignatura, d.NivelEducativo, d.TipoActividad,d.CategoriaDocente,d.CaracterDesignacion,
                                                                    d.DedicacionDocente, d.CargaHoraria, d.FechaInicio,d.FechaFinalizacion,d.Establecimiento,
                                                                    d.Localidad, d.Pais)).ToList().ForEach(doc => cv.AgregarDocencia(doc));

            }


        }

        private void CorteDeControlEventosAcademicos(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //CORTE DE CONTROL PARA EVENTOS ACADEMICOS
            //1.- Controlo que haya al menos 1 resultado
            var lista = ArmarFilas(tablaCVs, "EventosAcademicosId", "EventosAcademicosBaja"); new List<RowDeDatos>();
           
            if (lista.Count > 0)
            {
                var items_anonimos = (from RowDeDatos dRow in lista
                                            select new //CvEventoAcademico ()
                                            {
                                                Id = dRow.GetInt("EventosAcademicosId",0),
                                                Denominacion = dRow.GetString("EventosAcademicosDenominacion", string.Empty),
                                                TipoDeEvento = dRow.GetInt("EventosAcademicosTipoDeEvento", 0),
                                                CaracterDeParticipacion = dRow.GetInt("EventosAcademicosCaracterDeParticipacion", 0),
                                                FechaInicio = dRow.GetDateTime("EventosAcademicosFechaInicio", new DateTime(1, 1, 1, 0, 0, 0)),
                                                FechaFinalizacion = dRow.GetDateTime("EventosAcademicosFechaFin", new DateTime(1, 1, 1, 0, 0, 0)),
                                                Duracion = dRow.GetString("EventosAcademicosDuracion", string.Empty),
                                                Institucion = dRow.GetInt("EventosAcademicosInstitucion", 0),
                                                Localidad = dRow.GetString("EventosAcademicosLocalidad", string.Empty),
                                                Pais = dRow.GetSmallintAsInt("EventosAcademicosPais", 9),
                                                Precedente = dRow.GetInt("EventosAcademicosPrecedente", 0),
                                                Baja = dRow.GetInt("EventosAcademicosBaja", 0),
                                                UnidadTiempo = dRow.GetSmallintAsInt("EventosAcademicosUnidadTiempo", 0),
                                            }).Distinct().ToList();

                items_anonimos.RemoveAll(e => items_anonimos.Any(prev => prev.Precedente == e.Id));
                items_anonimos.RemoveAll(e => e.Baja != 0);

                items_anonimos.Select(e => new CvEventoAcademico(e.Id, e.Denominacion, e.TipoDeEvento, e.CaracterDeParticipacion,
                                                                    e.FechaInicio, e.FechaFinalizacion, e.Duracion, e.Institucion,
                                                                    e.Localidad, e.Pais, e.UnidadTiempo)).ToList().ForEach(ev => cv.AgregarEventoAcademico(ev));
                

            }
        }

        private void CorteDeControlOtrasCapacidades(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            //CORTE DE CONTROL PARA OTRAS CAPACIDADES
            //1.- Controlo que haya al menos 1 resultado
            var lista = ArmarFilas(tablaCVs, "CapacidadesPersonalesId", "CapacidadesPersonalesBaja"); new List<RowDeDatos>();

            if (lista.Count > 0)
            {
                var items_anonimos = (from RowDeDatos dRow in lista
                                        select new //CvEventoAcademico ()
                                        {
                                            Id = dRow.GetInt("CapacidadesPersonalesId", 0),
                                            Tipo = dRow.GetSmallintAsInt("CapacidadesPersonalesTipo", 0),
                                            Detalle = dRow.GetString("CapacidadesPersonalesDetalle", ""),
                                            Precedente = dRow.GetInt("CapacidadesPersonalesPrecedente", 0),
                                            Baja = dRow.GetInt("CapacidadesPersonalesBaja", 0)
                                        }).Distinct().ToList();

                items_anonimos.RemoveAll(e => items_anonimos.Any(prev => prev.Precedente == e.Id));
                items_anonimos.RemoveAll(e => e.Baja != 0);

                items_anonimos.Select(e => new CvCapacidadPersonal(e.Id, e.Tipo, e.Detalle)).ToList().ForEach(ev => cv.AgregarCapacidadPersonal(ev));
            }
        }

        private void CorteDeControlMatriculas(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            var lista = ArmarFilas(tablaCVs, "IdMatricula", "MatriculaBaja");

            if (lista.Count > 0)
            {
                var items_anonimos = (from RowDeDatos dRow in lista
                                        select new //CvIdioma ()
                                        {
                                            Id = dRow.GetInt("IdMatricula", 0),
                                            Numero = dRow.GetString("MatriculaNumero", string.Empty),
                                            ExpedidaPor = dRow.GetString("MatriculaExpedidoPor", string.Empty),
                                            SituacionActual = dRow.GetString("MatriculaSituacionActual", string.Empty),
                                            FechaObtencion = dRow.GetDateTime("MatriculaFechaObtencion", new DateTime(1, 1, 1, 0, 0, 0)),
                                            Precedente = dRow.GetInt("MatriculaPrecedente", 0),
                                            Baja = dRow.GetInt("MatriculaBaja", 0)
                                            
                                        }).Distinct().ToList();

                items_anonimos.RemoveAll(e => items_anonimos.Any(prev => prev.Precedente == e.Id));
                items_anonimos.RemoveAll(e => e.Baja != 0);

                items_anonimos.Select(m => new CvMatricula(m.Id, m.Numero, m.ExpedidaPor, m.SituacionActual, 
                                           m.FechaObtencion)).ToList().ForEach(mat => cv.AgregarMatricula(mat));

            }

           
        }

        private void CorteDeControlPublicaciones(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            var lista = ArmarFilas(tablaCVs, "IdPublicacion", "PublicacionBaja");

            if (lista.Count > 0)
            {
                var items_anonimos = (from RowDeDatos dRow in lista
                                           select new //CvIdioma ()
                                           {
                                               Id = dRow.GetInt("IdPublicacion", 0),
                                               Titulo = dRow.GetString("PublicacionTitulo", string.Empty),
                                               Editorial = dRow.GetString("PublicacionEditorial", string.Empty),
                                               Hojas = dRow.GetSmallintAsInt("PublicacionHojas", 0).ToString(),
                                               Copia = ArmarIntDeBooleano(dRow.GetBoolean("PublicacionCopia")),
                                               Adjunto = ArmarIntDeBooleano(dRow.GetBoolean("PublicacionAdjunto")),
                                               Fecha = dRow.GetDateTime("PublicacionFecha", new DateTime(1, 1, 1, 0, 0, 0)),
                                               Precedente = dRow.GetInt("PublicacionPrecedente", 0),
                                               Baja = dRow.GetInt("PublicacionBaja", 0)

                                           }).Distinct().ToList();

                items_anonimos.RemoveAll(e => items_anonimos.Any(prev => prev.Precedente == e.Id));
                items_anonimos.RemoveAll(e => e.Baja != 0);

                items_anonimos.Select(p => new CvPublicaciones(p.Id, p.Titulo,p.Editorial,p.Hojas,p.Copia, p.Adjunto,
                                           p.Fecha)).ToList().ForEach(pub => cv.AgregarPublicacion(pub));

            }

        }

        private int ArmarIntDeBooleano(bool valor)
        {
            if (valor == true)
                return 1;
            return 0;
        }

        private void CorteDeControlInstituciones(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {

            var lista = ArmarFilas(tablaCVs, "IdInstitucion", "InstitucionBaja");

            if (lista.Count > 0)
            {
                var items_anonimos = (from RowDeDatos dRow in lista
                                              select new
                                              {
                                                  Id = dRow.GetInt("IdInstitucion", 0),
                                                  Institucion = dRow.GetString("InstitucionInstitucion", string.Empty),
                                                  CaracterEntidad = dRow.GetString("InstitucionCaracterEntidad", string.Empty),
                                                  Cargos = dRow.GetString("InstitucionCargos", string.Empty),
                                                  Afiliados = dRow.GetString("InstitucionAfiliados", string.Empty),
                                                  CategoriaActual = dRow.GetString("InstitucionCategoriaActual", string.Empty),
                                                  FechaAfiliacion = dRow.GetDateTime("InstitucionFechaAfiliacion", new DateTime(1, 1, 1, 0, 0, 0)),
                                                  Fecha = dRow.GetDateTime("InstitucionFecha", new DateTime(1, 1, 1, 0, 0, 0)),
                                                  FechaInicio = dRow.GetDateTime("InstitucionFechaInicio", new DateTime(1, 1, 1, 0, 0, 0)),
                                                  FechaFin = dRow.GetDateTime("InstitucionFechaFin", new DateTime(1, 1, 1, 0, 0, 0)),
                                                  Localidad = dRow.GetString("InstitucionLocalidad", string.Empty),
                                                  Pais = dRow.GetSmallintAsInt("InstitucionPais", 9),
                                                  Precedente = dRow.GetInt("InstitucionPrecedente", 0),
                                                  Baja = dRow.GetInt("InstitucionBaja", 0)

                                              }).Distinct().ToList();

                items_anonimos.RemoveAll(e => items_anonimos.Any(prev => prev.Precedente == e.Id));
                items_anonimos.RemoveAll(e => e.Baja != 0);

                items_anonimos.Select(i => new CvInstitucionesAcademicas(i.Id, i.Institucion, i.CaracterEntidad, i.Cargos, i.Afiliados,
                                            i.CategoriaActual, i.FechaAfiliacion, i.Fecha, i.FechaInicio, i.FechaFin,i.Localidad,
                                            i.Pais)).ToList().ForEach(inst => cv.AgregarInstitucionAcademica(inst));

            }
        }

        private void CorteDeControlExperienciasLaborales(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            var lista = ArmarFilas(tablaCVs, "IdExperienciaLaboral", "ExperienciaLaboralBaja");

            if (lista.Count > 0)
            {
                var items_anonimos = (from RowDeDatos dRow in lista
                                              select new
                                              {
                                                  Id = dRow.GetInt("IdExperienciaLaboral", 0),
                                                  PuestoOcupado = dRow.GetString("ExperienciaLaboralPuestoOcupado", string.Empty),
                                                  MotivoDesvinculacion = dRow.GetString("ExperienciaLaboralMotivoDesvinculacion", string.Empty),
                                                  NombreEmpleador = dRow.GetString("ExperienciaLaboralNombreEmpleador", string.Empty),
                                                  PersonasACargo = dRow.GetSmallintAsInt("ExperienciaLaboralPersonasACargo", 0),
                                                  TipoEmpresa = dRow.GetString("ExperienciaLaboralTipoEmpresa", string.Empty),
                                                  Actividad = dRow.GetString("ExperienciaLaboralActividad", string.Empty),
                                                  FechaInicio = dRow.GetDateTime("ExperienciaLaboralInicio"),
                                                  FechaFin = dRow.GetDateTime("ExperienciaLaboralFin", new DateTime(1, 1, 1, 0, 0, 0)),
                                                  Localidad = dRow.GetString("ExperienciaLaboralLocalidad", string.Empty),
                                                  Pais = dRow.GetSmallintAsInt("ExperienciaLaboralPais", 9),
                                                  Sector = dRow.GetString("ExperienciaLaboralSector", string.Empty),
                                                  AmbitoLaboral = dRow.GetSmallintAsInt("ExperienciaAmbitoLaboral", 2),
                                                  ModalidadContratacion = dRow.GetSmallintAsInt("ExperienciaModalidadContratacion",0),
                                                  Vigente = dRow.GetBoolean("ExperienciaVigente"),  
                                                  Precedente = dRow.GetInt("ExperienciaLaboralPrecedente", 0),
                                                  Baja = dRow.GetInt("ExperienciaLaboralBaja", 0)
                                              }).Distinct().ToList();

                items_anonimos.RemoveAll(e => items_anonimos.Any(prev => prev.Precedente == e.Id));
                items_anonimos.RemoveAll(e => e.Baja != 0);

                items_anonimos.Select(e => new CvExperienciaLaboral(e.Id, e.PuestoOcupado, e.MotivoDesvinculacion, e.NombreEmpleador, e.PersonasACargo,
                                            e.TipoEmpresa, e.Actividad, e.FechaInicio, e.FechaFin, e.Localidad,
                                            e.Pais,e.Sector,e.AmbitoLaboral, e.ModalidadContratacion, e.Vigente)).ToList().ForEach(exp => cv.AgregarExperienciaLaboral(exp));
            }  
        }

        private void CorteDeControlIdioma(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            var lista = ArmarFilas(tablaCVs, "IdIdioma", "IdiomaBaja");

            if (lista.Count > 0)
            {
                var items_anonimos = (from RowDeDatos dRow in lista
                                             select new //CvIdioma ()
                                             {
                                                 Id = dRow.GetInt("IdIdioma", 0),
                                                 Diploma = dRow.GetString("IdiomaDiploma", string.Empty),
                                                 Establecimiento = dRow.GetString("IdiomaEstablecimiento", string.Empty),
                                                 Idioma = dRow.GetString("IdiomaIdioma", string.Empty),
                                                 Lectura = dRow.GetSmallintAsInt("IdiomaLectura", 3),
                                                 Escritura = dRow.GetSmallintAsInt("IdiomaEscritura", 3),
                                                 Oral = dRow.GetSmallintAsInt("IdiomaOral", 3),
                                                 FechaObtencion = dRow.GetDateTime("IdiomaFechaObtencion", new DateTime(1, 1, 1, 0, 0, 0)),
                                                 Localidad = dRow.GetString("IdiomaLocalidad", string.Empty),
                                                 Pais = dRow.GetSmallintAsInt("IdiomaPais", 9),
                                                 Precedente = dRow.GetInt("IdiomaPrecedente", 0),
                                                 Baja = dRow.GetInt("IdiomaBaja", 0)
                                             }).Distinct().ToList();

                items_anonimos.RemoveAll(e => items_anonimos.Any(prev => prev.Precedente == e.Id));
                items_anonimos.RemoveAll(e => e.Baja != 0);

                items_anonimos.Select(i => new CvIdiomas(i.Id, i.Diploma, i.Establecimiento,i.Idioma, i.Lectura, i.Escritura, 
                                                           i.Oral,i.FechaObtencion,i.Localidad,i.Pais)).ToList().ForEach(idi => cv.AgregarIdioma(idi));

            }
       
        }

        private void CorteDeControlCompetenciaInformatica(TablaDeDatos tablaCVs, CurriculumVitae cv)
        {
            var lista = ArmarFilas(tablaCVs, "IdCompetenciaInformatica", "CompetenciaBaja");

            if (lista.Count > 0)
            {
                var items_anonimos = (from RowDeDatos dRow in lista
                                          select new 
                                          {
                                              Id = dRow.GetInt("IdCompetenciaInformatica", 0),
                                              Diploma = dRow.GetString("CompetenciaDiploma", string.Empty),
                                              Establecimiento = dRow.GetString("CompetenciaEstablecimiento", string.Empty),
                                              TipoInformatica = dRow.GetInt("CompetenciaTipoInformatica", 0),
                                              Conocimiento = dRow.GetInt("CompetenciaConocimiento", 0),
                                              Nivel = dRow.GetInt("CompetenciaNivel", 0),
                                              Localidad = dRow.GetString("CompetenciaLocalidad", string.Empty),
                                              Pais = dRow.GetSmallintAsInt("CompetenciaPais", 9),
                                              FechaObtencion = dRow.GetDateTime("CompetenciaFechaObtencion", new DateTime(1, 1, 1, 0, 0, 0)),
                                              Detalle = dRow.GetString("Detalle", string.Empty),
                                              Precedente = dRow.GetInt("CompetenciaPrecedente", 0),
                                              Baja = dRow.GetInt("CompetenciaBaja", 0)
                                          }).Distinct().ToList();

                items_anonimos.RemoveAll(e => items_anonimos.Any(prev => prev.Precedente == e.Id));
                items_anonimos.RemoveAll(e => e.Baja != 0);

                items_anonimos.Select(c => new CvCompetenciasInformaticas(c.Id, c.Diploma, c.Establecimiento, c.TipoInformatica, c.Conocimiento, c.Nivel,
                                                                    c.Localidad, c.Pais, c.FechaObtencion, c.Detalle)).ToList().ForEach(comp => cv.AgregarCompetenciaInformatica(comp));
            }
        }


        private List<RowDeDatos> ArmarFilas(TablaDeDatos tabla, string campo_id, string campo_baja)
        {
            var lista = new List<RowDeDatos>();
            tabla.Rows.ForEach(r =>
            {
                if (!(r.GetObject(campo_id) is DBNull))
                    lista.Add(r);
            });

            return lista;
        }

        # endregion

        #region CvDatosPersonales
        public void GuardarCVDatosPersonales(CvDatosPersonales datosPersonales, Usuario usuario)
        {
            
            var parametros = new Dictionary<string, object>();
            var cv = this.GetCV(usuario.Owner.Id);

            //Si la persona existe en Leg => Datos_Personales no se debe poder modificar ni DatosPersonales ni DatosPersonalesAdicionales
            //El domicilio al entrar x primera vez no deberia verlos los del Legajo, asiq hago un insert la primera vez

            //Si todavia no tiene CV
            if (cv.TieneCv == false)
            {
                //Si no es empleado
                if (cv.DatosPersonales.TieneLegajo == "No tiene legajo")
                {
                    try
                    {
                        validarDatos(datosPersonales);
                    }
                    catch (Exception e)
                    {                        
                        throw e;
                    }
                    //insertar en CV_DatosPersonales
                    parametros = CompletarDatosPersonales(datosPersonales, parametros, usuario);
                    parametros.Add("@IdPersona", usuario.Owner.Id);

                    conexion_bd.Ejecutar("dbo.CV_Ins_DatosPersonalesNoEmpleados1ravez", parametros);
                }
                //Si es empleado 
                validarDatosEmpleado(datosPersonales);
                //insert de CV
                parametros = new Dictionary<string, object>();
                parametros.Add("@Dni", datosPersonales.Dni);
                parametros.Add("@usuario", usuario.Id);
                conexion_bd.Ejecutar("dbo.CV_Ins_Curriculum", parametros);

                //insertar en GEN_Domicilios y CV_Domicilio el DomicilioPersonal
                parametros = CompletarDatosDomicilios(datosPersonales.DomicilioPersonal, parametros, 1, usuario, datosPersonales.DatosDeContacto.Telefono, datosPersonales.DatosDeContacto.Telefono2, datosPersonales.DatosDeContacto.Email);
                parametros.Add("@Dni", datosPersonales.Dni);
                conexion_bd.Ejecutar("dbo.CV_Ins_Domicilio", parametros);

                //

                //insertar en GEN_Domicilios y CV_Domicilio el DomicilioLaboral
                parametros = CompletarDatosDomicilios(datosPersonales.DomicilioLegal, parametros, 2, usuario, datosPersonales.DatosDeContacto.Telefono, datosPersonales.DatosDeContacto.Telefono2, datosPersonales.DatosDeContacto.Email);
                parametros.Add("@Dni", datosPersonales.Dni);
                conexion_bd.Ejecutar("dbo.CV_Ins_Domicilio", parametros); 

            }
            else
            {
                if (cv.DatosPersonales.TieneLegajo == "No tiene legajo") //Si ya tiene CV y no es Empleado
                {
                    //modificar el CV para no empleados
                    parametros = CompletarDatosPersonales(datosPersonales, parametros, usuario);
                    parametros.Add("@IdPersona", usuario.Owner.Id);

                    conexion_bd.Ejecutar("dbo.CV_Upd_DatosPersonalesNoEmpleados", parametros);
                }
 
                if (datosPersonales.DomicilioPersonal.Id > 0)
                {
                    //update GEN_Domicilios del domicilio personal
                    parametros = CompletarDatosDomicilios(datosPersonales.DomicilioPersonal, parametros, 1, usuario, datosPersonales.DatosDeContacto.Telefono, datosPersonales.DatosDeContacto.Telefono2, datosPersonales.DatosDeContacto.Email);
                    parametros.Add("@idDomicilio", datosPersonales.DomicilioPersonal.Id);
                    conexion_bd.Ejecutar("dbo.CV_Upd_Domicilio", parametros);
                }
                else 
                {
                    //insertar en GEN_Domicilios y CV_Domicilio el DomicilioPersonal
                    parametros = CompletarDatosDomicilios(datosPersonales.DomicilioPersonal, parametros, 1, usuario, datosPersonales.DatosDeContacto.Telefono, datosPersonales.DatosDeContacto.Telefono2, datosPersonales.DatosDeContacto.Email);
                    parametros.Add("@Dni", datosPersonales.Dni);
                    conexion_bd.Ejecutar("dbo.CV_Ins_Domicilio", parametros);
                }

                if (datosPersonales.DomicilioLegal.Id > 0)
                {
                    //update en GEN_Domicilios del domicilio laboral
                    parametros = CompletarDatosDomicilios(datosPersonales.DomicilioLegal, parametros, 2, usuario, datosPersonales.DatosDeContacto.Telefono, datosPersonales.DatosDeContacto.Telefono2, datosPersonales.DatosDeContacto.Email);
                    parametros.Add("@idDomicilio", datosPersonales.DomicilioLegal.Id);
                    conexion_bd.Ejecutar("dbo.CV_Upd_Domicilio", parametros);
                }
                else
                {
                    //insertar en GEN_Domicilios y CV_Domicilio el DomicilioLaboral
                    parametros = CompletarDatosDomicilios(datosPersonales.DomicilioLegal, parametros, 2, usuario, datosPersonales.DatosDeContacto.Telefono, datosPersonales.DatosDeContacto.Telefono2, datosPersonales.DatosDeContacto.Email);
                    parametros.Add("@Dni", datosPersonales.Dni);
                    conexion_bd.Ejecutar("dbo.CV_Ins_Domicilio", parametros);
                }
            }

            //this._cvDatosPersonales = datosPersonales;
            //this.lista_cv.Add(cv);
        }

        private Dictionary<string, object> CompletarDatosDomicilios(CvDomicilio domicilio , Dictionary<string, object> parametros, int tipo, Usuario usuario, string telefono, string telefono2, string email)
        {
            parametros = new Dictionary<string, object>();

            parametros.Add("@DomicilioCalle", domicilio.Calle);
            parametros.Add("@DomicilioNumero", domicilio.Numero);
            parametros.Add("@DomicilioPiso", domicilio.Piso);
            parametros.Add("@DomicilioDepto", domicilio.Depto);
            parametros.Add("@DomicilioCp", domicilio.Cp);
            parametros.Add("@DomicilioLocalidad", domicilio.Localidad);
            parametros.Add("@DomicilioProvincia", domicilio.Provincia);
            //parametros.Add("@Correo_Electronico_MDS", ""); // No se está utilizando el correo MDS. Ver correo - Email -
            parametros.Add("@DomicilioTipo", tipo);
            parametros.Add("@Usuario", usuario.Id);
            parametros.Add("@DomicilioTelefono", telefono);
            parametros.Add("@DomicilioTelefono2", telefono2);
            parametros.Add("@DomicilioCorreo_Electronico", email);
                      
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

        #region GuardadoDeItemCv

        private ItemCv GuardarItemCVParam(Dictionary<string, object> parametros, ItemCv item)
        {
            try
            {
                parametros.Keys.ToList().ForEach(k =>
                {
                    var v = parametros[k];
                    if (v is DateTime) {
                        if (v.Equals(new DateTime(1, 1, 1, 0, 0, 0)))
                        {
                            parametros.Remove(k);
                        }
                    }
                });
                var id = conexion_bd.EjecutarEscalar(item.SpInsercion(this), parametros);
                item.Id = int.Parse(id.ToString());
                return item;
            }
            catch (Exception e)
            {
                throw;
            }
        }


        public ItemCv GuardarItemCV(ItemCv item_nuevo, Usuario usuario)
        {
            return GuardarItemCV(item_nuevo, usuario, new Dictionary<string, object>());
        }
        
        private ItemCv GuardarItemCV(ItemCv item_cv, Usuario usuario, Dictionary<string, object> param_iniciales)
        {
            item_cv.validarDatos();

            var parametros = item_cv.Parametros(usuario, this);

            param_iniciales.Keys.ToList().ForEach(k => parametros[k] = param_iniciales[k]);

            parametros.Add("@idPersona", usuario.Owner.Id);

            return GuardarItemCVParam(parametros, item_cv);
        }
        
        public ItemCv ActualizarCv(ItemCv antecedentesAcademicos_nuevo, Usuario usuario)
        {
            return ActualizarCv(antecedentesAcademicos_nuevo, usuario, new Dictionary<string, object>());
        }


        private ItemCv ActualizarCv(ItemCv item_nuevo, Usuario usuario, Dictionary<string, object> param_iniciales)
        {
            param_iniciales.Add("@idRegistroAnterior", item_nuevo.Id);
            return GuardarItemCV(item_nuevo, usuario, param_iniciales);
        }

        public bool EliminarCV(ItemCv item, Usuario usuario)
        {
            var baja = CrearBaja(usuario);

            var parametros = new Dictionary<string, object>();
            parametros.Add("@Baja", baja);
            parametros.Add("@Usuario", usuario.Id);

            ActualizarCv(item, usuario, parametros);
            return true;
        }

        #endregion

        #region nombresSps

        public string SpActividadesCapacitacion()
        {
            return "dbo.CV_Ins_ActividadesDeCapacitacion";
        }
        
        public string SpEstudios()
        {
            return "dbo.CV_Ins_AntecedentesAcademicos";
        }

        public string SpDocencia() {
            return "dbo.CV_Ins_AntecedentesDeDocencia";
        }

        public string SpCapacidadPersonal() {
            return "dbo.CV_Ins_CapacidadesPersonales";
        }

        public string SPCompetenciasInformaticas() {
            return "dbo.CV_Ins_CompetenciasInformaticas";
        }

        public string SPEventosAcademicos() {
            return "dbo.CV_Ins_EventosAcademicos";
        }

        public string SPExperienciasLaborales() {
            return "dbo.CV_Ins_ExperienciasLaborales";
        }

        public string SPIdiomas() {
            return "dbo.CV_Ins_Idiomas";
        }

        public string SPInstituciones()
        {
            return "dbo.CV_Ins_Instituciones";
        }

        public string SPMatriculas()
        {
            return "dbo.CV_Ins_Matriculas";
        }

        public string SPPostulaciones()
        {
            return "dbo.CV_Ins_Postulaciones";
        }

        public string SPPubliaciones()
        {
            return "dbo.CV_Ins_Publicaciones";
        }

        #endregion

        #region parametros

        public Dictionary<string, object> ParametrosEstudios(CvEstudios estudios, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@IdTitulo", estudios.IdTitulo);
            parametros.Add("@Establecimiento", estudios.Establecimiento);
            parametros.Add("@Especialidad", estudios.Especialidad);
            parametros.Add("@FechaIngreso", estudios.FechaIngreso);
            parametros.Add("@FechaEgreso", estudios.FechaEgreso);
            parametros.Add("@Localidad", estudios.Localidad);
            parametros.Add("@Pais", estudios.Pais);
            parametros.Add("@Usuario", usuario.Id);
            parametros.Add("@Nivel", estudios.Nivel);
            parametros.Add("@Anios", estudios.Anios);
            
            return parametros;
        }

        public Dictionary<string, object> ParametrosDeActividadesDeCapacitacion(CvCertificadoDeCapacitacion actividad_nueva, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Titulo", actividad_nueva.DiplomaDeCertificacion);
            parametros.Add("@Establecimiento", actividad_nueva.Establecimiento);
            parametros.Add("@Especialidad", actividad_nueva.Especialidad);
            parametros.Add("@Duracion", actividad_nueva.Duracion);
            parametros.Add("@FechaIngreso", actividad_nueva.FechaInicio);
            parametros.Add("@FechaEgreso", actividad_nueva.FechaFinalizacion);
            parametros.Add("@Localidad", actividad_nueva.Localidad);
            parametros.Add("@Pais", actividad_nueva.Pais);
            parametros.Add("@Usuario", usuario.Id);
            parametros.Add("@unidadtiempo", actividad_nueva.UnidadTiempo);
            return parametros;
        }

        public Dictionary<string, object> ParametrosDeAntecedentesDocencia(CvDocencia docencia_nuevo, Usuario usuario)
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

        public Dictionary<string, object> ParametrosDeEventosAcademicos(CvEventoAcademico evento_academico_nuevo, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Denominacion", evento_academico_nuevo.Denominacion);
            parametros.Add("@TipoDeEvento", evento_academico_nuevo.TipoDeEvento);
            parametros.Add("@CaracterDeParticipacion", evento_academico_nuevo.CaracterDeParticipacion);
            parametros.Add("@FechaInicio", evento_academico_nuevo.FechaInicio);
            parametros.Add("@FechaFin", evento_academico_nuevo.FechaFinalizacion);
            parametros.Add("@Duracion", evento_academico_nuevo.Duracion);
            parametros.Add("@Institucion", evento_academico_nuevo.Institucion);
            parametros.Add("@Localidad", evento_academico_nuevo.Localidad);
            parametros.Add("@Pais", evento_academico_nuevo.Pais);
            parametros.Add("@Usuario", usuario.Id);
            parametros.Add("@IdUnidadTiempo", evento_academico_nuevo.UnidadTiempo);

            return parametros;
        }

        public Dictionary<string, object> ParametrosDePublicaciones(CvPublicaciones publicacion_nueva, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@CantidadHojas", publicacion_nueva.CantidadHojas);
            parametros.Add("@DatosEditorial", publicacion_nueva.DatosEditorial);
            parametros.Add("@DisponeCopia", publicacion_nueva.DisponeCopia);
            parametros.Add("@DisponeAdjunto", publicacion_nueva.DisponeAdjunto);
            parametros.Add("@Titulo", publicacion_nueva.Titulo);
            parametros.Add("@FechaPublicacion", publicacion_nueva.FechaPublicacion);
            parametros.Add("@Usuario", usuario.Id);


            return parametros;

        }

        public Dictionary<string, object> ParametrosDeMatricula(CvMatricula matricula_nueva, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@ExpedidoPor", matricula_nueva.ExpedidaPor);
            parametros.Add("@Numero", matricula_nueva.Numero);
            parametros.Add("@SituacionActual", matricula_nueva.SituacionActual);
            parametros.Add("@FechaInscripcion", matricula_nueva.FechaInscripcion);
            parametros.Add("@Usuario", usuario.Id);

            return parametros;
        }

        public Dictionary<string, object> ParametrosDeInstituciones(CvInstitucionesAcademicas institucion_nueva, Usuario usuario)
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

        public Dictionary<string, object> ParametrosDeExperiencias(CvExperienciaLaboral experiencia_nueva, Usuario usuario)
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
            parametros.Add("@Sector", experiencia_nueva.Sector);
            parametros.Add("@Ambito", experiencia_nueva.AmbitoLaboral);
            //Si es de AMBITO PUBLICO
            if (experiencia_nueva.AmbitoLaboral == 1)
            {
                parametros.Add("@ModalidadContratacion", experiencia_nueva.ModalidadContratacion);
                parametros.Add("@Vigente", experiencia_nueva.Vigente);
            } else {
                parametros.Add("@ModalidadContratacion", 0);
                parametros.Add("@Vigente", 0);
            }
            
         
            return parametros;
        }

        public Dictionary<string, object> ParametrosDelIdioma(CvIdiomas idioma_nuevo, Usuario usuario)
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

        public Dictionary<string, object> ParametrosDeCompetenciasInformaticas(CvCompetenciasInformaticas competencia, Usuario usuario)
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
            parametros.Add("@Detalle", competencia.Detalle);

            return parametros;
        }

        public Dictionary<string, object> ParametrosDeCapacidadPersonal(CvCapacidadPersonal capacidad, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@Tipo", capacidad.Tipo);
            parametros.Add("@Detalle", capacidad.Detalle);
            parametros.Add("@Usuario", usuario.Id);
            return parametros;
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

        #region Validaciones

        private void validarDatos(CvDatosPersonales datosPersonales)
        {
            var validador_datos = new Validador();

            validador_datos.DeberianSerNoVacias(new string[] { "Nombre", "Apellido", "Cuil" });
            validador_datos.DeberianSerFechasNoVacias(new string[] { "FechaNacimiento"});
            validador_datos.DeberianSerNaturalesOCero(new string[] { "Dni" }); 
            validador_datos.DeberianSerNaturalesOCero(new string[] { "Sexo", "EstadoCivil", "Nacionalidad", "TipoDocumento"});
            
            if (!validador_datos.EsValido(datosPersonales))
                throw new ExcepcionDeValidacion("El tipo de dato no es correcto");

            validarDatos(datosPersonales.DatosDeContacto);
            validarDatos(datosPersonales.DomicilioLegal);
            validarDatos(datosPersonales.DomicilioPersonal);
        }

        private void validarDatosEmpleado(CvDatosPersonales datosPersonales)
        {
            var validador_datos = new Validador();

            if (!validador_datos.EsValido(datosPersonales))
                throw new ExcepcionDeValidacion("El tipo de dato no es correcto");

            validarDatos(datosPersonales.DatosDeContacto);
            validarDatos(datosPersonales.DomicilioLegal);
            validarDatos(datosPersonales.DomicilioPersonal);
        }

        private void validarDatos(DatosDeContacto datos_de_contacto)
        {
            var validador = new Validador();

            validador.DeberianSerNoVacias(new string[] { "Telefono", "Telefono2", "Email" });

            if (!validador.EsValido(datos_de_contacto))
                throw new ExcepcionDeValidacion("El tipo de dato no es correcto");
        }

        private void validarDatos(CvDomicilio un_domicilio)
        {
            var validador_domicilio = new Validador();
            
            validador_domicilio.DeberianSerNoVacias(new string[] { "Calle"});
            validador_domicilio.DeberianSerNaturalesOCero(new string[] { "Numero", "Cp", "Provincia", "Localidad" });
            
            if (!validador_domicilio.EsValido(un_domicilio))
                throw new ExcepcionDeValidacion("El tipo de dato no es correcto");   
        }
        #endregion Validaciones
    }
}
