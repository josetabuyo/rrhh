--select * from CV_Instituciones

select * from dbo.CV_EventosAcademicos
go

Create Table dbo.CV_TiposDeEventoAcademico
(
Id Int identity(1,1) Primary Key,
Descripcion varchar(100) unique,
Baja Int default 0
)

go

Create Table dbo.CV_EventoCaracterDeParticipacion
(
Id Int identity(1,1) Primary Key,
Descripcion varchar(100) unique,
Baja Int default 0
)

go


Create Table dbo.CV_InstitucionesEventos
(
Id Int identity(1,1) Primary Key,
Descripcion varchar(100) unique,
Baja Int default 0
)


Create Table dbo.CV_Instituciones
(
Id Int identity(1,1) Primary Key,
Descripcion varchar(100) unique,
Baja Int default 0
)




