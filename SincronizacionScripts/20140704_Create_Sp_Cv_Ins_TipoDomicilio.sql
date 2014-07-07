Create procedure dbo.CV_Ins_TipoDomicilio
@Descripcion varchar(15)
as

Begin


 declare @NombreSp varchar(60)   
 set @NombreSp = (select OBJECT_NAME(@@PROCID))  
 exec dbo.Audit @NombreSp    



INSERT INTO [dbo].[CV_TipoDomicilio]
           ([Descripcion])
     VALUES
           (@Descripcion)

End
