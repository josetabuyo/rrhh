CREATE PROCEDURE [dbo].[WEB_GetEstadosCiviles] 
AS

declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp

select Id, Descripcion 
from dbo.Tabla_Estado_Civil 
where baja = 0