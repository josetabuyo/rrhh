/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/

CREATE TABLE [dbo].[SAC_Materias](
	[id] [smallint] NOT NULL IDENTITY,
	[Nombre] [varchar](50) NOT NULL,
	[idModalidad] [smallint] NOT NULL,
	[idusuario] [smallint] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[Baja] [bit] NOT NULL,
 CONSTRAINT [PK_SAC_Materias] PRIMARY KEY CLUSTERED 
(
	[id] ASC
) ON [PRIMARY]
) ON [PRIMARY]


