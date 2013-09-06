USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Ins_Horario]    Script Date: 03/19/2013 20:24:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SACC_Ins_Horario]
(	
	@nro_dia_semana  [smallint],
	@id_curso [smallint],
	@desde  [varchar](4),	
	@hasta [varchar](4)
) 

AS

INSERT INTO dbo.SAC_Horarios (NroDiaSemana, idCurso, Desde, Hasta)
values
(	
	@nro_dia_semana,
	@id_curso,
	@desde,
	@hasta
)
SELECT SCOPE_IDENTITY()
GO

