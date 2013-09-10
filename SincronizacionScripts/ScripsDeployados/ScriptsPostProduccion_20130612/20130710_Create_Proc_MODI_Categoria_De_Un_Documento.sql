USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MODI_Categoria_De_Un_Documento]
	@tabla varchar(50),
	@id_documento int
AS

BEGIN	
	SELECT  id_categoria
	FROM	dbo.MODI_CategoriasAsignadasADocumentos   
	WHERE	id_documento=@id_documento AND
			tabla=@tabla  
END
GO

