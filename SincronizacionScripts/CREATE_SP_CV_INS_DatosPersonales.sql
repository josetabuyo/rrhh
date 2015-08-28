
CREATE PROCEDURE [dbo].[CV_Ins_DatosPersonales]
(	

@Dni [int] ,
@Apellido [varchar](100),
@Nombre [varchar](100),
@Cuil [varchar](15),
@EstadoCivil [smallint],
@FechaNacimiento [datetime],
@LugarDeNacimiento [varchar](50),
@TipoDocumento [smallint],
@Nacionalidad [smallint],
@Sexo [smallint],

@DomicilioPersonalCalle [varchar](50),
@DomicilioPersonalNumero [int] ,
@DomicilioPersonalPiso [varchar](50),
@DomicilioPersonalDepto [varchar](50),
@DomicilioPersonalCp [smallint],
@DomicilioPersonalLocalidad [int] ,
@DomicilioPersonalProvincia [smallint],
@DomicilioPersonalTipo [smallint],

@DomicilioLegalCalle [varchar](50),
@DomicilioLegalNumero [int] ,
@DomicilioLegalPiso [varchar](50),
@DomicilioLegalDepto [varchar](50),
@DomicilioLegalCp [smallint],
@DomicilioLegalLocalidad [int] ,
@DomicilioLegalProvincia [smallint],
@DomicilioLegalTipo [smallint]
	
) 

AS

--declare @NombreSp varchar(60) 
--set @NombreSp = (select OBJECT_NAME(@@PROCID))
--exec dbo.Audit @NombreSp

BEGIN TRANSACTION
 
--Insert en DatosPersonales para conseguir el id  
INSERT INTO [dbo].[DatosPersonales]
	(TipoDocumento, NroDocumento, Apellido, Nombre, FechaNacimiento )
VALUES
	(@TipoDocumento, @Dni, @Apellido, @Nombre,  @FechaNacimiento)
	
declare @idDatosPersonales int
set @idDatosPersonales = (SELECT SCOPE_IDENTITY())

--Insert en DatosPersonalesAdicionales (sexo, estado civil, etc)
INSERT INTO [dbo].[DatosPersonalesAdicionales]
	(IdPersona, IdSexo, IdEstadoCivil, LugarNacimiento, IdNacionalidad, CUIL)
VALUES 
	(@idDatosPersonales,@Sexo,@EstadoCivil,@LugarDeNacimiento,@Nacionalidad,@Cuil )

--Insert en CV_DatosPersonales para filtrar
INSERT INTO [dbo].[CV_DatosPersonales]
	(IdPersona)
VALUES 
	(@idDatosPersonales)
	
--Insert el domicilio personal en Gen_Domicilios y capturar el id
INSERT INTO [dbo].[GEN_Domicilios]
	(Calle, Número, Piso, Dpto,Codigo_Postal,Localidad, Provincia )
VALUES 
	(@DomicilioPersonalCalle,@DomicilioPersonalNumero,@DomicilioPersonalPiso, @DomicilioPersonalDepto,@DomicilioPersonalCp,@DomicilioPersonalLocalidad,@DomicilioPersonalProvincia )

declare @idDomicilioPersonal int
set @idDomicilioPersonal = (SELECT SCOPE_IDENTITY())


--Insert el domicilio laboral en Gen_Domicilios y capturar el id
INSERT INTO [dbo].[GEN_Domicilios]
	(Calle, Número, Piso, Dpto,Codigo_Postal,Localidad, Provincia )
VALUES 
	(@DomicilioLegalCalle,@DomicilioLegalNumero,@DomicilioLegalPiso, @DomicilioLegalDepto,@DomicilioLegalCp,@DomicilioLegalLocalidad,@DomicilioLegalProvincia )

declare @idDomicilioLegal int
set @idDomicilioLegal = (SELECT SCOPE_IDENTITY())

--Insert ambos domicilios en CV_Domicilios para filtrar los domicilios que vienen por CV
INSERT INTO [dbo].[CV_Domicilios]
	(ID_Domicilio, Tipo, IdPersona)
VALUES 
	(@idDomicilioPersonal,@DomicilioPersonalTipo,@idDatosPersonales )
	
INSERT INTO [dbo].[CV_Domicilios]
	(ID_Domicilio, Tipo, IdPersona)
VALUES 
	(@DomicilioLegalCalle, @DomicilioLegalTipo, @idDatosPersonales )
	
COMMIT TRAN