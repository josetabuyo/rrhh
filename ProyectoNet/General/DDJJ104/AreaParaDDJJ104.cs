using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace General
{
    //Estados
    //1. Generar
    //2. Imprimir
    //3. ReImprimir

    public class AreaParaDDJJ104
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Persona> Personas { get; set; }
        public List<AreaParaDDJJ104> AreasInformalesDependientes { get; set; }
        public DDJJ104_2001 DDJJ { get; set; }
        public AreaParaDDJJ104 AreaSuperior { get; set; }
        public string Direccion { get; set; }
        public int Jerarquia { get; set; }

        public AreaParaDDJJ104()
        {
            this.Personas = new List<Persona>();
            this.AreasInformalesDependientes = new List<AreaParaDDJJ104>();
        }

    }
}
