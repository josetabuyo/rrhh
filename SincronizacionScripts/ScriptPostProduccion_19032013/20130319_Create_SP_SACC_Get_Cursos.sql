CREATE PROCEDURE [dbo].[SACC_Get_Cursos]

AS
BEGIN

	SELECT
		id,
		IdAula,
		IdMateria,
		IdDocente,
		Fecha,
		idBaja,
		HoraCatedra
	FROM
		dbo.sac_cursos

	WHERE idBaja is null
	
END

