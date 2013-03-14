CREATE PROCEDURE [dbo].[SACC_Ins_Docente]
(	
	@IdDocente  [int],	
	@IdUsuario [smallint],
	@Fecha [datetime],
	@idBaja [int] = null	
) 

AS

BEGIN
    
INSERT INTO dbo.SAC_Docentes (IdDocente, IdUsuario, Fecha, idBaja)
values
(	
	@IdDocente,	
	@IdUsuario,
	GETDATE(),
	@idBaja	
) 

END   