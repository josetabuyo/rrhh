alter table dbo.CV_Idiomas 
add IdPersona Int

go

alter table dbo.CV_Idiomas
add constraint FK_IdiomasDatosPersonales foreign key (IdPersona)
references dbo.DatosPersonales(Id)