CREATE PROCEDURE [dbo].[CV_Upd_ActividadesAcademicas]
(
	@idAntecedente [int], 
	@Titulo varchar(100) = null,
	@Establecimiento varchar(100) = null,
	@Especialidad varchar(100) = null,
	@FechaIngreso[datetime] = null,
	@FechaEgreso[datetime] = null,
	@Localidad varchar(100) = null,
	@Pais varchar(100) = null,
	@Usuario[int]

)

AS

BEGIN
UPDATE [dbo].[CV_AntecedentesAcademicos]
SET 
	Titulo = @Titulo,
	Establecimiento = @Establecimiento,
	Especialidad = @Especialidad,
	FechaIngreso = @FechaIngreso,
	FechaEgreso = @FechaEgreso,
	Localidad = @Localidad,
	Pais = @Pais,
	Usuario = @Usuario,
	FechaOperacion = GETDATE()
WHERE
	Id = @idAntecedente

	
END