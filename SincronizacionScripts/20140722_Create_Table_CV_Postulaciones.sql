CREATE TABLE [dbo].[CV_Postulaciones](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPuesto] [int] NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Motivo][varchar](500) NULL,
	[Observaciones][varchar](500)NULL,
	[FechaInscripcion] [datetime] NOT NULL
) 