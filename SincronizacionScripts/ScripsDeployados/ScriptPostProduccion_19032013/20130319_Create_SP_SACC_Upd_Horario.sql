USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Upd_Horario]    Script Date: 03/19/2013 20:30:31 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SACC_Upd_Horario]
(	
	@id_horario [smallint] = 0,
	@nro_dia_semana  [smallint],
	@desde  [varchar](4),	
	@hasta [varchar](4)
) 

AS
    
UPDATE [dbo].[SAC_Horarios]       
      
SET  	  
	[NroDiaSemana] = @nro_dia_semana,
	[Desde] = @desde,
	[Hasta] = @hasta
WHERE       
	[id]  = @id_horario
GO

