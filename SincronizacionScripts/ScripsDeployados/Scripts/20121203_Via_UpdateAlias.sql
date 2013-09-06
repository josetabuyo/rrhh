Create Procedure dbo.Via_UpdateAlias
@Id_area int,
@Descripcion_alias varchar(50)
as

update dbo.Via_Alias_Area
set Alias = @Descripcion_alias
where id_area = @Id_area
