ALTER PROCEDURE [dbo].[SIC_InsertTransicionDeDocumentos]

	@IdAreaOrigen int,
	@IdAreaDestino int = null,
	@Fecha datetime = null,
	@IdUsuario smallint,
	@IdDocumento int,
	@Tipo varchar(10),
	@Comentarios varchar(100) = null
AS

INSERT INTO dbo.SIC_TransicionesDeDocumentos
	( [IdDocumento]
      ,[IdAreaOrigen]
      ,[IdAreaDestino]
      ,[Fecha]
      ,[Tipo]
      ,[IdUsuario]
      ,[FechaOperacion]
      ,[Comentarios]) 
      VALUES
    (@IdDocumento, @IdAreaOrigen,
	@IdAreaDestino,	@Fecha, @Tipo,
	@IdUsuario, getdate(), @Comentarios
	)
	
	select SCOPE_Identity()
