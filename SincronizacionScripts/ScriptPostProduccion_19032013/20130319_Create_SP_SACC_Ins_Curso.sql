CREATE PROCEDURE [dbo].[SACC_Ins_Curso]
(	
	@id_aula  [smallint],
	@id_materia  [smallint],
	@id_docente  [int],
	@fecha		[datetime],
	@baja		[int] = null,
	@horaCatedra  [smallint]
) 

AS
    
INSERT INTO [dbo].[SAC_Cursos]
	(IdAula, IdMateria, IdDocente, Fecha, idBaja, HoraCatedra)
VALUES
	(@id_aula, @id_materia, @id_docente, @fecha, @baja, @horaCatedra)
	
SELECT SCOPE_IDENTITY()	

