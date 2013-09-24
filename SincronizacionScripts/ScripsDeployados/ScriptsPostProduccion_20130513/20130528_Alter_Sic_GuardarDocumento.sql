ALTER PROCEDURE [dbo].[SIC_GuardarDocumento]
@idTipoDeDocumento int,
@numero Varchar(50),
@idCategoria int,
@idAreaOrigen int = null,
@extracto Varchar(1000),
@ticket Varchar(6),
@idAreaDestino int = null,
@comentarios Varchar(1000) = '',
@idUsuario int,
@Fecha_documento Datetime = null

AS
BEGIN
	SET NOCOUNT ON;	
	INSERT INTO [DB_RRHH].[dbo].SIC_Documentos
		SELECT		@idTipoDeDocumento	as IdTipoDeDocumento
				   ,@numero				as Numero
				   ,@idCategoria		as IdCategoria
				   ,@extracto			as Extracto
				   ,@ticket				as Ticket
				   ,@comentarios		as Comentarios
				   ,@idUsuario			as IdUsuario
				   ,GETDATE()			as Fecha
				   ,@Fecha_documento    as FechaDocumento
	SELECT @@IDENTITY	
END


