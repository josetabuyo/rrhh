USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[MODI_Asignar_Imagen_A_Un_Documento]
	@id_imagen int,
	@tabla varchar(50),
	@orden float,
	@id_documento int,
	@id_usuario int
AS

BEGIN
	UPDATE dbo.MODI_Imagenes 
	SET id_documento=@id_documento,
		orden=@orden,
		tabla=@tabla,
		id_usuario_ultima_modificacion=@id_usuario,
		fecha_ultima_modificacion= GETDATE()
	WHERE id_imagen=@id_imagen
END
GO

