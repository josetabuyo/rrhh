CREATE procedure dbo.MODI_GET_Datos_Personales_Por_Id_interna        
@id_interna int        
as        
SELECT dp.[Id_Interna],         
 [Apellido],         
 [Nombre],         
 P.Id_Planta Tipo_Planta , --   [Tipo_Planta],         
 [Sexo],         
 [Fecha_Nacimiento],        
 [Lugar_Nacimiento],         
 [Nacionalidad],         
 [Fecha_Ingreso_Pais],         
 [Carta_Ciudadania],         
 [Juzgado],         
 [Secretario],         
 [Fecha_Juzgado],         
 left(Cuil_Nro,2) +'-'+ right(left(Cuil_Nro,10),8) +'-'+ right(rtrim(Cuil_Nro),1) Cuil_Nro,         
 [Tipo_Documento],         
 [Nro_Documento],         
 [Distrito_Militar],         
 [Clase],         
 [Cedula_Identidad],         
 [Expedida_por],         
 [Regimen_Jubilatorio],         
 [Denominacion],         
 [Estado_Civil],         
 [Fecha_Matrimonio],         
 [Fecha_Matrimonio_2da],         
 [Grupo_Sanguineo],         
 [Factor_Sanguineo],         
 [Credencial],         
 [Obra_Social],         
 [Nro_Afiliado],         
 DP.[Usuario],        
 A.Id_Area ,        
 TA.Descripcion Area,        
 TP.descripcion Tipo_planta_Desc,    
 CASE WHEN month(DP.Fecha_Nacimiento) > month(getdate())  
 THEN datediff(yy,DP.Fecha_Nacimiento,getdate())-1    
 ELSE datediff(yy,DP.Fecha_Nacimiento,getdate())    
  END edad        
        
FROM [dbo].[Datos_Personales]DP        
        
inner join VW_Desglose_Area A        
 on A.documento=DP.nro_documento        
left join tabla_areas TA        
 on ta.id= a.Id_area        
        
LEFT JOIN dbo.VW_Desglose_Planta P        
 on P.Documento = DP.Nro_Documento        
left join dbo.tipo_de_planta TP        
 on TP.Id = p.id_planta        
        
where dp.Id_Interna=@id_interna        
        
        
        

