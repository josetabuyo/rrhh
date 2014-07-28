CREATE PROCEDURE [dbo].[CV_Ins_Domicilio]
(
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
	INSERT INTO [dbo].[GEN_Domicilios]
		(Calle, Número, Piso, Dpto,Codigo_Postal,Localidad, Provincia,Telefono,Correo_Electronico,Correo_Electronico_MDS,Telefono2 )
	VALUES 
		(@DomicilioCalle,@DomicilioNumero,@DomicilioPiso, @DomicilioDepto,@DomicilioCp,@DomicilioLocalidad,@DomicilioProvincia,@DomicilioTelefono,@DomicilioCorreo_Electronico,@Correo_Electronico_MDS,@DomicilioTelefono2 )

	declare @idDomicilio int
	--set @idDomicilio = (SELECT SCOPE_IDENTITY())
	set @idDomicilio = (select @@identity)

	declare @idDatosPersonales int
	set @idDatosPersonales = (SELECT Id FROM [DB_RRHH].[dbo].[DatosPersonales] WHERE NroDocumento = @Dni) 

	--Insert domicilio en CV_Domicilios para filtrar los domicilios que vienen por CV
	INSERT INTO [dbo].[CV_Domicilios]
		(ID_Domicilio, Tipo, IdPersona)
	VALUES 
		(@idDomicilio,@DomicilioTipo,@idDatosPersonales)
	
END