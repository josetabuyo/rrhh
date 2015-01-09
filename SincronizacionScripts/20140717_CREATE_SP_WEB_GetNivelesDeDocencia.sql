USE [DB_RRHH]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].WEB_GetNivelesDeDocencia 
AS

declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp

select Id, Descripcion 
from dbo.[Tabla_Nivel_Docencia]