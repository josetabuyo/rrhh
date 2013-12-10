CREATE PROCEDURE [dbo].[SACC_Upd_Password]
(	
	@idUsuario  [smallint],
	@password_actual  [varchar](150),
	@password_nuevo  [varchar](150)
) 

AS

BEGIN
    
UPDATE [dbo].[WEB_Passwords]            
SET  	     
	[password]  = @password_nuevo
	 
WHERE       
	[idUsuario]  = @idUsuario  and
	[password]  = @password_actual
	
select	@@rowcount
	
END