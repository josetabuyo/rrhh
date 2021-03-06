USE [DB_RRHH]
GO
/****** Objeto:  Table [dbo].[SAC_Evaluaciones]    Fecha de la secuencia de comandos: 04/16/2013 19:27:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SAC_Evaluaciones](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[idInstanciaEvaluacion] [smallint] NOT NULL,
	[idAlumno] [int] NOT NULL,
	[idCurso] [smallint] NOT NULL,
	[Calificacion] [char](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[idUsuario] [char](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[fecha] [datetime] NULL,
	[idBaja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[SAC_Evaluaciones]  WITH CHECK ADD FOREIGN KEY([idAlumno])
REFERENCES [dbo].[SAC_Alumnos] ([IdPersona])
GO
ALTER TABLE [dbo].[SAC_Evaluaciones]  WITH CHECK ADD FOREIGN KEY([idCurso])
REFERENCES [dbo].[SAC_Cursos] ([Id])
GO
ALTER TABLE [dbo].[SAC_Evaluaciones]  WITH CHECK ADD FOREIGN KEY([idInstanciaEvaluacion])
REFERENCES [dbo].[SAC_InstanciasDeEvaluaciones] ([id])