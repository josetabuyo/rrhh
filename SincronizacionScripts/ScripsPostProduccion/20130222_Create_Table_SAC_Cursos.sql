USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[SAC_Cursos]    Script Date: 03/07/2013 20:59:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SAC_Cursos](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[IdHorario] [smallint] NOT NULL,
	[IdDocente] [smallint] NOT NULL,
	[IdAula] [smallint] NOT NULL,
	[IdMateria] [smallint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SAC_Cursos]  WITH CHECK ADD FOREIGN KEY([IdDocente])
REFERENCES [dbo].[SAC_Docentes] ([id])
GO

ALTER TABLE [dbo].[SAC_Cursos]  WITH CHECK ADD FOREIGN KEY([IdHorario])
REFERENCES [dbo].[SAC_Horarios] ([id])
GO

ALTER TABLE [dbo].[SAC_Cursos]  WITH CHECK ADD FOREIGN KEY([IdMateria])
REFERENCES [dbo].[SAC_Materias] ([id])
GO


