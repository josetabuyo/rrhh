CREATE PROCEDURE [dbo].[MAU_GuardarUsuario]
    @id int,
	@alias char(15) = NULL,
	@clave_encriptada varchar(60) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE dbo.RH_Usuarios
    SET Nombre=ISNULL(@alias,Nombre), 
        Password=ISNULL(@clave_encriptada,Password)
    WHERE id=@id
END