USE [DB_RRHH]
GO
/****** Object:  Table [dbo].[MAU_Accesos_A_URL]    Script Date: 10/06/2014 20:23:51 ******/
SET IDENTITY_INSERT [dbo].[MAU_Accesos_A_URL] ON
INSERT [dbo].[MAU_Accesos_A_URL] ([id], [url], [idBaja], [fechaBaja]) VALUES (22, N'/WebRH/FormularioConcursar/EtapasPostulacion.aspx', NULL, NULL)
SET IDENTITY_INSERT [dbo].[MAU_Accesos_A_URL] OFF

/****** Object:  Table [dbo].[MAU_Funcionalidades]    Script Date: 10/06/2014 20:23:51 ******/
SET IDENTITY_INSERT [dbo].[MAU_Funcionalidades] ON
INSERT [dbo].[MAU_Funcionalidades] ([Id], [Nombre], [IdBaja], [FechaBaja]) VALUES (14, N'etapas_postular', NULL, NULL)
SET IDENTITY_INSERT [dbo].[MAU_Funcionalidades] OFF

/****** Object:  Table [dbo].[MAU_Items_De_Menu]    Script Date: 10/06/2014 20:23:51 ******/
SET IDENTITY_INSERT [dbo].[MAU_Items_De_Menu] ON
INSERT [dbo].[MAU_Items_De_Menu] ([id], [nombre], [descripcion], [idAccesoAUrl], [orden], [idBaja], [fechaBaja], [padre]) VALUES (19, N'Etapas Postular', N'Cambiar las etapas de las postulaciones', 22, 6, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MAU_Items_De_Menu] OFF

/****** Object:  Table [dbo].[MAU_Items_De_Menu_Por_Menu]    Script Date: 10/06/2014 20:23:51 ******/
SET IDENTITY_INSERT [dbo].[MAU_Items_De_Menu_Por_Menu] ON
INSERT [dbo].[MAU_Items_De_Menu_Por_Menu] ([id], [id_itemDeMenu], [id_menu], [idBaja], [fechaBaja]) VALUES (19, 19, 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[MAU_Items_De_Menu_Por_Menu] OFF

/****** Object:  Table [dbo].[MAU_Accesos_A_Url_Por_Funcionalidad]    Script Date: 10/06/2014 20:23:51 ******/
SET IDENTITY_INSERT [dbo].[MAU_Accesos_A_Url_Por_Funcionalidad] ON
INSERT [dbo].[MAU_Accesos_A_Url_Por_Funcionalidad] ([Id], [IdAccesoAUrl], [IdFuncionalidad]) VALUES (22, 22, 14)
SET IDENTITY_INSERT [dbo].[MAU_Accesos_A_Url_Por_Funcionalidad] OFF
