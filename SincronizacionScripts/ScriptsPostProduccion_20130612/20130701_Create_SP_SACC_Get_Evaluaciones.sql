CREATE PROCEDURE [dbo].[SACC_Get_Evaluaciones]

AS

BEGIN

SELECT	ev.id,
		ev.idInstanciaEvaluacion, 
		ie.Descripcion				DescripcionInstanciaEvaluacion,
		ev.idAlumno, 
		ev.idCurso, 
		ev.Calificacion, 
		ev.FechaEvaluacion
 
FROM [dbo].[SAC_Evaluaciones] ev
left join dbo.SAC_InstanciasDeEvaluaciones ie on
ev.idInstanciaEvaluacion = ie.id

WHERE ev.idBaja is null  
END
GO