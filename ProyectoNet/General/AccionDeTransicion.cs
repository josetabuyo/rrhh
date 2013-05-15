namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AccionDeTransicion
    {
        public 2 int Id { get; set; }
        public String Descripcion { get; set; }
        public string DescripcionPasado { get; set; }
        public string DescripcionEstadoInbox { get; set; }

        public AccionDeTransicion()
        {

        }

        public AccionDeTransicion(int id, String descripcion, String descripcion_pasado, String descripcion_estado_inbox)
        {
            this.Id = id;
            this.Descripcion = descripcion;
            this.DescripcionPasado = descripcion_pasado;
            this.DescripcionEstadoInbox = descripcion_estado_inbox;
        }

    }
}
