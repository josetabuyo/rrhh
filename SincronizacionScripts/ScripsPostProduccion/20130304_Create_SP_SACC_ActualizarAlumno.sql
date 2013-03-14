set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Objeto:  StoredProcedure [dbo].[SACC_GetTodosLosAlumnos]    Fecha de la secuencia de comandos: 02/27/2013 21:37:47 ******/

CREATE PROCEDURE [dbo].[SACC_ActualizarAlumno]
(	@IdPersona  [int],
	@IdModalidad  [int],
	@ModificadoPor  [varchar](30),
	@FechaModificacion [datetime] ) 

AS
  

IF EXISTS (SELECT * FROM dbo.SAC_Alumnos WHERE IdPersona = @IdPersona)
BEGIN
    
UPDATE [dbo].[SAC_Alumnos]       
      
SET  
	[IdPersona]  = @IdPersona,      
	[IdModalidad]  = @IdModalidad,      
	[ModificadoPor]  = @ModificadoPor,      
	[FechaModificacion]  = GETDATE()      
      
WHERE       
	[IdPersona]  = @IdPersona  

END
ELSE
BEGIN 
INSERT INTO dbo.SAC_Alumnos
values
(	@IdPersona,
	@IdModalidad,
	@ModificadoPor,
	GETDATE() ) 

END     
      
      