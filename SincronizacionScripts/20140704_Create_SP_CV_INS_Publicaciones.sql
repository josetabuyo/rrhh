Create Procedure dbo.CV_Ins_Publicaciones
@CantidadHojas varchar(100),
@DatosEditorial varchar(100),
@DisponeCopia bit,
@Titulo varchar(100),
@FechaPublicacion datetime,
@Usuario int,
--@FechaOperacion datetime,
@Baja int,
@Documento int

as

BEGIN


declare @NombreSp varchar(60)   
 set @NombreSp = (select OBJECT_NAME(@@PROCID))  
 exec dbo.Audit @NombreSp  

declare @IdPersona int  
  
select @IdPersona = Id from dbo.DatosPersonales where NroDocumento = @Documento  

INSERT INTO [dbo].[CV_Publicaciones]
           ([CantidadHojas]
           ,[DatosEditorial]
           ,[DisponeCopia]
           ,[Titulo]
           ,[FechaPublicacion]
           ,[Usuario]
           ,[FechaOperacion]
           ,[Baja]
           ,[IdPersona])
     VALUES
           (@CantidadHojas,
           @DatosEditorial,
           @DisponeCopia,
           @Titulo,
           @FechaPublicacion, 
           @Usuario,
          getdate(),
           @Baja,
           @IdPersona)

END