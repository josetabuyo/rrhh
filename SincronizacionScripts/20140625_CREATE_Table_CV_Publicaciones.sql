CREATE TABLE [dbo].[CV_Publicaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CantidadHojas][varchar](100) NULL,
	[DatosEditorial][varchar](100) NULL,
	[DisponeCopia][bit] NULL,
	[Titulo][varchar](100) NULL,	
	[FechaPublicacion][datetime]  NULL,
	[Usuario][int] NOT NULL,
	[FechaOperacion][datetime] NOT NULL,
	[Baja][int] NULL
)