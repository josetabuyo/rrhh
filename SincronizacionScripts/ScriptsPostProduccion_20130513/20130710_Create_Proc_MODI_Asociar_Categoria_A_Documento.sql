USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MODI_Asignar_Categoria_A_Un_Documento]
	@id_categoria int,
	@tabla varchar(50),
	@id_documento int
AS

BEGIN
	UPDATE dbo.MODI_Categorias_Documentos 
	SET id_documento=@id_documento,
		tabla=@tabla
	WHERE id_imagen=@id_categoria
END
GO

