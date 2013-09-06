CREATE TRIGGER MODI_TrgTablaCategoriasAsignadasADocumentoActualizada ON [dbo].[MODI_CategoriasAsignadasADocumentos] 
FOR UPDATE, INSERT
AS	
	if exists(SELECT * FROM deleted)
	begin
		INSERT INTO dbo.[MODI_CategoriasAsignadasADocumento_Log]
		SELECT	u.id as id_registro_actualizado, u.id_categoria, u.id_documento, u.tabla, u.id_usuario_ultima_modificacion, u.fecha_ultima_modificacion
		FROM	deleted u	 
    end else begin
		INSERT INTO dbo.[MODI_CategoriasAsignadasADocumento_Log]
		SELECT	i.id as id_registro_actualizado, i.id_categoria, i.id_documento, i.tabla, i.id_usuario_ultima_modificacion, i.fecha_ultima_modificacion
		FROM	INSERTED i	
    end
GO