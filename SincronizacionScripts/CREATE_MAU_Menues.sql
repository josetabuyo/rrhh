CREATE TABLE [dbo].[MAU_Menues](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[menu] [varchar](255) NULL,
	[idbaja] [int] NULL,
	[fecha] [datetime] NULL
 CONSTRAINT [PK_MAU_Menues] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
) ON [PRIMARY]
