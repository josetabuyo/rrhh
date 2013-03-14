USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[SAC_Asistencias]    Script Date: 03/07/2013 21:01:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SAC_Asistencias](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[idAlumno] [int] NOT NULL,
	[idCurso] [smallint] NOT NULL,
	[fechaAsistencia] [datetime] NOT NULL,
	[descripcion] [char](30) NOT NULL,
	[idUsuario] [char](30) NOT NULL,
	[fecha] [datetime] NULL,
	[baja] [bit] NULL,
 CONSTRAINT [PK_SAC_Asistencias_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SAC_Asistencias]  WITH CHECK ADD FOREIGN KEY([idAlumno])
REFERENCES [dbo].[SAC_Alumnos] ([IdPersona])
GO

ALTER TABLE [dbo].[SAC_Asistencias]  WITH CHECK ADD FOREIGN KEY([idCurso])
REFERENCES [dbo].[SAC_Cursos] ([Id])
GO


