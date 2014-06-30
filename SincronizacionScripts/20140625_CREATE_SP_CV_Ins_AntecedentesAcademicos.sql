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
	@Baja [int]  = null

)

AS

BEGIN
	
	INSERT INTO [dbo].[CV_AntecedentesAcademicos]
		(Titulo, Establecimiento, Especialidad, FechaIngreso, FechaEgreso, Localidad, Pais,Usuario,FechaOperacion,Baja )
	VALUES 
		(@Titulo, @Establecimiento,@Especialidad,@FechaIngreso, @FechaEgreso,@Localidad,@Pais,@Usuario,GETDATE(),@Baja )
	
END