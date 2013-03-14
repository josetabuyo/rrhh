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



