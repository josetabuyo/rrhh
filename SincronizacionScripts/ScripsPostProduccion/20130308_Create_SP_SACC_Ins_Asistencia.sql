CREATE PROCEDURE [dbo].[SACC_Ins_Asistencia]
					@id_alumno int,
					@id_curso smallint,
					@fecha_asistencia datetime,
					@descripcion char(30),
					@id_usuario int,
					@fecha datetime = null,
					@baja bit = 0
AS

BEGIN

	INSERT INTO [dbo].[SAC_Asistencias]
			   ([idAlumno]
			   ,[idCurso]
			   ,[fechaAsistencia]
			   ,[descripcion]
			   ,[idUsuario]
			   ,[fecha]
			   ,[baja]
			   )
		 VALUES
			   (@id_alumno,
				@id_curso,
				@fecha_asistencia,
				@descripcion,
				@id_usuario,
				@fecha,
				@baja)
END				
