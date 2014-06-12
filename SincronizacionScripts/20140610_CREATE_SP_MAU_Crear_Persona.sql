USE [DB_RRHH]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].MAU_CrearPersona
    @tipoDocumento int,
	@documento int,
	@nombre varchar(100),
	@apellido varchar(100)
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRAN
   
	INSERT INTO dbo.datosPersonales(TipoDocumento,NroDocumento,Apellido,Nombre)
	VALUES(@tipoDocumento, @documento,@apellido, @nombre)
    SELECT @@IDENTITY
    
    COMMIT TRAN 
END

