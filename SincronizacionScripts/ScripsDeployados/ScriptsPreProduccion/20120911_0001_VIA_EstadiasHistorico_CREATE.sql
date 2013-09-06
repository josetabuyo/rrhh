SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[VIA_EstadiasHistorico](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdEstadia] [int] NOT NULL,
	[IdComision] [int] NOT NULL,
	[FechaDesde] [smalldatetime] NOT NULL,
	[FechaHasta] [smalldatetime] NOT NULL,
	[Provincia] [smallint] NOT NULL,
	[Eventual] [smallmoney] NOT NULL,
	[AdicPorPasaje] [smallmoney] NOT NULL,
	[CalculadoPorCategoria] [smallmoney] NOT NULL,
	[Motivo] [nvarchar](100) NULL,
	[Baja] [bit] NOT NULL,
	[Usuario] [smallint] NOT NULL,
	[FechaModificacion] [smalldatetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY])

GO