CREATE PROCEDURE [dbo].[SACC_Ins_Observacion]
(	
	@FechaCarga  [smalldatetime],				
	@Relacion  [varchar](100),					
	@PersonaCarga  [varchar](100),				
	@Pertenece [varchar](100),					
	@Asunto [varchar](100),						
	@ReferenteMDS [varchar](100),				
	@Seguimiento [varchar](500),				
	@Resultado [varchar](500),					
	@FechaDelResultado [smalldatetime],			
	@ReferenteRtaMDS [varchar](100),			
	@idUsuario [smallint],						
	@idBaja [int] = null
) 

AS
  
BEGIN

INSERT INTO [dbo].[SAC_Observaciones] (
			[FechaCarga], 
			[Relacion], 
			[PersonaCarga], 
			[Pertenece], 
			[Asunto], 
			[ReferenteMDS], 
			[Seguimiento], 
			[Resultado], 
			[FechaDelResultado], 
			[ReferenteRtaMDS], 
			[idUsuario],
			[idBaja]) 
values
(	
	 @FechaCarga,  
	 @Relacion,  
	 @PersonaCarga, 
	 @Pertenece,
	 @Asunto, 
	 @ReferenteMDS, 
	 @Seguimiento, 
	 @Resultado, 
	 @FechaDelResultado,
	 @ReferenteRtaMDS,
	 @idUsuario,
	 @idBaja
)	
	select @@ROWCOUNT
END 