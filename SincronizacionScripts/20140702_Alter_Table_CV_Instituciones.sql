alter table dbo.CV_Instituciones 
add IdPersona Int

go

alter table dbo.CV_Instituciones
add constraint FK_InstitucionesDatosPersonales foreign key (IdPersona)
references dbo.DatosPersonales(Id)