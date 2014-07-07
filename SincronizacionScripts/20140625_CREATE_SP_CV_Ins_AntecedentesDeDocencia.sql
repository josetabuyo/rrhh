create procedure dbo.CV_Ins_AntecedentesDeDocencia
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
@Usuario int,
--@FechaOperacion, datetime,
@Baja int= null,
@Documento int = null

AS

Begin

declare @NombreSp varchar(60)   
 set @NombreSp = (select OBJECT_NAME(@@PROCID))  
 exec dbo.Audit @NombreSp  


declare @IdPersona int
select @IdPersona = id from dbo.datospersonales where nrodocumento = @Documento


INSERT INTO [dbo].[CV_AntecedentesDeDocencia]
           ([Asignatura]
           ,[CaracterDesignacion]
           ,[CargaHoraria]
           ,[CategoriaDocente]
           ,[DedicacionDocente]
           ,[Establecimiento]
           ,[NivelEducativo]
           ,[TipoActividad]
           ,[FechaInicio]
           ,[FechaFinalizacion]
           ,[Localidad]
           ,[Pais]
           ,[Usuario]
           ,[FechaOperacion]
           ,[Baja],
           [IdPersona])
     VALUES
           (@Asignatura,
           @CaracterDesignacion,
           @CargaHoraria,
           @CategoriaDocente,
           @DedicacionDocente,
           @Establecimiento,
           @NivelEducativo,
           @TipoActividad,
           @FechaInicio,
           @FechaFinalizacion,
           @Localidad,
           @Pais,
           @Usuario,
           GETDATE(),
           @Baja,
           @IdPersona)


END











