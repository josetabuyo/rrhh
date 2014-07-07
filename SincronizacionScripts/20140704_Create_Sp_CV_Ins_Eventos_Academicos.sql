Create Procedure dbo.CV_Ins_EventosAcademicos
@Documento int,
@Denominacion varchar(100),
@TipoDeEvento varchar(100),
@CaracterDeParticipacion varchar(100),
@FechaInicio datetime,
@FechaFin datetime,
@Duracion varchar(50),
@Institucion varchar(100),
@Localidad varchar(100),
@Pais varchar(100),
@Usuario int,
--@FechaOperacion, datetime,>
@Baja int=null
AS

BEGIN

 declare @NombreSp varchar(60)   
 set @NombreSp = (select OBJECT_NAME(@@PROCID))  
 exec dbo.Audit @NombreSp    

declare @IdPersona int    
 select @IdPersona = Id from dbo.DatosPersonales where NroDocumento = @Documento    


INSERT INTO [DB_RRHH].[dbo].[CV_EventosAcademicos]
           ([IdPersona]
           ,[Denominacion]
           ,[TipoDeEvento]
           ,[CaracterDeParticipacion]
           ,[FechaInicio]
           ,[FechaFin]
           ,[Duracion]
           ,[Institucion]
           ,[Localidad]
           ,[Pais]
           ,[Usuario]
           ,[FechaOperacion]
           ,[Baja])
     VALUES
           (@IdPersona,
           @Denominacion,
           @TipoDeEvento, 
           @CaracterDeParticipacion,
           @FechaInicio,
           @FechaFin,
           @Duracion,
           @Institucion, 
           @Localidad, 
           @Pais, 
           @Usuario, 
          getdate(),
           @Baja )

END