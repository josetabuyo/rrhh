USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[SAC_Bajas]    Script Date: 03/19/2013 20:03:00 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SAC_Bajas](
	[IdBaja] [int] IDENTITY(1,1) NOT NULL,
	[Motivo] [varchar](50) NULL,
	[IdUsuario] [smallint] NOT NULL,
	[Fecha] [datetime] NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

