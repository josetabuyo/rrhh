Create procedure [dbo].[CV_Ins_Matriculas]
@ExpedidoPor varchar(100)=null,
@Numero varchar(100)=null,
@SituacionActual varchar(100)=null,
@FechaInscripcion datetime=null,
@Usuario int=null,
--@FechaOperacion datetime=null,
@Baja int=null,
@IdPersona int=null

AS

BEGIN

	 declare @NombreSp varchar(60)   
	 set @NombreSp = (select OBJECT_NAME(@@PROCID))  
	 exec dbo.Audit @NombreSp   

	INSERT INTO [dbo].[CV_Matriculas]
			   ([ExpedidaPor]
			   ,[Numero]
			   ,[SituacionActual]
			   ,[FechaInscripcion]
			   ,[Usuario]
			   ,[FechaOperacion]
			   ,[Baja]
			   ,[IdPersona])
			   VALUES
			   (@ExpedidaPor,
			   @Numero, 
			   @SituacionActual, 
			   @FechaInscripcion, 
			   @Usuario,
			   getdate(),
			   @Baja, 
			   @IdPersona)
	           
	SELECT SCOPE_IDENTITY()  
           
END




