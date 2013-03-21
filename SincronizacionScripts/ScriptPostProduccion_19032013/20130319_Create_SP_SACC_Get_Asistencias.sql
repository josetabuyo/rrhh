USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Get_Asistencias]    Script Date: 03/19/2013 20:20:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Get_Asistencias]

AS

BEGIN

select * from [dbo].[SAC_Asistencias]

END

GO

