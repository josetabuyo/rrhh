Create Procedure dbo.CV_GetNivelesCompetenciasInformaticas
AS

select Id, Descripcion
from dbo.CV_NivelesCompetenciasInformaticas 
where Baja = 0


