CREATE PROCEDURE [dbo].[CV_Upd_Domicilio]
(
	@idDomicilio [int],
	@Dni [int],
	@DomicilioCalle [varchar](50),
	@DomicilioNumero [int] ,
	@DomicilioPiso [varchar](50) = null,
	@DomicilioDepto [varchar](50) = null,
	@DomicilioCp [smallint] = null,
	@DomicilioLocalidad [int] ,
	@DomicilioProvincia [smallint],
	@DomicilioTipo [smallint],
	@DomicilioTelefono varchar(20) = null,
    @DomicilioCorreo_Electronico varchar(50) = null,
    @Usuario smallint = null,
    @Correo_Electronico_MDS varchar(50) = null,
    @DomicilioTelefono2 varchar(50) = null
	
)

AS

BEGIN

	--Insert el domicilio  en Gen_Domicilios y capturar el id
	UPDATE [dbo].[GEN_Domicilios]
		SET Calle = @DomicilioCalle,
			Número = @DomicilioNumero,
			Piso = @DomicilioPiso,
			Dpto = @DomicilioDepto,
			Codigo_Postal = @DomicilioCp,
			Localidad = @DomicilioLocalidad,
			Provincia = @DomicilioProvincia,
			Telefono = @DomicilioTelefono,
			Correo_Electronico = @DomicilioCorreo_Electronico,
			Correo_Electronico_MDS = @Correo_Electronico_MDS,
			Telefono2 = Telefono2
		WHERE ID_Domicilio = @idDomicilio
	
END