CREATE PROCEDURE [dbo].[MAU_GetFuncionalidadesDeUsuarios] 
AS
BEGIN  
  SELECT DISTINCT 
		idFuncionalidad id_funcionalidad,
		idUsuario id_usuario
  FROM [dbo].[MAU_Funcionalidades] MF
  INNER JOIN  [dbo].[MAU_Funcionalidades_Por_Usuario] MFU ON
		MFU.[IdFuncionalidad] = MF.[ID]
  WHERE MF.[IdBaja] is null AND MFU.[IdBaja] is null
END


