
Alter Table dbo.CV_CompetenciasInformaticas
Add IdTipoInformatica int
go
Alter Table dbo.CV_CompetenciasInformaticas
Add IdConocimiento int
go
Alter Table dbo.CV_CompetenciasInformaticas
Add IdNivel int
go


ALTER TABLE dbo.CV_CompetenciasInformaticas
ADD CONSTRAINT fk_CompInf_Tipo
FOREIGN KEY (IdTipoInformatica)
REFERENCES dbo.CV_TipoCompetenciaInformatica(Id)

go

ALTER TABLE dbo.CV_CompetenciasInformaticas
ADD CONSTRAINT fk_CompInf_Conoc
FOREIGN KEY (IdConocimiento)
REFERENCES dbo.CV_ConocimientosCompetenciasInformaticas(Id)

go

ALTER TABLE dbo.CV_CompetenciasInformaticas
ADD CONSTRAINT fk_CompInf_Nivel
FOREIGN KEY (IdNivel)
REFERENCES dbo.CV_NivelesCompetenciasInformaticas(Id)

go


alter Procedure [dbo].[CV_Upd_Del_CompetenciasInformaticas]  
@IdCompetencia int = null,  
@Diploma varchar(100)=null,  
@Establecimiento varchar(100)=null,  
@FechaObtencion datetime=null,  
@TipoInformatica varchar(100)=null,  
@Conocimiento varchar(100)=null,  
@Nivel varchar(50)=null,  
@Localidad varchar(100)=null,  
@Pais int=null,  
@Usuario int=null,  
@Baja int=null,  
@Detalle varchar(100)=null  
  
AS  
  
BEGIN  
  
declare @NombreSp varchar(60)   
 set @NombreSp = (select OBJECT_NAME(@@PROCID))  
 exec dbo.Audit @NombreSp    
  
UPDATE dbo.CV_CompetenciasInformaticas  
   SET Diploma = isnull(@Diploma,Diploma),   
      Establecimiento = isnull(@Establecimiento,Establecimiento),  
      FechaObtencion = isnull(@FechaObtencion,FechaObtencion),   
      IdTipoInformatica = isnull(cast(@TipoInformatica as int),IdTipoInformatica),   
      IdConocimiento = isnull(cast(@Conocimiento as int),IdConocimiento),   
      IdNivel = isnull(cast(@Nivel as int),IdNivel),  
      Localidad = isnull(@Localidad,Localidad),  
      Pais = isnull(@Pais,Pais),   
      Usuario = isnull(@Usuario,Usuario),  
      FechaOperacion = getdate(),  
      Baja = isnull(@Baja,Baja),  
   Detalle = isnull(@Detalle,Detalle)   
        
 WHERE id=@IdCompetencia  
  
END  
  
  
  
  
go


alter PROCEDURE [dbo].[CV_GetCurriculumVitae]     
(    
 @idPersona int    
)    
AS    
BEGIN    
 SELECT     
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
  dom_pers.Telefono DomPers_Telefono,  
  dom_pers.Telefono2 DomPers_Telefono2,  
  dom_pers.Correo_Electronico DomPers_Email,  
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
  eve_acad.TipoDeEvento EventosAcademicosTipoDeEvento,    
  eve_acad.CaracterDeParticipacion EventosAcademicosCaracterDeParticipacion,    
  eve_acad.FechaInicio EventosAcademicosFechaInicio,    
  eve_acad.FechaFin EventosAcademicosFechaFin,    
  eve_acad.Duracion EventosAcademicosDuracion,    
  eve_acad.Institucion EventosAcademicosInstitucion,    
  eve_acad.Localidad EventosAcademicosLocalidad,    
  eve_acad.Pais EventosAcademicosPais,    
  eve_acad.Baja EventosAcademicosBaja,    
      
  comp_info.Id IdCompetenciaInformatica,    
  comp_info.Diploma CompetenciaDiploma,    
  comp_info.Establecimiento CompetenciaEstablecimiento,    
  comp_info.FechaObtencion CompetenciaFechaObtencion,    
  ----------
 -- comp_info.TipoInformatica CompetenciaTipoInformatica,    
  cast(tipo_comp_info.Id as varchar) CompetenciaTipoInformatica,
 --comp_info.Conocimiento CompetenciaConocimiento,    
  cast(conoc_comp_info.Id as varchar) CompetenciaConocimiento, 
 --comp_info.Nivel CompetenciaNivel,   
  cast(nivel_comp_info.Id as varchar) CompetenciaNivel,     
  
  ----------
  comp_info.Localidad CompetenciaLocalidad,    
  comp_info.Pais CompetenciaPais,    
  comp_info.Baja CompetenciaBaja,    
  comp_info.Detalle Detalle,    
      
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
    
 LEFT JOIN dbo.CV_Domicilios cv_dom_pers    
  ON cv_dom_pers.IdPersona = dp.Id    
   AND cv_dom_pers.Tipo = 1    
 LEFT JOIN dbo.GEN_Domicilios dom_pers    
  ON cv_dom_pers.Id_Domicilio = dom_pers.Id_Domicilio    
      
    
 LEFT JOIN dbo.CV_Domicilios cv_dom_lab    
  ON cv_dom_lab.IdPersona = dp.Id    
   AND cv_dom_lab.Tipo = 2    
 LEFT JOIN dbo.GEN_Domicilios dom_lab    
  ON cv_dom_lab.Id_Domicilio = dom_lab.Id_Domicilio     
       
      
 LEFT JOIN dbo.Datos_Personales TieneLegajo    
  ON TieneLegajo.IdPersona = dp.Id    
      
 LEFT JOIN dbo.CV_AntecedentesAcademicos ant_acad    
  ON ant_acad.IdPersona = dp.Id    
    
 LEFT JOIN dbo.CV_AntecedentesDeDocencia ant_doc    
  ON ant_doc.IdPersona = dp.Id    
     
 LEFT JOIN dbo.CV_CapacidadesPersonales cap_pers    
  ON cap_pers.IdPersona = dp.Id    
     
 LEFT JOIN dbo.CV_EventosAcademicos eve_acad    
  ON eve_acad.IdPersona = dp.Id    
     
 LEFT JOIN dbo.CV_CompetenciasInformaticas comp_info    
  ON comp_info.IdPersona = dp.Id    
     
 ----
 Left Join dbo.CV_TipoCompetenciaInformatica tipo_comp_info
 ON comp_info.IdTipoInformatica   = tipo_comp_info.id
 Left Join dbo.CV_ConocimientosCompetenciasInformaticas conoc_comp_info
 ON comp_info.IdConocimiento =conoc_comp_info.id
 Left Join dbo.CV_NivelesCompetenciasInformaticas nivel_comp_info
 ON comp_info.IdNivel  =nivel_comp_info.id
 
 ----    
           
 LEFT JOIN dbo.CV_ExperienciasLaborales exp_labor    
  ON exp_labor.IdPersona = dp.Id    
     
 LEFT JOIN dbo.CV_Idiomas idioma    
  ON idioma.IdPersona = dp.Id    
     
 LEFT JOIN dbo.CV_Instituciones instituc    
  ON instituc.IdPersona = dp.Id    
      
 LEFT JOIN dbo.CV_Matriculas matric    
  ON matric.IdPersona = dp.Id    
      
 LEFT JOIN dbo.CV_Publicaciones publi    
  ON publi.IdPersona = dp.Id    
     
 LEFT JOIN dbo.CV_ActividadesDeCapacitacion activ_capac    
  ON activ_capac.IdPersona = dp.Id    
     
 WHERE     
  (dom_lab.DatoDeBaja = 0 OR dom_lab.DatoDeBaja IS NULL)    
  and     
  (dom_pers.DatoDeBaja = 0 OR dom_pers.DatoDeBaja IS NULL)     
 /* and    
  (ant_acad.Baja = 0  OR ant_acad.Baja is null)    
  and    
  (ant_doc.Baja = 0 OR ant_doc.Baja is null)    
  and    
  (cap_pers.Baja = 0  OR cap_pers.Baja is null)    
  and    
  (comp_info.Baja = 0 OR comp_info.Baja is null)    
  and    
  (exp_labor.Baja = 0 OR exp_labor.Baja is null)    
  and    
  (idioma.Baja = 0 OR idioma.Baja is null)    
  and    
  (instituc.Baja = 0 OR instituc.Baja is null)    
  and    
  (matric.Baja = 0 OR matric.Baja is null)    
  and     
  (activ_capac.Baja = 0 OR activ_capac.Baja is null)    
  and    
  (publi.Baja = 0 OR publi.Baja is null) */   
  and dp.Id = @idPersona    
END    
  

go



 Alter PROCEDURE [dbo].[CV_Ins_CompetenciasInformaticas]  
(  
 @Diploma varchar(100) = null,  
 @Establecimiento varchar(100) = null,  
 @FechaObtencion[datetime] = null,  
 @TipoInformatica varchar(100) = null,  
 @Conocimiento varchar(100) = null,  
 @Nivel varchar(50)  = null,  
 @Localidad varchar(100)  = null,  
 @Pais int = null,  
 @Usuario[int],   
 @Baja [int]  = null,  
 @Documento int = null,  
 @IdPersona int =null,  
 @Detalle varchar(100)  = null  
  
)  
  
AS  
  
BEGIN  
  
/* COMENTADO por el agreado de "@IdPersona int =null" y "SELECT SCOPE_IDENTITY()"  
*********************************************************************************  
declare @IdPersona int      
 select @IdPersona = Id from dbo.DatosPersonales where NroDocumento = @Documento      
  
*/   
   
 INSERT INTO [dbo].[CV_CompetenciasInformaticas]  
  (Diploma, Establecimiento, FechaObtencion, IdTipoInformatica, IdConocimiento,IdNivel,Localidad, Pais,Usuario,FechaOperacion,Baja,IdPersona, Detalle )  
 VALUES   
  (@Diploma, @Establecimiento,@FechaObtencion, cast(@TipoInformatica as int), cast(@Conocimiento as int),cast(@Nivel as int),@Localidad,@Pais,@Usuario,GETDATE(),@Baja,@IdPersona, @Detalle)  
   
SELECT SCOPE_IDENTITY()  
END  
  



