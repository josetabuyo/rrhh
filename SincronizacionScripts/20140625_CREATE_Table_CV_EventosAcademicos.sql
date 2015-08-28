DROP TABLE [dbo].[CV_EventosAcademicos]

USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[CV_EventosAcademicos]    Script Date: 07/23/2014 21:34:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CV_EventosAcademicos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Denominacion] [varchar](100) NULL,
	[TipoDeEvento] [varchar](100) NULL,
	[CaracterDeParticipacion] [varchar](100) NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFin] [datetime] NULL,
	[Duracion] [varchar](50) NULL,
	[Institucion] [varchar](100) NULL,
	[Localidad] [varchar](100) NULL,
	[Pais] [int] NOT NULL,
	[Usuario] [int] NOT NULL,
	[FechaOperacion] [datetime] NOT NULL,
	[Baja] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CV_EventosAcademicos]  WITH CHECK ADD  CONSTRAINT [fk_idPersona_datospersonales] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[DatosPersonales] ([Id])
GO

ALTER TABLE [dbo].[CV_EventosAcademicos] CHECK CONSTRAINT [fk_idPersona_datospersonales]
GO


