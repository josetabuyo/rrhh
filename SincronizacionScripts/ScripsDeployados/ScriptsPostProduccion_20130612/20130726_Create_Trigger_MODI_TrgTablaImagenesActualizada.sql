CREATE TRIGGER MODI_TrgTablaImagenesActualizada ON [dbo].[MODI_Imagenes] 
FOR UPDATE
AS
	INSERT INTO dbo.MODI_Imagenes_Log
	SELECT	i.id_imagen, i.legajo, i.id_documento, i.tabla, i.nombre_imagen, i.id_usuario_ultima_modificacion, i.fecha_ultima_modificacion
	FROM	INSERTED i
GO