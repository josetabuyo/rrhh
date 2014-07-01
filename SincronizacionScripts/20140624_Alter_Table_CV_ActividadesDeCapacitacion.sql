
alter table dbo.CV_ActividadesDeCapacitacion 
add IdPersona Int

go

alter table dbo.CV_ActividadesDeCapacitacion
add constraint FK_ActividadesDatosPersonales foreign key (IdPersona)
references dbo.DatosPersonales(Id)