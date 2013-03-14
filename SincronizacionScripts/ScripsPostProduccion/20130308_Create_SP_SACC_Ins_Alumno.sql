CREATE PROCEDURE [dbo].[SACC_Ins_Alumno]
(	
	@IdPersona  [int],
	@IdModalidad  [int],
	@IdUsuario  [varchar](30),
	@Fecha [datetime],
	@IdBaja [int] = null	
) 

AS
  
BEGIN

INSERT INTO dbo.SAC_Alumnos
values
(	
	@IdPersona,
	@IdModalidad,
	@IdUsuario,
	GETDATE(),
	@IdBaja
) 

END     