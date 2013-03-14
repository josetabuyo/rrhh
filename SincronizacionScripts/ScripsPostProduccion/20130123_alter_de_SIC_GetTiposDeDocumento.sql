alter PROCEDURE [dbo].[SIC_GetTiposDeDocumento]
	-- Add the parameters for the stored procedure here
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
		td.Id Id,
		td.Descripcion Descripcion,
		td.Sigla Sigla
	FROM
		dbo.SIC_TipoDeDocumento td
	ORDER BY 
		td.Id

END
