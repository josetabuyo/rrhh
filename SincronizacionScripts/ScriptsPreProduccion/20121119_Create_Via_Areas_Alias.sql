create table dbo.Via_Alias_Area
(
Id int identity(1,1) primary key,
Id_area int not null,
Alias Varchar(50) not null unique
)

alter table dbo.Via_Alias_area add constraint fk_Areas_alias foreign key (Id_area) 
references dbo.tabla_areas(Id)