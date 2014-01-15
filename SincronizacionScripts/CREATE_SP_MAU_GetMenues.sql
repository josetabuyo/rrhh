CREATE PROCEDURE dbo.MAU_GetMenues
	@id_menu int = null
AS
BEGIN  

  SELECT MM.[id]				IdMenu
        ,MM.[menu]				NombreMenu
        ,MIM.[id]				IdItemMenu
        ,MIM.[nombre]			NombreItemMenu
        ,MIM.[descripcion]		DescripcionItemMenu
        ,MIM.[idAccesoAUrl]		IdAccesoAUrl
        ,MIM.[orden]			OrdenItemMenu
  FROM [dbo].[MAU_Menues] MM
  LEFT JOIN [dbo].[MAU_Items_De_Menu_Por_Menu] MIMM ON
	     MM.Id = MIMM.Id_Menu
  LEFT JOIN [dbo].[MAU_Items_De_Menu] MIM ON
	     MIM.Id = MIMM.Id_ItemDeMenu
  WHERE (MM.id = @id_menu or @id_menu is null) AND	   
		 MM.idBaja is null AND MIM.idBaja is null	
END

