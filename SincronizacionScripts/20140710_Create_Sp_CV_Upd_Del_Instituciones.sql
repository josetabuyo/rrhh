USE [DB_RRHH]
GO
/****** Object:  StoredProcedure [dbo].[CV_Upd_Del_Instituciones]    Script Date: 07/22/2014 20:31:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER Procedure [dbo].[CV_Upd_Del_Instituciones]
(
@idInstitucion [int], 
@CaracterEntidad varchar(100)=null,
@CargosDesempeniados varchar(100)=null,
@CategoriaActual varchar(100)=null,
@Fecha datetime=null,
@FechaDeAfiliacion datetime=null,
@FechaInicio datetime=null,
@FechaFin datetime=null,
@Institucion varchar(100)=null,
@NumeroAfiliado varchar(100)=null,
@Localidad int=null,
@Pais int=null,
@Usuario int=null,
@Baja int=null
)

AS

BEGIN

declare @NombreSp varchar(60) 
	set @NombreSp = (select OBJECT_NAME(@@PROCID))
	exec dbo.Audit @NombreSp  

UPDATE [dbo].[CV_Instituciones]
   SET 
      CaracterEntidad = isnull(@CaracterEntidad,CaracterEntidad),
      CargosDesempeniados = isnull(@CargosDesempeniados,CargosDesempeniados), 
      CategoriaActual = isnull(@CategoriaActual,CategoriaActual),
      Fecha = isnull(@Fecha,Fecha), 
      FechaDeAfiliacion = isnull(@FechaDeAfiliacion,FechaDeAfiliacion), 
      FechaInicio = isnull(@FechaInicio, FechaInicio),
      FechaFin = isnull(@FechaFin,FechaFin), 
      Institucion = isnull(@Institucion,Institucion),
      NumeroAfiliado = isnull(@NumeroAfiliado,NumeroAfiliado), 
      Localidad = isnull(@Localidad,Localidad), 
      Pais = isnull(@Pais,Pais), 
      Usuario = isnull(@Usuario, Usuario),
      FechaOperacion = getdate(),
      Baja = isnull(@Baja,Baja) 
   WHERE Id = @idInstitucion


END



