/*CAMBIAR PUESTO POR PERFIL*/
/*1ro Buscar todos los elementos de la base que se llamen Puesto  */
--adm_buscar_string 'puesto'

/*Resultado*/
/*
Tipo||Nombre
----------------------------
F 	fk_puesto_agrupamiento
F 	fk_puesto_estudios
F 	fk_puesto_familia
F 	fk_puesto_profesion
F 	fk_puesto_tipos
P 	CV_Get_Postulaciones
P 	CV_Get_Puestos
P 	CV_Get_Puestos_aza
P 	CV_GetCurriculumVitae
P 	CV_GetCurriculumVitae_aza
P 	CV_GetCurriculumVitae_orig
P 	CV_Ins_ExperienciasLaborales
P 	CV_Ins_Postulaciones
P 	CV_Upd_Del_ExperienciasLaborales
P 	CV_Upd_Del_Postulacion
PK	PK__CV_EstudioPuesto__120C0F7E
PK	PK__CV_FamiliaPuesto__02C9CBEE
PK	PK__CV_TipoPuestos__0E3B7E9A
U 	CV_AgrupamientoPuestos
U 	CV_EstudioPuestos
U 	CV_FamiliaPuestos
U 	CV_ProfesionPuestos
U 	CV_Puesto
U 	CV_TipoPuestos
UQ	UQ__CV_EstudioPuesto__130033B7
UQ	UQ__CV_FamiliaPuesto__03BDF027
UQ	UQ__CV_TipoPuestos__0F2FA2D3
*/

/*2) Generar scripts de creación de tablas con el nombre de columna nuevo   */


CREATE TABLE [dbo].[CV_FamiliaPerfiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Baja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CV_ProfesionPerfiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Baja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO


SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CV_AgrupamientoPerfiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Baja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CV_TipoPerfiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Baja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CV_EstudioPerfiles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](100) NULL,
	[Baja] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Descripcion] ASC
) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CV_Perfil](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Denominacion] [varchar](100) NULL,
	[Nivel] [varchar](10) NULL,
	[Vacantes] [int] NULL,
	[Fecha] [datetime] NULL,
	[id_comite] [int] NULL,
	[Numero] [varchar](100) NULL,
	[IdFamilia] [int] NULL,
	[IdProfesion] [int] NULL,
	[IdAgrupamiento] [int] NULL,
	[IdTipoPerfil] [int] NULL,
	[IdEstudio] [int] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[CV_AgrupamientoPerfiles] ADD  DEFAULT (0) FOR [Baja]
GO
ALTER TABLE [dbo].[CV_EstudioPerfiles] ADD  DEFAULT (0) FOR [Baja]
GO
ALTER TABLE [dbo].[CV_FamiliaPerfiles] ADD  DEFAULT (0) FOR [Baja]
GO
ALTER TABLE [dbo].[CV_ProfesionPerfiles] ADD  DEFAULT (0) FOR [Baja]
GO
ALTER TABLE [dbo].[CV_TipoPerfiles] ADD  DEFAULT (0) FOR [Baja]
GO
ALTER TABLE [dbo].[CV_Perfil]  WITH CHECK ADD  CONSTRAINT [fk_perfil_agrupamiento] FOREIGN KEY([IdAgrupamiento])
REFERENCES [dbo].[CV_AgrupamientoPerfiles] ([Id])
GO
ALTER TABLE [dbo].[CV_Perfil] CHECK CONSTRAINT [fk_perfil_agrupamiento]
GO
ALTER TABLE [dbo].[CV_Perfil]  WITH CHECK ADD  CONSTRAINT [fk_perfil_estudios] FOREIGN KEY([IdEstudio])
REFERENCES [dbo].[CV_EstudioPerfiles] ([Id])
GO
ALTER TABLE [dbo].[CV_Perfil] CHECK CONSTRAINT [fk_perfil_estudios]
GO
ALTER TABLE [dbo].[CV_Perfil]  WITH CHECK ADD  CONSTRAINT [fk_perfil_familia] FOREIGN KEY([IdFamilia])
REFERENCES [dbo].[CV_FamiliaPerfiles] ([Id])
GO
ALTER TABLE [dbo].[CV_Perfil] CHECK CONSTRAINT [fk_perfil_familia]
GO
ALTER TABLE [dbo].[CV_Perfil]  WITH CHECK ADD  CONSTRAINT [fk_perfil_profesion] FOREIGN KEY([IdProfesion])
REFERENCES [dbo].[CV_ProfesionPerfiles] ([Id])
GO
ALTER TABLE [dbo].[CV_Perfil] CHECK CONSTRAINT [fk_perfil_profesion]
GO
ALTER TABLE [dbo].[CV_Perfil]  WITH CHECK ADD  CONSTRAINT [fk_perfil_tipos] FOREIGN KEY([IdTipoPerfil])
REFERENCES [dbo].[CV_TipoPerfiles] ([Id])
GO
ALTER TABLE [dbo].[CV_Perfil] CHECK CONSTRAINT [fk_perfil_tipos]
GO

















