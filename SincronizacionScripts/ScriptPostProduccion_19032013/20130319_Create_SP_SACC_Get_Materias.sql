USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Get_Materias]    Script Date: 03/19/2013 20:21:50 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SACC_Get_Materias]

AS

BEGIN

select
mat.id							Id,	
mat.Nombre						Nombre,
mo.IdModalidad					IdModalidad,
mo.Descripcion					ModalidadDescripcion,
mat.Fecha						Fecha,
cic.id							idCiclo,
cic.Nombre						NombreCiclo

From dbo.SAC_Materias mat
left join dbo.SAC_Modalidad as mo
on mat.idModalidad = mo.IdModalidad
left join dbo.SAC_Ciclos cic
on cic.id = mat.idCiclo

where mat.idBaja is null

END
GO

