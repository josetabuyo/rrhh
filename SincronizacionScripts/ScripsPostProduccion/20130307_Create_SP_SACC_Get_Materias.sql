CREATE PROCEDURE [dbo].[SACC_Get_Materias]

AS

BEGIN

select
mat.id							Id,	
mat.Nombre						Nombre,
mo.IdModalidad					IdModalidad,
mo.Descripcion					ModalidadDescripcion,
mat.Fecha						Fecha

From dbo.SAC_Materias mat
left join dbo.SAC_Modalidad as mo
on mat.idModalidad = mo.IdModalidad

where mat.Baja = 0

END
