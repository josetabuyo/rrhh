Create Procedure [dbo].[CV_Ins_ExperienciasLaborales]
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
@Baja int=null,
@IdPersona int =null


AS


BEGIN

 declare @NombreSp varchar(60)   
 set @NombreSp = (select OBJECT_NAME(@@PROCID))  
 exec dbo.Audit @NombreSp 

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


SELECT SCOPE_IDENTITY()	

END

