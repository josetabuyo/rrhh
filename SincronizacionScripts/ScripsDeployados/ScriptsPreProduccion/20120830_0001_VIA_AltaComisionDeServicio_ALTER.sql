/****** Object:  StoredProcedure [dbo].[VIA_AltaComisionDeServicio]    Script Date: 08/30/2012 22:18:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[VIA_AltaComisionDeServicio]
@idAreaCreadora int,
@documentoAgente int,
@estado nvarchar(50),
@baja bit,
@usuario smallint,
@idPrimerArea smallint
AS

BEGIN

declare @idComision smallint

insert into dbo.VIA_ComisionesDeServicio (IdAreaCreadora, DocumentoAgente, estado, Baja, Usuario)
values (@idAreaCreadora,@documentoAgente,@estado,@baja,@usuario )

set @idComision = (select SCOPE_IDENTITY())


	INSERT INTO [DB_RRHH].[dbo].VIA_Transiciones_De_Viaticos
		SELECT		@idComision as id_viatico
				   ,@idAreaCreadora as id_area_origen
				   ,@idPrimerArea as id_area_destino
				   ,1	as id_accion
				   ,GETDATE() as fecha
				   ,'' as comentario

select @idComision

END