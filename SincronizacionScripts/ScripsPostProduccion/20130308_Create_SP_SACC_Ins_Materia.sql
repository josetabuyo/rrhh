CREATE PROCEDURE [dbo].[SACC_Ins_Materia]
(	
	@Nombre  [varchar](30),
	@IdModalidad  [smallint],	
	@IdUsuario [smallint],
	@Fecha [smalldatetime],
	@Baja [int] = null
) 

AS
  
BEGIN

INSERT INTO dbo.SAC_Materias (Nombre, idModalidad, idusuario, Fecha, idBaja)
values
(	
	@Nombre,
	@IdModalidad,
	@IdUsuario,
	GETDATE(),
	@Baja	
) 

END       