USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[SAC_InstanciasDeEvaluaciones]    Script Date: 05/27/2013 20:15:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

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

GO

SET ANSI_PADDING OFF
GO


