USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Ins_Asistencia]    Script Date: 03/19/2013 20:23:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Ins_Asistencia]
					@id_alumno int,
					@id_curso smallint,
					@fecha_asistencia datetime,
					@descripcion char(30),
					@valor smallint,
					@id_usuario int,
					@fecha datetime = null,
					@baja int = null
AS

BEGIN

	INSERT INTO [dbo].[SAC_Asistencias]
			   ([idAlumno]
			   ,[idCurso]
			   ,[fechaAsistencia]
			   ,[descripcion]
			   ,[valor]
			   ,[idUsuario]
			   ,[fecha]
			   ,[idBaja]
			   )
		 VALUES
			   (@id_alumno,
				@id_curso,
				@fecha_asistencia,
				@descripcion,
				@valor,
				@id_usuario,
				@fecha,
				@baja)
END		
GO

