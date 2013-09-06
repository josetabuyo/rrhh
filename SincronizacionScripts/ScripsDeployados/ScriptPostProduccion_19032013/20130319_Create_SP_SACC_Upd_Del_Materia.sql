USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Upd_Del_Materia]    Script Date: 03/19/2013 20:30:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Upd_Del_Materia]
(	
	@IdMateria  [smallint] = 0,
	@Nombre  [varchar](30),
	@IdModalidad  [smallint],
	@Ciclo  [smallint] = 1,		
	@IdUsuario [smallint],
	@Fecha [smalldatetime],
	@IdBaja [int] = null	
) 

AS

BEGIN
    
UPDATE [dbo].[SAC_Materias]       
      
SET  	     
	[Nombre]  = @Nombre,  
	[idModalidad] = @IdModalidad,    
	[idusuario]  = @IdUsuario,      
	[Fecha]  = GETDATE(),
	[idBaja] = @IdBaja,
	[idCiclo] = @Ciclo
      
WHERE       
	[id]  = @IdMateria  

END
GO

