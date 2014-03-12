CREATE Procedure dbo.MAU_CrearUsuario
@id_persona int,
@alias char(15),
@clave_encriptada varchar(60)
as

BEGIN TRAN --creando_usuario
declare @id_usuario int 
select @id_usuario = max(id)+1 FROM dbo.RH_Usuarios

insert into dbo.RH_Usuarios(Id, Nombre, Password, Vence_Passw, Baja, Actualizar_Passw, Administrador, IdPersona)
values(@id_usuario, @alias,'usuario web', '2015-12-12 00:00:00',0, 1, 0, @id_persona)

insert into dbo.web_passwords(IdUsuario, Password)
values(@id_usuario, @clave_encriptada)

COMMIT TRAN --creando_usuario

SELECT @Id_Usuario as Id_Usuario

