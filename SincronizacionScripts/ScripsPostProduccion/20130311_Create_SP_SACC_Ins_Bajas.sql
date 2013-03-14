CREATE procedure [dbo].[SACC_Ins_Bajas]
@Motivo varchar(50),
@IdUsuario smallint,
@Fecha smalldatetime
as

insert into dbo.SAC_Bajas (Motivo, IdUsuario, Fecha)
values (@Motivo,@IdUsuario, getdate())

select SCOPE_IDENTITY()