CREATE PROCEDURE [dbo].[SIC_ActualizarDocumentos]
@idDocumento int,
@idTipoDeDocumento int = null,
@numero Varchar(50) = null,
@idCategoria int = null,
@idAreaOrigen int = null,
@extracto Varchar(1000) = null,
@ticket Varchar(6) = null,
@idAreaDestino int = null,
@comentarios Varchar(1000) = '',
@idUsuario int,
@Fecha datetime = null

AS

UPDATE 
	dbo.SIC_Documentos
SET 
	IdTipoDeDocumento = @idTipoDeDocumento,
	Numero = @numero,
	idCategoria = @idCategoria,
	IdAreaOrigen = @IdAreaOrigen,
	Extracto = @extracto,
	Ticket = @ticket,
	IdAreaDestino = @idAreaDestino,
	Comentarios = @comentarios,	
	IdUsuario = @IdUsuario, 
	Fecha = @Fecha
WHERE 
	Id = @idDocumento
	
SELECT @@IDENTITY	