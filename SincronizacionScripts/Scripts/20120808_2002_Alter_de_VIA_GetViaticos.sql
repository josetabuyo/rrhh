 -- =============================================  
-- Author: AZA
-- ALTER  date: 08/08/2012  
-- Description: Trae todos los Viáticos  
-- Description:  
-- =============================================  
  
ALTER PROCEDURE [dbo].[VIA_GetViaticos]  
AS  
BEGIN  
 SET NOCOUNT ON;  
 SELECT  CS.[Id]      AS Id     
    ,CS.[Baja]     AS Baja  
    ,TA.id      AS IdAreaCreadora  
    ,TA.descripcion    AS DescripcionAreaCreadora  
    ,DP.Nombre     AS Persona_Nombre  
    ,DP.Apellido    AS Persona_Apellido  
    ,DP.Nro_Documento   AS Persona_Documento  
    ,TAP.id      AS Persona_Area_Id  
    ,TAP.descripcion   AS Persona_Area_Descripcion  
    ,E.Id      AS Estadia_Id  
    ,E.FechaDesde    AS Estadia_Desde  
    ,E.FechaHasta    AS Estadia_Hasta  
    ,Pr.idProvincia    AS Estadia_Provincia_Id  
    ,Pr.nombreProvincia   AS Estadia_Provincia_Nombre  
    ,E.Eventual     AS Estadia_Eventuales  
    ,E.AdicPorPasaje   AS Estadia_AdicionalParaPasajes  
    ,E.CalculadoPorCategoria AS Estadia_CalculadoPorCategoria  
    ,E.Motivo     AS Estadia_Motivo  
    ,P.Id      AS Pasaje_Id  
    ,LO.idLocalidad    AS Pasaje_LocalidadOrigen_Id  
    ,LO.nombrelocalidad   AS Pasaje_LocalidadOrigen_Nombre  
    ,LD.idLocalidad    AS Pasaje_LocalidadDestino_Id  
    ,LD.nombrelocalidad   AS Pasaje_LocalidadDestino_Nombre  
    ,P.Fecha     AS Pasaje_FechaDeViaje  
    ,MT.Id      AS Pasaje_MedioDeTransporte_Id  
    ,MT.Nombre     AS Pasaje_MedioDeTransporte_Nombre  
    ,MP.Id      AS Pasaje_MedioDePago_Id  
    ,MP.Nombre     AS Pasaje_MedioDePago_Nombre  
    ,P.Precio     AS Pasaje_Precio  
    ,H.id      AS Transicion_Id  
    ,TAO.id      AS Transicion_AreaOrigen_Id  
    ,TAO.descripcion   AS Transicion_AreaOrigen_Descripcion  
    ,TAD.id      AS Transicion_AreaDestino_Id  
    ,TAD.descripcion   AS Transicion_AreaDestino_Descripcion  
    ,H.accion     AS Transicion_Accion  
    ,H.fecha     AS Transicion_Fecha  
    ,H.comentario    AS Transicion_Comentario,
    TADD.Telefono As Telefono_Area,
    DP.Cuil_Nro As Cuil_Persona,
    DP.Id_Interna As Legajo_Persona,
    
    
     niv.nivel   Nivel_Funcion,  
 gra.grado   Grado_Rango,
 CASE CTR.Tipo_contrato
 when 1 then 'Contrato 1421'
 WHEN 2 then 'Contrato 1184'
 END  AS Categoria_Persona
      
 FROM  VIA_ComisionesDeServicio CS   
    LEFT JOIN dbo.tabla_areas TA ON    
     CS.IdAreaCreadora = TA.id  
    LEFT JOIN dbo.Datos_Personales DP ON  
     CS.DocumentoAgente = DP.Nro_Documento  
    LEFT JOIN dbo.vw_desglose_area DA ON    
     DP.id_interna = DA.id_interna    
    LEFT JOIN dbo.tabla_areas TAP ON    
     TAP.id = DA.id_area    
     
    LEFT JOIN dbo.tabla_areas_detalle TADD
    on TADD.id_area = TAP.id
     
    LEFT JOIN VIA_Estadias E ON  
     CS.Id = E.IdComision  
    LEFT JOIN Provincias Pr ON  
     E.Provincia = Pr.codAFIP  
    LEFT JOIN VIA_Pasajes P ON  
     CS.Id = P.IdComision  
    LEFT JOIN LocalidadesAFIP LO ON  
     P.LocalidadOrigen = LO.idLocalidad  
    LEFT JOIN LocalidadesAFIP LD ON  
     P.LocalidadDestino = LD.idLocalidad  
    LEFT JOIN VIA_MediosDeTransporte MT ON  
     P.MedioDeTransporte = MT.Id  
    LEFT JOIN VIA_MediosDePago MP ON  
     P.MedioDePago = MP.Id  
    LEFT JOIN VIA_Prototipo_Historial_Comision_De_Servicio H ON  
     CS.Id = H.id_viatico  
    LEFT JOIN dbo.tabla_areas TAO ON    
     TAO.id = H.id_area_origen    
    LEFT JOIN dbo.tabla_areas TAD ON    
     TAD.id = H.id_area_destino 
    LEFT JOIN dbo.Ctr_contratos CTR
    on CTR.Nro_documento = DP.Nro_documento
   LEFT join dbo.vw_desglose_nivelGrado vwng on  
	dp.id_interna = vwng.id_interna  
	LEFT join dbo.tabla_niveles niv on  
	niv.id = vwng.id_nivel  
	LEFT join dbo.tabla_grados gra on  
	gra.id = vwng.id_grado  
	LEFT join dbo.vw_desglose_planta vwdp on  
	dp.id_interna = vwdp.id_interna  
	LEFT join dbo.tipo_de_planta pla on  
	vwdp.id_planta = pla.id       
                 
    WHERE CTR.BAJA = 0
 ORDER BY CS.Id     
      
      
END  