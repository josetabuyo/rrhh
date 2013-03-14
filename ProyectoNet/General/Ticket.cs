using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class Documento
    {
        public Documento()
        {
            this.TransicionesRealizadas = new List<TransicionDeTramite>();
        }

        public Documento(int _id, string _descripcion )
        {
            this.TransicionesRealizadas = new List<TransicionDeTramite>();
            this.Id = _id;
            this.Descripcion = _descripcion;
        }

        public Documento(int _id, string _descripcion, Area area_creadora)
        {
            this.TransicionesRealizadas = new List<TransicionDeTramite>();
            this.Id = _id;
            this.Descripcion = _descripcion;
            _areaCreadora = area_creadora;
        }

        protected int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }

        public String Descripcion { get; set; }

        protected Area _areaCreadora;
        public Area AreaCreadora { get { return _areaCreadora; } set { _areaCreadora = value; } }

        public Area AreaActual
        {
            get
            {
                var areaActual = AreaCreadora;
                if (TransicionesRealizadas.Count > 0)
                {
                    var maxFecha = TransicionesRealizadas.Select(t => t.Fecha).Max();
                    var ultimaTransicion = TransicionesRealizadas.Find(t => t.Fecha == maxFecha);
                    areaActual = ultimaTransicion.AreaDestino;
                }
                return areaActual;
            }
        }

        private List<TransicionDeTramite> TransicionesRealizadas { get; set; }

        public void enviarA(Area area_destino, AccionDeTransicion accion, String comentario)
        {
            var transicion = new TransicionDeTramite(this.AreaActual, area_destino, accion, DateTime.Now, comentario);
            this.TransicionesRealizadas.Add(transicion);
        }
    }
}
