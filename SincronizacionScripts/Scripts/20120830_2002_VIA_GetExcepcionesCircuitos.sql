CREATE PROCEDURE dbo.VIA_GetExcepcionesCircuito
AS
	Select 
		id,
		id_circuito IdCircuito,
		id_origen IdOrigen, 
		id_destino IdDestino
	FROM 
		dbo.[VIA_ExcepcionesCircuitos]

GO