CREATE PROCEDURE dbo.SIC_GetTransicionesDeDocumentos

	@IdAreaOrigen int = null,
	@IdAreaDestino int = null,
	@IdTransicion int = null,
	@Desde smalldatetime = null,
	@Hasta smalldatetime = null,
	@IdDocumento int = null
	
AS

SELECT [Id]
      ,[IdDocumento]
      ,[IdAreaOrigen]
      ,[IdAreaDestino]
      ,[Fecha]
      ,[IdUsuario]
      ,[FechaOperacion]
  FROM [DB_RRHH].[dbo].[SIC_TransicionesDeDocumentos]
	WHERE 
	(@IdAreaOrigen = IdAreaOrigen OR @IdAreaOrigen is null) AND
	(@IdAreaDestino = IdAreaDestino OR @IdAreaDestino is null) AND
	(@IdTransicion = Id OR @IdTransicion is null) AND
	(Fecha >= @Desde OR @Desde is null) AND
	(Fecha <= @Hasta OR @Hasta is null) AND
	(@IdDocumento = IdDocumento or @IdDocumento is null)
  
GO