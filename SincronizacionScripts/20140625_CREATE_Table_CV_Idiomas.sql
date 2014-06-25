CREATE TABLE [dbo].[CV_Idiomas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Diploma][varchar](100) NULL,
	[Establecimiento][varchar](100) NULL,
	[Idioma][varchar](50) NULL,	
	[Escritura][varchar](50) NULL,
	[Lectura][varchar](50) NULL,
	[Oral][varchar](50) NULL,	
	[FechaObtencion][datetime]  NULL,
	[FechaFin][datetime]  NULL,
	[Localidad][varchar](100) NULL,
	[Pais][varchar](100) NULL,
	[Usuario][int] NOT NULL,
	[FechaOperacion][datetime] NOT NULL,
	[Baja][int] NULL
)