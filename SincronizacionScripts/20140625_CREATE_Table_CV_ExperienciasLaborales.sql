CREATE TABLE [dbo].[CV_ExperienciasLaborales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Actividad][varchar](100) NULL,
	[MotivoDesvinculacion][varchar](100) NULL,
	[NombreEmpleador][varchar](100) NULL,	
	[PersonasACargo][varchar](100) NULL,
	[PuestoOcupado][varchar](100) NULL,	
	[TipoEmpresa][varchar](100) NULL,
	[FechaInicio][datetime]  NULL,
	[FechaFin][datetime]  NULL,
	[Localidad][varchar](100) NULL,
	[Pais][varchar](100) NULL,
	[Usuario][int] NOT NULL,
	[FechaOperacion][datetime] NOT NULL,
	[Baja][int] NULL
)
 