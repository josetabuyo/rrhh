USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Get_Inscripciones]    Script Date: 03/19/2013 20:21:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Get_Inscripciones]

AS

BEGIN

select
insc.id							Id,	
insc.IdCurso					IdCurso,
insc.IdAlumno					IdAlumno,
insc.Fecha						Fecha

From dbo.SAC_Inscripciones insc

where insc.idBaja is null

END
GO

