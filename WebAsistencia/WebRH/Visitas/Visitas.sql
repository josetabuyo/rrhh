USE DB_RRHH
GO

BEGIN tran


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_Acreditacion]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
	DROP TABLE [dbo].[CtlAcc_Acreditacion]
GO

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[CtlAcc_AutorizacionFechaPersonas]') AND OBJECTPROPERTY(id, N'IsUserTable') = 1)
	DROP TABLE [CtlAcc_AutorizacionFechaPersonas]
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
	Apellido	varchar(32) not null,
	Nombre		varchar(64) not null,
	Documento	int			not null,
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
	[IdMotivo] [tinyint] NOT NULL foreign key references [dbo].[CtlAcc_Motivo] (IdMotivo),
	[Lugar] [varchar] (64) NOT NULL,
	[Representa] [varchar] (64) NOT NULL,
	[Log_UserId] [int] not null,
	[Log_Fecha] smalldatetime not null default( getdate() ),
	[Log_IP] varchar(16) not null default(''), 

) ON [PRIMARY]
GO


CREATE TABLE [dbo].[CtlAcc_AutorizacionFecha](
	[IdAutorizacion] [int] NOT NULL foreign key references CtlAcc_Autorizacion ([IdAutorizacion]),
	[Fecha] [smalldatetime] NOT NULL,
	primary key ([IdAutorizacion], [Fecha]),

) ON [PRIMARY]
GO


CREATE TABLE [dbo].[CtlAcc_AutorizacionFechaPersonas](
	[IdAutorizacion] [int] NOT NULL,
	[Fecha] [smalldatetime] NOT NULL,
	[IdPersona] [int] NOT NULL foreign key references dbo.CtlAcc_PersonaVisita ([IdPersona]),
	[NroCredencial] varchar(64) not null,
	foreign key ([IdAutorizacion], [Fecha]) references dbo.CtlAcc_AutorizacionFecha ([IdAutorizacion], [Fecha]),
	primary key ([IdAutorizacion], [Fecha], [IdPersona]),

) ON [PRIMARY]
GO


CREATE TABLE [dbo].[CtlAcc_Acreditacion](
	[IdAcreditacion] int primary key,
	[IdAutorizacion] int foreign key references [dbo].[CtlAcc_Autorizacion] (IdAutorizacion),
	[Fecha] [smalldatetime],
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


	SELECT	top 20
			t.IdPersona Id, t.Apellido, t.Nombre, t.Documento
	FROM	dbo.CtlAcc_PersonaVisita as t
	WHERE	t.Nombre LIKE '%' + @Nombre + '%'
	AND		t.Apellido LIKE '%' + @Apellido + '%'
	AND		t.Documento = case when @Documento = 0 then t.Documento else @Documento end
	ORDER	BY t.Apellido ASC, t.Nombre ASC, t.Documento ASC

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

	SET @Apellido	= LTRIM(RTRIM(UPPER(@Apellido)))
	SET @Nombre		= LTRIM(RTRIM(UPPER(@Nombre)))

	SET @IdPersona = (SELECT IdPersona FROM dbo.CtlAcc_PersonaVisita as p WHERE p.Documento = @Documento AND p.Apellido = @Apellido AND p.Nombre = @Nombre )
	IF ( @IdPersona > 0 ) RETURN

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
	@IdMotivo [tinyint],
	@Lugar [varchar] (64),
	@Representa [varchar] (64),
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
										[IdMotivo], 
										[Lugar], 
										[Representa], 
										[Log_UserId],
										[Log_IP] ) 
	VALUES	(	@IdAutorizacion,
				@IdFuncionario,
				@IdPersona,
				@IdMotivo,
				@Lugar,
				@Representa,
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

/*
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
*/



IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_SEL_Autorizaciones]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[CtlAcc_SEL_Autorizaciones]
GO

CREATE 
PROCEDURE dbo.CtlAcc_SEL_Autorizaciones
(
	@Fecha	smalldatetime
)
AS
BEGIN

----------------------
----------------------
CREATE TABLE #tmpFun ( IdFuncionario int, Apellido	varchar(64), Nombre		varchar(64), NroDoc		int, Tratamiento	varchar(32), Telefono	int,  Lugar		varchar(128) )
INSERT INTO #tmpFun exec CtlAcc_SEL_Funcionario 1
----------------------
----------------------

	SELECT	af.IdAutorizacion, pe.Apellido, pe.Nombre, pe.Documento, au.Representa, fu.Tratamiento + ' ' +  fu.Apellido + ' ' + fu.Nombre as Funcionario, au.Lugar
	FROM	( SELECT aaff.IdAutorizacion FROM [dbo].[CtlAcc_AutorizacionFecha] as aaff WHERE aaff.Fecha = @Fecha ) as af
	INNER	JOIN	[dbo].[CtlAcc_Autorizacion] as au ON au.IdAutorizacion = af.IdAutorizacion
	INNER	JOIN	[dbo].[CtlAcc_PersonaVisita] as pe ON au.IdPersona = pe.IdPersona
	INNER	JOIN	#tmpFun as fu ON fu.IdFuncionario = au.IdFuncionario
	LEFT	JOIN	[dbo].[CtlAcc_Acreditacion] as ac ON ac.IdAutorizacion = au.IdAutorizacion and ac.Fecha = @Fecha
	WHERE	ac.IdAcreditacion IS null

----------------------
---------------------
DROP TABLE #tmpFun
---------------------
----------------------

END
GO

-- exec CtlAcc_SEL_Autorizaciones '20140109'

-----------------------------------------
-----------------------------------------


IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_INS_PersonaAutorizacionFecha]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[CtlAcc_INS_PersonaAutorizacionFecha]
GO

CREATE 
PROCEDURE dbo.CtlAcc_INS_PersonaAutorizacionFecha
(
	@IdAutorizacion	int,
	@Fecha			smalldatetime,
	@Apellido		varchar(32),
	@Nombre			varchar(64),
	@Documento		int,
	@NroCredencial	varchar(64)
)
AS
BEGIN

	DECLARE @IdPersona INT;

	EXEC dbo.CtlAcc_INS_Persona @Apellido, @Nombre, @Documento, @IdPersona output;
	
	INSERT INTO dbo.CtlAcc_AutorizacionFechaPersonas ( IdAutorizacion, Fecha, IdPersona, NroCredencial )
	VALUES	( @IdAutorizacion, @Fecha, @IdPersona, @NroCredencial );

END
GO



-----------------------------------------
-----------------------------------------

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_SEL_PersonasAcreditacion]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[CtlAcc_SEL_PersonasAcreditacion]
GO

CREATE 
PROCEDURE dbo.CtlAcc_SEL_PersonasAcreditacion
(
	@IdAutorizacion	int,
	@Fecha			smalldatetime
)
AS
BEGIN

	SELECT	pvi.IdPersona, pvi.Apellido, pvi.Nombre, pvi.Documento, afp.NroCredencial
	FROM	dbo.CtlAcc_AutorizacionFechaPersonas as afp
	JOIN	dbo.CtlAcc_PersonaVisita as pvi ON afp.IdPersona = pvi.IdPersona
	WHERE	afp.IdAutorizacion = @IdAutorizacion
	AND		afp.Fecha = @Fecha;

END
GO


-----------------------------------------
-----------------------------------------

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_DEL_PersonasAcreditacion]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[CtlAcc_DEL_PersonasAcreditacion]
GO

CREATE 
PROCEDURE dbo.CtlAcc_DEL_PersonasAcreditacion
(
	@IdAutorizacion	int,
	@Fecha			smalldatetime,
	@IdPersona		int
)
AS
BEGIN

	DELETE	afp
	FROM	dbo.CtlAcc_AutorizacionFechaPersonas as afp
	WHERE	afp.IdAutorizacion = @IdAutorizacion
	AND		afp.Fecha = @Fecha
	AND		afp.IdPersona = @IdPersona;

END
GO


-----------------------------------------
-----------------------------------------

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[CtlAcc_INS_Acreditacion]') AND OBJECTPROPERTY(id,N'IsProcedure') = 1)
	DROP PROCEDURE [dbo].[CtlAcc_INS_Acreditacion]
GO

CREATE 
PROCEDURE dbo.CtlAcc_INS_Acreditacion
(
	@IdAutorizacion int,
	@Fecha [smalldatetime],
	@Log_UserId int,
	@Log_IP varchar(16)
)
AS
BEGIN

	declare @IdAcreditacion int;

	SET @IdAcreditacion = ISNULL((SELECT MAX(IdAcreditacion) FROM dbo.CtlAcc_Acreditacion), 0) + 1;

	INSERT [dbo].[CtlAcc_Acreditacion]( [IdAcreditacion], [IdAutorizacion], [Fecha], [Log_UserId], [Log_IP] )
	VALUES	( @IdAcreditacion, @IdAutorizacion, @Fecha, @Log_UserId, @Log_IP );

END
GO


-----------------------------------------
-----------------------------------------





/*********************************************************************************************************/
/*********************************************************************************************************/
/*********************************************************************************************************/

-- ROLLBACK tran
COMMIT tran


-- select * from DB_RRHH.dbo.CtlAcc_Autorizacion
-- select * from DB_RRHH.dbo.CtlAcc_PersonaVisita
-- select * from DB_RRHH.dbo.CtlAcc_AutorizacionFecha
-- select * from DB_RRHH.dbo.CtlAcc_AutorizacionFechaPersonas
-- delete DB_RRHH.dbo.CtlAcc_AutorizacionFechaPersonas


-- select * FROM [CtlAcc_Acreditacion]
-- select * FROM dbo.CtlAcc_Autorizacion
-- delete dbo.CtlAcc_Acreditacion
