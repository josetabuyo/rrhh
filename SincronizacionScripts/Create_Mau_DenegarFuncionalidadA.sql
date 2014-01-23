CREATE Procedure dbo.Mau_DenegarFuncionalidadA
@Id_usuario int,
@Id_funcionalidad int
as

delete from dbo.mau_funcionalidades_por_usuario
where IdUsuario =@Id_usuario
and IdFuncionalidad = @Id_funcionalidad


GO

grant exec on dbo.[Mau_DenegarFuncionalidadA] to RRHH_SIS_LEG_ADM
grant exec on dbo.[Mau_DenegarFuncionalidadA] to RRHH_SIS_LEG_INS
grant exec on dbo.[Mau_DenegarFuncionalidadA] to RRHH_SIS_LEG_UPD
grant exec on dbo.[Mau_DenegarFuncionalidadA] to RRHH_SIS_LEG_USR
grant exec on dbo.[Mau_DenegarFuncionalidadA] to usrRRHHws