USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Ins_Docente]    Script Date: 03/19/2013 20:24:40 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Ins_Docente]
(	
	@IdDocente  [int],	
	@IdUsuario [smallint],
	@Fecha [datetime],
	@idBaja [int] = null	
) 

AS

BEGIN
    
INSERT INTO dbo.SAC_Docentes (IdDocente, IdUsuario, Fecha, idBaja)
values
(	
	@IdDocente,	
	@IdUsuario,
	GETDATE(),
	@idBaja	
) 

END  
GO

