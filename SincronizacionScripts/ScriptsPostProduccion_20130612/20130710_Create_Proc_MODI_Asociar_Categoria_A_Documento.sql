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
	begin tran
		UPDATE dbo.MODI_CategoriasAsignadasADocumentos
		SET id_categoria=@id_categoria	   
		WHERE	id_documento=@id_documento AND
				tabla=@tabla
	   if @@rowcount = 0
	   begin
		  insert dbo.MODI_CategoriasAsignadasADocumentos(id_categoria, id_documento, tabla) values (@id_categoria,@id_documento,@tabla)
	   end
	commit tran
END
GO

