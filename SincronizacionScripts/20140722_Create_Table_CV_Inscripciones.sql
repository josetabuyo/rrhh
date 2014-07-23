CREATE TABLE [dbo].[CV_Inscripciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPuesto] [int] NOT NULL,
	[IdPersona] [int] NOT NULL,
	[FechaInscripcion] [datetime] NOT NULL	
) 