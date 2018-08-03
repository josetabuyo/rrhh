using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Recibos
{
    public class ReciboFirmado
    {

        public int idRecibo { get; set; }
        public int idArchivo { get; set; }
        public int confirmado { get; set; } //es la confirmacion de firma del empleado, proceso en el cual el empleado reconoce al recibo de sueldo generado
        public DateTime fecha_confirmacion { get; set; }
        public string conforme { get; set; } //indicador si firma conforme o no (si,no)
        public string observacion { get; set; } //observacion cuando firma en disconformidad
       
        public ReciboFirmado()
        {
        }


    }
}
