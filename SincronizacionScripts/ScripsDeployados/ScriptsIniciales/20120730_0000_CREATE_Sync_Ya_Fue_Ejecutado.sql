CREATE PROCEDURE Sync_Ya_Fue_Ejecutado
@script varchar(256)
AS
BEGIN
DECLARE @mensaje varchar(50)
SELECT COUNT(*) FROM DBO.Sync_Registro R WHERE R.nombreScript LIKE @script
END


