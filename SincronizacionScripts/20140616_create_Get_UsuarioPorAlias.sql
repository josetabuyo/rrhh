create procedure dbo.Get_UsuarioPorAlias
@alias varchar(50)
as

select rh.Id,dp.NroDocumento,dp.nombre, dp.apellido 
from rh_usuarios rh, datospersonales dp
where rh.IdPersona = dp.Id
and rh.nombre = @alias

