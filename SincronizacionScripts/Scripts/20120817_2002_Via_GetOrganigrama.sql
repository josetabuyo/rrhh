CREATE PROCEDURE dbo.VIA_GetOrganigrama

AS
BEGIN
    -- Insert statements for procedure here
	SELECT codigo, Id_area, Descripcion, Baja, Acto_Baja, Acto_Nro, Acto_Fecha
	FROM dbo.Tabla_Areas_Estructura
	WHERE baja = 0
END
GO