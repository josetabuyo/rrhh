USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MODI_Imagenes_De_Un_Legajo]
	@id_interna INT
AS

BEGIN
	SELECT		I.id_imagen,
				I.nro_folio
		FROM	dbo.MODI_Imagenes I
		WHERE	I.id_interna = @id_interna
END
GO

