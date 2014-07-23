USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[CV_Instituciones]    Script Date: 07/22/2014 20:47:44 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CV_Instituciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CaracterEntidad] [varchar](100) NULL,
	[CargosDesempeniados] [varchar](100) NULL,
	[CategoriaActual] [varchar](100) NULL,
	[Fecha] [datetime] NULL,
	[FechaDeAfiliacion] [datetime] NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFin] [datetime] NULL,
	[Institucion] [varchar](100) NULL,
	[NumeroAfiliado] [varchar](100) NULL,
	[Localidad] [int] NULL,
	[Pais] [int] NOT NULL,
	[Usuario] [int] NOT NULL,
	[FechaOperacion] [datetime] NOT NULL,
	[Baja] [int] NULL,
	[IdPersona] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CV_Instituciones]  WITH CHECK ADD  CONSTRAINT [FK_InstitucionesDatosPersonales] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[DatosPersonales] ([Id])
GO

ALTER TABLE [dbo].[CV_Instituciones] CHECK CONSTRAINT [FK_InstitucionesDatosPersonales]
GO


