CREATE PROCEDURE [dbo].[SACC_Get_Accesos_Sistema]

AS

BEGIN

	select id, menu, url, nombre_item as nombre, orden, padre
	from [dbo].[SAC_Accesos_Sistema]  A
	where A.idbaja is null

END
