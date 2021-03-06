/****** Objeto:  Table [dbo].[VIA_ContactosArea]    Fecha de la secuencia de comandos: 10/11/2012 21:19:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO 
CREATE TABLE [dbo].[VIA_ContactosArea](
	[Id_Area] [int] NOT NULL,
	[DNI] [int] NOT NULL,
	[Baja] [bit] NOT NULL,
	[Nro_Orden] [int] NULL,
	[Indicador_Cargo] [int] NULL,
	[Telefono] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Fax] [varchar](20) COLLATE SQL_Latin1_General_CP1_CI_AS NULL,
	[Mail] [varchar](50) COLLATE SQL_Latin1_General_CP1_CI_AS NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF