USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Del_Horarios]    Script Date: 03/19/2013 20:18:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SACC_Del_Horarios]
(	
	@id_curso [smallint] = 0
) 

AS
    
DELETE [dbo].[SAC_Horarios] WHERE idCurso = @id_curso

GO

