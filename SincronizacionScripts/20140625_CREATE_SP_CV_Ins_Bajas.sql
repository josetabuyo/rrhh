
CREATE PROCEDURE [dbo].[CV_Ins_Bajas]
(
	@Motivo varchar(100) = null,
	@Usuario[int] 
)

AS

BEGIN
	
	INSERT INTO [dbo].[CV_Bajas]
		(Motivo, Usuario )
	VALUES 
		(@Motivo, @Usuario )
	
END