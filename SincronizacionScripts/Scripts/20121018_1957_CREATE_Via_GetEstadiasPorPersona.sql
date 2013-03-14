create Procedure dbo.Via_GetEstadiasPorPersona
@Documento int  
as  
  
select ve.FechaDesde FechaDesde,   
ve.FechaHasta Fechahasta,   
ve.Provincia IdProvincia,   
Pr.nombreProvincia NombreProvincia,  
ve.Eventual Eventual,  
ve.AdicPorPasaje AdicionalParaPasajes,  
ve.CalculadoPorCategoria CalculadoPorCategoria,  
ve.Motivo Motivo  
from dbo.via_estadias ve,dbo.VIA_ComisionesDeServicio c,Provincias Pr     
where ve.IdComision = c.id  
and ve.provincia = Pr.codAFIP   
and c.DocumentoAgente = @Documento  
  