CREATE TABLE [dbo].[CV_CompetenciasInformaticas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Diploma][varchar](100) NULL,
	[Establecimiento][varchar](100) NULL,
	[FechaObtencion][datetime]  NULL,
	[TipoInformatica][varchar](100) NULL,
	[Conocimiento][varchar](100) NULL,
	[Nivel][varchar](50) NULL,
	[Localidad][varchar](100) NULL,
	[Pais][varchar](100) NULL,
	[Usuario][int] NOT NULL,
	[FechaOperacion][datetime] NOT NULL,
	[Baja][int] NULL
)