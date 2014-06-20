CREATE PROCEDURE [dbo].[WEB_GetLocalidades] 
AS

declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp

select 
	loc.idLocalidad		Id, 
	loc.nombrelocalidad Descripcion,
	prov.IdProvincia	IdProvincia
from	dbo.LocalidadesAFIP loc INNER JOIN 
		dbo.Provincias prov	
		ON prov.codAFIP = loc.id_provincia
where loc.baja = 0