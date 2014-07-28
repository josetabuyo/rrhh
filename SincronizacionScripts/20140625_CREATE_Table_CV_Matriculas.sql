CREATE TABLE [dbo].[CV_Matriculas](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ExpedidaPor][varchar](100) NULL,
	[Numero][varchar](100) NULL,
	[SituacionActual][varchar](100) NULL,	
	[FechaInscripcion][datetime]  NULL,
	[Usuario][int] NOT NULL,
	[FechaOperacion][datetime] NOT NULL,
	[Baja][int] NULL
)