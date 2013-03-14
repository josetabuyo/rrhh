CREATE PROCEDURE [dbo].[SACC_Upd_Del_Materia]
(	
	@IdMateria  [smallint] = 0,
	@Nombre  [varchar](30),
	@IdModalidad  [smallint],	
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
	[idBaja] = @IdBaja
      
WHERE       
	[id]  = @IdMateria  

END
