CREATE PROCEDURE [dbo].[SACC_Ins_Materia]
(	
	@IdMateria  [smallint] = 0,
	@Nombre  [varchar](30),
	@IdModalidad  [smallint],	
	@IdUsuario [smallint],
	@Fecha [smalldatetime] 
) 

AS
  

IF EXISTS (SELECT * FROM dbo.SAC_Materias WHERE id = @IdMateria)
BEGIN
    
UPDATE [dbo].[SAC_Materias]       
      
SET  	     
	[Nombre]  = @Nombre,  
	[idModalidad] = @IdModalidad,    
	[idusuario]  = @IdUsuario,      
	[Fecha]  = GETDATE()      
      
WHERE       
	[id]  = @IdMateria  

END
ELSE
BEGIN 
INSERT INTO dbo.SAC_Materias (Nombre, idModalidad, idusuario, Fecha)
values
(	
	@Nombre,
	@IdModalidad,
	@IdUsuario,
	GETDATE() 
) 

END     