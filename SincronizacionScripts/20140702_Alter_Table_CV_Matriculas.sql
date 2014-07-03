
alter table dbo.CV_Matriculas 
add IdPersona Int

go

alter table dbo.CV_Matriculas
add constraint FK_MatriculasDatosPersonales foreign key (IdPersona)
references dbo.DatosPersonales(Id)