using System;
using System.Collections.Generic;
using System.Text;
using General;


namespace General
{
    public class TransicionDeViatico
    {
        public TransicionDeViatico()
        {

        }
        public TransicionDeViatico(Area area_origen, Area area_destino, AccionDeTransicion accion, DateTime fecha, String comentario)
        {
            this.AreaOrigen = area_origen;
            this.AreaDestino = area_destino;
            this.Accion = accion;
            this.Comentario = Comentario;
            this.Fecha = fecha;
        }
        public TransicionDeViatico(int id, Area area_origen, Area area_destino, AccionDeTransicion accion, DateTime fecha, String comentario)
        {
            this.Id = id;            
            this.AreaOrigen = area_origen;
            this.AreaDestino = area_destino;
            this.Accion = accion;
            this.Comentario = comentario;
            this.Fecha = fecha;
        }
        public int Id { get; set; }
        public Area AreaOrigen { get; set; }
        public Area AreaDestino { get; set; }
        public AccionDeTransicion Accion { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
    }
}
