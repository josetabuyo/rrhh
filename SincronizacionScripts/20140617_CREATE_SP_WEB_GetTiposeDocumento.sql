CREATE PROCEDURE [dbo].[WEB_GetTiposDeDocumento] 
AS

declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp

select Id, Descripcion 
from dbo.Tabla_Docidentidad 
where baja = 0