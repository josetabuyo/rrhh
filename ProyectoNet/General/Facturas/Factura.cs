using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Facturas
{
    public class Factura
    {
        public int Id_Factura { get; set; }
        public int Mes { get; set; }
        public int Anio { get; set; }
        public decimal Monto_Contrato { get; set; }
        public decimal Monto_Otras_Factura { get; set; }
        public decimal Monto_A_Factura { get; set; }
        public decimal Saldo { get; set; }
        public int Id_Contrato { get; set; }
        public int Nro_Documento { get; set; }
        public string Nro_Contrato { get; set; }
        public string Acto_Tipo { get; set; }
        public string Acto_Nro { get; set; }
        public Persona Persona { get; set; }
        public DateTime Fecha_Recibida { get; set; }
        public string Nro_Factura { get; set; }
        public decimal Monto_Factura { get; set; }
        public string Area { get; set; }
        public string Firmante { get; set; }
        public bool estaSeleccionado { get; set; }

    }
}
