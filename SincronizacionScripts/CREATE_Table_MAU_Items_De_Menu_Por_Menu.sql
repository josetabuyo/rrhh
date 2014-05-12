CREATE TABLE [dbo].[MAU_Items_De_Menu_Por_Menu](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_itemDeMenu] [int] NOT NULL,
	[id_menu] [int] NOT NULL,
	[idBaja] [int] NULL,
	[fechaBaja] [datetime] NULL
 CONSTRAINT [PK_MAU_Items_De_Menu_Por_Menu] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
) ON [PRIMARY]


