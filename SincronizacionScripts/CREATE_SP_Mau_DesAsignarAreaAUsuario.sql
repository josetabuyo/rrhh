CREATE procedure[dbo].[MAU_DesAsignarAreaAUsuario]
	@id_usuario int,
	@id_area int
AS

BEGIN
	DELETE	RH_Usuarios_Areas_Web
	WHERE	id_usuario = @id_usuario AND
			id_area = @id_area
end



