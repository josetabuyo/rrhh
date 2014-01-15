CREATE procedure[dbo].[Web_GetUsuarioPorAlias]      
	@alias varchar(15) = null 
as      

declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp
      
SELECT 
	us.id				Id,
	us.nombre			Alias,      
	us.password			Clave_Encriptada
FROM   dbo.RH_usuarios		us	 
				
where            
  (us.Nombre = @alias OR @alias is null) AND
  us.Baja <> 1

