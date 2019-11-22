using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace General
{
    public class DocumentosRecepcionados
    {
        public int Id { get; set; }
        public int Id_Tipo_Doc { get; set; }
        public int IdPersona { get; set; }
        public int Cantidad_Folios { get; set; }
        public DateTime Fecha_Recepcion { get; set; }
        public int Usuario_Recepcion { get; set; }
        public DateTime Fecha_Carga { get; set; }
        public int Usuario_Carga { get; set; }
        
    }
}
