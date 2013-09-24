USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Upd_Del_Docente]    Script Date: 03/19/2013 20:28:59 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Upd_Del_Docente]
(	
	@IdDocente  [int],	
	@IdUsuario [smallint],
	@Fecha [datetime],
	@idBaja [int] = null
) 

AS
  
BEGIN
    
UPDATE [dbo].[SAC_Docentes]       
      
SET  	  
	[IdDocente] = @IdDocente,	
	[idUsuario]  = @IdUsuario,      
	[Fecha]  = GETDATE(),
	[idBaja] = @idBaja
      
WHERE       
	[IdDocente]  = @IdDocente  

END
GO

