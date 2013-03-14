/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
COMMIT
BEGIN TRANSACTION
GO

CREATE TABLE dbo.SAC_Articuladores
	(
	idUsuario smallint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE [dbo].SAC_Articuladores ADD CONSTRAINT
	PK_SAC_Articuladores PRIMARY KEY CLUSTERED 
	(
	idUsuario
	) ON [PRIMARY]

GO
ALTER TABLE [dbo].SAC_Articuladores ADD CONSTRAINT
	FK_SAC_Articuladores_RH_Usuarios FOREIGN KEY
	(
	idUsuario
	) REFERENCES dbo.RH_Usuarios
	(
	Id
	)
GO
COMMIT