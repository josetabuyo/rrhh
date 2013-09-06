USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Upd_Del_Alumno]    Script Date: 03/19/2013 20:28:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Upd_Del_Alumno]
(	
	@IdPersona  [int],
	@IdModalidad  [int],
	@IdUsuario  [varchar](30),
	@Fecha [datetime],
	@IdBaja [int] = null	
) 

AS

BEGIN
    
UPDATE [dbo].[SAC_Alumnos]       
      
SET  
	[IdPersona]  = @IdPersona,      
	[IdModalidad]  = @IdModalidad,      
	[IdUsuario]  = @IdUsuario,      
	[Fecha]  = GETDATE(),
	[idBaja] = @IdBaja
      
WHERE       
	[IdPersona]  = @IdPersona  

END
GO

