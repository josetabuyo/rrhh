CREATE PROCEDURE [dbo].[SACC_Upd_Del_Curso]
(	
	@id_curso	[smallint],
	@id_aula    [smallint],
	@id_materia [smallint],
	@id_docente [int],
	@fecha		[datetime],
	@baja		[int] = null,
	@horaCatedra [smallint]
) 

AS
    
UPDATE [dbo].[SAC_Cursos]
	SET 		
		IdAula = @id_aula,
		IdMateria = @id_materia,
		IdDocente = @id_docente,
		Fecha = @fecha,
		idBaja = @baja,
		HoraCatedra = @horaCatedra
	WHERE Id = @id_curso

