USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[SAC_Cursos]    Script Date: 03/19/2013 22:15:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SAC_Cursos](
	[Id] [smallint] IDENTITY(1,1) NOT NULL,
	[IdAula] [smallint] NOT NULL,
	[IdMateria] [smallint] NOT NULL,
	[IdDocente] [int] NULL,
	[Fecha] [datetime] NULL,
	[idBaja] [int] NULL,
	[HoraCatedra] [smallint] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SAC_Cursos]  WITH CHECK ADD FOREIGN KEY([IdDocente])
REFERENCES [dbo].[SAC_Docentes] ([IdDocente])
GO

ALTER TABLE [dbo].[SAC_Cursos]  WITH CHECK ADD FOREIGN KEY([IdMateria])
REFERENCES [dbo].[SAC_Materias] ([id])
GO

