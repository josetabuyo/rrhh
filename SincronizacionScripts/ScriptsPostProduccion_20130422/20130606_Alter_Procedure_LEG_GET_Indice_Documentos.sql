ALTER       PROCEDURE [dbo].[LEG_GET_Indice_Documentos]
 @id [int],      
 @legajo [int]      
AS
--Domicilio PERSONAL      
SELECT ID_INTERNA,NRO_DOC,'MDS' JUR,'DGRHyORG' ORG,'Cert. de Domicilio' TIPO,Folio FOLIO,fecha_comunicacion,'' Fecha_Hasta, 'Domicilio_personal'  tabla,  Id_domicilio id   
FROM Domicilio_personal      
WHERE id_interna = @id  and folio<> '99-999/999'  and datodebaja =0      
      
      
UNION       
      
--Domicilio FAMILIARES      
      
SELECT d.ID_INTERNo,d.DOC_titular,'MDS','DGRHyORG','Cert. de Domicilio',FOLIO,fechacomunicacion,'', 'Domicilio_familiares'  tabla,  D.id id        
FROM dbo.Domicilio_familiares D      
inner join datos_familiares DF      
 on d.id_interno = df.id_interna and d.id_fam = idfam      
WHERE d.id_interno = @id  and folio <> '99-999/999'      
      
UNION       
      
--DESIGNACIONES      
select id_interna,nro_doc,jurisdiccion,organismo,tr.descripcion +' '+ acto_nro Documento,folio,fecha_desde,fecha_hasta , 'designaciones'  tabla,  D.id_designacion id
from designaciones D      
inner join tabla_tipos_resoluciones TR      
 on TR.id = d.acto_tipo      
where (id_interna = @id or nro_doc = @legajo)      
and folio <> '99-999/999' and datodebaja = 0      
      
      
union       
      
--CARRERA ADMINISTRATIVA      
select id_interna,doc_tit,jurisdicción,organismo,tr.descripcion +' ' + acto_nro,folio,fecha_desde,fecha_hasta , 'carrera_administrativa'  tabla,  C.id_carrera id
from carrera_administrativa C      
inner join tabla_tipos_resoluciones TR      
 on TR.id = c.acto_tipo      
where (id_interna = @id or doc_tit = @legajo)      
and folio <> '99-999/999' and datodebaja = 0      
      
      
UNION       
      
--FELICITACIONES      
      
SELECT DP.ID_INTERNA,DP.NRO_DOCUMENTO,Fel.jurisdicción, FEL.ORGANISMO,tr.descripcion +' '+ acto_nro, FEL.FOLIO_NRO,FEL.FECHA,FEL.FECHA, 'Felicitaciones'  tabla,  Fel.id id      
FROM dbo.Datos_Personales  DP       
LEFT JOIN dbo.Felicitaciones Fel       
 ON DP.id_Interna = Fel.id_Interna       
inner join tabla_tipos_resoluciones TR      
 on TR.id = fel.acto_tipo      
WHERE (Nro_Documento = @Legajo or DP.id_interna = @id )      
and folio_nro <> '99-999/999' and datodebaja = 0      
      
      
--EMBARGOS      
      
union       
      
select id_interna, legajo, 'MDS','DGRHyORG','Embargo',folio,trabado_fecha,levantado_fecha , 'embargos'  tabla,  id_embargo id        
from embargos      
where (id_interna = @id)      
and folio <> '99-999/999' and datodebaja = 0      
      
      
union       
      
--Estudiios realizados      
select id_interna,nro_doc, 'MDS','DGRHyORG','Estudio nivel: '+ NE.descripcion,folio_nro,fecha_ingreso,fecha_egreso, 'estudios_realizados'  tabla,  id_estudio id           
from estudios_realizados ER      
inner join tabla_nivel_estudios NE      
  on NE.id = er.nivel      
WHERE (Nro_Doc = @Legajo or id_interna = @id)      
and ER.folio_nro <> '99-999/999' and datodebaja = 0      
      
      
UNION       
      
--estudios_idiomas      
select id_interna,nro_doc, 'MDS','DGRHyORG','Estudio : Idiomas',folio,'','', 'estudios_Idiomas'  tabla,  id id                 
from estudios_Idiomas      
WHERE (Nro_Doc = @Legajo or id_interna = @id )      
and folio <> '99-999/999' and datodebaja = 0      
      
UNION       
      
--estudios_ESPECIALIDADES      
select id_interna,doc_tit, 'MDS','DGRHyORG','Estudio : Especialidad',folio,'','', 'estudios_especilidades'  tabla,  id id             
from estudios_especilidades      
WHERE (Doc_tit = @Legajo or id_interna = @id )      
and folio <> '99-999/999' and datodebaja = 0      
      
      
UNION       
      
--OTROS ESTUDIOS      
select id_interna,nro_doc, 'MDS','DGRHyORG','Estudio : Otros',folio_nro,fecha_Ingreso,fecha_egreso, 'estudios_otros'  tabla,  id id                   
from estudios_otros      
WHERE (nro_Doc = @Legajo or id_interna = @id )      
and folio_nro <> '99-999/999' and datodebaja = 0      
      
      
union       
      
--LICENCIAS      
      
select id_interna,legajo, jurisdicción,organismo,'Licencia',folio,fecha_inicio,Fecha_fin, 'licencias'  tabla,  id_licencia id             
from licencias      
where (id_interna = @id)      
and folio <> '99-999/999' and datodebaja = 0      
      
      
union       
      
--PASIVIDAD      
      
select id_interna,nro_doc,'MDS','DGRHyORG','Pasividad',folio_nro,'','', 'pasividad'  tabla,  id_interna id        
from pasividad      
where id_interna = @id      
and folio_nro <> '99-999/999'       
union       
      
--CAPACITACION      
      
select id_interna,doc_titular,jurisdicción,organismo,'Capacitación',folio_nro,fecha_desde,fecha_hasta, 'capacitacion'  tabla,  id_capacitacion id          
from capacitacion      
where id_interna = @id      
and folio_nro <> '99-999/999' and datodebaja = 0      
      
      
union       
      
--CALIFICACIONES      
select id_interna,doc_titular,jurisdiccion,organismo,'Calificaciones',folio,fecha_desde, fecha_hasta, 'calificaciones'  tabla,  id_calificacion id                
from calificaciones      
where id_interna = @id      
and folio <> '99-999/999' and datodebaja = 0      
      
union       
      
--ANTECEDENTES MILITARES      
      
select id_interna,legajo,'MDS','DGRHyORG','Ant. Militar','00-000/000','','', 'antec_militares'  tabla,  id id           
from dbo.antec_militares      
where id_interna = @id       
      
      
union      
      
-- OTROS SERVICIOS      
      
select id_interna,0,'MDS','DGRHyORG','Otros Cert. de Trabajo',folio,fecha_desde,fecha_hasta, 'leg_otros_servicios'  tabla,  id id           
from dbo.leg_otros_servicios      
where id_interna = @id      
and folio <> '99-999/999' and datodebaja = 0      
      
      
      
UNION      
      
-- SERVICIOS ADM PUBLICA      
select id_interna,doc_titular,jurisdiccion,organismo,'Cert. de Trabajo',folio,fecha_desde,fecha_hasta, 'LEG_Servicios_adm_publica'  tabla,  id id           
from dbo.LEG_Servicios_adm_publica      
where id_interna = @id      
and folio <> '99-999/999' and datodebaja = 0      
      
      
union      
      
--OTROS DOC AGREGADOS      
select id_interna,legajo,Jurisdicción,Organismo,Tipo,Foja,Fecha_Agregado,'', 'Otros_Indice_Documentos'  tabla,  id_otros_indice id         
from  dbo.Otros_Indice_Documentos      
where id_interna = @id      
and foja <> '99-999/999' and datodebaja = 0      
      
      
union      
      
--PSICOFISICOS      
      
select id_interna,0,Jurisdiccion,Organismo,'Cert. Psicofisico',Folio_nro,Fecha,'', 'Psicofisico'  tabla,  id_psicofisico id 
from  dbo.Psicofisico      
where id_interna = @id      
and Folio_Nro <> '99-999/999' and datodebaja = 0      
      
    
  
union      
      
--OTROS DOCUMENTOS
      
select id_interna,0,Jurisdiccion,Organismo,motivo,Folio,Fecha,'', 'Otros_Datos'  tabla,  id id       
from  dbo.Otros_Datos  
where id_interna = @id      
and Folio <> '99-999/999' and datodebaja = 0      
  
--faml 26_feb_2010    

union      
      
--SITUACIONES ESPECIALES DE REVISTA
      
select id_interna,0,Jurisdicción,Organismo,motivo,Folio_Nro,Fecha_Desde,Fecha_Hasta, 'Situaciones_Especiales'  tabla,  id_situaciones id         
from  dbo.Situaciones_Especiales 
where id_interna = @id      
and Folio_Nro <> '99-999/999' and datodebaja = 0    

--faml 26_feb_2010
      
union  
  
--select 0,dp.nro_documento,'MDS','MDS','DDJJ Cargos Año: ' + cast(año as varchar),folio,fecharecepciono,''  
--FROM dbo.LEG_DDJJ_Cargos Dc  
--INNER JOIN dbo.Datos_Personales dp  
-- on dp.Nro_documento = dc.Nro_documento AND  
-- dp.id_interna = @Id  
--where folio <> '99-999/999'  
--order by folio  
  
select 0,dp.nro_documento,'MDS','MDS',(select AA.Descripcion from dbo.Tabla_Comprobante_Descripcion  AA where AA.ID = Dc.Id_Comprobante ) + cast(año as varchar),folio,fecharecepciono,'', 'LEG_DDJJ_Cargos'  tabla,  id id   
FROM dbo.LEG_DDJJ_Cargos Dc  
INNER JOIN dbo.Datos_Personales dp  
 on dp.Nro_documento = dc.Nro_documento AND  
 dp.id_interna = @Id  
where folio <> '99-999/999'  
order by folio

