USE DB_RRHH
GO

BEGIN tran


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[Ctl_Acreditacion]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
	DROP TABLE [dbo].[Ctl_Acreditacion]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_Autorizacion]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
	DROP TABLE [dbo].[CtlAcc_Autorizacion]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_Motivo]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
	DROP TABLE [dbo].[CtlAcc_Motivo]
GO



CREATE TABLE [dbo].[CtlAcc_Motivo](
	[IdMotivo] tinyint not null primary key,
	[Motivo] [varchar](32) NOT NULL,
) ON [PRIMARY]
GO


	INSERT [dbo].[CtlAcc_Motivo]( [IdMotivo], [Motivo] )
	SELECT 1 as IdMotivo, 'Reunión de trabajo' as Motivo
	UNION ALL 
	SELECT 2 as IdMotivo, 'Audiencia' as Motivo
	UNION ALL 
	SELECT 3 as IdMotivo, 'Capacitación' as Motivo
	UNION ALL 
	SELECT 4 as IdMotivo, 'Trámites varios' as Motivo
	UNION ALL 
	SELECT 5 as IdMotivo, 'Visita' as Motivo
	UNION ALL 
	SELECT 6 as IdMotivo, 'Entrevista' as Motivo
	GO



CREATE TABLE [dbo].[CtlAcc_Autorizacion](
	[IdAutorizacion] [int] NOT NULL primary key,
	[Fecha] [smalldatetime] NOT NULL,
	[IdFuncionario] [int] NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Telefono] [int] NOT NULL,
	[IdMotivo] [tinyint] NOT NULL foreign key references [dbo].[CtlAcc_Motivo] (IdMotivo),
	[Lugar] [varchar] (64) NOT NULL,
	[Representa] [varchar] (64) NOT NULL,
	[Acompanantes] [tinyint] NOT NULL,
	[Log_UserId] [int] not null,
	[Log_Fecha] smalldatetime not null default( getdate() ),
	[Log_IP] varchar(16) not null default(''), 

) ON [PRIMARY]
GO


CREATE TABLE [dbo].[Ctl_Acreditacion](
	[IdAcreditacion] int primary key,
	[IdAutorizacion] int foreign key references [dbo].[CtlAcc_Autorizacion] (IdAutorizacion),
	[NroCredencial] varchar(64) not null,
	[Log_UserId] int not null,
	[Log_Fecha] smalldatetime not null default( getdate() ),
	[Log_IP] varchar(16) not null default(''), 
)
GO






/*********************************************************************************************************/
/*********************************************************************************************************/
/*********************************************************************************************************/


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_SEL_Funcionario]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[CtlAcc_SEL_Funcionario]
GO

CREATE 
PROCEDURE dbo.CtlAcc_SEL_Funcionario 
(
	@IdUser int
)
AS
BEGIN

	SELECT	1, 'NOVOA', 'MARTA', 0, 'Dra.', 43790000, 'Dir.RRHH - MDS - Piso 21 - Ala Belgrano.'
	union all
	SELECT	2, 'SPINAZZOLA', 'GUSTAVO', 0, 'Dr.', 43790000, 'Dir.RRHH - MDS - Piso 21 - Ala Moreno.'

END
GO



IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_SEL_Motivo]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[CtlAcc_SEL_Motivo]
GO

CREATE 
PROCEDURE dbo.CtlAcc_SEL_Motivo
AS
BEGIN

	SELECT	[IdMotivo], [Motivo]
	FROM	[dbo].[CtlAcc_Motivo]

END
GO







/*********************************************************************************************************/
/*********************************************************************************************************/
/*********************************************************************************************************/


-- ROLLBACK tran
COMMIT tran






