CREATE procedure[dbo].[MAU_AsignarAreaAUsuario]
	@id_usuario int,
	@id_area int
AS

BEGIN
	INSERT INTO RH_Usuarios_Areas_Web (id_usuario, id_area, baja)
	values(@id_usuario, @id_area, 0)
end



