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
		dp.TipoDocumento,
		dpAdd.IdSexo Sexo,
		dpadd.IdEstadoCivil EstadoCivil,
		dpadd.CUIL,
		dpadd.LugarNacimiento,
		dp.FechaNacimiento,
		dpadd.IdNacionalidad Nacionalidad,
		
		dom_pers.ID_Domicilio DomPers_Id, 
		dom_pers.Calle DomPers_Calle,
		dom_pers.Número DomPers_Numero,
		dom_pers.Piso DomPers_Piso,
		dom_lab.Dpto DomPers_Depto,
		dom_pers.Localidad DomPers_Localidad,
		dom_pers.Codigo_Postal DomPers_CodigoPostal,
		isnull(dom_pers.Provincia, 0) DomPers_IdProvincia,

		dom_lab.ID_Domicilio DomLab_Id,
		dom_lab.Calle DomLab_Calle,
		dom_lab.Número DomLab_Numero,
		dom_lab.Piso DomLab_Piso,
		dom_lab.Dpto DomLab_Depto,
		dom_lab.Localidad DomLab_Localidad,
		dom_lab.Codigo_Postal DomLab_CodigoPostal,
		isnull(dom_lab.Provincia, 0) DomLab_IdProvincia,
		CASE 
			WHEN TieneLegajo.idPersona is null THEN 'No tiene legajo'
			ELSE 'Tiene legajo'
			END AS TieneLegajo,
		CASE  
			WHEN cvdp.IdPersona is null THEN 'No tiene curriculum'
			ELSE 'Tiene curriculum'
			END AS TieneCurriculum
		
	FROM dbo.DatosPersonales dp
	LEFT JOIN dbo.CV_DatosPersonales cvdp
		ON cvdp.IdPersona = dp.Id
	LEFT JOIN dbo.DatosPersonalesAdicionales dpadd
		ON dpadd.IdPersona = dp.Id

	LEFT JOIN dbo.CV_Domicilios cv_dom_pers
		ON cv_dom_pers.IdPersona = dp.Id
			AND cv_dom_pers.Tipo = 1
	LEFT JOIN dbo.GEN_Domicilios dom_pers
		ON cv_dom_pers.Id_Domicilio = dom_pers.Id_Domicilio


	LEFT JOIN dbo.CV_Domicilios cv_dom_lab
		ON cv_dom_lab.IdPersona = dp.Id
			AND cv_dom_lab.Tipo = 2
	LEFT JOIN dbo.GEN_Domicilios dom_lab
		ON cv_dom_lab.Id_Domicilio = dom_lab.Id_Domicilio
		
		
	LEFT JOIN dbo.Datos_Personales TieneLegajo
		ON TieneLegajo.IdPersona = dp.Id

	WHERE 
		(dom_lab.DatoDeBaja = 0 OR dom_lab.DatoDeBaja IS NULL)
		and 
		(dom_pers.DatoDeBaja = 0 OR dom_pers.DatoDeBaja IS NULL) 
		and dp.NroDocumento = @NroDocumento
END


