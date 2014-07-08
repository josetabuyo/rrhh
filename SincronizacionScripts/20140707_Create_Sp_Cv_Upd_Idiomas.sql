Create Procedure dbo.CV_Upd_Idiomas
@IdIdioma int,
@Diploma varchar(100)=null,
@Establecimiento  varchar(100)=null,
@Idioma varchar(50)=null,
@Escritura varchar(50)=null,
@Lectura varchar(50)=null,
@Oral varchar(50)=null,
@FechaObtencion datetime=null,
@FechaFin datetime=null,
@Localidad varchar(100)=null,
@Pais varchar(100)=null,
@Usuario int=null,
@Baja int=null

AS

BEGIN

declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp  

UPDATE dbo.CV_Idiomas
   SET Diploma = isnull(@Diploma,Diploma), 
      Establecimiento = isnull(@Establecimiento,Establecimiento), 
      Idioma = isnull(@Idioma,Idioma),
      Escritura = isnull(@Escritura, Escritura),
      Lectura = isnull(@Lectura,Lectura),
      Oral = isnull(@Oral,Oral), 
      FechaObtencion = isnull(@FechaObtencion,FechaObtencion), 
      FechaFin = isnull(@FechaFin,FechaFin),
      Localidad = isnull(@Localidad,Localidad),
      Pais = isnull(@Pais,Pais),
      Usuario = isnull(@Usuario,Usuario), 
      FechaOperacion =getdate(),
      Baja = isnull(@Baja,Baja)
     WHERE id = @IdIdioma


END
