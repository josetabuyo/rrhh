SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[TR_Estadias]

ON [dbo].[VIA_Estadias]

AFTER INSERT, UPDATE

AS 

BEGIN

SET NOCOUNT ON;

INSERT INTO VIA_EstadiasHistorico
SELECT [Id]
      ,[IdComision]
      ,[FechaDesde]
      ,[FechaHasta]
      ,[Provincia]
      ,[Eventual]
      ,[AdicPorPasaje]
      ,[CalculadoPorCategoria]
      ,[Motivo]
      ,[Baja]
      ,[Usuario]
      ,getdate()
FROM INSERTED

END