CREATE PROCEDURE [dbo].[CV_Ins_AntecedentesAcademicos]
(
	@Titulo varchar(100) = null,
	@Establecimiento varchar(100) = null,
	@Especialidad varchar(100) = null,
	@FechaIngreso[datetime] = null,
	@FechaEgreso[datetime] = null,
	@Localidad varchar(100) = null,
	@Pais varchar(100)  = null,
	@Usuario[int], 
	@Baja [int]  = null,
	@Dni [int]

)

AS

BEGIN
	
	declare @idDatosPersonales int
	set @idDatosPersonales = (SELECT Id FROM [DB_RRHH].[dbo].[DatosPersonales] WHERE NroDocumento = @Dni) 
	
	INSERT INTO [dbo].[CV_AntecedentesAcademicos]
		(Titulo, Establecimiento, Especialidad, FechaIngreso, FechaEgreso, Localidad, Pais,Usuario,FechaOperacion,Baja,IdPersona )
	VALUES 
		(@Titulo, @Establecimiento,@Especialidad,@FechaIngreso, @FechaEgreso,@Localidad,@Pais,@Usuario,GETDATE(),@Baja,@idDatosPersonales )
	
	SELECT SCOPE_IDENTITY()
	
END