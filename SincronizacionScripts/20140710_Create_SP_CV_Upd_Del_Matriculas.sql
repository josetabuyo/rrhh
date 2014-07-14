CREATE PROCEDURE [dbo].[CV_Upd_Del_Matriculas]
(
	@idMatricula [int], 
	@ExpedidoPor varchar(100) = null,
	@Numero varchar(100) = null,
	@SituacionActual varchar(100) = null,
	@FechaInscripcion[datetime] = null,
	@Usuario[int],
	@idBaja [int] = null
)

AS

BEGIN

	declare @NombreSp varchar(60) 
	set @NombreSp = (select OBJECT_NAME(@@PROCID))
	exec dbo.Audit @NombreSp  

	UPDATE [dbo].[CV_Matriculas]
	SET 
		ExpedidaPor = ISNULL(@ExpedidoPor,ExpedidaPor),
		Numero = ISNULL(@Numero,Numero),
		SituacionActual = ISNULL(@SituacionActual,SituacionActual),
		FechaInscripcion = ISNULL(@FechaInscripcion,FechaInscripcion),
		Usuario = @Usuario,
		FechaOperacion = GETDATE(),
		Baja = ISNULL(@idBaja, Baja)	
	WHERE
		Id = @idMatricula
	
	
END