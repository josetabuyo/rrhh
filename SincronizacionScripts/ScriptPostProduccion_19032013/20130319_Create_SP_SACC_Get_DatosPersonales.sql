USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Get_DatosPersonales]    Script Date: 03/19/2013 20:20:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SACC_Get_DatosPersonales] 
@DocumentoPersona int
as
select 
pe.Id,
pr.Documento,
pr.Apellido,
pr.Nombre,
isnull(pr.Lugar_de_trabajo,'') LugarDeTrabajo,
isnull(pr.Telefono,'') Telefono,
isnull(pr.Email_mds, '') Email_MDS,
isnull(pr.Email_personal,'') Email_Personal,
isnull(pr.Fecha_comunicacion,'') FechaDeComunicacion,
isnull(cd.Calle,'')	+  ' ' + isnull(cd.Numero,'') +  ' ' + isnull( 'Piso ' + cd.Piso,'') +  ' ' + isnull( 'Dto ' + cd.Depto,'') Direccion,
--isnull(cd.Calle,'') Calle,
--isnull(cd.Numero,'') Numero,
--isnull(cd.Piso,'') Piso,
--isnull(cd.Depto,'') Depto,
--isnull(cd.Casa,'') Casa,
--isnull(cd.Manzana,'') Manzana,
--isnull(cd.Torre, '') Torre,
--isnull(cd.Uf, '') Uf,
--isnull(cd.Codigo_postal, '') CodigoPostal,
--isnull(cd.Localidad,'') Localidad,
isnull(cd.Barrio,'') Barrio,
isnull(cd.IdLocalidad,'') IdLocalidad

from dbo.CRED_PersonasRelevadas pr 
inner join  dbo.CRED_Domicilios cd on 
pr.Documento = cd.Documento
inner join dbo.CRED_Personas pe on
pr.Documento = pe.Documento
 where pr.Documento = @DocumentoPersona







GO

