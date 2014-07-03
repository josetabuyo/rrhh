Create Procedure dbo.CV_Ins_Idiomas
@Diploma varchar(100)=null,
@Establecimiento varchar(100)=null,
@Idioma varchar(50)=null,
@Escritura varchar(50)=null,
@Lectura varchar(50)=null,
@Oral varchar(50)=null,
@FechaObtencion datetime=null,
@FechaFin datetime=null,
@Localidad varchar(100)=null,
@Pais varchar(100)=null,
@Usuario int=null,
--@FechaOperacion datetime=null,
@Baja int=null,
@Documento int=null
AS

BEGIN

declare @IdPersona int
select @IdPersona = id from dbo.datospersonales where nrodocumento = @Documento

INSERT INTO [dbo].[CV_Idiomas]
           ([Diploma]
           ,[Establecimiento]
           ,[Idioma]
           ,[Escritura]
           ,[Lectura]
           ,[Oral]
           ,[FechaObtencion]
           ,[FechaFin]
           ,[Localidad]
           ,[Pais]
           ,[Usuario]
           ,[FechaOperacion]
           ,[Baja]
           ,[IdPersona])
     VALUES
          (@Diploma,
           @Establecimiento,
           @Idioma,
           @Escritura,
           @Lectura,
           @Oral,
           @FechaObtencion,
           @FechaFin, 
           @Localidad,
           @Pais, 
           @Usuario,
           getdate(),
           @Baja,
           @IdPersona
           )


END


