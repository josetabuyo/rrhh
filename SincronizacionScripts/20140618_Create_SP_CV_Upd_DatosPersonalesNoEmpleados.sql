
CREATE PROCEDURE [dbo].[CV_Upd_DatosPersonalesNoEmpleados]
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
 
	--Si el usuario no es del ministerio y ya cargo un CV
 	--UPDATE de datos personales
    UPDATE DatosPersonales 
		SET  TipoDocumento = @TipoDocumento,
			 NroDocumento = @Dni,
			 Apellido = @Apellido,
			 Nombre = @Nombre,
			 FechaNacimiento = @FechaNacimiento	 
		WHERE NroDocumento=@Dni
	

	--Update en DatosPersonalesAdicionales (sexo, estado civil, etc)
	UPDATE DatosPersonalesAdicionales
			SET  IdSexo = @Sexo,
				 IdEstadoCivil = @EstadoCivil,
				 LugarNacimiento = @LugarDeNacimiento,
				 IdNacionalidad = @Nacionalidad,
				 CUIL = @Cuil	
			WHERE IdPersona = @idDatosPersonales
		
COMMIT TRAN