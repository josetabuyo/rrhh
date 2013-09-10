USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[SAC_Docentes]    Script Date: 03/19/2013 20:09:38 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SAC_Docentes](
	[IdDocente] [int] NOT NULL,
	[IdUsuario] [smallint] NULL,
	[Fecha] [datetime] NULL,
	[idBaja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[IdDocente] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SAC_Docentes]  WITH CHECK ADD  CONSTRAINT [FK_SAC_Docentes_CRED_Personas] FOREIGN KEY([IdDocente])
REFERENCES [dbo].[CRED_Personas] ([Id])
GO

ALTER TABLE [dbo].[SAC_Docentes] CHECK CONSTRAINT [FK_SAC_Docentes_CRED_Personas]
GO

