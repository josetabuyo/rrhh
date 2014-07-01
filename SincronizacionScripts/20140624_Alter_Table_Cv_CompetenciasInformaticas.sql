
alter table dbo.CV_CompetenciasInformaticas 
add IdPersona Int

go

alter table dbo.CV_CompetenciasInformaticas
add constraint FK_CompetenciasDatosPersonales foreign key (IdPersona)
references dbo.DatosPersonales(Id)
