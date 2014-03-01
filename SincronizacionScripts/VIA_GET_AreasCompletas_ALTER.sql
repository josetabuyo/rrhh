ALTER procedure[dbo].[VIA_GetAreasCompletas]
	@id_area int = null,      
	@id_usuario_administrador int = null
AS


declare @NombreSp varchar(60) 
set @NombreSp = (select OBJECT_NAME(@@PROCID))
exec dbo.Audit @NombreSp

BEGIN

	SELECT 
		ta.id_area,
		ta.descripcion,
		isnull(dap2.Apellido, '')			  		    Apellido_Responsable,
		isnull(dap2.Nombre, '')							Nombre_Responsable,
		isnull(	   (tad.Calle	+ ' ' + 
					tad.Nro		+ ' ' + 
(CASE tad.Piso WHEN '' then '' else ' Piso ' + tad.Piso end)
					+ 
(CASE tad.Dpto WHEN '' then '' else ' Dto ' + tad.Dpto end)
					+
					' - ('		+ convert(varchar(10), localAfip.codigopostal, 103) + 
					') '		+ localAfip.nombrelocalidad + 
					' - '		+ prov.nombreProvincia
			   ), '') AS								direccion,
		isnull(dp2.Apellido, '')						Apellido_Asistente,
		isnull(dp2.Nombre, '')							Nombre_Asistente,
		isnull(ca.Telefono, '')							Telefono_Asistente,
		isnull(ca.Fax, '')								Fax_Asistente,
		isnull(ca.Mail, '')								Mail_Asistente, 
		isnull(tdc.Descripcion, '')						Cargo,
		isnull(ca.Nro_orden, 1)							Prioridad_Asistente, 
		isnull(dca.Tipo_Dato, 0)						Id_Dato_Area,
		isnull(ttd.Descripcion, '')					    Descripcion_Dato_Area,
		isnull(dca.Dato, '')							Dato_Area,
		isnull(dca.Orden, 0)							Orden
	
	FROM
		dbo.tabla_areas_estructura							ta
		left join  dbo.Tabla_Areas_Detalle					tad on
			tad.Id_Area =  ta.Id_Area
			and tad.Baja <> 1

		LEFT JOIN dbo.LocalidadesAFIP						localAfip ON 
			tad.Localidad = localAfip.idLocalidad
			and localAfip.baja <>1 
		LEFT JOIN dbo.Partidos								partidos ON 
			localAfip.ID_Partido = partidos.Partido
			and partidos.Baja = 'N'
		LEFT JOIN dbo.Provincias							prov ON 
			prov.codAFIP = localAfip.id_provincia



		left join  dbo.Tabla_Areas_DatosContacto			dca on
			dca.Id_Area =  ta.Id_Area 
			and dca.baja <> 1
		left join dbo.Tabla_Tipo_De_Dato					ttd on
			ttd.id = dca.Tipo_Dato
		left join  dbo.Tabla_Areas_Asistentes				ca	on 
			ca.Id_Area =  ta.Id_area 
			and ca.Baja <> 1
		left join  dbo.Tabla_Areas_Descripcion_Cargos		tdc on 
			tdc.id = ca.Indicador_Cargo 
			and tdc.Baja <> 1
		left join  dbo.DatosPersonales						dp2	on
			dp2.NroDocumento =  ca.DNI
		left JOIN dbo.Datos_Personales						DP	ON 
			DP.IdPersona = DP2.Id  			  	  	         
		left join dbo.Tabla_Firmantes						fir on
			fir.Area = ta.Id_area 
			and fir.Baja <> 1
		left join  dbo.DatosPersonales						dap2 on
			dap2.NroDocumento =  fir.Nro_Documento 
		LEFT JOIN dbo.Datos_Personales						DAP	ON 
			DAP.IdPersona = DAP2.Id  
		LEFT JOIN RH_Usuarios_Areas_Web						UAW ON
			ta.id_area = UAW.Id_Area
	
	WHERE		ta.baja = 0 AND
				(ta.id_area = @id_area OR @id_area is null) AND
				(UAW.Id_Usuario = @id_usuario_administrador OR @id_usuario_administrador is null)
	

		
end



