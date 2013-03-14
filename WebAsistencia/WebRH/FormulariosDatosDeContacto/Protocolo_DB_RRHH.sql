USE DB_RRHH
GO


BEGIN TRAN

	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='ProtTel_ContactoArea') 
		DROP TABLE ProtTel_ContactoArea 
	GO

	IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='ProtTel_TipoContacto') 
		DROP TABLE ProtTel_TipoContacto
	GO


	CREATE TABLE dbo.ProtTel_TipoContacto
	(
		idTipoContacto tinyint primary key,
		TipoContacto varchar(32) not null,
	)
	GO

	INSERT dbo.ProtTel_TipoContacto ( idTipoContacto, TipoContacto )
	VALUES ( 1, 'Teléfono (ppal.)' )
	GO

	INSERT dbo.ProtTel_TipoContacto ( idTipoContacto, TipoContacto )
	VALUES ( 2, 'Fax (ppal.)' )
	GO

	INSERT dbo.ProtTel_TipoContacto ( idTipoContacto, TipoContacto )
	VALUES ( 3, 'E-mail (ppal.)' )
	GO

	INSERT dbo.ProtTel_TipoContacto ( idTipoContacto, TipoContacto )
	VALUES ( 4, 'Teléfono' )
	GO

	INSERT dbo.ProtTel_TipoContacto ( idTipoContacto, TipoContacto )
	VALUES ( 5, 'Fax' )
	GO

	INSERT dbo.ProtTel_TipoContacto ( idTipoContacto, TipoContacto )
	VALUES ( 6, 'E-mail' )
	GO

	CREATE TABLE dbo.ProtTel_ContactoArea
	(
		IdContactoArea int primary key,
		IdArea int foreign key references dbo.Tabla_Areas (Id),
		idTipoContacto tinyint foreign key references dbo.ProtTel_TipoContacto (idTipoContacto),
		ContactoArea varchar(32) not null default(''),
	)
	GO

ROLLBACK TRAN



/***************
 ***************/


	IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[Web_GetArea]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
		DROP PROCEDURE dbo.Web_GetArea
	GO

	CREATE PROCEDURE [dbo].[Web_GetArea]
	(
		@IdArea int
	)
	AS
	BEGIN

		 select	ta.id id_area,    
				ta.descripcion nombre_area,
				td.Calle + td.Nro + ' - Piso ' + td.Piso +  ' (CP ' + convert(varchar(6), td.Codigo_Postal) + ') - ' +
				lo.nombrelocalidad +
				case when lo.nombrelocalidad = 'CIUDAD AUTONOMA DE BS AS' then '' 
					 else ', ' + pt.Descripcion 
				end +
				case when lo.nombrelocalidad = 'CIUDAD AUTONOMA DE BS AS' then '' 
					 else ', ' + pr.nombreProvincia
				end direccion_area
		 from	dbo.Tabla_Areas ta 
		 inner	join dbo.Tabla_Areas_Detalle	td on ta.id = td.id_area
		 inner	join dbo.LocalidadesAFIP		lo on lo.idLocalidad = td.Localidad
		 inner	join dbo.Partidos				pt on pt.Partido = lo.ID_Partido
		 inner	join dbo.Provincias				pr on pr.codAFIP = lo.id_provincia
		 where	ta.id = @IdArea

	END
	GO

	GRANT EXEC ON [dbo].[Web_GetArea] TO usrRRHHws
	GO

	EXEC [dbo].[Web_GetArea] 939


/***************
 ***************/


	IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[Web_GetContactoArea]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
		DROP PROCEDURE dbo.Web_GetContactoArea
	GO

	CREATE PROCEDURE [dbo].[Web_GetContactoArea]
	(
		@IdArea int
	)
	AS
	BEGIN

		 select	IdContactoArea,
				idTipoContacto,
				ContactoArea
		 from	dbo.ProtTel_ContactoArea as ca
		 where	ca.IdArea = @IdArea

	END
	GO

	GRANT EXEC ON [dbo].[Web_GetContactoArea] TO usrRRHHws
	GO

	EXEC [dbo].[Web_GetContactoArea] 939


/***************
 ***************/









/*
ALTER procedure [dbo].[Web_Login]    
@usuario varchar(50),    
@password varchar(50)    
as    
    
DECLARE @usua int    
set @usua = ( select top 1 isnull(ta.id,0)
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
  td.Calle + td.Nro + ' - Piso ' + td.Piso +  ' (CP ' + convert(varchar(6), td.Codigo_Postal) + ') - ' +
  lo.nombrelocalidad /* + ', ' + pt.Descripcion + ', ' + pr.nombreProvincia */ direccion_area

 from     
  [dbo].[RH_Usuarios_Areas_Web] aw    
 inner join dbo.RH_usuarios us on    
   us.id = aw.id_usuario    
 inner join dbo.tabla_areas ta on    
  ta.id = id_area    
 inner join dbo.Tabla_Areas_Detalle td on
  td.Id_Area = ta.id
 inner join dbo.LocalidadesAFIP lo on
  lo.idLocalidad = td.Localidad
 inner join dbo.Partidos pt on
  pt.Partido = lo.ID_Partido
 inner join dbo.Provincias pr on
  pr.codAFIP = lo.id_provincia
 inner join dbo.web_passwords pa on    
  pa.idUsuario = us.id    
 where     
  us.Nombre = @usuario and    
  pa.password = @password  and    
--  us.password = @password  and    
  us.Baja <> 1    

IF @usua > 0
BEGIN
	insert into log_web values (@usua, getdate())    
END    

EXEC [dbo].[Web_Login] 'fabian', 'l3WIqH4QWCAycWcSzPXYXRil/M8='

*/


/*

	BEGIN tran 
		
		 create table #con( id int identity (1,1), area int, tipo int, contacto varchar(255) )		


		 insert #con( area, tipo, contacto )		
		 select	ta.id id_area,    
				1 tipo,
				td.Telefono as contacto

		 from	dbo.Tabla_Areas ta 
		 inner	join dbo.Tabla_Areas_Detalle	td on ta.id = td.id_area
		 inner	join dbo.LocalidadesAFIP		lo on lo.idLocalidad = td.Localidad
		 inner	join dbo.Partidos				pt on pt.Partido = lo.ID_Partido
		 inner	join dbo.Provincias				pr on pr.codAFIP = lo.id_provincia
		 where	ltrim(rtrim(Telefono)) > '0'
		 union all
		 select	ta.id id_area,    
				2,
				td.Fax
		 from	dbo.Tabla_Areas ta 
		 inner	join dbo.Tabla_Areas_Detalle	td on ta.id = td.id_area
		 inner	join dbo.LocalidadesAFIP		lo on lo.idLocalidad = td.Localidad
		 inner	join dbo.Partidos				pt on pt.Partido = lo.ID_Partido
		 inner	join dbo.Provincias				pr on pr.codAFIP = lo.id_provincia
		 where	ltrim(rtrim(td.Fax)) > '0'
		 order  by 1 asc

		
		insert	ProtTel_ContactoArea
		select	* from #con

		drop table #con

	rollback tran

*/


