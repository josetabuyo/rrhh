/*NO PASAR POR EL MOMENTO

create PROCEDURE [dbo].[CV_GetCurriculumVitae]           
(          
 @idPersona int          
)          
AS       

set nocount on
   
BEGIN    
Create table #auxiliar
(
  IdPersona int,          
  Nombre varchar(100),          
  Apellido varchar(100),          
  NroDocumento int,        
  TipoDocumento smallint,          
  Sexo smallint,          
  EstadoCivil smallint,          
  CUIL varchar(15),          
  LugarNacimiento varchar(50),          
  FechaNacimiento Datetime,          
  Nacionalidad smallint,          
            
  DomPers_Id int ,           
  DomPers_Calle varchar(50),          
  DomPers_Numero int,          
  DomPers_Piso varchar(50),          
  DomPers_Depto varchar(50),          
  DomPers_Localidad int,          
  DomPers_CodigoPostal smallint,        
  DomPers_Telefono varchar(20),        
  DomPers_Telefono2 varchar(20),     
  DomPers_Email varchar(50)  ,        
  DomPers_IdProvincia smallint,          
          
  DomLab_Id int,          
  DomLab_Calle varchar(50),           
  DomLab_Numero int,          
  DomLab_Piso varchar(50),           
  DomLab_Depto varchar(50),            
  DomLab_Localidad int ,          
  DomLab_CodigoPostal smallint,          
  DomLab_IdProvincia smallint, 
  TieneLegajo varchar(20),
  TieneCurriculum varchar(20),
               
  IdAntecedentesAcademicos int,          
  AntecedentesAcademicosTitulo varchar(100),          
  AntecedentesAcademicosNivel int,          
  AntecedentesAcademicosEstablecimiento varchar(100),      
  AntecedentesAcademicosEspecialidad  varchar(100),                
  AntecedentesAcademicosFechaIngreso datetime,          
  AntecedentesAcademicosFechaEgreso datetime,          
  AntecedentesAcademicosLocalidad varchar(100),            
  AntecedentesAcademicosPais int,          
  AntecedentesAcademicosBaja int,          
            
  IdAntecedentesDeDocencia int,          
  AntecedentesDeDocenciaAsignatura varchar(100),          
  AntecedentesDeDocenciaCaracterDesignacion varchar(100),          
  AntecedentesDeDocenciaCargaHoraria varchar(100),          
  AntecedentesDeDocenciaCategoriaDocente varchar(100),          
  AntecedentesDeDocenciaDedicacionDocente varchar(100),          
  AntecedentesDeDocenciaEstablecimiento varchar(100),          
  AntecedentesDeDocenciaNivelEducativo int,        
  AntecedentesDeDocenciaTipoActividad varchar(100),          
  AntecedentesDeDocenciaFechaInicio datetime,          
  AntecedentesDeDocenciaFechaFinalizacion datetime,           
  AntecedentesDeDocenciaLocalidad varchar(100),             
  AntecedentesDeDocenciaPais int,          
  AntecedentesDeDocenciaBaja int,      
         
  CapacidadesPersonalesId int,          
  CapacidadesPersonalesTipo int,          
  CapacidadesPersonalesDetalle varchar(1000),          
  CapacidadesPersonalesBaja int,
            
  EventosAcademicosId int,          
  EventosAcademicosDenominacion varchar(100),        
  EventosAcademicosTipoDeEvento int,    
  EventosAcademicosCaracterDeParticipacion int,    
        
  EventosAcademicosFechaInicio datetime,          
  EventosAcademicosFechaFin datetime,          
  EventosAcademicosDuracion varchar(50),      
    
  EventosAcademicosInstitucion int,          
  EventosAcademicosLocalidad varchar(100),          
  EventosAcademicosPais int,          
  EventosAcademicosBaja int,    
            
  IdCompetenciaInformatica int,          
  CompetenciaDiploma varchar(100),          
  CompetenciaEstablecimiento varchar(100),          
  CompetenciaFechaObtencion datetime,          
  CompetenciaTipoInformatica int,      
  CompetenciaConocimiento int,       
  CompetenciaNivel int,      
  CompetenciaLocalidad varchar(100),          
  CompetenciaPais int,          
  CompetenciaBaja int,          
  Detalle varchar(100),         
                
  IdExperienciaLaboral int,          
  ExperienciaLaboralActividad varchar(100),          
  ExperienciaLaboralMotivoDesvinculacion varchar(100),          
  ExperienciaLaboralNombreEmpleador varchar(100),          
  ExperienciaLaboralPersonasACargo int,          
  ExperienciaLaboralPuestoOcupado varchar(100),
  ExperienciaLaboralTipoEmpresa varchar(100),          
  ExperienciaLaboralInicio datetime,          
  ExperienciaLaboralFin datetime,          
  ExperienciaLaboralLocalidad varchar(100),           
  ExperienciaLaboralPais int,          
  ExperienciaLaboralBaja int,          
  ExperienciaLaboralSector varchar(100),      
    
  IdIdioma int,          
  IdiomaDiploma varchar(100),              
  IdiomaEstablecimiento varchar(100),          
  IdiomaIdioma varchar(50),             
  IdiomaEscritura int,          
  IdiomaLectura int,          
  IdiomaOral int,          
  IdiomaFechaObtencion datetime,          
  IdiomaFechaFin datetime,          
  IdiomaLocalidad varchar(100),                
  IdiomaPais int,          
  IdiomaBaja int,          
                        
  IdInstitucion int,          
  InstitucionCaracterEntidad varchar(100),               
  InstitucionCargos varchar(100),           
  InstitucionCategoriaActual varchar(100),           
  InstitucionFecha datetime,          
  InstitucionFechaAfiliacion datetime,          
  InstitucionFechaInicio datetime,           
  InstitucionFechaFin datetime,          
  InstitucionInstitucion varchar(100),           
  InstitucionAfiliados varchar(100),          
  InstitucionLocalidad varchar(100),         
  InstitucionPais int,           
  InstitucionBaja int,    
                                              
  IdMatricula int,          
  MatriculaExpedidoPor varchar(100),          
  MatriculaNumero varchar(100),          
  MatriculaSituacionActual varchar(100),          
  MatriculaFechaObtencion datetime,          
  MatriculaBaja int,          
            
 IdPublicacion int,          
 PublicacionHojas varchar(100),            
 PublicacionEditorial varchar(100),         
 PublicacionCopia int,          
 PublicacionAdjunto int,            
 PublicacionTitulo varchar(100),          
 PublicacionFecha datetime,          
 PublicacionBaja int,          
                                    
 IdCertificadoCapacitacion int,          
 CertificadoDiploma varchar(100),           
 CertificadoEstablecimiento varchar(100),           
 CertificadoEspecialidad varchar(100),           
 CertificadoDuracion varchar(50),           
 CertificadoFechaInicio datetime,          
 CertificadoFechaFinalizacion datetime,          
 CertificadoLocalidad varchar(100),       
 CertificadoPais int,          
 CertificadoBaja int       

)


CREATE CLUSTERED INDEX Idx1 ON #auxiliar(Idpersona)

SELECT * INTO #auxiliar2 from #auxiliar

CREATE CLUSTERED INDEX Idx3 ON #auxiliar2(Idpersona)


/*---------*/

Insert into #auxiliar
(
  IdPersona,          
  Nombre ,          
  Apellido ,          
  NroDocumento ,        
  TipoDocumento ,          
  Sexo ,          
  EstadoCivil ,          
  CUIL ,          
  LugarNacimiento ,          
  FechaNacimiento ,          
  Nacionalidad ,          
            
  DomPers_Id  ,           
  DomPers_Calle ,          
  DomPers_Numero ,          
  DomPers_Piso ,          
  DomPers_Depto ,          
  DomPers_Localidad ,          
  DomPers_CodigoPostal ,        
  DomPers_Telefono,        
  DomPers_Telefono2,     
  DomPers_Email  ,        
  DomPers_IdProvincia ,      
          
  DomLab_Id ,          
  DomLab_Calle ,           
  DomLab_Numero ,          
  DomLab_Piso ,           
  DomLab_Depto ,            
  DomLab_Localidad  ,          
  DomLab_CodigoPostal ,          
  DomLab_IdProvincia , 
  TieneLegajo ,
 TieneCurriculum ,
               
  IdAntecedentesAcademicos ,          
  AntecedentesAcademicosTitulo ,          
  AntecedentesAcademicosNivel ,          
  AntecedentesAcademicosEstablecimiento ,      
  AntecedentesAcademicosEspecialidad ,                
  AntecedentesAcademicosFechaIngreso ,          
  AntecedentesAcademicosFechaEgreso ,          
  AntecedentesAcademicosLocalidad ,            
  AntecedentesAcademicosPais ,          
  AntecedentesAcademicosBaja ,          
            
  IdAntecedentesDeDocencia ,          
  AntecedentesDeDocenciaAsignatura ,          
  AntecedentesDeDocenciaCaracterDesignacion ,          
  AntecedentesDeDocenciaCargaHoraria ,          
  AntecedentesDeDocenciaCategoriaDocente ,          
  AntecedentesDeDocenciaDedicacionDocente ,          
  AntecedentesDeDocenciaEstablecimiento ,          
  AntecedentesDeDocenciaNivelEducativo ,        
  AntecedentesDeDocenciaTipoActividad ,          
  AntecedentesDeDocenciaFechaInicio ,          
  AntecedentesDeDocenciaFechaFinalizacion ,           
  AntecedentesDeDocenciaLocalidad ,             
  AntecedentesDeDocenciaPais ,          
  AntecedentesDeDocenciaBaja ,      
         
  CapacidadesPersonalesId ,          
  CapacidadesPersonalesTipo ,          
  CapacidadesPersonalesDetalle ,          
  CapacidadesPersonalesBaja ,
            
  EventosAcademicosId ,          
  EventosAcademicosDenominacion ,        
  EventosAcademicosTipoDeEvento ,    
  EventosAcademicosCaracterDeParticipacion ,    
        
  EventosAcademicosFechaInicio ,          
  EventosAcademicosFechaFin ,          
  EventosAcademicosDuracion ,      
    
  EventosAcademicosInstitucion ,          
  EventosAcademicosLocalidad ,          
  EventosAcademicosPais ,          
  EventosAcademicosBaja ,    
            
  IdCompetenciaInformatica ,          
  CompetenciaDiploma ,          
  CompetenciaEstablecimiento ,          
  CompetenciaFechaObtencion ,          
  CompetenciaTipoInformatica ,      
  CompetenciaConocimiento ,       
  CompetenciaNivel ,      
  CompetenciaLocalidad ,          
  CompetenciaPais ,          
  CompetenciaBaja ,          
  Detalle
)

SELECT --distinct          
  dp.Id IdPersona,          
  dp.Nombre,          
  dp.Apellido,          
  dp.NroDocumento,        
  dp.TipoDocumento,          
  dpAdd.IdSexo Sexo,          
  dpadd.IdEstadoCivil EstadoCivil,          
  dpadd.CUIL,          
  dpadd.LugarNacimiento,          
  dp.FechaNacimiento,          
  dpadd.IdNacionalidad Nacionalidad,          
            
  dom_pers.ID_Domicilio DomPers_Id,           
  dom_pers.Calle DomPers_Calle,          
  dom_pers.Número DomPers_Numero,          
  dom_pers.Piso DomPers_Piso,          
  dom_pers.Dpto DomPers_Depto,          
  dom_pers.Localidad DomPers_Localidad,          
  dom_pers.Codigo_Postal DomPers_CodigoPostal,        
  pers_tel1.Telefono DomPers_Telefono,  
  pers_tel2.Telefono DomPers_Telefono2,  
  pers_email.Email  DomPers_Email,  
  
  isnull(dom_pers.Provincia, 0) DomPers_IdProvincia,          
          
  dom_lab.ID_Domicilio DomLab_Id,          
  dom_lab.Calle DomLab_Calle,          
  dom_lab.Número DomLab_Numero,          
  dom_lab.Piso DomLab_Piso,          
  dom_lab.Dpto DomLab_Depto,        
  dom_lab.Localidad DomLab_Localidad,          
  dom_lab.Codigo_Postal DomLab_CodigoPostal,          
  isnull(dom_lab.Provincia, 0) DomLab_IdProvincia,          
  CASE           
   WHEN TieneLegajo.idPersona is null THEN 'No tiene legajo'          
   ELSE 'Tiene legajo'          
   END AS TieneLegajo,          
  CASE            
   WHEN cvdp.IdPersona is null THEN 'No tiene curriculum'          
   ELSE 'Tiene curriculum'          
   END AS TieneCurriculum,          
             
  ant_acad.Id IdAntecedentesAcademicos,          
  ant_acad.Titulo AntecedentesAcademicosTitulo,          
  ant_acad.Nivel AntecedentesAcademicosNivel,          
  ant_acad.Establecimiento AntecedentesAcademicosEstablecimiento,          
  ant_acad.Especialidad AntecedentesAcademicosEspecialidad,          
  ant_acad.FechaIngreso AntecedentesAcademicosFechaIngreso,          
  ant_acad.FechaEgreso AntecedentesAcademicosFechaEgreso,          
  ant_acad.Localidad AntecedentesAcademicosLocalidad,          
  ant_acad.Pais AntecedentesAcademicosPais,          
  ant_acad.Baja AntecedentesAcademicosBaja,          
            
  ant_doc.Id IdAntecedentesDeDocencia,          
  ant_doc.Asignatura AntecedentesDeDocenciaAsignatura,          
  ant_doc.CaracterDesignacion AntecedentesDeDocenciaCaracterDesignacion,          
  ant_doc.CargaHoraria AntecedentesDeDocenciaCargaHoraria,          
  ant_doc.CategoriaDocente AntecedentesDeDocenciaCategoriaDocente,          
  ant_doc.DedicacionDocente AntecedentesDeDocenciaDedicacionDocente,          
  ant_doc.Establecimiento AntecedentesDeDocenciaEstablecimiento,          
  ant_doc.NivelEducativo AntecedentesDeDocenciaNivelEducativo,        
  ant_doc.TipoActividad AntecedentesDeDocenciaTipoActividad,          
  ant_doc.FechaInicio AntecedentesDeDocenciaFechaInicio,          
  ant_doc.FechaFinalizacion AntecedentesDeDocenciaFechaFinalizacion,          
  ant_doc.Localidad AntecedentesDeDocenciaLocalidad,          
  ant_doc.Pais AntecedentesDeDocenciaPais,          
  ant_doc.Baja AntecedentesDeDocenciaBaja,          
          
  cap_pers.Id CapacidadesPersonalesId,          
  cap_pers.Tipo CapacidadesPersonalesTipo,          
  cap_pers.Detalle CapacidadesPersonalesDetalle,          
  cap_pers.Baja CapacidadesPersonalesBaja,          
            
  eve_acad.Id EventosAcademicosId,          
  eve_acad.Denominacion EventosAcademicosDenominacion,        
    
  eve_acad_tipo.Id EventosAcademicosTipoDeEvento,    
  
   eve_acad_carac.Id EventosAcademicosCaracterDeParticipacion,    
        
  eve_acad.FechaInicio EventosAcademicosFechaInicio,          
  eve_acad.FechaFin EventosAcademicosFechaFin,          
  eve_acad.Duracion EventosAcademicosDuracion,     
    
  eve_acad_insti.Id EventosAcademicosInstitucion,          
           
  eve_acad.Localidad EventosAcademicosLocalidad,          
  eve_acad.Pais EventosAcademicosPais,          
  eve_acad.Baja EventosAcademicosBaja,          
            
  comp_info.Id IdCompetenciaInformatica,          
  comp_info.Diploma CompetenciaDiploma,          
  comp_info.Establecimiento CompetenciaEstablecimiento,          
  comp_info.FechaObtencion CompetenciaFechaObtencion,          
  ----------      
  tipo_comp_info.Id CompetenciaTipoInformatica,      
  conoc_comp_info.Id CompetenciaConocimiento,       
  nivel_comp_info.Id CompetenciaNivel,           
        
  ----------      
  comp_info.Localidad CompetenciaLocalidad,          
  comp_info.Pais CompetenciaPais,          
  comp_info.Baja CompetenciaBaja,          
  comp_info.Detalle Detalle          



FROM dbo.DatosPersonales dp          
 LEFT JOIN dbo.CV_DatosPersonales cvdp          
  ON cvdp.IdPersona = dp.Id          
 LEFT JOIN dbo.DatosPersonalesAdicionales dpadd          
  ON dpadd.IdPersona = dp.Id          
          
 LEFT JOIN dbo.CV_Domicilios cv_dom_pers          
  ON cv_dom_pers.IdPersona = dp.Id          
   AND cv_dom_pers.Tipo = 1          
 LEFT JOIN dbo.GEN_Domicilios dom_pers          
  ON cv_dom_pers.Id_Domicilio = dom_pers.Id_Domicilio          
  and isnull(dom_pers.DatoDeBaja,0)=0  
          
 LEFT JOIN dbo.CV_Domicilios cv_dom_lab          
  ON cv_dom_lab.IdPersona = dp.Id          
   AND cv_dom_lab.Tipo = 2          
 LEFT JOIN dbo.GEN_Domicilios dom_lab          
  ON cv_dom_lab.Id_Domicilio = dom_lab.Id_Domicilio           
    and isnull(dom_pers.DatoDeBaja,0)=0  
   
 --contacto personal (inicio)  
LEFT JOIN dbo.GEN_Telefonos pers_tel1  
  ON dom_pers.Id_Contacto =  pers_tel1.Id_Contacto  
  AND pers_tel1.Tipo_Contacto  = 1  
  
LEFT JOIN dbo.GEN_Telefonos pers_tel2  
  ON dom_pers.Id_Contacto =  pers_tel2.Id_Contacto  
  AND pers_tel2.Tipo_Contacto  = 2  
  
LEFT JOIN dbo.GEN_Emails pers_email  
  ON dom_pers.Id_Contacto =  pers_email.Id_Contacto  
  AND pers_email.Tipo_Contacto = 3  

             
            
 LEFT JOIN dbo.Datos_Personales TieneLegajo          
  ON TieneLegajo.IdPersona = dp.Id          
            
 LEFT JOIN dbo.CV_AntecedentesAcademicos ant_acad          
  ON ant_acad.IdPersona = dp.Id          
  and ant_acad.Baja is null      
          
 LEFT JOIN dbo.CV_AntecedentesDeDocencia ant_doc          
  ON ant_doc.IdPersona = dp.Id          
  and ant_doc.Baja is null      
           
 LEFT JOIN dbo.CV_CapacidadesPersonales cap_pers          
  ON cap_pers.IdPersona = dp.Id          
  and cap_pers.Baja is null      
 LEFT JOIN dbo.CV_EventosAcademicos eve_acad          
  ON eve_acad.IdPersona = dp.Id          
           
 ----          
 LEFT JOIN dbo.CV_TiposDeEventoAcademico eve_acad_tipo    
 ON eve_acad_tipo.id= eve_acad.IdTipoDeEvento    
 LEFT JOIN dbo.CV_CaracterDeParticipacionEvento eve_acad_carac    
 ON eve_acad_carac.id= eve_acad.IdCaracterParticipacion    
 LEFT JOIN dbo.CV_InstitucionesEventos eve_acad_insti    
 ON eve_acad_insti.id= eve_acad.IdInstitucion    
           
 ----    
           
 LEFT JOIN dbo.CV_CompetenciasInformaticas comp_info          
 ON comp_info.IdPersona = dp.Id          
           
 ----      
 Left Join dbo.CV_TipoCompetenciaInformatica tipo_comp_info      
 ON comp_info.IdTipoInformatica   = tipo_comp_info.id      
 Left Join dbo.CV_ConocimientosCompetenciasInformaticas conoc_comp_info      
 ON comp_info.IdConocimiento =conoc_comp_info.id      
 Left Join dbo.CV_NivelesCompetenciasInformaticas nivel_comp_info      
 ON comp_info.IdNivel  =nivel_comp_info.id      
 and comp_info.Baja is null      
       
         
           
 WHERE dp.Id = @idPersona          





/*2do insert*/

insert into #auxiliar2(
IdPersona,          
  Nombre ,          
  Apellido ,          
  NroDocumento ,        
  TipoDocumento ,          
  Sexo ,          
  EstadoCivil ,          
  CUIL ,          
  LugarNacimiento ,          
  FechaNacimiento , 


IdExperienciaLaboral,          
  ExperienciaLaboralActividad,          
  ExperienciaLaboralMotivoDesvinculacion,          
  ExperienciaLaboralNombreEmpleador,          
  ExperienciaLaboralPersonasACargo,          
  ExperienciaLaboralPuestoOcupado,
  ExperienciaLaboralTipoEmpresa,          
  ExperienciaLaboralInicio ,
  ExperienciaLaboralFin, 
  ExperienciaLaboralLocalidad,           
  ExperienciaLaboralPais, 
  ExperienciaLaboralBaja ,          
  ExperienciaLaboralSector,      
    
  IdIdioma ,          
  IdiomaDiploma,              
  IdiomaEstablecimiento,          
  IdiomaIdioma ,             
  IdiomaEscritura ,          
  IdiomaLectura ,          
  IdiomaOral ,          
  IdiomaFechaObtencion ,          
  IdiomaFechaFin ,          
  IdiomaLocalidad ,                
  IdiomaPais ,          
  IdiomaBaja ,          
                        
  IdInstitucion ,          
  InstitucionCaracterEntidad ,               
  InstitucionCargos ,           
  InstitucionCategoriaActual,           
  InstitucionFecha ,          
  InstitucionFechaAfiliacion ,          
  InstitucionFechaInicio ,           
  InstitucionFechaFin ,          
  InstitucionInstitucion,           
  InstitucionAfiliados ,          
  InstitucionLocalidad,         
  InstitucionPais ,           
  InstitucionBaja,    
                                              
  IdMatricula,          
  MatriculaExpedidoPor,          
  MatriculaNumero,          
  MatriculaSituacionActual,          
  MatriculaFechaObtencion ,          
  MatriculaBaja ,          
            
 IdPublicacion ,          
 PublicacionHojas ,            
 PublicacionEditorial ,         
 PublicacionCopia ,          
 PublicacionAdjunto ,            
 PublicacionTitulo ,          
 PublicacionFecha ,          
 PublicacionBaja ,          
                                    
 IdCertificadoCapacitacion ,          
 CertificadoDiploma ,           
 CertificadoEstablecimiento,           
 CertificadoEspecialidad,           
 CertificadoDuracion,           
 CertificadoFechaInicio,          
 CertificadoFechaFinalizacion ,          
 CertificadoLocalidad ,       
 CertificadoPais ,          
 CertificadoBaja 
)
  SELECT --distinct    
  
  dp.Id IdPersona,          
  dp.Nombre,          
  dp.Apellido,          
  dp.NroDocumento,        
  dp.TipoDocumento,          
  dpAdd.IdSexo Sexo,          
  dpadd.IdEstadoCivil EstadoCivil,          
  dpadd.CUIL,          
  dpadd.LugarNacimiento,          
  dp.FechaNacimiento, 
  
  
         
  ----          
  exp_labor.Id IdExperienciaLaboral,          
  exp_labor.Actividad ExperienciaLaboralActividad,          
  exp_labor.MotivoDesvinculacion ExperienciaLaboralMotivoDesvinculacion,          
  exp_labor.NombreEmpleador ExperienciaLaboralNombreEmpleador,          
  exp_labor.PersonasACargo ExperienciaLaboralPersonasACargo,          
  exp_labor.PuestoOcupado ExperienciaLaboralPuestoOcupado,          
  exp_labor.TipoEmpresa ExperienciaLaboralTipoEmpresa,          
  exp_labor.FechaInicio ExperienciaLaboralInicio,          
  exp_labor.FechaFin ExperienciaLaboralFin,          
  exp_labor.Localidad ExperienciaLaboralLocalidad,          
  exp_labor.Pais ExperienciaLaboralPais,          
  exp_labor.Baja ExperienciaLaboralBaja,          
  exp_labor.Sector ExperienciaLaboralSector,         
            
  idioma.Id IdIdioma,          
  idioma.Diploma IdiomaDiploma,          
  idioma.Establecimiento IdiomaEstablecimiento,          
  idioma.Idioma IdiomaIdioma,          
  idioma.Escritura IdiomaEscritura,          
  idioma.Lectura IdiomaLectura,          
  idioma.Oral IdiomaOral,          
  idioma.FechaObtencion IdiomaFechaObtencion,          
  idioma.FechaFin IdiomaFechaFin,          
  idioma.Localidad IdiomaLocalidad,          
  idioma.Pais IdiomaPais,          
  idioma.Baja IdiomaBaja,          
            
  instituc.Id IdInstitucion,          
  instituc.CaracterEntidad InstitucionCaracterEntidad,          
  instituc.CargosDesempeniados InstitucionCargos,          
  instituc.CategoriaActual InstitucionCategoriaActual,          
  instituc.Fecha InstitucionFecha,          
  instituc.FechaDeAfiliacion InstitucionFechaAfiliacion,          
  instituc.FechaInicio InstitucionFechaInicio,           
  instituc.FechaFin InstitucionFechaFin,          
  instituc.Institucion InstitucionInstitucion,          
  instituc.NumeroAfiliado InstitucionAfiliados,          
  instituc.Localidad InstitucionLocalidad,          
  instituc.Pais InstitucionPais,           
  instituc.Baja InstitucionBaja,          
            
  matric.Id IdMatricula,          
  matric.ExpedidaPor MatriculaExpedidoPor,          
  matric.Numero MatriculaNumero,          
  matric.SituacionActual MatriculaSituacionActual,          
  matric.FechaInscripcion MatriculaFechaObtencion,          
  matric.Baja MatriculaBaja,          
            
  publi.Id IdPublicacion,          
  publi.CantidadHojas PublicacionHojas,          
  publi.DatosEditorial PublicacionEditorial,          
  publi.DisponeCopia PublicacionCopia,          
  publi.DisponeAdjunto PublicacionAdjunto,            
  publi.Titulo PublicacionTitulo,          
  publi.FechaPublicacion PublicacionFecha,          
  publi.Baja PublicacionBaja,          
            
  activ_capac.Id IdCertificadoCapacitacion,          
  activ_capac.Titulo CertificadoDiploma,          
  activ_capac.Establecimiento CertificadoEstablecimiento,          
  activ_capac.Especialidad CertificadoEspecialidad,          
  activ_capac.Duracion CertificadoDuracion,          
  activ_capac.FechaIngreso CertificadoFechaInicio,          
  activ_capac.FechaEgreso CertificadoFechaFinalizacion,          
  activ_capac.Localidad CertificadoLocalidad,          
  activ_capac.Pais CertificadoPais,          
  activ_capac.Baja CertificadoBaja          
            
 FROM dbo.DatosPersonales dp          
 LEFT JOIN dbo.CV_DatosPersonales cvdp          
  ON cvdp.IdPersona = dp.Id   
         
 LEFT JOIN dbo.DatosPersonalesAdicionales dpadd          
  ON dpadd.IdPersona = dp.Id          


                 
 LEFT JOIN dbo.CV_ExperienciasLaborales exp_labor          
  ON exp_labor.IdPersona = dp.Id          
  and exp_labor.Baja is null      
 LEFT JOIN dbo.CV_Idiomas idioma          
  ON idioma.IdPersona = dp.Id          
  and idioma.Baja is null      
 LEFT JOIN dbo.CV_Instituciones instituc          
  ON instituc.IdPersona = dp.Id          
  and instituc.Baja is null      
            
 LEFT JOIN dbo.CV_Matriculas matric          
  ON matric.IdPersona = dp.Id          
  and matric.Baja is null      
            
 LEFT JOIN dbo.CV_Publicaciones publi          
  ON publi.IdPersona = dp.Id      
  and publi.Baja is null      
           
 LEFT JOIN dbo.CV_ActividadesDeCapacitacion activ_capac          
  ON activ_capac.IdPersona = dp.Id          
  and activ_capac.Baja is null      
           
 WHERE           
  dp.Id = @idPersona    

/*fin 2do insert*/

  --SELECT distinct * FROM #auxiliar
  
  
 -- SELECT distinct a2.* FROM #auxiliar a1, #auxiliar2 a2
 -- where a1.id = a2.id
  
  
  select
  a1.IdPersona,          
  a1.Nombre ,          
  a1.Apellido ,          
  a1.NroDocumento ,        
  a1.TipoDocumento ,          
  a1.Sexo ,          
  a1.EstadoCivil ,          
  a1.CUIL ,          
  a1.LugarNacimiento ,          
  a1.FechaNacimiento ,          
  a1.Nacionalidad ,          
            
  a1.DomPers_Id  ,           
  a1.DomPers_Calle ,          
  a1.DomPers_Numero ,          
  a1.DomPers_Piso ,          
  a1.DomPers_Depto ,          
  a1.DomPers_Localidad ,          
  a1.DomPers_CodigoPostal ,        
  ltrim(rtrim(a1.DomPers_Telefono))DomPers_Telefono ,        
  ltrim(rtrim(a1.DomPers_Telefono2))DomPers_Telefono2 ,     
  a1.DomPers_Email  ,        
  a1.DomPers_IdProvincia ,          
          
  a1.DomLab_Id ,          
  a1.DomLab_Calle ,           
  a1.DomLab_Numero ,          
  a1.DomLab_Piso ,           
  a1.DomLab_Depto ,            
  a1.DomLab_Localidad  ,          
  a1.DomLab_CodigoPostal ,          
  a1.DomLab_IdProvincia , 
  ltrim(rtrim(a1.TieneLegajo))TieneLegajo ,
  ltrim(rtrim(a1.TieneCurriculum))TieneCurriculum ,
               
  a1.IdAntecedentesAcademicos ,          
  a1.AntecedentesAcademicosTitulo ,          
  a1.AntecedentesAcademicosNivel ,          
  a1.AntecedentesAcademicosEstablecimiento ,      
  a1.AntecedentesAcademicosEspecialidad ,                
  a1.AntecedentesAcademicosFechaIngreso ,          
  a1.AntecedentesAcademicosFechaEgreso ,          
  a1.AntecedentesAcademicosLocalidad ,            
  a1.AntecedentesAcademicosPais ,          
  a1.AntecedentesAcademicosBaja ,          
            
  a1.IdAntecedentesDeDocencia ,          
  a1.AntecedentesDeDocenciaAsignatura ,          
  a1.AntecedentesDeDocenciaCaracterDesignacion ,          
  a1.AntecedentesDeDocenciaCargaHoraria ,          
  a1.AntecedentesDeDocenciaCategoriaDocente ,          
  a1.AntecedentesDeDocenciaDedicacionDocente ,          
  a1.AntecedentesDeDocenciaEstablecimiento ,          
  a1.AntecedentesDeDocenciaNivelEducativo ,        
  a1.AntecedentesDeDocenciaTipoActividad ,          
  a1.AntecedentesDeDocenciaFechaInicio ,          
  a1.AntecedentesDeDocenciaFechaFinalizacion ,           
  a1.AntecedentesDeDocenciaLocalidad ,             
  a1.AntecedentesDeDocenciaPais ,          
  a1.AntecedentesDeDocenciaBaja ,      
         
  a1.CapacidadesPersonalesId ,          
  a1.CapacidadesPersonalesTipo ,          
  a1.CapacidadesPersonalesDetalle ,          
  a1.CapacidadesPersonalesBaja ,
            
  a1.EventosAcademicosId ,          
  a1.EventosAcademicosDenominacion ,        
  a1.EventosAcademicosTipoDeEvento ,    
  a1.EventosAcademicosCaracterDeParticipacion ,    
        
  a1.EventosAcademicosFechaInicio ,          
  a1.EventosAcademicosFechaFin ,          
  a1.EventosAcademicosDuracion ,      
    
  a1.EventosAcademicosInstitucion ,          
  a1.EventosAcademicosLocalidad ,          
  a1.EventosAcademicosPais ,          
  a1.EventosAcademicosBaja ,    
            
  a1.IdCompetenciaInformatica ,          
  a1.CompetenciaDiploma ,          
  a1.CompetenciaEstablecimiento ,          
  a1.CompetenciaFechaObtencion ,          
  a1.CompetenciaTipoInformatica ,      
  a1.CompetenciaConocimiento ,       
  a1.CompetenciaNivel ,      
  a1.CompetenciaLocalidad ,          
  a1.CompetenciaPais ,          
  a1.CompetenciaBaja ,          
  a1.Detalle ,         
                
  a2.IdExperienciaLaboral ,          
  a2.ExperienciaLaboralActividad ,          
  a2.ExperienciaLaboralMotivoDesvinculacion ,          
  a2.ExperienciaLaboralNombreEmpleador ,          
  a2.ExperienciaLaboralPersonasACargo ,          
  a2.ExperienciaLaboralPuestoOcupado ,
  a2.ExperienciaLaboralTipoEmpresa ,          
  a2.ExperienciaLaboralInicio ,          
  a2.ExperienciaLaboralFin ,          
  a2.ExperienciaLaboralLocalidad ,           
  a2.ExperienciaLaboralPais ,          
  a2.ExperienciaLaboralBaja ,          
  a2.ExperienciaLaboralSector ,      
    
  a2.IdIdioma ,          
  a2.IdiomaDiploma ,              
  a2.IdiomaEstablecimiento ,          
  a2.IdiomaIdioma,             
  a2.IdiomaEscritura ,          
  a2.IdiomaLectura ,          
  a2.IdiomaOral ,          
  a2.IdiomaFechaObtencion ,          
  a2.IdiomaFechaFin ,          
  a2.IdiomaLocalidad ,                
  a2.IdiomaPais ,          
  a2.IdiomaBaja ,          
                        
  a2.IdInstitucion ,          
  a2.InstitucionCaracterEntidad ,               
  a2.InstitucionCargos ,           
  a2.InstitucionCategoriaActual ,           
  a2.InstitucionFecha ,          
  a2.InstitucionFechaAfiliacion ,          
  a2.InstitucionFechaInicio ,           
  a2.InstitucionFechaFin ,          
  a2.InstitucionInstitucion ,           
  a2.InstitucionAfiliados ,          
  a2.InstitucionLocalidad ,         
  a2.InstitucionPais ,           
  a2.InstitucionBaja ,    
                                              
  a2.IdMatricula ,          
  a2.MatriculaExpedidoPor ,          
  a2.MatriculaNumero ,          
  a2.MatriculaSituacionActual ,          
  a2.MatriculaFechaObtencion ,          
  a2.MatriculaBaja ,          
            
 a2.IdPublicacion ,          
 a2.PublicacionHojas ,            
 a2.PublicacionEditorial ,         
 a2.PublicacionCopia ,          
 a2.PublicacionAdjunto ,            
 a2.PublicacionTitulo ,          
 a2.PublicacionFecha ,          
 a2.PublicacionBaja ,          
                                    
 a2.IdCertificadoCapacitacion ,          
 a2.CertificadoDiploma ,           
 a2.CertificadoEstablecimiento ,           
 a2.CertificadoEspecialidad ,           
 a2.CertificadoDuracion ,           
 a2.CertificadoFechaInicio ,          
 a2.CertificadoFechaFinalizacion ,          
 a2.CertificadoLocalidad ,       
 a2.CertificadoPais,          
 a2.CertificadoBaja       
 FROM #auxiliar a1 
  join #auxiliar2 a2
 on a1.idpersona = a2.idpersona 
   order by a2.IdAntecedentesAcademicos asc
  
  

 END 

 --set nocount off 


*/