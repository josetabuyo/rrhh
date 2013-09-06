
CREATE TABLE [dbo].[SAC_HistoricoEvaluaciones](
	[id] [smallint] IDENTITY(1,1) NOT NULL,
	[idInstanciaEvaluacion] [smallint] NOT NULL,
	[idAlumno] [int] NOT NULL,
	[idCurso] [smallint] NOT NULL,
	[Calificacion] [varchar](30) NULL,
	[idUsuario] [smallint] NULL,
	[fechaEvaluacion] [datetime] NULL,
	[fecha] [datetime] NULL,
	[idBaja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[SAC_Evaluaciones]  WITH CHECK ADD FOREIGN KEY([idAlumno])
REFERENCES [dbo].[SAC_Alumnos] ([IdPersona])
GO

ALTER TABLE [dbo].[SAC_Evaluaciones]  WITH CHECK ADD FOREIGN KEY([idCurso])
REFERENCES [dbo].[SAC_Cursos] ([Id])
GO

ALTER TABLE [dbo].[SAC_Evaluaciones]  WITH CHECK ADD FOREIGN KEY([idInstanciaEvaluacion])
REFERENCES [dbo].[SAC_InstanciasDeEvaluaciones] ([id])
GO


