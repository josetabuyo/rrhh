CREATE PROCEDURE [dbo].[CV_Upd_Del_ActividadesAcademicas]
(
	@idAntecedente [int], 
	@Titulo varchar(100) = null,
	@Nivel varchar(100) = null,
	@Establecimiento varchar(100) = null,
	@Especialidad varchar(100) = null,
	@FechaIngreso[datetime] = null,
	@FechaEgreso[datetime] = null,
	@Localidad varchar(100) = null,
	@Pais varchar(100) = null,
	@Usuario[int],
	@idBaja [int] = null
)

AS

BEGIN

	declare @NombreSp varchar(60) 
	set @NombreSp = (select OBJECT_NAME(@@PROCID))
	exec dbo.Audit @NombreSp  

	UPDATE [dbo].[CV_AntecedentesAcademicos]
	SET 
		Titulo = ISNULL(@Titulo,Titulo),
		Nivel = ISNULL(@Nivel,Nivel),
		Establecimiento = ISNULL(@Establecimiento,Establecimiento),
		Especialidad = ISNULL(@Especialidad,Especialidad),
		FechaIngreso = ISNULL(@FechaIngreso,FechaIngreso),
		FechaEgreso = ISNULL(@FechaEgreso,FechaEgreso),
		Localidad = ISNULL(@Localidad,Localidad),
		Pais = ISNULL(@Pais,Pais),
		Usuario = @Usuario,
		FechaOperacion = GETDATE(),
		Baja = ISNULL(@idBaja, Baja)	
	WHERE
		Id = @idAntecedente
	
	
END