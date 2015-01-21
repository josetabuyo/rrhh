USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[LIC_LogErroresCalculoLicencia]    Script Date: 12/16/2014 20:49:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[LIC_LogErroresCalculoLicencia](
	[documento] [int] NULL,
	[apellido] [varchar](100) NULL,
	[nombre] [varchar](100) NULL,
	[anio_minimo_imputable] [smallint] NULL,
	[anio_maximo_imputable] [smallint] NULL,
	[cantidad_de_dias_imputables] [smallint] NULL,
	[fecha_desde_solicitada] [smalldatetime] NULL,
	[fecha_hasta_solicitada] [smalldatetime] NULL,
	[fecha_de_calculo] [smalldatetime] NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


