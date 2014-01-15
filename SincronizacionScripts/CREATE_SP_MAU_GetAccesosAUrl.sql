CREATE PROCEDURE dbo.MAU_GetMenues
	@id_menu int = null
AS
BEGIN  

  SELECT MM.[id]				IdMenu
        ,MM.[menu]				NombreMenu
        ,MIM.[id]				IdItemMenu
        ,MIM.[nombre]			NombreItemMenu
        ,MIM.[descripcion]	DescripcionItemMenu
        ,MIM.[idAccesoAUrl]	IdAccesoAUrl
  FROM [dbo].[MAU_Menues] MM
  LEFT JOIN [dbo].[MAU_Items_De_Menu_Por_Menu] MIMM ON
	     MM.Id = MIMM.IdMenu
  LEFT JOIN [dbo].[MAU_Items_De_Menu] MIM ON
	     MIM.Id = MIMM.IdItemMenu
  WHERE (MM.id = @id_menu or @id_menu is null) AND	   
		 MM.idBaja is null AND MIM.idBaja is null	
END


