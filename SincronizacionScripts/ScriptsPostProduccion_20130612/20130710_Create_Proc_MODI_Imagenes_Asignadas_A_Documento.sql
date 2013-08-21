USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[MODI_Imagenes_Asignadas_A_Un_Documento]
	@tabla varchar(50),
	@id_documento INT
AS

BEGIN
	SELECT		I.id_imagen,
				I.orden
		FROM	dbo.MODI_Imagenes I
		WHERE	I.tabla = @tabla AND
				I.id_documento = @id_documento
END
GO

