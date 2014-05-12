ALTER procedure[dbo].[Web_GetUsuario]      
	@id int = null,
	@id_persona int = null,
	@alias varchar(15) = null 
as      

declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp
      
SELECT 
	us.id				Id,
	us.nombre			Alias,      
	wp.password			Clave_Encriptada,
	us.IdPersona		Id_Persona,
    us.baja             Baja
FROM	dbo.RH_usuarios		us	 INNER JOIN
		dbo.web_passwords	wp on 
		wp.idUsuario = us.id	
				
where            
  (us.id = @id OR @id is null) AND 
  (us.Nombre = @alias OR @alias is null) AND 
  (us.IdPersona = @id_persona OR @id_persona is null)

