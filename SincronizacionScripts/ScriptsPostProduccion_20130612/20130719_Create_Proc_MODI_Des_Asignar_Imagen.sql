USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MODI_Des_Asignar_Imagen]
	@id_imagen int
AS

BEGIN
	UPDATE dbo.MODI_Imagenes 
	SET id_documento=NULL,
		tabla=NULL
	WHERE id_imagen=@id_imagen
END
GO

