Create procedure dbo.CV_Ins_Matriculas
@ExpedidaPor varchar(100)=null,
@Numero varchar(100)=null,
@SituacionActual varchar(100)=null,
@FechaInscripcion datetime=null,
@Usuario int=null,
--@FechaOperacion datetime=null,
@Baja int=null,
@Documento int=null

AS

BEGIN

declare @IdPersona int
select @IdPersona = id from dbo.datospersonales where nrodocumento = @Documento

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
           
           
END




