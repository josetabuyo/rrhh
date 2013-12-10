CREATE PROCEDURE [dbo].[SACC_Get_Observaciones]

AS
BEGIN

	SELECT
		id,
		FechaCarga,
		Relacion,
		PersonaCarga,
		Pertenece,
		Asunto,
		ReferenteMDS,
		Seguimiento,
		Resultado,
		FechaDelResultado,
		ReferenteRtaMDS,
		idBaja
		
	FROM
		dbo.SAC_Observaciones

	WHERE idBaja is null
	
END