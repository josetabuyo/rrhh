USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MODI_Get_Imagen]
	@id_imagen int
AS

BEGIN
	SELECT	nombre_imagen, 
			bytes_imagen	 
	FROM	dbo.MODI_Imagenes 
	WHERE id_imagen=@id_imagen
END
GO

