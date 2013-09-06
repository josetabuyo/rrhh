--procedure para obtener el ultimo codigo de ticket
create procedure dbo.VIA_GetUltimoCodigoDeTicket
as
	select 
		case count(codigo)
			   when 0 then 'AAA000'
			   else max(codigo)
		end codigo
	from dbo.VIA_TicketsGenerados
	
	