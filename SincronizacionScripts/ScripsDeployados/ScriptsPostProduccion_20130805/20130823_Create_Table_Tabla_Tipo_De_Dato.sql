USE [DB_RRHH]
GO
/****** Objeto:  Table [dbo].[Tabla_Tipo_De_Dato]    Fecha de la secuencia de comandos: 08/23/2013 21:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tabla_Tipo_De_Dato](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](30) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
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