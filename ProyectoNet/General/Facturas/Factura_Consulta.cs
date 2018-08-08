using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Facturas
{
    public class Factura_Consulta
    {
        public int Id_Factura { get; set; }
        public Persona Persona { get; set; }
        public DateTime Fecha_Factura { get; set; }
        public DateTime Fecha_Recibida { get; set; }
        public DateTime? Fecha_Pase { get; set; }
        public string Nro_Factura { get; set; }
        public decimal Monto_Contrato { get; set; }
        public decimal Monto_Factura { get; set; }
        public int Mes_Imputado { get; set; }
        public int Anio_Imputado { get; set; }
        public string Area { get; set; }
        public string Firmante { get; set; }
        
    }
}
