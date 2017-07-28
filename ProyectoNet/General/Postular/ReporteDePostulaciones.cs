using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Postular
{
    public class ReporteDePostulaciones
    {
        public int idPostulacion { get; set; }
        public int idPerfil { get; set; }
        public string nombrePerfil { get; set; }
        public int idPersona { get; set; }
        public string numero { get; set; }
        public DateTime fechaInscripcion { get; set; }
        public int documento { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public List<string> informes { get; set; }

        public ReporteDePostulaciones(string nombrePerfil, string numero, DateTime fechaInscripcion, int documento, string nombre, string apellido, List<string> informes)
        {
            this.nombrePerfil = nombrePerfil;
            this.numero = numero;
            this.fechaInscripcion = fechaInscripcion;
            this.documento = documento;
            this.nombre = nombre;
            this.apellido = apellido;
            this.informes = informes;

        }

        public ReporteDePostulaciones()
        {

        }
    }
}