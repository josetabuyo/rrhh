CREATE procedure [dbo].[CV_Ins_Instituciones]
@CaracterEntidad varchar(100)=null,
@CargosDesempeniados varchar(100)=null,
@CategoriaActual varchar(100)=null,
@Fecha datetime=null,
@FechaDeAfiliacion datetime=null,
@FechaInicio datetime=null,
@FechaFin datetime=null,
@Institucion varchar(100)=null,
@NumeroAfiliado varchar(100)=null,
@Localidad varchar(100)=null,
@Pais varchar(100)=null,
@Usuario int=null,
@FechaOperacion datetime=null,
@Baja int=null,
@IdPersona int=null

           
AS

BEGIN

INSERT INTO [DB_RRHH].[dbo].[CV_Instituciones]
           ([CaracterEntidad]
           ,[CargosDesempeniados]
           ,[CategoriaActual]
           ,[Fecha]
           ,[FechaDeAfiliacion]
           ,[FechaInicio]
           ,[FechaFin]
           ,[Institucion]
           ,[NumeroAfiliado]
           ,[Localidad]
           ,[Pais]
           ,[Usuario]
           ,[FechaOperacion]
           ,[Baja]
           ,[IdPersona])
     VALUES
          (@CaracterEntidad,
           @CargosDesempeniados,
           @CategoriaActual, 
           @Fecha,
           @FechaDeAfiliacion,
           @FechaInicio, 
           @FechaFin,
           @Institucion,
           @NumeroAfiliado,
           @Localidad, 
           @Pais, 
           @Usuario,
           getdate(), 
           @Baja,
           @IdPersona)


END


