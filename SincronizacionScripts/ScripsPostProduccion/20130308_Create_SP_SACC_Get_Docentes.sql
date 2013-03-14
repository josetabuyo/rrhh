CREATE PROCEDURE [dbo].[SACC_Get_Docentes]

AS

BEGIN

select
pe.Id							Id,	
pe.Documento					Documento,
pe.Apellido						Apellido,
pe.Nombres						Nombre,
isnull(pr.Telefono,'')			Telefono,
isnull(pr.Email_personal,'')	Mail,
isnull(cd.Calle,'')	+  ' ' + isnull(cd.Numero,'') +  ' ' + isnull( 'Piso ' + cd.Piso,'') +  ' ' + isnull( 'Dto ' + cd.Depto,'')	 Direccion

From dbo.SAC_Docentes doc
inner join dbo.CRED_Personas pe on 
doc.IdDocente = pe.Id
inner join dbo.CRED_PersonasRelevadas pr on
pe.Documento = pr.Documento
inner join  dbo.CRED_Domicilios cd on 
pe.Documento = cd.Documento
--inner join dbo.Datos_Personales dp on
--pe.Documento = dp.Nro_Documento
--inner join RH_Usuarios_Areas_Web aw on
--dp.Id_Interna = aw.id
-- inner join dbo.tabla_areas ta on      
--  ta.id = aw.Id_Area      


WHERE doc.idBaja is null

END