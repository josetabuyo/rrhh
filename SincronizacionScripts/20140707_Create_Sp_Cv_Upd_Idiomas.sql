CREATE PROCEDURE [dbo].[CV_Upd_Del_Idiomas]
(
	@idIdioma [int], 
	@Diploma varchar(100) = null,
	@Idioma varchar(50) = null,
	@Establecimiento varchar(100) = null,
	@Escritura varchar(50) = null,
	@Lectura varchar(50) = null,
	@Oral varchar(50) = null,
	@FechaObtencion[datetime] = null,
	@FechaFin[datetime] = null,
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

	UPDATE [dbo].[CV_Idiomas]
	SET 
		Diploma = ISNULL(@Diploma,Diploma),
		Idioma = ISNULL(@Idioma,Idioma),
		Establecimiento = ISNULL(@Establecimiento,Establecimiento),
		Escritura = ISNULL(@Escritura,Escritura),
		Lectura = ISNULL(@Lectura,Lectura),
		Oral = ISNULL(@Oral,Oral),
		FechaObtencion = ISNULL(@FechaObtencion,FechaObtencion),
		FechaFin = ISNULL(@FechaFin,FechaFin),
		Localidad = ISNULL(@Localidad,Localidad),
		Pais = ISNULL(@Pais,Pais),
		Usuario = @Usuario,
		FechaOperacion = GETDATE(),
		Baja = ISNULL(@idBaja, Baja)	
	WHERE
		Id = @idIdioma
	
	
END