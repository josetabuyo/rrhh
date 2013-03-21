USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Get_Horarios]    Script Date: 03/19/2013 20:21:07 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Get_Horarios]

AS

BEGIN

	SELECT
		id,
		idCurso,
		NroDiaSemana,
		Desde,
		Hasta
	FROM
		dbo.sac_horarios

--WHERE al.Baja = 0

END
GO

