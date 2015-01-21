using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;



namespace General
{
    public class SolicitudInvalidaException:Exception
    {
        public string Message() {
            return "Inconsistencia de datos en licencias: Existen solicitudes de licencia ingresadas sin una autorizacion previa.";
        }
    }
}
