CREATE PROCEDURE [dbo].[SIC_GetDocumentos]  
AS  
BEGIN  
 SET NOCOUNT ON;  
 SELECT  
	 doc.Id						AS IdDocumento   
    ,doc.Numero					AS Numero
    ,doc.Extracto				AS Extracto    
    ,doc.Ticket					AS Ticket  
    ,doc.Comentarios			AS Comentarios  
    ,doc.Fecha					AS FechaCargaDocumento  
    ,areaOrigen.id				AS IdAreaOrigen  
    ,areaOrigen.descripcion		AS NombreAreaOrigen  
    ,areaDestino.id				AS IdAreaDestino  
    ,areaDestino.descripcion	AS NombreAreaDestino  
    ,td.Id						AS IdTipoDeDocumento  
    ,td.Descripcion				AS DescripcionTipoDocumento  
    ,cd.Id						AS IdCategoriaDeDocumento  
    ,cd.Descripcion				AS DescripcionCategoria  
    
    
    FROM  dbo.SIC_Documentos doc  
    INNER JOIN dbo.SIC_TipoDeDocumento td ON
    doc.IdTipoDeDocumento = td.Id
    INNER JOIN dbo.SIC_CategoriaDeDocumento cd ON
    doc.IdCategoria = cd.Id
    LEFT JOIN dbo.Tabla_Areas areaOrigen ON    
     doc.IdAreaOrigen = areaOrigen.id  
    LEFT JOIN dbo.Tabla_Areas areaDestino ON  
     doc.IdAreaDestino = areaDestino.id 

    ORDER BY doc.Id
    
    END
GO