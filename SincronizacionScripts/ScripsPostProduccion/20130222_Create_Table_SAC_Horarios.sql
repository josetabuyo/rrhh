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

CREATE TABLE [dbo].[SAC_Horarios](
	[id] [smallint] NOT NULL IDENTITY(1,1),
	[NroDiaSemana] [smallint] NOT NULL,
	[Desde] [char](4) NOT NULL,
	[Hasta] [char](4) NOT NULL,
 CONSTRAINT [PK_SAC_Horarios_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
) ON [PRIMARY]

ALTER TABLE [dbo].[SAC_Horarios]
ADD UNIQUE (Id, NroDiaSemana)


COMMIT



