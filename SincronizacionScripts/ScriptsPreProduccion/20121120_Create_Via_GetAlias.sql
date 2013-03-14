/*Obtiene todos los Alias de las áreas*/
Create Procedure dbo.Via_GetAlias
as

select Id, Id_Area, Alias from dbo.Via_Alias_Area
