using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class Funcionalidad
    {
        public string Grupo { get; set; }
        public string Nombre { get; set; }
        public int Id { get; set; }
        public bool SoloParaVerificados { get; set; }
        public bool SoloParaEmpleados { get; set; }
        public bool basica { get; set; }

        public Funcionalidad()
        {

        }
        public Funcionalidad(int id, string nombre, string grupo, bool solo_para_verificados, bool solo_para_empleados, bool basica)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Grupo = grupo;
            this.SoloParaVerificados = solo_para_verificados;
            this.SoloParaEmpleados = solo_para_empleados;
            this.basica = basica;
        }

        public override bool Equals(Object obj)
        {
            if (obj.GetType() != this.GetType()) return false;
            return this.Id == ((Funcionalidad)obj).Id;
        }
    }
}
