ALTER PROCEDURE [dbo].[SACC_Ins_Materia]
(	
	@Nombre  [varchar](50),
	@IdModalidad  [smallint],	
	@Ciclo  [smallint] = 1,	
	@IdUsuario [smallint],
	@Fecha [smalldatetime],
	@Baja [int] = null
) 

AS
  
BEGIN

INSERT INTO dbo.SAC_Materias (Nombre, idModalidad, idusuario, Fecha, idBaja, idCiclo)
values
(	
	@Nombre,
	@IdModalidad,
	@IdUsuario,
	GETDATE(),
	@Baja,
	@Ciclo	
) 

END     