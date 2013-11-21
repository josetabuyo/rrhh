
alter table dbo.sac_asistencias
drop column descripcion
go

alter table dbo.sac_asistencias
drop column valor_aux
go

alter table dbo.sac_asistencias
alter column valor varchar(10)
go

update dbo.sac_asistencias
set valor = '0' where valor = 5
go

update dbo.sac_asistencias
set valor = '-' where valor = 6
go