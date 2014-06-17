CREATE PROCEDURE [dbo].[WEB_GetProvincias]
AS

declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp

SELECT p.idProvincia id , P.nombreProvincia nombre
FROM [dbo].[Provincias] P