USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MODI_Asignar_Imagen_A_Folio_De_Legajo]
	@id_imagen int,
	@nro_folio int,
	@id_usuario int
AS

BEGIN
	UPDATE dbo.MODI_Imagenes 
	SET nro_folio=@nro_folio,
		id_usuario_ultima_modificacion=@id_usuario,
		fecha_ultima_modificacion= GETDATE()
	WHERE id_imagen=@id_imagen
END
GO

