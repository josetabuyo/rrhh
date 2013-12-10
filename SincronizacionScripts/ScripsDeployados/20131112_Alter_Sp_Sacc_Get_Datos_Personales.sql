ALTER procedure[dbo].[SACC_Get_DatosPersonales] 
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
isnull(cd.IdLocalidad,'') IdLocalidad,
dp.FechaNacimiento,
desig_fecha.Fecha_Min FechaIngresoMDS,
al.IdModalidad,
da.Id_area						IdArea,
ta.descripcion					NombreArea,
al.idBaja BajaAlumno,
doc.idBaja BajaDocente

from dbo.CRED_PersonasRelevadas pr 
inner join  dbo.CRED_Domicilios cd on 
pr.Documento = cd.Documento
left join dbo.DatosPersonales dp ON
dp.Nrodocumento = pr.Documento
inner join dbo.CRED_Personas pe on
dp.Id = pe.id
left join dbo.Designaciones_Fechas desig_fecha ON
desig_fecha.Nro_Doc = dp.NroDocumento
left join dbo.SAC_Alumnos al ON
al.IdPersona = pe.Id
left join dbo.SAC_Docentes doc ON
doc.IdDocente = pe.Id
left join dbo.LEG_Desglose_Area as da
on pr.Documento = da.Documento
left join dbo.Tabla_Areas ta on
da.Id_Area = ta.id

 where pr.Documento = @DocumentoPersona
