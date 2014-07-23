
CREATE TABLE [dbo].[CV_Puesto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Familia] [varchar](100) NULL,
	[Profesion] [varchar](100) NULL,
	[Denominacion] [varchar](100) NULL,
	[Nivel] [varchar](10) NULL,
	[Agrupamiento] [varchar](100) NULL,
	[Vacantes] [int] NULL,
	[Tipo] [varchar](50) NULL,
	[Fecha] [datetime] NULL
) 
