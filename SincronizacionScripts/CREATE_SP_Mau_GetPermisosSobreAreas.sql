CREATE procedure[dbo].MAU_GetPermisosSobreAreas
AS

declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp

BEGIN
	SELECT 
		ta.id_area,
		UAW.Id_Usuario
	
	FROM	dbo.tabla_areas_estructura							ta
			LEFT JOIN RH_Usuarios_Areas_Web						UAW ON
			ta.id_area = UAW.Id_Area
	
	WHERE	ta.baja = 0	AND
			UAW.id_usuario IS NOT NULL	
end


