USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Ins_Materia]    Script Date: 03/19/2013 20:28:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Ins_Materia]
(	
	@Nombre  [varchar](30),
	@IdModalidad  [smallint],	
	@Ciclo  [smallint] = 1,	
	@IdUsuario [smallint],
	@Fecha [smalldatetime],
	@Baja [int] = null
) 

AS
  
BEGIN

INSERT INTO dbo.SAC_Materias (Nombre, idModalidad, idusuario, Fecha, idBaja, idCiclo)
values
(	
	@Nombre,
	@IdModalidad,
	@IdUsuario,
	GETDATE(),
	@Baja,
	@Ciclo	
) 

END     
GO

