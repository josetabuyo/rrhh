CREATE TABLE [dbo].[VIA_PasajesHistorico](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPasaje] [int] NOT NULL,	
	[IdComision] [int] NOT NULL,
	[LocalidadOrigen] [int] NOT NULL,
	[LocalidadDestino] [int] NOT NULL,
	[Precio] [smallmoney] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[MedioDeTransporte] [smallint] NOT NULL,
	[MedioDePago] [smallint] NOT NULL,
	[Baja] [bit] NOT NULL,
	[Usuario] [smallint] NOT NULL,
	[FechaModificacion] [smalldatetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY]
)
GO