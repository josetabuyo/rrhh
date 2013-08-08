USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MODI_Agregar_Imagen_Sin_Asignar_A_Un_Legajo]
	@legajo int,
	@nombre_imagen varchar(50),
	@bytes_imagen text
AS

BEGIN
	INSERT INTO		dbo.MODI_Imagenes
					(legajo, 
					nombre_imagen, 
					bytes_imagen)
	VALUES			(@legajo, 
					@nombre_imagen, 
					@bytes_imagen)	
	
	SELECT @@IDENTITY as "id_imagen"
END
GO
