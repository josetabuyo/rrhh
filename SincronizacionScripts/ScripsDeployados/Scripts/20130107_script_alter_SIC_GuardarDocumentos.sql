ALTER PROCEDURE [dbo].[SIC_GuardarDocumento]
@idTipoDeDocumento int,
@numero Varchar(50),
@idCategoria int,
@idAreaOrigen int,
@extracto Varchar(1000),
@ticket Varchar(6),
@idAreaDestino int = null,
@comentarios Varchar(1000) = '',
@idUsuario int


AS
BEGIN
	SET NOCOUNT ON;	
	INSERT INTO [DB_RRHH].[dbo].SIC_Documentos
		SELECT		@idTipoDeDocumento	as IdTipoDeDocumento
				   ,@numero				as Numero
				   ,@idCategoria		as IdCategoria
				   ,@idAreaOrigen		as IdAreaOrigen
				   ,@extracto			as Extracto
				   ,@ticket				as Ticket
				   ,@idAreaDestino		as IdAreaDestino
				   ,@comentarios		as Comentarios
				   ,@idUsuario			as IdUsuario
				   ,GETDATE()			as Fecha
	SELECT @@IDENTITY	
END