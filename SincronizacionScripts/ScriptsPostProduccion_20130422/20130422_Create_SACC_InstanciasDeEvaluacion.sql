CREATE TABLE [dbo].[SAC_InstanciasDeEvaluaciones](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](30) NULL,
	[idUsuario] [smallint] NULL,
	[fecha] [datetime] NULL,
	[idBaja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]