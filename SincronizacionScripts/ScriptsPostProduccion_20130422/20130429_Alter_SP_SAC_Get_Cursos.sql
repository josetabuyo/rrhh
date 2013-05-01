SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SACC_Get_Cursos]

AS
BEGIN

	SELECT
		id,
		IdMateria,
		IdDocente,
		Fecha,
		FechaInicio,
		FechaFin,
		idBaja,
		IdEspacioFisico
	FROM
		dbo.sac_cursos

	WHERE idBaja is null
	
END
