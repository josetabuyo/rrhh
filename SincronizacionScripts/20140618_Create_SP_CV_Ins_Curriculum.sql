
CREATE PROCEDURE [dbo].[CV_Ins_Curriculum]
(	
	@Dni [int],
	@usuario [smallint] = null	
) 

AS

--declare @NombreSp varchar(60) 
--set @NombreSp = (select OBJECT_NAME(@@PROCID))
--exec dbo.Audit @NombreSp

 declare @idDatosPersonales int
 set @idDatosPersonales = (SELECT Id FROM DatosPersonales WHERE NroDocumento= @Dni) 
 
 --Insert en CV_DatosPersonales para filtrar
INSERT INTO [dbo].[CV_DatosPersonales]
	(IdPersona)
VALUES 
	(@idDatosPersonales)