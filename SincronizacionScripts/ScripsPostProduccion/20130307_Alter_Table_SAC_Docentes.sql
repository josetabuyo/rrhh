USE AdventureWorks2012;
GO
EXEC sp_rename 'dbo.SAC_Docentes.FechaModificacion', 'Fecha', 'COLUMN';
GO