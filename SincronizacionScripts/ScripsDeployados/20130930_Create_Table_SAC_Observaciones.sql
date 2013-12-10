CREATE TABLE [dbo].[SAC_Observaciones](
	[id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FechaCarga] [smalldatetime] NOT NULL,
	[Relacion] [varchar](100) NULL,
	[PersonaCarga] [varchar](100) NULL,
	[Pertenece] [varchar](100)  NULL,
	[Asunto] [varchar](100)  NULL,
	[ReferenteMDS] [varchar](100) NULL,
	[Seguimiento] [varchar](500) NULL,
	[Resultado] [varchar](500)  NULL,
	[FechaDelResultado] [smalldatetime]  NULL,
	[ReferenteRtaMDS] [varchar](100) NULL,
	[idUsuario] [smallint] NOT NULL,
	[idBaja][int] null
	)
	 