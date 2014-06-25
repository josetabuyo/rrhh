CREATE TABLE [dbo].[CV_AntecedentesAcademicos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100)  NOT NULL,
	[Establecimiento][varchar](100) NULL,
	[Especialidad] [varchar](100)  NULL,
	[FechaIngreso][datetime]  NULL,
	[FechaEgreso][datetime]  NULL,
	[Localidad][varchar](100) NULL,
	[Pais][varchar](100) NULL,
	[Usuario][int] NOT NULL,
	[FechaOperacion][datetime] NOT NULL,
	[Baja][int] NULL
	
) 