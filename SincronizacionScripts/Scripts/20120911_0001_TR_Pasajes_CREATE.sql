
CREATE TRIGGER TR_Pasajes

ON VIA_Pasajes

AFTER INSERT, UPDATE

AS 

BEGIN

SET NOCOUNT ON;

INSERT INTO VIA_PasajesHistorico
SELECT [Id]
      ,[IdComision]
      ,[LocalidadOrigen]
      ,[LocalidadDestino]
      ,[Precio]
      ,[Fecha]
      ,[MedioDeTransporte]
      ,[MedioDePago]
      ,[Baja]
      ,[Usuario]
      ,getdate()
FROM INSERTED

END