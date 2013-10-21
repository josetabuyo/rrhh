
CREATE TABLE [dbo].[VIA_ExcepcionesCircuitos](
	[id] [int] NOT NULL,
	[id_circuito] [int] NOT NULL,
	[id_origen] [int] NOT NULL,
	[id_destino] [int] NOT NULL,
 CONSTRAINT [PK_VIA_ExcepcionesCircuitos] PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


