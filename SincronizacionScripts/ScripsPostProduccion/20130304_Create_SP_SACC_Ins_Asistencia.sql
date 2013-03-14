/****** Object:  StoredProcedure [dbo].[SACC_GetAsistencias]    Script Date: 03/05/2013 20:14:50 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SACC_Ins_Asistencia]
					@id_alumno int,
					@id_curso smallint,
					@fecha_asistencia datetime,
					@descripcion char(30),
					@id_usuario int,
					@fecha datetime = getdate,
					@baja bit = 0
AS

if not exists(select * from dbo.sac_asistencias where idAlumno = @id_alumno and idCurso = @id_curso and fechaAsistencia = @fecha_asistencia)
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
GO



