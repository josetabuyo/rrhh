USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MODI_Asignar_Imagen_A_Documento]
	@tabla varchar(50),
	@id BIGINT,
	@nombre_imagen varchar(50),
	@bytes_imagen text
AS

BEGIN
	INSERT INTO		dbo.MODI_ImagenesAsignadasADocumento 
					(idDocumento, 
					tabla, 
					nombre_imagen, 
					bytes_imagen)
	VALUES			(@id, 
					@tabla, 
					@nombre_imagen, 
					@bytes_imagen)	
END
GO

