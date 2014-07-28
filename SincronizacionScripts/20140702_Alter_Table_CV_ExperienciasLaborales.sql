
alter table dbo.CV_ExperienciasLaborales 
add IdPersona Int

go

alter table dbo.CV_ExperienciasLaborales
add constraint FK_ExperienciasDatosPersonales foreign key (IdPersona)
references dbo.DatosPersonales(Id)
