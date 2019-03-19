using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class AprobacionPorComite
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdComiteAprobador { get; set; }
        public int IdEvaluacion { get; set; }
        public int IdUsuario { get; set; }

        public AprobacionPorComite()
        {

        }

        public AprobacionPorComite(DateTime fecha, int id, int id_comite_aprobador, int id_evaluacion, int id_usuario_aprobacion)
        {
            this.Fecha = fecha;
            this.Id = id;
            this.IdComiteAprobador = id_comite_aprobador;
            this.IdEvaluacion = id_evaluacion;
            this.IdUsuario = id_usuario_aprobacion;
        }
    }
}
