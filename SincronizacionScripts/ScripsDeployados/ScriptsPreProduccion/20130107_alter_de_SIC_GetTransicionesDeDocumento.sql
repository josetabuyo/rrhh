ALTER PROCEDURE [dbo].[SIC_GetTransicionesDeDocumentos]

	@IdAreaOrigen int = null,
	@IdAreaDestino int = null,
	@IdTransicion int = null,
	@Desde datetime = null,
	@Hasta datetime = null,
	@IdDocumento int = null,
	@Tipo varchar(10) = null
	
AS

SELECT [Id]
      ,[IdDocumento]
      ,[IdAreaOrigen]
      ,[IdAreaDestino]
      ,[Fecha]
      ,[IdUsuario]
      ,[FechaOperacion]
	  ,[Tipo]
	  ,[Comentarios]
  FROM [DB_RRHH].[dbo].[SIC_TransicionesDeDocumentos]
	WHERE 
	(@IdAreaOrigen = IdAreaOrigen OR @IdAreaOrigen is null) AND
	(@IdAreaDestino = IdAreaDestino OR @IdAreaDestino is null) AND
	(@IdTransicion = Id OR @IdTransicion is null) AND
	(Fecha >= @Desde OR @Desde is null) AND
	(Fecha <= @Hasta OR @Hasta is null) AND
	(@IdDocumento = IdDocumento or @IdDocumento is null) AND
	(@Tipo = Tipo or @Tipo is null) 