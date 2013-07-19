USE [DB_RRHH]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[MODI_Get_Ids_De_Imagenes_Sin_Asignar_Para_El_Legajo]
	@legajo INT
AS

BEGIN
	SELECT		I.id_imagen
		FROM	dbo.MODI_Imagenes I
		WHERE	I.legajo = @legajo AND
				I.tabla is NULL AND
				I.id_documento is NULL
END
GO

