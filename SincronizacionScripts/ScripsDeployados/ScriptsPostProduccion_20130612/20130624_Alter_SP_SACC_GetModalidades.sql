set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
GO
/****** Objeto:  StoredProcedure [dbo].[SACC_GetTodosLosAlumnos]    Fecha de la secuencia de comandos: 02/27/2013 21:37:47 ******/

ALTER PROCEDURE [dbo].[SACC_GetModalidades]

AS

BEGIN

select
		mo.IdModalidad		IdModalidad,
		mo.Descripcion		ModalidadDescripcion,
		ie.id				idInstancia,
		ie.Descripcion		DescripcionInstancia


FROM
dbo.SAC_Modalidad mo
inner join dbo.SAC_Modalidad_InstanciasDeEvaluaciones mi on
mo.IdModalidad = mi.IdModalidad
inner join dbo.SAC_InstanciasDeEvaluaciones ie on
mi.idInstanciaEvaluacion = ie.id


WHERE	ie.idBaja is null

ORDER BY mo.IdModalidad	

END


