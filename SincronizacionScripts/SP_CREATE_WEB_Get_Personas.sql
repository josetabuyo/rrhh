CREATE procedure [dbo].[WEB_Get_Personas]            
as      

SELECT 
 dp.id ID,
 dp.legajo Legajo,         
 dp.[Apellido],         
 dp.[Nombre],           
 dp.FechaNacimiento [Fecha_Nacimiento],               
 dp.TipoDocumento Tipo_Documento,         
 dp.NroDocumento Nro_Documento        
        
FROM [dbo].datosPersonales DP        	     
        
        




