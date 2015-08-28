
Create Table dbo.CV_NivelesCompetenciasInformaticas 
(
Id int identity(1,1) primary key,
Descripcion varchar(100) not null,
Baja int not null default 0
)

go

