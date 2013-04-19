USE [DB_RRHH]
GO
/****** Objeto:  Table [dbo].[SAC_InstanciasDeEvaluaciones]    Fecha de la secuencia de comandos: 04/16/2013 18:54:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SAC_InstanciasDeEvaluaciones](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[fechaEvaluacion] [datetime] NOT NULL,
	[Descripcion] [char](30),
	[idUsuario] [char](30) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[fecha] [datetime] NULL,
	[idBaja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
