using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Postular
{
    public class CVCaracterDeParticipacionEvento
    {

        public int Id;
        public string Descripcion;

        public CVCaracterDeParticipacionEvento()
        {

        }

        public CVCaracterDeParticipacionEvento(int id, string descripcion)
        {
            this.Id = id;
            this.Descripcion = descripcion;
        }
    }
}
