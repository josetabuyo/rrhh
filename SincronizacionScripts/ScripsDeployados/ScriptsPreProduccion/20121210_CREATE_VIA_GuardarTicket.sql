--procedure para insertar un nuevo ticket generado
alter procedure dbo.VIA_GuardarTicket
	@codigoTicket varchar(8)
as
declare @registros int
	set @registros = (select count(*) from dbo.VIA_TicketsGenerados)
	if (@registros = 0) 
		insert into dbo.VIA_TicketsGenerados (codigo, fecha)
		values (@codigoTicket, getdate())
	else
		update dbo.VIA_TicketsGenerados set codigo = @codigoTicket, fecha = getdate()
	