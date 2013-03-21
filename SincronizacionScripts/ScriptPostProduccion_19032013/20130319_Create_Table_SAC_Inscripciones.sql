USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[SAC_Inscripciones]    Script Date: 03/19/2013 20:13:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SAC_Inscripciones](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idCurso] [smallint] NOT NULL,
	[idAlumno] [int] NOT NULL,
	[idusuario] [smallint] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[idBaja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SAC_Inscripciones]  WITH CHECK ADD  CONSTRAINT [FK_SAC_Inscripciones_SAC_Alumno] FOREIGN KEY([idAlumno])
REFERENCES [dbo].[SAC_Alumnos] ([IdPersona])
GO

ALTER TABLE [dbo].[SAC_Inscripciones] CHECK CONSTRAINT [FK_SAC_Inscripciones_SAC_Alumno]
GO

ALTER TABLE [dbo].[SAC_Inscripciones]  WITH CHECK ADD  CONSTRAINT [FK_SAC_Inscripciones_SAC_Cursos] FOREIGN KEY([idCurso])
REFERENCES [dbo].[SAC_Cursos] ([Id])
GO

ALTER TABLE [dbo].[SAC_Inscripciones] CHECK CONSTRAINT [FK_SAC_Inscripciones_SAC_Cursos]
GO

