Create Procedure dbo.Via_AltaAlias
@Id_area int,
@Descripcion_alias varchar(50)
as

insert into dbo.Via_Alias_Area
values (@Id_area,@Descripcion_alias)