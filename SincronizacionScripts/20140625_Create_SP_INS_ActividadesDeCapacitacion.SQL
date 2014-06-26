Create procedure dbo.CV_Ins_ActividadesDeCapacitacion
@Titulo varchar(100) = null,
@Establecimiento varchar(100) = null,
@Especialidad varchar(100) = null,
@Duracion varchar(50) = null,
@FechaIngreso datetime = null,
@FechaEgreso datetime= null,
@Localidad varchar(100)= null,
@Pais varchar(100)= null,
@Usuario int,
--@FechaOperacion datetime = null,
@Baja int= null

AS

Begin


INSERT INTO [dbo].[CV_ActividadesDeCapacitacion]
           ([Titulo]
           ,[Establecimiento]
           ,[Especialidad]
           ,[Duracion]
           ,[FechaIngreso]
           ,[FechaEgreso]
           ,[Localidad]
           ,[Pais]
           ,[Usuario]
           ,[FechaOperacion]
           ,[Baja])
     VALUES
           (
            @Titulo,
	    @Establecimiento,
	    @Especialidad,
	    @Duracion,
	    @FechaIngreso,
	    @FechaEgreso,
	    @Localidad,
            @Pais,
	    @Usuario,
	    getdate(),
	    @Baja
	)

END











