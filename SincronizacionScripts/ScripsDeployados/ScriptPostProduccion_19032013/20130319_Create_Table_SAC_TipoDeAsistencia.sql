USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[SAC_TipoAsistencia]    Script Date: 03/20/2013 20:06:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SAC_TipoAsistencia](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[valor] [smallint] NOT NULL,
	[idusuario] [smallint] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[idBaja] [int] NULL,
 CONSTRAINT [PK_SAC_TipoAsistencia] PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

