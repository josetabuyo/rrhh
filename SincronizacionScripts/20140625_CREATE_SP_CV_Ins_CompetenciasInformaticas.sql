
CREATE PROCEDURE [dbo].[CV_Ins_CompetenciasInformaticas]
(
	@Diploma varchar(100) = null,
	@Establecimiento varchar(100) = null,
	@FechaObtencion[datetime] = null,
	@TipoInformatica varchar(100) = null,
	@Conocimiento varchar(100) = null,
	@Nivel varchar(50)  = null,
	@Localidad varchar(100)  = null,
	@Pais varchar(100)  = null,
	@Usuario[int], 
	@Baja [int]  = null

)

AS

BEGIN
	
	INSERT INTO [dbo].[CV_CompetenciasInformaticas]
		(Diploma, Establecimiento, FechaObtencion, TipoInformatica, Conocimiento,Nivel,Localidad, Pais,Usuario,FechaOperacion,Baja )
	VALUES 
		(@Diploma, @Establecimiento,@FechaObtencion,@TipoInformatica, @Conocimiento,@Nivel,@Localidad,@Pais,@Usuario,GETDATE(),@Baja )
	
END