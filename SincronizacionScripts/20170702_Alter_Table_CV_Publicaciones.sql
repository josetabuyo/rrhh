alter table dbo.CV_Publicaciones 
add IdPersona Int

go

alter table dbo.CV_Publicaciones
add constraint FK_PublicacionesDatosPersonales foreign key (IdPersona)
references dbo.DatosPersonales(Id)