--Sp a modificar
--CV_GetCurriculumVitae
--CV_Ins_EventosAcademicos
--Cv_Upd_Del_EventosAcademicos

--select * from dbo.CV_EventosAcademicos


Create Table dbo.CV_TiposDeEventoAcademico
(
Id Int identity(1,1) Primary Key,
Descripcion varchar(100) unique,
Baja Int default 0
)

go 


insert into dbo.CV_TiposDeEventoAcademico (Descripcion)
values('Charla')

insert into dbo.CV_TiposDeEventoAcademico (Descripcion)
values('Coloquio')

insert into dbo.CV_TiposDeEventoAcademico (Descripcion)
values('Cursillo')

insert into dbo.CV_TiposDeEventoAcademico (Descripcion)
values('Curso')

insert into dbo.CV_TiposDeEventoAcademico (Descripcion)
values('Disertación')

insert into dbo.CV_TiposDeEventoAcademico (Descripcion)
values('Exposición')

insert into dbo.CV_TiposDeEventoAcademico (Descripcion)
values('Mesa Redonda')

insert into dbo.CV_TiposDeEventoAcademico (Descripcion)
values('Seminario')

insert into dbo.CV_TiposDeEventoAcademico (Descripcion)
values('Taller')


go

Create Table dbo.CV_CaracterDeParticipacionEvento
(
Id Int identity(1,1) Primary Key,
Descripcion varchar(100) unique,
Baja Int default 0
)
go

insert into dbo.CV_CaracterDeParticipacionEvento (Descripcion)
values('Experto')

insert into dbo.CV_CaracterDeParticipacionEvento (Descripcion)
values('Invitado')

insert into dbo.CV_CaracterDeParticipacionEvento (Descripcion)
values('Moderador')

insert into dbo.CV_CaracterDeParticipacionEvento (Descripcion)
values('Orador')

insert into dbo.CV_CaracterDeParticipacionEvento (Descripcion)
values('Organizador')

go

Create Table dbo.CV_InstitucionesEventos
(
Id Int identity(1,1) Primary Key,
Descripcion varchar(100) unique,
Baja Int default 0
)

insert into dbo.CV_InstitucionesEventos (Descripcion)
values('U.A.D.E.')

insert into dbo.CV_InstitucionesEventos (Descripcion)
values('U.A.I.')

insert into dbo.CV_InstitucionesEventos (Descripcion)
values('U.B.A.')

insert into dbo.CV_InstitucionesEventos (Descripcion)
values('U.C.A.')

insert into dbo.CV_InstitucionesEventos (Descripcion)
values('U.S.A.L.')

insert into dbo.CV_InstitucionesEventos (Descripcion)
values('U.T.N.')

GO

alter table dbo.CV_EventosAcademicos
Add IdTipoDeEvento int

alter table dbo.CV_EventosAcademicos
Add IdCaracterParticipacion int

alter table dbo.CV_EventosAcademicos
Add IdInstitucion int

GO

alter table dbo.CV_EventosAcademicos
add constraint fk_evento_tipoevento foreign key (IdTipoDeEvento)
references dbo.CV_TiposDeEventoAcademico (Id)

alter table dbo.CV_EventosAcademicos
add constraint fk_evento_caracter foreign key (IdCaracterParticipacion)
references dbo.CV_CaracterDeParticipacionEvento (Id)

alter table dbo.CV_EventosAcademicos
add constraint fk_evento_institucion foreign key (IdInstitucion)
references dbo.CV_InstitucionesEventos (Id)

GO


