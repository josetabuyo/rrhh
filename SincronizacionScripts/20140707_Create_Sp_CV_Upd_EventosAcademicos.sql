Create Procedure dbo.Cv_Upd_Del_EventosAcademicos
@IdEvento int = null,
@Denominacion varchar(100)=null,
@TipoDeEvento  varchar(100)=null,
@CaracterDeParticipacion varchar(100)=null,
@FechaInicio  datetime=null,
@FechaFin datetime=null,
@Duracion varchar(50)=null,
@Institucion varchar(100)=null,
@Localidad varchar(100)=null,
@Pais varchar(100)=null,
@Usuario int=null,
@Baja int=null

AS

Begin

declare @NombreSp varchar(60) 
	set @NombreSp = (select OBJECT_NAME(@@PROCID))
	exec dbo.Audit @NombreSp  

UPDATE [dbo].[CV_EventosAcademicos]
   SET Denominacion = isnull(@Denominacion, Denominacion),
      TipoDeEvento = isnull(@TipoDeEvento,TipoDeEvento),
      CaracterDeParticipacion = isnull(@CaracterDeParticipacion,CaracterDeParticipacion),
      FechaInicio = isnull(@FechaInicio,FechaInicio), 
      FechaFin = isnull(@FechaFin,FechaFin),
      Duracion = isnull(@Duracion,Duracion), 
      Institucion = isnull(@Institucion,Institucion), 
      Localidad = isnull(@Localidad,Localidad),
      Pais = isnull(@Pais,Pais), 
      Usuario = isnull(@Usuario,Usuario), 
      FechaOperacion =getdate(),
      Baja = isnull(@Baja,Baja)
 WHERE id = @IdEvento


END



