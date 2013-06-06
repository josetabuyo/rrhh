/****** Object:  Table [dbo].[SAC_Accesos_Sistema]    Script Date: 06/05/2013 22:23:01 ******/
SET IDENTITY_INSERT [dbo].[SAC_Accesos_Sistema] ON
INSERT [dbo].[SAC_Accesos_Sistema] ([id], [menu], [url], [nombre_item], [nivel], [idbaja], [fecha], [orden], [padre]) VALUES (1, CONVERT(TEXT, N'SACC'), CONVERT(TEXT, N'FormABMMaterias.aspx'), CONVERT(TEXT, N'Materias'), 2, NULL, CAST(0x0000A1D200000000 AS DateTime), 3, 0)
INSERT [dbo].[SAC_Accesos_Sistema] ([id], [menu], [url], [nombre_item], [nivel], [idbaja], [fecha], [orden], [padre]) VALUES (2, CONVERT(TEXT, N'SACC'), CONVERT(TEXT, N'FormABMCursos.aspx'), CONVERT(TEXT, N'Cursos'), 2, NULL, CAST(0x0000A1D200000000 AS DateTime), 5, 0)
INSERT [dbo].[SAC_Accesos_Sistema] ([id], [menu], [url], [nombre_item], [nivel], [idbaja], [fecha], [orden], [padre]) VALUES (3, CONVERT(TEXT, N'SACC CENARD'), CONVERT(TEXT, N'FormABMCursos.aspx'), CONVERT(TEXT, N'Cursos'), 2, NULL, CAST(0x0000A1D200000000 AS DateTime), 1, 0)
INSERT [dbo].[SAC_Accesos_Sistema] ([id], [menu], [url], [nombre_item], [nivel], [idbaja], [fecha], [orden], [padre]) VALUES (4, CONVERT(TEXT, N'SACC'), CONVERT(TEXT, N'FormABMAlumnos.aspx'), CONVERT(TEXT, N'Alumnos'), 2, NULL, CAST(0x0000A1D400000000 AS DateTime), 1, 0)
INSERT [dbo].[SAC_Accesos_Sistema] ([id], [menu], [url], [nombre_item], [nivel], [idbaja], [fecha], [orden], [padre]) VALUES (5, CONVERT(TEXT, N'SACC'), CONVERT(TEXT, N'FormABMEspaciosFisicos.aspx'), CONVERT(TEXT, N'Espacios Físicos'), 2, NULL, CAST(0x0000A1D400000000 AS DateTime), 2, 0)
SET IDENTITY_INSERT [dbo].[SAC_Accesos_Sistema] OFF
