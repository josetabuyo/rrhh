alter table dbo.CV_ConocimientosCompetenciasInformaticas
add IdTipo int default 1

go

alter table dbo.CV_ConocimientosCompetenciasInformaticas 
add constraint fk_tipo_competencia foreign key
(IdTipo) references dbo.CV_TipoCompetenciaInformatica (Id)

go


Alter Procedure dbo.CV_GetConocimientosCompetenciasInformaticas  
AS  
  
select Id, Descripcion, IdTipo  
from dbo.CV_ConocimientosCompetenciasInformaticas   
where Baja = 0  