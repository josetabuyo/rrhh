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
