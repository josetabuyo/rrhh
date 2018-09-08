using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MED
{
    public class VerificacionCodigoGdeDocumento
    {
        public DateTime FechaVerificacion { get; set; }
        public string PersonaVerificadora { get; set; }
        public bool EsPositiva { get { return !this.IsNull(); } }

        public VerificacionCodigoGdeDocumento()
        {
        }

        public VerificacionCodigoGdeDocumento(DateTime fecha_verificacion, string persona_verificadora)
        {
            this.FechaVerificacion = fecha_verificacion;
            this.PersonaVerificadora = persona_verificadora;
        }

        public static VerificacionCodigoGdeDocumento Null()
        {
            return new VerificacionCodigoGdeDocumento(DateTime.MinValue, String.Empty);
        }

        public bool IsNull()
        {
            return this.FechaVerificacion.Equals(DateTime.MinValue) && this.PersonaVerificadora.Equals(string.Empty);
        }

        public static string UsuarioVerifFromDB(int id_usuario)
        {
            //modificar esto cuando necesitemos el nombre, o mas datos de la persona que verifico el codigo gde.
            if (id_usuario == 0) return string.Empty;
            return id_usuario.ToString();
        }
    }
}
