using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class MAU_Perfil
    {
        public string Nombre { get; set; }
        public int Id { get; set; }
        public List<Funcionalidad> Funcionalidades { get; set; }
        public DateTime FechaDesde { get; set; }
        public List<Area> Areas { get; set; }
        public List<Entidad> Entidades { get; set; }
        public bool Basica { get; set; }
        public int TipoPerfil { get; set; }


        public MAU_Perfil()
        {

        }
        public MAU_Perfil(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Areas = new List<Area>();
            this.Entidades = new List<Entidad>();
            this.Funcionalidades = new List<Funcionalidad>();

        }

        public MAU_Perfil(int id, string nombre, bool basica)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Areas = new List<Area>();
            this.Entidades = new List<Entidad>();
            this.Funcionalidades = new List<Funcionalidad>();
            this.Basica = basica;

        }


    }
}
