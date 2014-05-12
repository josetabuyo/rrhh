CREATE PROCEDURE dbo.MAU_GetAccesosAUrl
	@id_url int = null,
	@id_funcionalidad int = null
AS
BEGIN  

  SELECT [MU].[id]
        ,[MU].[idFuncionalidad]
        ,[MU].[url]
  FROM [dbo].[MAU_Accesos_A_URL] MU
  LEFT JOIN [dbo].[MAU_Funcionalidades] MF ON
	     MU.[idFuncionalidad] = MF.[Id]
  WHERE (MU.Id = @id_url or @id_url is null) AND
		(MF.Id = @id_funcionalidad or @id_funcionalidad is null) AND
		MU.idBaja is null AND
		MF.idBaja is null		
END


GO


grant exec on dbo.MAU_GetAccesosAUrl to RRHH_SIS_LEG_ADM
grant exec on dbo.MAU_GetAccesosAUrl to RRHH_SIS_LEG_INS
grant exec on dbo.MAU_GetAccesosAUrl to RRHH_SIS_LEG_UPD
grant exec on dbo.MAU_GetAccesosAUrl to RRHH_SIS_LEG_USR
grant exec on dbo.MAU_GetAccesosAUrl to usrRRHHws


GO


