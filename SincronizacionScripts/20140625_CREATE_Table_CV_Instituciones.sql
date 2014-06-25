CREATE TABLE [dbo].[CV_Instituciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CaracterEntidad][varchar](100) NULL,
	[CargosDesempeniados][varchar](100) NULL,
	[CategoriaActual][varchar](100) NULL,	
	[Fecha][datetime]  NULL,
	[FechaDeAfiliacion][datetime]  NULL,
	[FechaInicio][datetime]  NULL,
	[FechaFin][datetime]  NULL,
	[Institucion][varchar](100) NULL,
	[NumeroAfiliado][varchar](100) NULL,	
	[Localidad][varchar](100) NULL,
	[Pais][varchar](100) NULL,
	[Usuario][int] NOT NULL,
	[FechaOperacion][datetime] NOT NULL,
	[Baja][int] NULL
)