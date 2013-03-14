ALTER PROCEDURE [dbo].[VIA_GetZonas]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		zon.Id IdZona, zon.NombreZona, 
		prov.codAFIP IdProvincia, prov.nombreProvincia,
		loc.idLocalidad IdLocalidad, loc.nombrelocalidad NombreLocalidad
	FROM
		dbo.VIA_Zonas zon
		INNER JOIN dbo.VIA_Rel_Zona_Prov relZonaProv
			ON zon.Id = relZonaProv.IdZona
		INNER JOIN dbo.Provincias prov
			ON prov.codAFIP = relZonaProv.Cod_AFIP_Prov
		INNER JOIN dbo.LocalidadesAFIP loc
			ON prov.codAFIP = loc.id_provincia
	ORDER BY 
		zon.NombreZona, prov.nombreProvincia, loc.NombreLocalidad

END