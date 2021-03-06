USE [DB_RRHH]
GO
/****** Objeto:  Table [dbo].[SAC_Modalidad_InstanciasDeEvaluaciones]    Fecha de la secuencia de comandos: 06/14/2013 22:03:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SAC_Modalidad_InstanciasDeEvaluaciones](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[idModalidad] [int] NOT NULL,
	[idInstanciaEvaluacion] [smallint] NOT NULL,
 CONSTRAINT [PK_dbo.SAC_Modalidades_InstanciasDeEvaluaciones] PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[SAC_Modalidad_InstanciasDeEvaluaciones]  WITH CHECK ADD  CONSTRAINT [FK_Modalidades] FOREIGN KEY([idModalidad])
REFERENCES [dbo].[SAC_Modalidad] ([idModalidad])
GO
ALTER TABLE [dbo].[SAC_Modalidad_InstanciasDeEvaluaciones] CHECK CONSTRAINT [FK_Modalidades]
GO
ALTER TABLE [dbo].[SAC_Modalidad_InstanciasDeEvaluaciones]  WITH CHECK ADD  CONSTRAINT [FK_InstanciaEvaluacion] FOREIGN KEY([idInstanciaEvaluacion])
REFERENCES [dbo].[SAC_InstanciasDeEvaluaciones] ([id])
GO
ALTER TABLE [dbo].[SAC_Modalidad_InstanciasDeEvaluaciones] CHECK CONSTRAINT [FK_InstanciaEvaluacion]