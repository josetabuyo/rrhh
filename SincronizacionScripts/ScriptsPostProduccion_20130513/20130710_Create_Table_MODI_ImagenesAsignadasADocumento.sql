USE [DB_RRHH]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MODI_ImagenesAsignadasADocumento](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[idDocumento] [smallint] NOT NULL,
	[tabla] [varchar](30) NOT NULL,
	[nombre_imagen] [varchar](50) NOT NULL,
	[bytes_imagen] [text] NOT NULL
PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


