CREATE PROCEDURE [dbo].[SIC_GetCategoriasDeDocumento]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		cd.Id Id,
		cd.Descripcion Descripcion
	FROM
		dbo.SIC_CategoriaDeDocumento cd
	ORDER BY 
		cd.Id

END