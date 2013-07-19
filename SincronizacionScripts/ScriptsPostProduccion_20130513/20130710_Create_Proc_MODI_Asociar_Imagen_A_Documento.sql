USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MODI_Asignar_Imagen_A_Un_Documento]
	@id_imagen int,
	@tabla varchar(50),
	@id_documento int
AS

BEGIN
	UPDATE dbo.MODI_Imagenes 
	SET id_documento=@id_documento,
		tabla=@tabla
	WHERE id_imagen=@id_imagen
END
GO

