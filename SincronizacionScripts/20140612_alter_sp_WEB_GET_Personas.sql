ALTER procedure [dbo].[WEB_Get_Personas]    
  @id_persona int = null   
as   


declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp   

SELECT 
 dp.id ID,
 lp.legajo Legajo,         
 dp.[Apellido],         
 dp.[Nombre],           
 dp.FechaNacimiento [Fecha_Nacimiento],               
 dp.TipoDocumento Tipo_Documento,         
 dp.NroDocumento Nro_Documento        
        
FROM [dbo].datosPersonales DP
LEFT JOIN dbo.LegajosPersonas lp
	ON lp.idPersona = dp.id
where dp.id = @id_persona or @id_persona is null




