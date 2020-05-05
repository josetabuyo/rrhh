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
        public int mes { get; set; }
        public int anio { get; set; }
        public int tipoLiquidacion { get; set; }
        public int conforme { get; set; } //es la confirmacion de firma del empleado, proceso en el cual el empleado reconoce al recibo de sueldo generado
        public int idUsuario { get; set; }
        public DateTime fechaConformidadUsuario { get; set; }
        public string hash { get; set; } 
               
        public ReciboFirmado()
        {
        }
        public ReciboFirmado(int idRecibo, int idArchivo, int mes, int anio, int tipoLiquidacion, int conforme, int idUsuario)
        {
            this.idRecibo =idRecibo;
            this.idArchivo=idArchivo;
            this.mes=mes;
            this.anio=anio;
            this.tipoLiquidacion= tipoLiquidacion;
            this.conforme=conforme;
            this.idUsuario=idUsuario;

        }

    }
}
