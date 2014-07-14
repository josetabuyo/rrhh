Create Procedure dbo.CV_Upd_Del_CompetenciasInformaticas
@IdCompetencia int = null,
@Diploma varchar(100)=null,
@Establecimiento varchar(100)=null,
@FechaObtencion datetime=null,
@TipoInformatica varchar(100)=null,
@Conocimiento varchar(100)=null,
@Nivel varchar(50)=null,
@Localidad varchar(100)=null,
@Pais varchar(100)=null,
@Usuario int=null,
@Baja int=null

AS

BEGIN

declare @NombreSp varchar(60) 
	set @NombreSp = (select OBJECT_NAME(@@PROCID))
	exec dbo.Audit @NombreSp  

UPDATE dbo.CV_CompetenciasInformaticas
   SET Diploma = isnull(@Diploma,Diploma), 
      Establecimiento = isnull(@Establecimiento,Establecimiento),
      FechaObtencion = isnull(@FechaObtencion,FechaObtencion), 
      TipoInformatica = isnull(@TipoInformatica,TipoInformatica), 
      Conocimiento = isnull(@Conocimiento,Conocimiento), 
      Nivel = isnull(@Nivel,Nivel),
      Localidad = isnull(@Localidad,Localidad),
      Pais = isnull(@Pais,Pais), 
      Usuario = isnull(@Usuario,Usuario),
      FechaOperacion = getdate(),
      Baja = isnull(@Baja,Baja)
      
 WHERE id=@IdCompetencia

END



