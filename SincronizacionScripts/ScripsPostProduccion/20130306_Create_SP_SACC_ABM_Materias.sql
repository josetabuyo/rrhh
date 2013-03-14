CREATE PROCEDURE [dbo].[SACC_ABM_Materia]
(	
	@IdMateria  [smallint] = 0,
	@Nombre  [varchar](30),
	@IdModalidad  [smallint],	
	@IdUsuario [smallint],
	@Fecha [smalldatetime],
	@Baja [bit] = 0	
) 

AS
  

IF EXISTS (SELECT * FROM dbo.SAC_Materias WHERE id = @IdMateria)
BEGIN
    
UPDATE [dbo].[SAC_Materias]       
      
SET  	     
	[Nombre]  = @Nombre,  
	[idModalidad] = @IdModalidad,    
	[idusuario]  = @IdUsuario,      
	[Fecha]  = GETDATE(),
	[Baja] = @Baja
      
WHERE       
	[id]  = @IdMateria  

END
ELSE
BEGIN 
INSERT INTO dbo.SAC_Materias (Nombre, idModalidad, idusuario, Fecha, Baja)
values
(	
	@Nombre,
	@IdModalidad,
	@IdUsuario,
	GETDATE(),
	@Baja	
) 

END     