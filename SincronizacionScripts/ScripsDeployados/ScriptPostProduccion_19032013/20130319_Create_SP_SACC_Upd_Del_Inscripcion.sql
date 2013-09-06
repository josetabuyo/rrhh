USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Upd_Del_Inscripcion]    Script Date: 03/19/2013 20:29:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Upd_Del_Inscripcion]
(	
	@idCurso  [smallint],
	@idAlumno  [int],	
	@IdUsuario [smallint],
	@Fecha [smalldatetime],
	@IdBaja [int] = null	
) 

AS

BEGIN
    
UPDATE [dbo].[SAC_Inscripciones]       
      
SET  	     
	[idCurso]  = @idCurso,  
	[idAlumno] = @idAlumno,    
	[idusuario]  = @IdUsuario,      
	[Fecha]  = GETDATE(),
	[idBaja] = @IdBaja
      
WHERE       
	[idCurso]  = @idCurso and
	[idAlumno] = @idAlumno  

END

GO

