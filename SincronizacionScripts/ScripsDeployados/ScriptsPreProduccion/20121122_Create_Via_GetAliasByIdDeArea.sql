Create Procedure dbo.Via_GetAliasByIdDeArea
@id_area int
as

select Id, Id_Area, Descripcion
from dbo.via_alias_area
where id_area = @id_area