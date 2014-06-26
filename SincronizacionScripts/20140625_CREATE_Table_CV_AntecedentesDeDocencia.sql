CREATE TABLE [dbo].[CV_AntecedentesDeDocencia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Asignatura][varchar](100) NULL,
	[CaracterDesignacion][varchar](100) NULL,
	[CargaHoraria][varchar](100) NULL,
	[CategoriaDocente][varchar](100) NULL,
	[DedicacionDocente][varchar](100) NULL,
	[Establecimiento][varchar](100) NULL,
	[NivelEducativo][varchar](100) NULL,
	[TipoActividad][varchar](100) NULL,	
	[FechaInicio][datetime]  NULL,
	[FechaFinalizacion][datetime]  NULL,
	[Localidad][varchar](100) NULL,
	[Pais][varchar](100) NULL,
	[Usuario][int] NOT NULL,
	[FechaOperacion][datetime] NOT NULL,
	[Baja][int] NULL
) 