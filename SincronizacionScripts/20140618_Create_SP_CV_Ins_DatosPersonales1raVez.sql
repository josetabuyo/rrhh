
CREATE PROCEDURE [dbo].[CV_Ins_DatosPersonalesNoEmpleados1ravez]
(	

@Dni [int],
@Apellido [varchar](100),
@Nombre [varchar](100),
@Cuil [varchar](15),
@EstadoCivil [smallint],
@FechaNacimiento [datetime],
@LugarDeNacimiento [varchar](50),
@TipoDocumento [smallint],
@Nacionalidad [smallint],
@Sexo [smallint],
@usuario [smallint] = null
	
) 

AS

--declare @NombreSp varchar(60) 
--set @NombreSp = (select OBJECT_NAME(@@PROCID))
--exec dbo.Audit @NombreSp

BEGIN TRANSACTION
 declare @idDatosPersonales int
 set @idDatosPersonales = (SELECT Id FROM DatosPersonales WHERE NroDocumento= @Dni) 
 
	--Si el usuario no es del ministerio y es la primera vez que carga el CV
 	--UPDATE de datos personales
    UPDATE DatosPersonales 
		SET  TipoDocumento = @TipoDocumento,
			 NroDocumento = @Dni,
			 Apellido = @Apellido,
			 Nombre = @Nombre,
			 FechaNacimiento = @FechaNacimiento	 
		WHERE NroDocumento=@Dni
	

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
	

COMMIT TRAN