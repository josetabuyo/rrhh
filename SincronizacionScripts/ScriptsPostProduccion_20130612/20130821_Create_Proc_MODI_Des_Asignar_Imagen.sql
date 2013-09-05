USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MODI_Des_Asignar_Imagen]
	@id_imagen int,
	@id_usuario int
AS

BEGIN
	UPDATE dbo.MODI_Imagenes 
	SET nro_folio=NULL,		
		id_usuario_ultima_modificacion=@id_usuario,
		fecha_ultima_modificacion= GETDATE()
	WHERE id_imagen=@id_imagen
END
GO

