USE [DB_RRHH]
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Tabla_Nivel_Docencia](
	[Id] [smallint] NOT NULL,
	[Descripcion] [nvarchar](50) NULL,
	[Baja] [bit] NOT NULL,
	[orden] [smallint] NULL)
GO

SET ANSI_PADDING OFF
GO

