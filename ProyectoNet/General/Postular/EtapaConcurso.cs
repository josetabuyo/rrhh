using System;
namespace General
{
    public class EtapaConcurso
    {
        public int Id{ get; set; }
        public string Descripcion { get; set; }
        

        public EtapaConcurso()
        {

        }

        public EtapaConcurso(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
