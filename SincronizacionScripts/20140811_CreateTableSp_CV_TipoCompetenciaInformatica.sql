Create Table dbo.CV_TipoCompetenciaInformatica
(
Id int identity(1,1) primary key,
Descripcion varchar(100) not null,
Baja int not null default 0
)

go

insert into dbo.CV_TipoCompetenciaInformatica (Descripcion) values ('Aplicativos y Utilitarios')
insert into dbo.CV_TipoCompetenciaInformatica (Descripcion) values ('Bases de Datos')
insert into dbo.CV_TipoCompetenciaInformatica (Descripcion) values ('Lenguajes de Programación')
insert into dbo.CV_TipoCompetenciaInformatica (Descripcion) values ('Programas de Diseño gráfico')
insert into dbo.CV_TipoCompetenciaInformatica (Descripcion) values ('Sistemas Operativos')
insert into dbo.CV_TipoCompetenciaInformatica (Descripcion) values ('Otros')

go

create Procedure dbo.CV_GetTiposCompetenciasInformaticas
As

Select Id, Descripcion
from dbo.CV_TipoCompetenciaInformatica
where Baja = 0


go
