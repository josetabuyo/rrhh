CREATE TABLE [dbo].[MAU_Items_De_Menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](256) NULL,
	[descripcion] [varchar](256) NULL,
	[idAccesoAUrl] [int] NOT NULL,
	[orden] [int] NULL,
	[idBaja] [int] NULL,
	[fechaBaja] [datetime] NULL
 CONSTRAINT [PK_MAU_Items_De_Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
) ON [PRIMARY]


