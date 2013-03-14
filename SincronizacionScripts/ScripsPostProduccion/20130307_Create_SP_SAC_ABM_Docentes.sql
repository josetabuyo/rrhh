CREATE PROCEDURE [dbo].[SACC_ABM_Docente]
(	
	@IdDocente  [smallint] = 0,
	@NroDocumento  [int],
	@Apellido  [varchar](50),	
	@Nombre [varchar](50),
	@IdUsuario [smallint],
	@Fecha [datetime],
	@Baja [bit] = 0	
) 

AS
  

IF EXISTS (SELECT * FROM dbo.SAC_Docentes WHERE id = @IdDocente)
BEGIN
    
UPDATE [dbo].[SACC_ABM_Docente]       
      
SET  	  
	[NroDocumento] = @NroDocumento,
	[Apellido] = @Apellido,    
	[Nombre]  = @Nombre,  	
	[idUsuario]  = @IdUsuario,      
	[FechaModificacion]  = GETDATE(),
	[Baja] = @Baja
      
WHERE       
	[id]  = @IdDocente  

END
ELSE
BEGIN 
INSERT INTO dbo.SAC_Docentes (NroDocumento, Apellido, Nombre, IdUsuario, FechaModificacion, Baja)
values
(	
	@NroDocumento,
	@Apellido,
	@Nombre,
	@IdUsuario,
	GETDATE(),
	@Baja	
) 

END   