USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[CV_Usuarios_EmailRegistro]    Script Date: 09/17/2014 22:01:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CV_Usuarios_EmailRegistro](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Id_Usuario] [smallint] NOT NULL,
	[Id_Contacto] [int] NOT NULL
) ON [PRIMARY]

GO


