
DROP TABLE [dbo].[VIA_Prototipo_Historial_Comision_De_Servicio]
GO


/****** Object:  Table [dbo].[VIA_Prototipo_Historial_Comision_De_Servicio]    Script Date: 08/30/2012 21:52:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING OFF
GO

CREATE TABLE [dbo].[VIA_Transiciones_De_Viaticos](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[id_viatico] [int] NOT NULL,
	[id_area_origen] [int] NOT NULL,
	[id_area_destino] [int] NOT NULL,
	[id_accion] [int] NOT NULL,
	[fecha] [datetime] NOT NULL,
	[comentario] [varchar](2048) NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


