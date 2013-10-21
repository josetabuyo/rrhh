CREATE TABLE [dbo].[VIA_RelacionesOrganigrama](
	[IdAreaPadre] [int] NOT NULL,
	[IdAreaHija] [int] NOT NULL,
	[APartirDe] [smalldatetime] NOT NULL,
	[PorElMotivo] [varchar](5000) COLLATE Modern_Spanish_CI_AS NOT NULL,
	[IdUsuario] [smallint] NOT NULL,
	[FechaDeCarga] [smalldatetime] NOT NULL,
 CONSTRAINT [PK_VIA_RelacionesOrganigrama] PRIMARY KEY CLUSTERED 
(
	[IdAreaHija] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[VIA_RelacionesOrganigrama]  WITH CHECK ADD  CONSTRAINT [FK_VIA_RelacionesOrganigrama_RH_Usuarios] FOREIGN KEY([IdUsuario])
REFERENCES [dbo].[RH_Usuarios] ([Id])
GO
ALTER TABLE [dbo].[VIA_RelacionesOrganigrama] CHECK CONSTRAINT [FK_VIA_RelacionesOrganigrama_RH_Usuarios]
GO
ALTER TABLE [dbo].[VIA_RelacionesOrganigrama]  WITH CHECK ADD  CONSTRAINT [FK_VIA_RelacionesOrganigrama_VIA_Areas] FOREIGN KEY([IdAreaPadre])
REFERENCES [dbo].[VIA_Areas] ([id])
GO
ALTER TABLE [dbo].[VIA_RelacionesOrganigrama] CHECK CONSTRAINT [FK_VIA_RelacionesOrganigrama_VIA_Areas]
GO
ALTER TABLE [dbo].[VIA_RelacionesOrganigrama]  WITH CHECK ADD  CONSTRAINT [FK_VIA_RelacionesOrganigrama_VIA_Areas1] FOREIGN KEY([IdAreaHija])
REFERENCES [dbo].[VIA_Areas] ([id])
GO
ALTER TABLE [dbo].[VIA_RelacionesOrganigrama] CHECK CONSTRAINT [FK_VIA_RelacionesOrganigrama_VIA_Areas1]