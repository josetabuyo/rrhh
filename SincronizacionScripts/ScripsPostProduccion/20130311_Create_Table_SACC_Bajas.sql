CREATE TABLE [dbo].[SAC_Bajas](
	[IdBaja] [int] NOT NULL Identity,
	[Motivo] [varchar](50),	
	[IdUsuario] [smallint] NOT NULL,
	[Fecha] [datetime] NOT NULL,
)	