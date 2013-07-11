USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MODI_Imagenes_Asignadas_A_Documento]
	@tabla varchar(50),
	@id INT
AS

BEGIN
	SELECT		I.nombre_imagen,
				I.bytes_imagen
		FROM	dbo.MODI_ImagenesAsignadasADocumento I
		WHERE	I.tabla = @tabla AND
				I.idDocumento = @id

END
GO

