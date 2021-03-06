set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CV_Upd_Del_Postulacion]
(
	@idPostulacion [int], 
	@IdPuesto [int],
	@IdPersona [int],
	@Motivo varchar(500) = null,
	@Observaciones varchar(50) = null,
	@Numero varchar(6) = null,
	@FechaInscripcion [datetime],
	@Usuario[int],
	@idBaja [int] = null
)

AS

BEGIN

	declare @NombreSp varchar(60) 
	set @NombreSp = (select OBJECT_NAME(@@PROCID))
	exec dbo.Audit @NombreSp  

	UPDATE [dbo].[CV_Postulaciones]
	SET 
		Motivo = ISNULL(@Motivo,Motivo),
		Observaciones = ISNULL(@Observaciones,Observaciones),
		Numero = ISNULL(@Numero,Numero),
		FechaInscripcion = ISNULL(@FechaInscripcion,FechaInscripcion),
		Usuario = @Usuario,
		Baja = ISNULL(@idBaja, Baja)	
	WHERE
		Id = @idPostulacion
	
	
END
