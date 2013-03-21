USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Ins_Alumno]    Script Date: 03/19/2013 20:23:25 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Ins_Alumno]
(	
	@IdPersona  [int],
	@IdModalidad  [int],
	@IdUsuario  [varchar](30),
	@Fecha [datetime],
	@IdBaja [int] = null	
) 

AS
  
BEGIN

INSERT INTO dbo.SAC_Alumnos
values
(	
	@IdPersona,
	@IdModalidad,
	@IdUsuario,
	GETDATE(),
	@IdBaja
) 

END   
GO

