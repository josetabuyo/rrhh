USE DB_RRHH
GO

BEGIN tran


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_Acreditacion]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
	DROP TABLE [dbo].[CtlAcc_Acreditacion]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_AutorizacionFecha]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
	DROP TABLE [dbo].[CtlAcc_AutorizacionFecha]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_Autorizacion]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
	DROP TABLE [dbo].[CtlAcc_Autorizacion]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_Motivo]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
	DROP TABLE [dbo].[CtlAcc_Motivo]
GO


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_PersonaVisita]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
	DROP TABLE [dbo].[CtlAcc_PersonaVisita]
GO


CREATE TABLE dbo.CtlAcc_PersonaVisita (
	IdPersona	int primary key,
	Apellido	varchar(32) ,
	Nombre		varchar(64) ,
	Documento	int			,
)
GO

CREATE NONCLUSTERED INDEX IX_PersonaVisita_Apellido ON dbo.CtlAcc_PersonaVisita (Apellido);
GO

CREATE NONCLUSTERED INDEX IX_PersonaVisita_Nombre ON dbo.CtlAcc_PersonaVisita (Nombre);
GO

CREATE NONCLUSTERED INDEX IX_PersonaVisita_Documento ON dbo.CtlAcc_PersonaVisita (Documento);
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
	[IdFuncionario] [int] NOT NULL,
	[IdPersona] [int] NOT NULL,
	[Telefono] [bigint] NOT NULL,
	[IdMotivo] [tinyint] NOT NULL foreign key references [dbo].[CtlAcc_Motivo] (IdMotivo),
	[Lugar] [varchar] (64) NOT NULL,
	[Representa] [varchar] (64) NOT NULL,
	[Acompanantes] [tinyint] NOT NULL,
	[Log_UserId] [int] not null,
	[Log_Fecha] smalldatetime not null default( getdate() ),
	[Log_IP] varchar(16) not null default(''), 

) ON [PRIMARY]
GO


CREATE TABLE [dbo].[CtlAcc_AutorizacionFecha](
	[IdAutorizacion] [int] NOT NULL foreign key references CtlAcc_Autorizacion ([IdAutorizacion]),
	[Fecha] [smalldatetime]
) ON [PRIMARY]
GO


CREATE TABLE [dbo].[CtlAcc_Acreditacion](
	[IdAcreditacion] int primary key,
	[IdAutorizacion] int foreign key references [dbo].[CtlAcc_Autorizacion] (IdAutorizacion),
	[Fecha] [smalldatetime],
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

	SELECT	1 IdFuncionario, 'NOVOA' Apellido, 'MARTA' Nombre, 0 NroDoc, 'Dra.' Tratamiento, 43790000 Telefono, 'Dir.RRHH - MDS - Piso 21 - Ala Belgrano.' Lugar
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



IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_SEL_Persona]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[CtlAcc_SEL_Persona]
GO

CREATE 
PROCEDURE dbo.CtlAcc_SEL_Persona
(
	@Apellido	varchar(64),
	@Nombre		varchar(64),
	@Documento	int
)
AS
BEGIN


	SELECT	Id, Nombre, Apellido, Documento
	FROM	(
				SELECT	IdPersona Id, Nombre, Apellido, Documento
				FROM	dbo.CtlAcc_PersonaVisita
			)	as t
	WHERE	t.Nombre LIKE '%' + @Nombre + '%'
	AND		t.Apellido LIKE '%' + @Apellido + '%'
	AND		t.Documento = case when @Documento = 0 then t.Documento else @Documento end

END
GO




IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_SEL_Autorizaciones_Hoy]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[CtlAcc_SEL_Autorizaciones_Hoy]
GO

CREATE 
PROCEDURE dbo.CtlAcc_SEL_Autorizaciones_Hoy
(
	@Apellido	varchar(64),
	@Nombre		varchar(64),
	@Documento	int
)
AS
BEGIN

CREATE TABLE #tmpFun ( IdFuncionario int, Apellido	varchar(64), Nombre		varchar(64), NroDoc		int, Tratamiento	varchar(32), Telefono	int,  Lugar		varchar(128) )
INSERT INTO #tmpFun exec CtlAcc_SEL_Funcionario 1


CREATE TABLE #tmpPer ( Id int, Nombre varchar(64), Apellido varchar(64), Documento int, Telefono int )
INSERT INTO #tmpPer exec CtlAcc_SEL_Persona '', '', 0


SELECT	U.IdAutorizacion,
		U.Acompanantes,
		CASE WHEN A.IdAcreditacion IS NULL THEN 0 ELSE 1 END Acreditacion,
		U.Fecha,
		U.IdFuncionario,
		U.Lugar,
		U.IdMotivo,
		U.Representa,
		U.IdPersona,
		F.Apellido +', ' + F.Nombre Funcionario,
		P.Apellido +', ' + P.Nombre Persona,
		M.Motivo

FROM	(
			SELECT	1	IdAutorizacion, 
					2	Acompanantes,
					convert(datetime,convert(varchar(8), getdate(),112 ))	Fecha, 
					1	IdFuncionario, 
					'PISO 14'	Lugar, 
					1 IdMotivo, 
					'Presidencia' Representa, 
					2 IdPersona
			UNION ALL
			SELECT	2	IdAutorizacion, 
					4	Acompanantes, 
					convert(datetime,convert(varchar(8), getdate(),112 ))	Fecha, 
					2	IdFuncionario, 
					'PISO 21'	Lugar, 
					3 IdMotivo, 
					'MIN: ECONOM.' Representa, 
					3 IdPersona
		)	as U
JOIN	dbo.CtlAcc_Motivo as M ON U.IdMotivo = M.IdMotivo
JOIN	#tmpFun as F ON F.IdFuncionario = U.IdFuncionario
JOIN	#tmpPer as P ON P.Id = U.IdPersona
LEFT	JOIN dbo.CtlAcc_Acreditacion as A ON A.IdAutorizacion = U.IdAutorizacion
WHERE	U.Fecha = convert(datetime,convert(varchar(8), getdate(),112 ))

DROP TABLE #tmpFun
DROP TABLE #tmpPer


END
GO


-----------------------------------------
-----------------------------------------

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_INS_Persona]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[CtlAcc_INS_Persona]
GO

CREATE 
PROCEDURE dbo.CtlAcc_INS_Persona
(
	@Apellido	varchar(64),
	@Nombre		varchar(64),
	@Documento	int,
	@IdPersona	int output
)
AS
BEGIN

	SET NOCOUNT ON

	SET @IdPersona = (SELECT IdPersona FROM dbo.CtlAcc_PersonaVisita as p WHERE p.Documento = @Documento AND p.Apellido = @Apellido AND p.Nombre = @Nombre )
	IF ( @IdPersona > 0 ) 
		return

	SET @IdPersona = ISNULL((SELECT MAX(IdPersona) FROM dbo.CtlAcc_PersonaVisita), 0) + 1

	INSERT dbo.CtlAcc_PersonaVisita ( IdPersona, Apellido, Nombre, Documento )
	VALUES ( @IdPersona, @Apellido, @Nombre, @Documento )

END
GO



-----------------------------------------
-----------------------------------------


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_INS_Autorizacion]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[CtlAcc_INS_Autorizacion]
GO

CREATE 
PROCEDURE dbo.CtlAcc_INS_Autorizacion
(
	@IdFuncionario [int],
	@IdPersona [int],
	@Telefono [bigint],
	@IdMotivo [tinyint],
	@Lugar [varchar] (64),
	@Representa [varchar] (64),
	@Acompanantes [tinyint],
	@Log_UserId [int],
	@Log_IP varchar(16),
	@IdAutorizacion int output
)
AS
BEGIN

	SET NOCOUNT ON

	SET @IdAutorizacion = ISNULL((SELECT MAX(IdAutorizacion) FROM dbo.CtlAcc_Autorizacion), 0) + 1

	INSERT [dbo].[CtlAcc_Autorizacion]( [IdAutorizacion], 
										[IdFuncionario], 
										[IdPersona], 
										[Telefono], 
										[IdMotivo], 
										[Lugar], 
										[Representa], 
										[Acompanantes], 
										[Log_UserId],
										[Log_IP] ) 
	VALUES	(	@IdAutorizacion,
				@IdFuncionario,
				@IdPersona,
				@Telefono,
				@IdMotivo,
				@Lugar,
				@Representa,
				@Acompanantes,
				@Log_UserId,
				@Log_IP				
			)


END
GO


-----------------------------------------
-----------------------------------------


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_INS_AutorizacionFecha]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[CtlAcc_INS_AutorizacionFecha]
GO

CREATE 
PROCEDURE dbo.CtlAcc_INS_AutorizacionFecha
(
	@IdAutorizacion	int,
	@Fecha	smalldatetime
)
AS
BEGIN

	INSERT [dbo].[CtlAcc_AutorizacionFecha]( [IdAutorizacion], [Fecha] )
	VALUES ( @IdAutorizacion, @Fecha )

END
GO



-----------------------------------------
-----------------------------------------




-----------------------------------------
-----------------------------------------


/*********************************************************************************************************/
/*********************************************************************************************************/
/*********************************************************************************************************/

-- ROLLBACK tran
COMMIT tran
