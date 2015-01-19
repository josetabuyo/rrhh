
alter table dbo.CV_AntecedentesDeDocencia 
add IdPersona Int

go

alter table dbo.CV_AntecedentesDeDocencia
add constraint FK_AntecedentesDatosPersonales foreign key (IdPersona)
references dbo.DatosPersonales(Id)