USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Del_Asistencias]    Script Date: 03/19/2013 20:17:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SACC_Del_Asistencias]
(	
	@id_alumno [int] = 0,
	@id_curso [int] = 0,
	@fecha_asistencia [datetime]
) 

AS
    
DELETE 
	[dbo].[SAC_Asistencias] 
WHERE 
	[idAlumno] = @id_alumno AND
	[idCurso] = @id_curso AND
	[fechaAsistencia] = @fecha_asistencia

GO

