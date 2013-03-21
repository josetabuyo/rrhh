USE [DB_RRHH]
GO

/****** Object:  StoredProcedure [dbo].[SACC_Ins_Bajas]    Script Date: 03/19/2013 20:23:56 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[SACC_Ins_Bajas]
@Motivo varchar(50),
@IdUsuario smallint,
@Fecha smalldatetime
as

insert into dbo.SAC_Bajas (Motivo, IdUsuario, Fecha)
values (@Motivo,@IdUsuario, getdate())

select SCOPE_IDENTITY()
GO

