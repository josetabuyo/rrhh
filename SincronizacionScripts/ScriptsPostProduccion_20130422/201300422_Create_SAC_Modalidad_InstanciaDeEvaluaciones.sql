/****** Object:  Table [dbo].[SAC_Modalidad_InstanciaDeEvaluaciones]    Script Date: 04/22/2013 20:44:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[SAC_Modalidad_InstanciaDeEvaluaciones](
	[id] [smallint] NOT NULL,
	[idInstanciaEvaluacion] [smallint] NOT NULL,
	[idModalidad] [int] NOT NULL,
 CONSTRAINT [PK_dbo.SAC_Modalidad_InstanciaDeEvaluaciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[SAC_Modalidad_InstanciaDeEvaluaciones]  WITH CHECK ADD  CONSTRAINT [FK_InstanciaEvaluacion] FOREIGN KEY([idInstanciaEvaluacion])
REFERENCES [dbo].[SAC_InstanciasDeEvaluaciones] ([id])
GO

ALTER TABLE [dbo].[SAC_Modalidad_InstanciaDeEvaluaciones] CHECK CONSTRAINT [FK_InstanciaEvaluacion]
GO

ALTER TABLE [dbo].[SAC_Modalidad_InstanciaDeEvaluaciones]  WITH CHECK ADD  CONSTRAINT [FK_Modalidad] FOREIGN KEY([idModalidad])
REFERENCES [dbo].[SAC_Modalidad] ([IdModalidad])
GO

ALTER TABLE [dbo].[SAC_Modalidad_InstanciaDeEvaluaciones] CHECK CONSTRAINT [FK_Modalidad]
GO


