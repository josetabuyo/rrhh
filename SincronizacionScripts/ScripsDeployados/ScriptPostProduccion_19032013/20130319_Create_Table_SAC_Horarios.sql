USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[SAC_Horarios]    Script Date: 03/19/2013 20:09:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SAC_Horarios](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[idCurso] [smallint] NOT NULL,
	[NroDiaSemana] [smallint] NOT NULL,
	[Desde] [char](4) NOT NULL,
	[Hasta] [char](4) NOT NULL,
 CONSTRAINT [PK_SAC_Horarios_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SAC_Horarios]  WITH CHECK ADD FOREIGN KEY([idCurso])
REFERENCES [dbo].[SAC_Cursos] ([Id])
GO

