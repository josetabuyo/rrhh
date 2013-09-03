ALTER TABLE dbo.Tabla_Areas_DatosContacto DROP DF__Tabla_Areas__Fax__63112973
ALTER TABLE dbo.Tabla_Areas_DatosContacto DROP DF__Tabla_Are__Telef__621D053A
ALTER TABLE dbo.Tabla_Areas_DatosContacto DROP DF__Tabla_Area__Mail__64054DAC
TRUNCATE TABLE dbo.Tabla_Areas_DatosContacto
ALTER TABLE dbo.Tabla_Areas_DatosContacto ALTER COLUMN Telefono smallint  

USE [DB_RRHH]
GO
EXEC sp_rename 'dbo.Tabla_Areas_DatosContacto.Telefono', 'Tipo_Dato', 'COLUMN';
GO
USE [DB_RRHH]
GO
EXEC sp_rename 'dbo.Tabla_Areas_DatosContacto.Fax', 'Dato', 'COLUMN';
GO
ALTER TABLE dbo.Tabla_Areas_DatosContacto DROP COLUMN Mail
