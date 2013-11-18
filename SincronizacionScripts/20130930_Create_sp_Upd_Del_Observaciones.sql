CREATE PROCEDURE [dbo].[SACC_Upd_Del_Observaciones]
(	
	@id int,
	@FechaCarga  smalldatetime,				
	@Relacion  varchar(100),					
	@PersonaCarga  varchar(100),				
	@Pertenece varchar(100),					
	@Asunto varchar(100),						
	@ReferenteMDS varchar(100),				
	@Seguimiento varchar(500),				
	@Resultado varchar(500),					
	@FechaDelResultado smalldatetime,			
	@ReferenteRtaMDS varchar(100),			
	@idUsuario smallint,						
	@id_baja int = null
) 

AS
    
UPDATE [dbo].[SAC_Observaciones]
	SET 		
		[FechaCarga] = @FechaCarga,
		[Relacion] = @Relacion,
		[PersonaCarga] = @PersonaCarga,
		[Pertenece] = @Pertenece,
		[Asunto] = @Asunto,
		[ReferenteMDS] = @ReferenteMDS,
		[Seguimiento] = @Seguimiento,
		[Resultado] = @Resultado,
		[FechaDelResultado] = @FechaDelResultado,
		[ReferenteRtaMDS] = @ReferenteRtaMDS,
		[idUsuario] = @idUsuario,
		[idBaja] = @id_baja		
	WHERE id = @id
	
	select @@ROWCOUNT