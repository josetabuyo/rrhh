CREATE PROCEDURE [dbo].[SACC_Upd_Del_Docente]
(	
	@IdDocente  [smallint],	
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
