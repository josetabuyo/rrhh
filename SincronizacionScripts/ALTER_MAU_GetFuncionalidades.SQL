ALTER PROCEDURE [dbo].[MAU_GetFuncionalidades] 
	@id_usuario int = null,
	@id_funcionalidad int = null
AS
BEGIN  
  SELECT DISTINCT
		 MF.[Id]
        ,MF.[Nombre]
  FROM [dbo].[MAU_Funcionalidades] MF
  LEFT JOIN  [dbo].[MAU_Funcionalidades_Por_Usuario] MFU ON
		MFU.[IdFuncionalidad] = MF.[ID]
  WHERE (MFU.IdUsuario = @id_usuario or @id_usuario is null) AND
		(MF.Id = @id_funcionalidad or @id_funcionalidad is null) AND
		MF.[IdBaja] is null AND MFU.[IdBaja] is null
END
