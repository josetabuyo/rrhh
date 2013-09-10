USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[SAC_Ciclos]    Script Date: 03/19/2013 20:03:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SAC_Ciclos](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[idusuario] [smallint] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[idBaja] [int] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

