
ALTER PROCEDURE [dbo].[SIC_InsertTransicionDeDocumentos]

	@IdAreaOrigen int,
	@IdAreaDestino int = null,
	@Fecha datetime = null,
	@IdUsuario smallint,
	@IdDocumento int,
	@Tipo varchar(10)
AS

INSERT INTO dbo.SIC_TransicionesDeDocumentos
	( [IdDocumento]
      ,[IdAreaOrigen]
      ,[IdAreaDestino]
      ,[Fecha]
      ,[Tipo]
      ,[IdUsuario]
      ,[FechaOperacion]) 
      VALUES
    (@IdDocumento, @IdAreaOrigen,
	@IdAreaDestino,	@Fecha, @Tipo,
	@IdUsuario, getdate()
	)
	
	select SCOPE_Identity()