/*CAMBIAR PUESTO POR PERFIL*/
/*1ro Buscar todos los elementos de la base que se llamen Puesto  */
--adm_buscar_string 'puesto'

/*Resultado*/
/* select * from cv_postulaciones select * from CV_EtapasPostulaciones
Tipo||Nombre
----------------------------
F 	fk_puesto_agrupamiento
F 	fk_puesto_estudios
F 	fk_puesto_familia
F 	fk_puesto_profesion
F 	fk_puesto_tipos
P 	CV_Get_Postulaciones ---CV_Get_Postulaciones2
P 	CV_Get_Puestos-- CV_Get_Perfiles
P 	CV_Ins_Postulaciones--VER
P 	CV_Upd_Del_ExperienciasLaborales-- revisar
P 	CV_Upd_Del_Postulacion -- Revisar
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
--select * from dbo.cv_postulaciones
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




/**/


begin tran
go
/*

SET IDENTITY_INSERT dbo.CV_FamiliaPerfiles ON
SET IDENTITY_INSERT dbo.CV_ProfesionPerfiles ON
SET IDENTITY_INSERT dbo.CV_AgrupamientoPerfiles ON
SET IDENTITY_INSERT dbo.CV_TipoPerfiles ON
SET IDENTITY_INSERT dbo.CV_EstudioPerfiles ON
SET IDENTITY_INSERT dbo.CV_Perfil ON

SET IDENTITY_INSERT dbo.CV_FamiliaPerfiles OFF
SET IDENTITY_INSERT dbo.CV_ProfesionPerfiles OFF
SET IDENTITY_INSERT dbo.CV_AgrupamientoPerfiles OFF
SET IDENTITY_INSERT dbo.CV_TipoPerfiles OFF
SET IDENTITY_INSERT dbo.CV_EstudioPerfiles OFF
SET IDENTITY_INSERT dbo.CV_Perfil OFF

*/

insert into dbo.CV_FamiliaPerfiles (Descripcion,Baja) select Descripcion,Baja from dbo.CV_FamiliaPuestos
go
insert into dbo.CV_ProfesionPerfiles (Descripcion,Baja) select Descripcion,Baja from dbo.CV_ProfesionPuestos
go
insert into dbo.CV_AgrupamientoPerfiles (Descripcion,Baja) select Descripcion,Baja from  dbo.CV_AgrupamientoPuestos
go
insert into dbo.CV_TipoPerfiles (Descripcion,Baja) select Descripcion,Baja from  dbo.CV_TipoPuestos
go
insert into dbo.CV_EstudioPerfiles (Descripcion,Baja) select Descripcion,Baja from  dbo.CV_EstudioPuestos
go
insert into dbo.CV_Perfil (Denominacion,Nivel,Vacantes,Fecha,id_comite,Numero,IdFamilia,IdProfesion,IdAgrupamiento,IdTipoPerfil,IdEstudio) select Denominacion,Nivel,Vacantes,Fecha,id_comite,Numero,IdFamilia,IdProfesion,IdAgrupamiento,1,IdEstudio from  dbo.CV_Puesto

go

rollback
--commit

/*
select * from  dbo.CV_FamiliaPuestos
select * from  dbo.CV_ProfesionPuestos
select * from  dbo.CV_AgrupamientoPuestos
select * from  dbo.CV_TipoPuestos
select * from  dbo.CV_EstudioPuestos
select * from  dbo.CV_Perfil

*/


/*2 Crear Stored Procedures*/
go

CREATE PROCEDURE [dbo].[CV_Get_Postulaciones2]    
(      
 @idPersona int = null  
)      
AS    
BEGIN    
    
 SELECT     
  postu.Id IdPostulacion,    
  postu.IdPersona,    
  postu.Motivo,    
  postu.Observaciones,    
  postu.Numero Postulacion_Numero,    
  postu.FechaInscripcion,    
      
  perfil.Id IdPerfil,    
 -- puesto.Familia,    
  fp.Descripcion Familia,  
    
 --puesto.Profesion,    
  pp.Descripcion Profesion,  
    
  perfil.Denominacion,    
  perfil.Nivel,    
    
 --puesto.Agrupamiento,    
 ap.Descripcion Agrupamiento,   
    
  perfil.Vacantes,    
    
 --puesto.Tipo,    
  tp.Descripcion Tipo,  
      
  perfil.Numero Puesto_Numero,    
      
  com.Id IdComite,    
  com.Numero NumeroDeComite,    
  com.Integrantes IntegrantesDelComite,  
  etapCon.Id IdEtapa,  
  etapCon.Descripcion EtapaDescripcion,  
  etapPos.Fecha FechaPostulacion,  
  etapPos.IdUsuario IdUsuarioPostulacion  
  
 FROM dbo.CV_Postulaciones postu    
 --INNER JOIN dbo.CV_Puesto puesto 
 INNER JOIN dbo.CV_perfil perfil    
 ON perfil.Id = postu.IdPuesto    
 INNER JOIN dbo.CV_Comite com    
 ON com.Id = perfil.id_comite    
     
 INNER join  dbo.CV_FamiliaPuestos fp  
 on fp.id =  perfil.IdFamilia  
   
 INNER JOIN dbo.CV_ProfesionPuestos pp  
 on pp.Id = perfil.IdProfesion  
   
 INNER JOIN dbo.CV_AgrupamientoPuestos ap  
 on ap.Id = perfil.IdAgrupamiento    
     
 INNER JOIN dbo.CV_TipoPuestos tp  
 on tp.Id = perfil.IdTipoPerfil    
  
 INNER JOIN dbo.CV_EstudioPuestos ep  
 on ep.Id = perfil.IdEstudio    
  

 LEFT JOIN CV_EtapasPostulaciones etapPos  
 ON etapPos.IdPostulacion = postu.Id  
 LEFT JOIN CV_EtapasConcurso etapCon  
 ON etapPos.IdEtapa = etapCon.Id  
   
   
  
where (postu.IdPersona = @idPersona or @idPersona is null)  
and postu.Baja is null  
     
END  
  

GO

  
CREATE PROCEDURE [dbo].[CV_Get_Perfiles]       
    
AS    
BEGIN    
    
 SELECT     
  per.Id IdPerfil,    

  fp.Descripcion Familia,  

  pp.Descripcion Profesion,  
    
  per.Denominacion,    
  per.Nivel,    

  ap.Descripcion Agrupamiento, --   
  per.Vacantes,    

  tp.Descripcion Tipo,  
  per.Fecha,    
  per.Numero NumeroDePuesto,    
 
  ep.Descripcion Estudio,  
  com.Id IdComite,    
  com.Numero NumeroDeComite,  
  com.Integrantes IntegrantesDelComite  
       
  FROM dbo.CV_perfil per    
  INNER JOIN dbo.CV_Comite com on    
  per.id_comite = com.Id    
    
 INNER JOIN dbo.CV_FamiliaPuestos fp  
on  per.IdFamilia=fp.id  
 INNER JOIN dbo.CV_ProfesionPuestos pp  
on per.IdProfesion= pp.id  
 INNER JOIN dbo.CV_AgrupamientoPuestos ap  
on per.IdAgrupamiento= ap.id  
 INNER JOIN dbo.CV_TipoPuestos tp  
on  per.IdTipoPerfil= tp.id  
   
 INNER JOIN dbo.CV_EstudioPuestos ep  
on per.IdEstudio=ep.id  
  
   
END    
    
GO
    
 

   
    
    
    
    
    
    
    
    
    
  





















