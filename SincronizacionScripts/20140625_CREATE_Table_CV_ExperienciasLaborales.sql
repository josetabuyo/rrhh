DROP TABLE [dbo].[CV_ExperienciasLaborales]

USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[CV_ExperienciasLaborales]    Script Date: 07/23/2014 21:36:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CV_ExperienciasLaborales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Actividad] [varchar](100) NULL,
	[MotivoDesvinculacion] [varchar](100) NULL,
	[NombreEmpleador] [varchar](100) NULL,
	[PersonasACargo] [bit] NULL,
	[PuestoOcupado] [varchar](100) NULL,
	[TipoEmpresa] [varchar](100) NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFin] [datetime] NULL,
	[Localidad] [varchar](100) NULL,
	[Pais] [int] NOT NULL,
	[Usuario] [int] NOT NULL,
	[FechaOperacion] [datetime] NOT NULL,
	[Baja] [int] NULL,
	[IdPersona] [int] NULL,
	[Sector] [varchar](100) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[CV_ExperienciasLaborales]  WITH CHECK ADD  CONSTRAINT [FK_ExperienciasDatosPersonales] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[DatosPersonales] ([Id])
GO

ALTER TABLE [dbo].[CV_ExperienciasLaborales] CHECK CONSTRAINT [FK_ExperienciasDatosPersonales]
GO

ALTER TABLE [dbo].[CV_ExperienciasLaborales] ADD  DEFAULT ('') FOR [Sector]
GO


