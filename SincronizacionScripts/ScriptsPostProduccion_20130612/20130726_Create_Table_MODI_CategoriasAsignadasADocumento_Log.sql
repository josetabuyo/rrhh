USE [DB_RRHH]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[MODI_CategoriasAsignadasADocumento_Log](
	[id_log] [int] IDENTITY(1,1) NOT NULL,
	[id_registro_actualizado] [int] NOT NULL,
	[id_categoria] [int] NOT NULL,
	[id_documento] [int] NULL,
	[tabla] [varchar](30) NULL,
	[id_usuario_ultima_modificacion] [int] NULL,
	[fecha_ultima_modificacion] [datetime] NULL
PRIMARY KEY CLUSTERED 
(
	[id_log] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO