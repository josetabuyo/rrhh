Create Procedure dbo.CV_Ins_ExperienciasLaborales
@Actividad varchar(100)=null,
@MotivoDesvinculacion varchar(100)=null,
@NombreEmpleador varchar(100)=null,
@PersonasACargo varchar(100)=null,
@PuestoOcupado varchar(100)=null,
@TipoEmpresa varchar(100)=null,
@FechaInicio datetime,
@FechaFin datetime,
@Localidad varchar(100)=null,
@Pais varchar(100)=null,
@Usuario int=null,
--@FechaOperacion datetime,
@Baja int=null,
@Documento int =null


AS


BEGIN


declare @IdPersona int
select @IdPersona = id from dbo.datospersonales where nrodocumento = @Documento


INSERT INTO [DB_RRHH].[dbo].[CV_ExperienciasLaborales]
           ([Actividad]
           ,[MotivoDesvinculacion]
           ,[NombreEmpleador]
           ,[PersonasACargo]
           ,[PuestoOcupado]
           ,[TipoEmpresa]
           ,[FechaInicio]
           ,[FechaFin]
           ,[Localidad]
           ,[Pais]
           ,[Usuario]
           ,[FechaOperacion]
           ,[Baja]
           ,[IdPersona])
     VALUES
           (@Actividad, 
           @MotivoDesvinculacion,
           @NombreEmpleador,
           @PersonasACargo,
           @PuestoOcupado,
           @TipoEmpresa, 
           @FechaInicio,
           @FechaFin,
           @Localidad,
           @Pais, 
           @Usuario, 
           getdate(),
           @Baja,
           @IdPersona)




END

