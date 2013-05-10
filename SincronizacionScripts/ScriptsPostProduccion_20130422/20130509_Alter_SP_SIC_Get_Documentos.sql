ALTER PROCEDURE [dbo].[SIC_GetDocumentos]  
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
    ,td.Id						AS IdTipoDeDocumento  
    ,td.Descripcion				AS DescripcionTipoDocumento         
    ,cd.Id						AS IdCategoriaDeDocumento  
    ,cd.Descripcion				AS DescripcionCategoria  
    ,td.Sigla		            AS SiglaTipoDocumento  
    
    FROM  dbo.SIC_Documentos doc  
    INNER JOIN dbo.SIC_TipoDeDocumento td ON
    doc.IdTipoDeDocumento = td.Id
    INNER JOIN dbo.SIC_CategoriaDeDocumento cd ON
    doc.IdCategoria = cd.Id

    ORDER BY doc.Id
    
    END

