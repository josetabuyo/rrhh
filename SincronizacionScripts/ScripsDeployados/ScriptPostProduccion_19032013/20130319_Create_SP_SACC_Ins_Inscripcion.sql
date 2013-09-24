USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Ins_Inscripcion]    Script Date: 03/19/2013 20:27:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Ins_Inscripcion]
(	
	@idCurso  [smallint],
	@idAlumno  [int],	
	@IdUsuario [smallint],
	@Fecha [smalldatetime],
	@IdBaja [int] = null	
) 

AS

BEGIN
    
INSERT [dbo].[SAC_Inscripciones]       
 
values
(	
	@idCurso,
	@idAlumno,
	@IdUsuario,
	GETDATE(),
	@IdBaja
) 

END   


GO

