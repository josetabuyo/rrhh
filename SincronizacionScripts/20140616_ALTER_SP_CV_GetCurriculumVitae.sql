ALTER PROCEDURE [dbo].[CV_GetCurriculumVitae] 
(
	@NroDocumento int
)
AS
BEGIN
	SELECT 
		dp.Id IdPersona,
		dp.Nombre,
		dp.Apellido,
		sex.Descripcion Sexo,
		eciv.Descripcion EstadoCivil,
		dpadd.CUIL,
		dpadd.LugarNacimiento,
		dp.FechaNacimiento,
		nac.Id Nacionalidad,

		dom_pers.Calle DomPers_Calle,
		dom_pers.Número DomPers_Numero,
		dom_pers.Piso DomPers_Piso,
		dom_lab.Dpto DomPers_Depto,
		dom_pers_afip.NombreLocalidad DomPers_Localidad,
		dom_pers.Codigo_Postal DomPers_CodigoPostal,
		isnull(prov_pers.IdProvincia, 0) DomPers_IdProvincia,

		dom_lab.Calle DomLab_Calle,
		dom_lab.Número DomLab_Numero,
		dom_lab.Piso DomLab_Piso,
		dom_lab.Dpto DomLab_Depto,
		dom_lab_afip.NombreLocalidad DomLab_Localidad,
		dom_lab.Codigo_Postal DomLab_CodigoPostal,
		isnull(prov_lab.IdProvincia, 0) DomLab_IdProvincia
	FROM dbo.DatosPersonales dp
	INNER JOIN dbo.CV_DatosPersonales cvdp
		ON cvdp.IdPersona = dp.Id
	INNER JOIN dbo.DatosPersonalesAdicionales dpadd
		ON dpadd.IdPersona = dp.Id
	INNER JOIN dbo.Tabla_Sexo sex
		ON sex.Id = dpAdd.IdSexo
	INNER JOIN dbo.Tabla_Nacionalidad nac
		ON nac.Id = dpadd.IdNacionalidad
	INNER JOIN dbo.Tabla_Estado_Civil eciv
		ON eciv.Id = dpadd.IdEstadoCivil


	INNER JOIN dbo.CV_Domicilios cv_dom_pers
		ON cv_dom_pers.IdPersona = dp.Id
			AND cv_dom_pers.Tipo = 1
	INNER JOIN dbo.GEN_Domicilios dom_pers
		ON cv_dom_pers.Id_Domicilio = dom_pers.Id_Domicilio
	LEFT JOIN dbo.Provincias prov_pers
		ON prov_pers.idProvincia = dom_pers.Provincia
	LEFT JOIN dbo.LocalidadesAFIP dom_pers_afip
		ON dom_pers_afip.idLocalidad = dom_pers.Localidad


	INNER JOIN dbo.CV_Domicilios cv_dom_lab
		ON cv_dom_lab.IdPersona = dp.Id
			AND cv_dom_lab.Tipo = 2
	INNER JOIN dbo.GEN_Domicilios dom_lab
		ON cv_dom_lab.Id_Domicilio = dom_lab.Id_Domicilio
	LEFT JOIN dbo.Provincias prov_lab
		ON prov_lab.idProvincia = dom_lab.Provincia
	LEFT JOIN dbo.LocalidadesAFIP dom_lab_afip
		ON dom_lab_afip.idLocalidad = dom_lab.Localidad

	WHERE 
		dom_lab.DatoDeBaja = 0
		and dom_pers.DatoDeBaja = 0
		and dp.NroDocumento = @NroDocumento
END

