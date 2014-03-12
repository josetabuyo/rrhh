CREATE PROCEDURE [dbo].[MAU_GuardarUsuario]
    @id int,
	@alias char(15) = NULL,
	@clave_encriptada varchar(60) = NULL
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN
    
    UPDATE dbo.RH_Usuarios
    SET Nombre=ISNULL(@alias,Nombre)
    WHERE id=@id
    
    UPDATE dbo.web_passwords
    SET Password=ISNULL(@clave_encriptada,Password)
    WHERE idUsuario=@id
    COMMIT TRAN 
END

