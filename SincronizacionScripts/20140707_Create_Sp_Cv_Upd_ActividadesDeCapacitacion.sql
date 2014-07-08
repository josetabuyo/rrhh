Create procedure dbo.Cv_Upd_ActividadesDeCapacitacion
@IdActividadDeCapacitacion int=NULL,
@Titulo varchar(100)=NULL,
@Establecimiento varchar(100)=NULL,
@Especialidad varchar(100)=NULL,
@Duracion varchar(50)=NULL,
@FechaIngreso datetime=NULL,
@FechaEgreso datetime=NULL,
@Localidad varchar(100)=NULL,
@Pais varchar(100)=NULL,
@Usuario int,
--@FechaOperacion datetime=NULL,
@Baja int=NULL

AS


BEGIN

declare @NombreSp varchar(60) 
	set @NombreSp = (select OBJECT_NAME(@@PROCID))
	exec dbo.Audit @NombreSp  


UPDATE dbo.CV_ActividadesDeCapacitacion
   SET Titulo = isnull(@Titulo,Titulo),
      Establecimiento = isnull(@Establecimiento,Establecimiento), 
      Especialidad = isnull(@Especialidad,Especialidad),
      Duracion = isnull(@Duracion,Duracion), 
      FechaIngreso = isnull(@FechaIngreso,FechaIngreso),
      FechaEgreso = isnull(@FechaEgreso,FechaEgreso),
      Localidad = isnull(@Localidad,Localidad), 
      Pais = isnull(@Pais,Pais),
      Usuario = isnull(@Usuario,Usuario),
      FechaOperacion = getdate(),
      Baja = isnull(@Baja,Baja)
      WHERE Id=@IdActividadDeCapacitacion


END


