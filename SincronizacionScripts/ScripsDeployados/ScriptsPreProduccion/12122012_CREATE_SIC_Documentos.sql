CREATE TABLE [dbo].[SIC_Documentos](
	[Id] [int] primary key IDENTITY(1,1) NOT NULL,
	[IdTipoDeDocumento] [int] NOT NULL,
	[Numero] [nvarchar](50) NOT NULL,
	[IdCategoria] [int] NOT NULL,
	[IdAreaOrigen] [int] NOT NULL,
	[Extracto] [nvarchar](1000) NOT NULL,
	[Ticket] [nvarchar](6) NOT NULL,
	[IdAreaDestino] [int], 
	[Comentarios] [nvarchar](1000),
	[IdUsuario] [smallint] NOT NULL,
	[Fecha] [datetime]
)



