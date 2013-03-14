CREATE PROCEDURE [dbo].[SACC_Upd_Del_Asistencia]
					@id_alumno int,
					@id_curso smallint,
					@fecha_asistencia datetime,
					@descripcion char(30),
					@id_usuario int,
					@fecha datetime = null,
					@baja bit = 0
AS


BEGIN
		UPDATE [dbo].[SAC_Asistencias] 
			SET [descripcion] = @descripcion,
				[fecha] = @fecha,
				[baja] = @baja,
				[idUsuario] = @id_usuario
			WHERE 
			[idAlumno] = @id_alumno AND
			[idCurso] = @id_curso AND
			[fechaAsistencia] = @fecha_asistencia
END