USE [DB_RRHH]
GO

/****** Object:  Table [dbo].[SAC_Articuladores]    Script Date: 03/19/2013 20:02:27 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SAC_Articuladores](
	[idUsuario] [smallint] NOT NULL,
 CONSTRAINT [PK_SAC_Articuladores] PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SAC_Articuladores]  WITH CHECK ADD  CONSTRAINT [FK_SAC_Articuladores_RH_Usuarios] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[RH_Usuarios] ([Id])
GO

ALTER TABLE [dbo].[SAC_Articuladores] CHECK CONSTRAINT [FK_SAC_Articuladores_RH_Usuarios]
GO

