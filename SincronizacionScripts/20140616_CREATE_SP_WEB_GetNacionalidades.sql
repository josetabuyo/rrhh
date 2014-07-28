CREATE PROCEDURE [dbo].[WEB_GetNacionalidades] 
AS

declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp

select Id, Descripcion 
from dbo.tabla_nacionalidad 
where baja = 0