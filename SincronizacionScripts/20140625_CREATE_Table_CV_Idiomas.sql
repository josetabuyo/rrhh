DROP TABLE [dbo].[CV_Idiomas]

USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[CV_Idiomas]    Script Date: 07/23/2014 21:37:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CV_Idiomas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Diploma] [varchar](100) NULL,
	[Establecimiento] [varchar](100) NULL,
	[Idioma] [varchar](50) NULL,
	[Escritura] [varchar](50) NULL,
	[Lectura] [varchar](50) NULL,
	[Oral] [varchar](50) NULL,
	[FechaObtencion] [datetime] NULL,
	[FechaFin] [datetime] NULL,
	[Localidad] [varchar](100) NULL,
	[Pais] [int] NOT NULL,
	[Usuario] [int] NOT NULL,
	[FechaOperacion] [datetime] NOT NULL,
	[Baja] [int] NULL,
	[IdPersona] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CV_Idiomas]  WITH CHECK ADD  CONSTRAINT [FK_IdiomasDatosPersonales] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[DatosPersonales] ([Id])
GO

ALTER TABLE [dbo].[CV_Idiomas] CHECK CONSTRAINT [FK_IdiomasDatosPersonales]
GO


