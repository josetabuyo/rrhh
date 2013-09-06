CREATE TABLE [dbo].[SAC_Accesos_Sistema](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[menu] [varchar](64) NULL,
	[url] [varchar](128) NULL,
	[nombre_item] [varchar](128) NULL,
	[idbaja] [int] NULL,
	[fecha] [datetime] NULL,
	[orden] [smallint] NULL,
	[padre] [smallint] NULL,
 CONSTRAINT [PK_SAC_Accesos_Sistema] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)