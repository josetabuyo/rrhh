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
COMMIT
BEGIN TRANSACTION
GO
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE [dbo].[SIC_TransicionesDeDocumentos]
	(
	Id int identity(1,1) NOT NULL,
	IdDocumento int NOT NULL,
	IdAreaOrigen int NOT NULL,
	IdAreaDestino int NULL,
	Fecha smalldatetime NULL,
	Tipo varchar(10),
	IdUsuario smallint NOT NULL,
	FechaOperacion smalldatetime NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE [dbo].[SIC_TransicionesDeDocumentos] ADD CONSTRAINT
	PK_SIC_TransicionesDeDocumentos PRIMARY KEY CLUSTERED 
	(
	Id
	) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SIC_TransicionesDeDocumentos] ADD CONSTRAINT
	FK_SIC_TransicionesDeDocumentos_SIC_Documentos FOREIGN KEY
	(
	IdDocumento
	) REFERENCES dbo.SIC_Documentos
	(
	Id
	)
GO
ALTER TABLE [dbo].[SIC_TransicionesDeDocumentos] ADD CONSTRAINT
	FK_SIC_TransicionesDeDocumentos_Tabla_Areas FOREIGN KEY
	(
	IdAreaOrigen
	) REFERENCES dbo.Tabla_Areas
	(
	id
	)
GO
ALTER TABLE [dbo].[SIC_TransicionesDeDocumentos] ADD CONSTRAINT
	FK_SIC_TransicionesDeDocumentos_Tabla_Areas1 FOREIGN KEY
	(
	IdAreaDestino
	) REFERENCES dbo.Tabla_Areas
	(
	id
	)
GO
ALTER TABLE [dbo].[SIC_TransicionesDeDocumentos] ADD CONSTRAINT
	FK_SIC_TransicionesDeDocumentos_RH_Usuarios FOREIGN KEY
	(
	IdUsuario
	) REFERENCES dbo.RH_Usuarios
	(
	Id
	)
GO
COMMIT
