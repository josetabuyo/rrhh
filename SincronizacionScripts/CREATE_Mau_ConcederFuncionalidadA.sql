CREATE Procedure dbo.Mau_ConcederFuncionalidadA
@Id_usuario int,
@Id_funcionalidad int
as


insert into dbo.mau_funcionalidades_por_usuario(IdUsuario,IdFuncionalidad)
values(@Id_usuario,@Id_funcionalidad)


GO

grant exec on dbo.[Mau_ConcederFuncionalidadA] to RRHH_SIS_LEG_ADM
grant exec on dbo.[Mau_ConcederFuncionalidadA] to RRHH_SIS_LEG_INS
grant exec on dbo.[Mau_ConcederFuncionalidadA] to RRHH_SIS_LEG_UPD
grant exec on dbo.[Mau_ConcederFuncionalidadA] to RRHH_SIS_LEG_USR
grant exec on dbo.[Mau_ConcederFuncionalidadA] to usrRRHHws
