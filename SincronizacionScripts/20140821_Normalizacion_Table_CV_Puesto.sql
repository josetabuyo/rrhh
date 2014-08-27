
Create Table dbo.CV_FamiliaPuestos
(
Id Int identity(1,1) Primary Key,
Descripcion varchar(100) unique,
Baja Int default 0
)

GO

Create Table dbo.CV_ProfesionPuestos--
(
Id Int identity(1,1) Primary Key,
Descripcion varchar(100) unique,
Baja Int default 0
)

GO

Create Table dbo.CV_AgrupamientoPuestos--
(
Id Int identity(1,1) Primary Key,
Descripcion varchar(100)unique,
Baja Int default 0
)

GO

Create Table dbo.CV_TipoPuestos--
(
Id Int identity(1,1) Primary Key,
Descripcion varchar(100)unique,
Baja Int default 0
)

GO

Create Table dbo.CV_EstudioPuestos
(
Id Int identity(1,1) Primary Key,
Descripcion varchar(100)unique,
Baja Int default 0
)

GO


alter table dbo.CV_Puesto
Add IdFamilia int

go

alter table dbo.CV_Puesto
Add IdProfesion int

go

alter table dbo.CV_Puesto
Add IdAgrupamiento int

go

alter table dbo.CV_Puesto
Add IdTipoPuesto int

go

alter table dbo.CV_Puesto
Add IdEstudio int

go


insert into dbo.CV_FamiliaPuestos(Descripcion)
values ('Administrativo/Contable')

insert into dbo.CV_FamiliaPuestos(Descripcion)
values ('Abogado dictaminante')

insert into dbo.CV_FamiliaPuestos(Descripcion)
values ('Abogado experto/especializado')

insert into dbo.CV_FamiliaPuestos(Descripcion)
values ('Abogado litigante/sumariante')

insert into dbo.CV_FamiliaPuestos(Descripcion)
values ('Gestión de la información')

insert into dbo.CV_FamiliaPuestos(Descripcion)
values ('Trabajo Social')

go

insert into dbo.CV_ProfesionPuestos(Descripcion)
values ('Abogacía')

insert into dbo.CV_ProfesionPuestos(Descripcion)
values ('Administración')

insert into dbo.CV_ProfesionPuestos(Descripcion)
values ('Contabilidad')

insert into dbo.CV_ProfesionPuestos(Descripcion)
values ('Ingeniería')

insert into dbo.CV_ProfesionPuestos(Descripcion)
values ('Trabajo Social')

go

insert into dbo.CV_AgrupamientoPuestos(Descripcion)
values ('General')

insert into dbo.CV_AgrupamientoPuestos(Descripcion)
values ('Profesional')

go

insert into dbo.CV_TipoPuestos(Descripcion)
values ('General')

go

insert into dbo.CV_EstudioPuestos(Descripcion)
values ('Secundario')

insert into dbo.CV_EstudioPuestos(Descripcion)
values ('Terciario')

insert into dbo.CV_EstudioPuestos(Descripcion)
values ('Universitario')

go

alter table dbo.CV_Puesto
add constraint fk_puesto_familia foreign key (IdFamilia)
references dbo.CV_FamiliaPuestos (Id)

go

alter table dbo.CV_Puesto
add constraint fk_puesto_profesion foreign key (IdProfesion)
references dbo.CV_ProfesionPuestos (Id)

go

alter table dbo.CV_Puesto
add constraint fk_puesto_agrupamiento foreign key (IdAgrupamiento)
references dbo.CV_AgrupamientoPuestos (Id)

go

alter table dbo.CV_Puesto
add constraint fk_puesto_tipos foreign key (IdTipoPuesto)
references dbo.CV_TipoPuestos (Id)

go

alter table dbo.CV_Puesto
add constraint fk_puesto_estudios foreign key (IdEstudio)
references dbo.CV_EstudioPuestos (Id)

go


update cv
set IdFamilia = (SELECT id from dbo.CV_FamiliaPuestos cvp
					where cv.Familia = cvp.Descripcion )
from dbo.CV_puesto cv

GO


update cv
set IdProfesion = (SELECT id from dbo.CV_ProfesionPuestos cvp
					where cv.Profesion = cvp.Descripcion )
from dbo.CV_puesto cv

go

update cv
set IdAgrupamiento = (SELECT id from dbo.CV_AgrupamientoPuestos cvp
					where cv.Agrupamiento = cvp.Descripcion )
from dbo.CV_puesto cv

go

update cv
set IdTipoPuesto = (SELECT id from dbo.CV_TipoPuestos cvp
					where cv.Tipo = cvp.Descripcion )
from dbo.CV_puesto cv


update cv
set IdEstudio = (SELECT id from dbo.CV_EstudioPuestos cvp
					where cv.Estudio = cvp.Descripcion )
from dbo.CV_puesto cv



GO

alter PROCEDURE [dbo].[CV_Get_Postulaciones]
(    
 @idPersona int    
)    
AS  
BEGIN  
  
 SELECT   
  postu.Id IdPostulacion,  
  postu.IdPersona,  
  postu.Motivo,  
  postu.Observaciones,  
  postu.Numero Postulacion_Numero,  
  postu.FechaInscripcion,  
    
  puesto.Id IdPuesto,  
 -- puesto.Familia,  
  fp.Descripcion Familia,
  
 --puesto.Profesion,  
  pp.Descripcion Profesion,
  
  puesto.Denominacion,  
  puesto.Nivel,  
  
 --puesto.Agrupamiento,  
 ap.Descripcion Agrupamiento, 
  
  puesto.Vacantes,  
  
 --puesto.Tipo,  
  tp.Descripcion Tipo,
    
  puesto.Numero Puesto_Numero,  
    
  com.Id IdComite,  
  com.Numero NumeroDeComite,  
  com.Integrantes IntegrantesDelComite  
  
 FROM dbo.CV_Postulaciones postu  
 INNER JOIN dbo.CV_Puesto puesto  
 ON puesto.Id = postu.IdPuesto  
 INNER JOIN dbo.CV_Comite com  
 ON com.Id = puesto.id_comite  
   
 INNER join  dbo.CV_FamiliaPuestos fp
 on fp.id =  puesto.IdFamilia
 
 INNER JOIN dbo.CV_ProfesionPuestos pp
 on pp.Id = puesto.IdProfesion
 
  INNER JOIN dbo.CV_AgrupamientoPuestos ap
 on ap.Id = puesto.IdAgrupamiento  
   
 INNER JOIN dbo.CV_TipoPuestos tp
 on tp.Id = puesto.IdTipoPuesto  

 INNER JOIN dbo.CV_EstudioPuestos ep
 on ep.Id = puesto.IdEstudio  

where postu.IdPersona = @idPersona  
   
END  
  

go

GO

  
ALTER PROCEDURE [dbo].[CV_Get_Puestos]     
  
AS  
BEGIN  
  
 SELECT   
  pue.Id IdPuesto,  
 -- pue.Familia, -- 
  fp.Descripcion Familia,
  --pue.Profesion, -- 
  pp.Descripcion Profesion,
  
  pue.Denominacion,  
  pue.Nivel,  
 -- pue.Agrupamiento, -- 
   ap.Descripcion Agrupamiento, -- 
  pue.Vacantes,  
  --pue.Tipo,--  
  tp.Descripcion Tipo,
  pue.Fecha,  
  pue.Numero NumeroDePuesto,  
  --pue.Estudio,--  
  ep.Descripcion Estudio,
  com.Id IdComite,  
  com.Numero NumeroDeComite,  
  com.Integrantes IntegrantesDelComite  
   
  FROM dbo.CV_Puesto pue  
  INNER JOIN dbo.CV_Comite com on  
  pue.id_comite = com.Id  
  
 INNER JOIN dbo.CV_FamiliaPuestos fp
on  pue.IdFamilia=fp.id
 INNER JOIN dbo.CV_ProfesionPuestos pp
on pue.IdProfesion= pp.id
 INNER JOIN dbo.CV_AgrupamientoPuestos ap
on pue.IdAgrupamiento= ap.id
 INNER JOIN dbo.CV_TipoPuestos tp
on  pue.IdTipoPuesto= tp.id
 
 INNER JOIN dbo.CV_EstudioPuestos ep
on pue.IdEstudio=ep.id
  
  
   
END  
  
  
 GO
 
 
alter table dbo.cv_puesto
drop column Familia

alter table dbo.cv_puesto
drop column Profesion

alter table dbo.cv_puesto
drop column Agrupamiento

alter table dbo.cv_puesto
drop column Tipo

alter table dbo.cv_puesto
drop column Estudio
  
  

  
  
  




GO

