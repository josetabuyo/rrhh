using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebRhUITestNew
{
    public class FakeArea
    {
        public FakeArea(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
