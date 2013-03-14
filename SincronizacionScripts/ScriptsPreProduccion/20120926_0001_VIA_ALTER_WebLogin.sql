ALTER procedure [dbo].[Web_Login]      
@usuario varchar(50),      
@password varchar(50)      
as      
      
DECLARE @usua int      
set @usua = ( select top 1 isnull(us.id,0)  
 from       
  [dbo].[RH_Usuarios_Areas_Web] aw      
 inner join dbo.RH_usuarios us on      
   us.id = aw.id_usuario      
 inner join dbo.tabla_areas ta on      
  ta.id = id_area      
 inner join dbo.web_passwords pa on      
  pa.idUsuario = us.id      
 where       
  us.Nombre = @usuario and      
  pa.password = @password  and      
--  us.password = @password  and      
  us.Baja <> 1      
)    
    
      
 select      
  us.nombre,      
  us.id id_usuario,      
  us.password,      
  ta.id id_area,      
  ta.descripcion nombre_area,
  isnull(fir.id, 0) es_firmante      
 from       
  [dbo].[RH_Usuarios_Areas_Web] aw      
 inner join dbo.RH_usuarios us on      
   us.id = aw.id_usuario      
 inner join dbo.tabla_areas ta on      
  ta.id = id_area      
 inner join dbo.web_passwords pa on      
  pa.idUsuario = us.id
 left join dbo.RH_Usuarios_Detalles det on
	det.Id_Usuario = aw.id_usuario
 left join dbo.Tabla_Firmantes fir on
	fir.Area = ta.id and
	fir.Nro_Documento = 
		case when det.Mail like '%[^0-9]%' 
		then null 
		else cast(det.Mail as int) end	
		--Esto es porque se uso el campo email para guardar el documento.
 where       
  us.Nombre = @usuario and      
  pa.password = @password  and   
  us.password = @password  and      
  us.Baja <> 1      
       
  
IF @usua > 0  
BEGIN  
 insert into log_web values (@usua, getdate())      
END      