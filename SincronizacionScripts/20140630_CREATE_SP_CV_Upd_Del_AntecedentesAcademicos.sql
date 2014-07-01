CREATE PROCEDURE [dbo].[CV_Upd_Del_ActividadesAcademicas]
(
	@idBaja [int],
	@idAntecedente [int] 
)

AS

BEGIN

	UPDATE [dbo].[CV_AntecedentesAcademicos]
	SET Baja = @idBaja	
	WHERE Id = @idAntecedente
	
END