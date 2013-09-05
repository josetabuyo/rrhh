USE DB_RRHH
GO

CREATE procedure [dbo].[Web_Login]      
	@usuario varchar(50),      
	@password varchar(50)      
as      
      
DECLARE @usua int
set @usua = ( 
	select top 1 isnull(us.id,0)  
	from       [dbo].[RH_Usuarios_Areas_Web] aw      
	inner		join dbo.RH_usuarios us on us.id = aw.id_usuario      
 inner join dbo.tabla_areas ta on      
  ta.id = aw.id_area      
 inner join dbo.web_passwords pa on      
  pa.idUsuario = us.id      
 where       
  us.Nombre = @usuario and      
  pa.password = @password  and        
  us.Baja <> 1      
)    
    


SELECT 
dp2.Nro_Documento,   fir.Nro_Documento,
det.Nro_Documento,
  us.id												id_usuario,
  us.nombre											,      
  us.password										,      
  ta.id												id_area,      
  ta.descripcion									nombre_area,
  ta.Presenta_DDJJ									,
  isnull(dp2.Apellido, '')							Apellido_Responsable,
  isnull(dp2.Nombre, '')							Nombre_Responsable,
 (tad.Calle + ' '+ tad.Nro + ' ' + ' Piso ' + 
  tad.Piso + ' Dto ' +tad.Dpto) AS					direccion,
  isnull(dp.Apellido, '')							Apellido_Asistente,
  isnull(dp.Nombre, '')								Nombre_Asistente,
  isnull(ca.Telefono, '')							Telefono_Asistente,
  isnull(ca.Fax, '')								Fax_Asistente,
  isnull(ca.Mail, '')								Mail_Asistente, 
  isnull(fir.id, 0)									es_firmante,
  isnull(tdc.Descripcion, '')						Cargo,
  isnull(ca.Nro_orden, 1)							Prioridad_Asistente, 
  isnull(dca.Dato, '')							Telefono_Area,
 
  fea.Id											Id_Funcionalidad,
  fea.Descripcion									Nombre_Funcionalidad
  
  
FROM       
  [dbo].[RH_Usuarios_Areas_Web]						aw      
 inner join dbo.RH_usuarios							us	on      
	us.id = aw.id_usuario      
 inner join dbo.tabla_areas							ta	on      
	ta.id = aw.id_area
 left join  dbo.Tabla_Areas_Detalle					tad on
	tad.Id_Area =  ta.id
 left join  dbo.Tabla_Areas_DatosContacto			dca on
	dca.Id_Area =  ta.id
 left join  dbo.Tabla_Areas_Asistentes				ca	on 
	ca.Id_Area =  ta.id and ca.Baja <> 1
 left join  dbo.Tabla_Areas_Descripcion_Cargos		tdc on 
	tdc.id = ca.Indicador_Cargo and tdc.Baja <> 1
 left join  dbo.Datos_Personales					dp	on
	dp.Nro_Documento =  ca.DNI	  	  	         
 inner join dbo.web_passwords						pa	on      
	pa.idUsuario = us.id
 left join dbo.RH_Usuarios_Detalles					det on
	det.Id_Usuario = aw.id_usuario
 left join dbo.Tabla_Firmantes						fir on
	fir.Area = ta.id 
	and fir.Baja <> 1
 left join  dbo.Datos_Personales					dp2 on
	dp2.Nro_Documento =  fir.Nro_Documento 
 left join dbo.VIA_Usuarios_Features				uf on
	aw.Id_usuario = uf.IdUsuario
 left join dbo.VIA_Features							fea on
	uf.IdFeature = fea.Id
				
where       
  us.Nombre = @usuario and      
  pa.password = @password  and      
  us.Baja <> 1    




select * from dbo.VIA_Usuarios_Features
select * from dbo.VIA_Features




	select top 1 isnull(us.id,0)  
	from       [dbo].[RH_Usuarios_Areas_Web] aw      
	 inner		join dbo.RH_usuarios us on us.id = aw.id_usuario      
	 inner join dbo.tabla_areas ta on      
	  ta.id = aw.id_area      
	 inner join dbo.web_passwords pa on      
	  pa.idUsuario = us.id      
	where       
	  us.Nombre = 'ususecre' and
	  us.Baja <> 1      


use db_rrhh

-- SELECT * FROM dbo.RH_usuarios WHERE	Id = 292
BEGIN TRAN

insert dbo.RH_usuarios
SELECT  305,
		'usuVisita',
		Password,
		Vence_Passw,
		Baja,
		Fecha_Baja,
		Actualizar_Passw,
		Administrador 

FROM	dbo.RH_usuarios
WHERE	Id = 292


rollback tran



begin tran

-- Insertar:
-- select top 1 * from dbo.RH_Usuarios_Areas_Web where Id_Usuario = 292


INSERT dbo.RH_Usuarios_Areas_Web ( Id_Usuario, Id_Area, baja )
select	top 1
		305 Id_Usu,
		Id_Area,
		baja
from	dbo.RH_Usuarios_Areas_Web where Id_Usuario = 292



ROLLBACK tran


begin tran


insert web_passwords ( idUsuario, password )
select 305, password from dbo.web_passwords where IdUsuario = 292


ROLLBACK tran


SELECT * FROM dbo.RH_usuarios WHERE Id = 305
SELECT * FROM dbo.RH_Usuarios_Areas_Web WHERE Id_Usuario = 305
SELECT * FROM web_passwords WHERE IdUsuario = 305



SELECT * FROM dbo.RH_usuarios WHERE Id = 292
SELECT * FROM dbo.RH_Usuarios_Areas_Web WHERE Id_Usuario = 292
SELECT * FROM web_passwords WHERE IdUsuario = 292


SELECT * FROM dbo.RH_usuarios WHERE Nombre LIKE '%admin%'
SELECT * FROM web_passwords WHERE IdUsuario = 1



begin tran

	update	dbo.RH_usuarios 
	set		Password = 'XxEgKLpTtNRAP32I0G8wZCc/v+M='
	where	Id = 305


	update	dbo.web_passwords
	set		Password = 'XxEgKLpTtNRAP32I0G8wZCc/v+M='
	where	idUsuario = 305


rollback tran
-- commit tran

-- exec [dbo].[Web_Login] 'usuvisita', 'XxEgKLpTtNRAP32I0G8wZCc/v+M='



-----------------------
-- usuVisita
-- usuVisita
-----------------------

begin tran

insert dbo.VIA_Features ( Id, Descripcion ) 
select 6, 'Visitas'


select * FROM dbo.VIA_Features


insert VIA_Usuarios_Features ( IdUsuario, IdFeature )
select 305, 6

select * FROM dbo.VIA_Usuarios_Features


rollback tran






