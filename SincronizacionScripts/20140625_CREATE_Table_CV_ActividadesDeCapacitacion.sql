CREATE TABLE [dbo].[CV_ActividadesDeCapacitacion](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[Establecimiento] [varchar](100) NULL,
	[Especialidad] [varchar](100) NULL,
	[Duracion] [varchar](50) NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaEgreso] [datetime] NULL,
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

ALTER TABLE [dbo].[CV_ActividadesDeCapacitacion]  WITH CHECK ADD  CONSTRAINT [FK_ActividadesDatosPersonales] FOREIGN KEY([IdPersona])
REFERENCES [dbo].[DatosPersonales] ([Id])
GO

ALTER TABLE [dbo].[CV_ActividadesDeCapacitacion] CHECK CONSTRAINT [FK_ActividadesDatosPersonales]
GO


