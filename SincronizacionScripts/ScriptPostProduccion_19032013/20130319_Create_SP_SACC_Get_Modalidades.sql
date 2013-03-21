USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_GetModalidades]    Script Date: 03/19/2013 20:22:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

/****** Objeto:  StoredProcedure [dbo].[SACC_GetTodosLosAlumnos]    Fecha de la secuencia de comandos: 02/27/2013 21:37:47 ******/

CREATE PROCEDURE [dbo].[SACC_GetModalidades]

AS

BEGIN

select
IdModalidad,
Descripcion					ModalidadDescripcion


From dbo.SAC_Modalidad


END



GO

