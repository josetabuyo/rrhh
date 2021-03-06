set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SACC_Ins_Curso]
(	
	@id_espacioFisico  [smallint],
	@id_materia  [smallint],
	@id_docente  [int],
	@fecha		[datetime],
	@baja		[int] = null,
	@horaCatedra  [smallint]
) 

AS
    
INSERT INTO [dbo].[SAC_Cursos]
	(IdMateria, IdDocente, Fecha, idBaja, HoraCatedra, IdEspacioFisico)
VALUES
	(@id_materia, @id_docente, @fecha, @baja, @horaCatedra, @id_espacioFisico)
	
SELECT SCOPE_IDENTITY()	
