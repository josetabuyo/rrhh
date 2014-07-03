
CREATE procedure [dbo].[CV_Upd_AntecedentesDeDocencia]
@IdDocencia[int],
@Asignatura varchar(100) = null,
@CaracterDesignacion varchar(100)= null,
@CargaHoraria varchar(100)= null,
@CategoriaDocente varchar(100)= null,
@DedicacionDocente varchar(100)= null,
@Establecimiento varchar(100)= null,
@NivelEducativo varchar(100)= null,
@TipoActividad varchar(100)= null,
@FechaInicio datetime,
@FechaFinalizacion datetime,
@Localidad varchar(100)= null,
@Pais varchar(100)= null,
@Usuario int

AS

BEGIN

	UPDATE [dbo].[CV_Upd_AntecedentesDeDocencia]
	SET
		Asignatura = @Asignatura,
		CaracterDesignacion = @CaracterDesignacion,
		CargaHoraria = @CargaHoraria,
		CategoriaDocente = @CategoriaDocente,
		DedicacionDocente = @DedicacionDocente,
		Establecimiento = @Establecimiento,
		NivelEducativo = @NivelEducativo,
		TipoActividad = @TipoActividad,
		FechaInicio = @FechaInicio,
		FechaFinalizacion = @FechaFinalizacion,
		Localidad = @Localidad,
		Pais = @Pais,
		Usuario = @Usuario,
		FechaOperacion = GetDate()
	WHERE
		Id = @IdDocencia

END
