/****** Object:  Table [dbo].[CV_AntecedentesDeDocencia]    Script Date: 07/23/2014 19:52:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[CV_AntecedentesDeDocencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Asignatura] [varchar](100) NULL,
	[CaracterDesignacion] [varchar](100) NULL,
	[CargaHoraria] [varchar](100) NULL,
	[CategoriaDocente] [varchar](100) NULL,
	[DedicacionDocente] [varchar](100) NULL,
	[Establecimiento] [varchar](100) NULL,
	[NivelEducativo] [int] NULL,
	[TipoActividad] [varchar](100) NULL,
	[FechaInicio] [datetime] NULL,
	[FechaFinalizacion] [datetime] NULL,
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

ALTER TABLE [dbo].[CV_AntecedentesDeDocencia]  WITH CHECK ADD  CONSTRAINT [FK_AntecedentesDatosPersonales] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[DatosPersonales] ([Id])
GO

ALTER TABLE [dbo].[CV_AntecedentesDeDocencia] CHECK CONSTRAINT [FK_AntecedentesDatosPersonales]
GO


