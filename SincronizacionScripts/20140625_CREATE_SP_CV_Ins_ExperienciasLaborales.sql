Create procedure dbo.CV_Ins_ExperienciasLaborales
@Actividad varchar(100) = null,
@MotivoDesvinculacion varchar(100)= null,
@NombreEmpleador varchar(100)= null,
@PersonasACargo varchar(100)= null,
@PuestoOcupado varchar(100)= null,
@TipoEmpresa varchar(100)= null,
@FechaInicio datetime= null,
@FechaFin datetime= null,
@Localidad varchar(100)= null,
@Pais varchar(100)= null,
@Usuario int,
--@FechaOperacion, datetime,
@Baja int= null

AS

Begin

INSERT INTO [dbo].[CV_ExperienciasLaborales]
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
           ,[Baja])
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
           @Baja)





END











