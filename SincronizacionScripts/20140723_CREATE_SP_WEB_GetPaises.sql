CREATE PROCEDURE [dbo].[WEB_GetPaises] 
AS

declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp

select Id, Descripcion 
from dbo.tabla_codigo_pais