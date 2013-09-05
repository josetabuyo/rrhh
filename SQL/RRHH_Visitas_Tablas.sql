USE [Acceso]
GO

BEGIN TRAN

CREATE TABLE [dbo].[AutAcc_Personas](
	[IdPersona] [int] NOT NULL,
	[Apellido] [varchar](16) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Nombre] [varchar](16) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[TipoDoc] [tinyint] NOT NULL,
	[Documento] [int] NOT NULL,
	[Tratamiento] [varchar](16) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Telefono] [int] NOT NULL,
	PRIMARY KEY CLUSTERED ( [IdPersona] ASC )
		WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[AutAcc_Organismo](
	[IdOrganismo] [tinyint] NOT NULL,
	[Organismo] [varchar](64) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PRIMARY KEY CLUSTERED ( [IdOrganismo] ASC ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

CREATE TABLE [dbo].[AutAcc_Funcionario](
	[IdFuncionario] [int] NOT NULL,
	[IdOrganismo] [tinyint] NOT NULL,
	CONSTRAINT [PK_Funcionario] PRIMARY KEY CLUSTERED ( [IdFuncionario] ASC ) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AutAcc_Funcionario]  WITH CHECK ADD FOREIGN KEY([IdFuncionario])
REFERENCES [dbo].[AutAcc_Personas] ([IdPersona])
GO

ALTER TABLE [dbo].[AutAcc_Funcionario]  WITH CHECK ADD FOREIGN KEY([IdOrganismo])
REFERENCES [dbo].[AutAcc_Organismo] ([IdOrganismo])
GO

CREATE TABLE [dbo].[AutAcc_Motivo](
	[IdMotivo] [tinyint] NOT NULL,
	[Motivo] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	PRIMARY KEY CLUSTERED ( [IdMotivo] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[AutAcc_Autorizacion](
	[IdAutorizacion] [int] NOT NULL,
	[IdFuncionario] [int] NOT NULL,
	[FechaDesde] [smalldatetime] NOT NULL,
	[FechaHasta] [smalldatetime] NOT NULL,
	[IdPersona] [int] NOT NULL,
	[IdMotivo] [tinyint] NOT NULL,
	[Lugar] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Representa] [varchar](32) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL,
	[Acomp] [tinyint] NOT NULL DEFAULT ((0)),
	[UserId] [uniqueidentifier] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL DEFAULT (getdate()),
	[IP] [varchar](16) COLLATE SQL_Latin1_General_CP1_CI_AS NOT NULL DEFAULT (''),
	PRIMARY KEY CLUSTERED ( [IdAutorizacion] ASC )
		WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[AutAcc_Autorizacion]  WITH CHECK ADD FOREIGN KEY([IdFuncionario])
REFERENCES [dbo].[AutAcc_Funcionario] ([IdFuncionario])
GO
ALTER TABLE [dbo].[AutAcc_Autorizacion]  WITH CHECK ADD FOREIGN KEY([IdMotivo])
REFERENCES [dbo].[AutAcc_Motivo] ([IdMotivo])
GO
ALTER TABLE [dbo].[AutAcc_Autorizacion]  WITH CHECK ADD FOREIGN KEY([IdPersona])
REFERENCES [dbo].[AutAcc_Personas] ([IdPersona])
GO
ALTER TABLE [dbo].[AutAcc_Autorizacion]  WITH CHECK ADD FOREIGN KEY([UserId])
REFERENCES [dbo].[aspnet_Users] ([UserId])


ROLLBACK TRAN

