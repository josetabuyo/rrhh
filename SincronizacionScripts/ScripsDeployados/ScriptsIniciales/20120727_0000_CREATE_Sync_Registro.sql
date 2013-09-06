IF NOT EXISTS (
	SELECT * FROM sys.objects 
	  WHERE object_id = OBJECT_ID(N'[dbo].[Sync_Registro]') 
	    AND type in (N'U'))
BEGIN 
    CREATE TABLE Sync_Registro(
		id				integer identity not null,
		versionScript	Timestamp,
		nombreScript	varchar(256),
		creador			varchar(256),
		fecha			datetime
    )
END