
GO
Create Table dbo.CV_ConocimientosCompetenciasInformaticas
(
Id Int identity(1,1) Primary key,
Descripcion varchar(100) not null,
Baja int not null default 0
)

GO

Create Procedure dbo.CV_GetConocimientosCompetenciasInformaticas
AS

select Id, Descripcion
from dbo.CV_ConocimientosCompetenciasInformaticas 
where Baja = 0

go

insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Access')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Android')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('ASP')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('ASP.Net')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('C')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('C++')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('C#.NET')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('CLEMENTINE')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Cobol')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Corel Draw')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Delphi')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Dreamweaver')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Excel')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Internet Explorer')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Java')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('JavaScript')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('JQuery')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Linux')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Lotus Notes')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Meta4')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('METADATA EDITOR')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Microsoft Windows')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('MPSGE')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('MySQL')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('NESSTAR EXPLORER')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Oracle')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Outlook')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Photoshop')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('PHP')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('PostgreSQL')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('PowerPoint')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('REDATAM')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('SPSS')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('SQL Server')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('STATA')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Visual Basic 6')
insert into dbo.CV_ConocimientosCompetenciasInformaticas (Descripcion) values ('Visual Basic.Net')










