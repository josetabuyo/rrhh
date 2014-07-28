DROP TABLE [dbo].[CV_CompetenciasInformaticas]

USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[CV_CompetenciasInformaticas]    Script Date: 07/23/2014 21:33:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CV_CompetenciasInformaticas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Diploma] [varchar](100) NULL,
	[Establecimiento] [varchar](100) NULL,
	[FechaObtencion] [datetime] NULL,
	[TipoInformatica] [varchar](100) NULL,
	[Conocimiento] [varchar](100) NULL,
	[Nivel] [varchar](50) NULL,
	[Localidad] [varchar](100) NULL,
	[Pais] [int] NOT NULL,
	[Usuario] [int] NOT NULL,
	[FechaOperacion] [datetime] NOT NULL,
	[Baja] [int] NULL,
	[IdPersona] [int] NULL,
	[Detalle] [varchar](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CV_CompetenciasInformaticas]  WITH CHECK ADD  CONSTRAINT [FK_CompetenciasDatosPersonales] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[DatosPersonales] ([Id])
GO

ALTER TABLE [dbo].[CV_CompetenciasInformaticas] CHECK CONSTRAINT [FK_CompetenciasDatosPersonales]
GO


