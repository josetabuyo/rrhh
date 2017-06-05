using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class AlertaPortal
    {
        //public int Id { get; set; }
        //public TipoAlertaPortal Tipo { get; set; }

        public string descripcion { get; set; }
        public string titulo { get; set; }
        public int id { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Usuario usuarioCreador { get; set; }
        public TipoAlertaPortal tipoAlerta { get; set; }
        public string estado { get; set; }

        public AlertaPortal()
        { }

        public AlertaPortal(int id, string titulo, string descripcion, TipoAlertaPortal tipoAlerta, DateTime fechaCreacion, Usuario usuarioCreador, string estado)
        {
            this.descripcion = descripcion;
            this.titulo = titulo;
            this.id = id;
            this.tipoAlerta = tipoAlerta;
            this.fechaCreacion = fechaCreacion;
            this.usuarioCreador = usuarioCreador;
            this.estado = estado;
        }

        public AlertaPortal(int id, TipoAlertaPortal tipoAlerta, DateTime fechaCreacion, Usuario usuarioCreador, bool estado)
        {
            this.id = id;
            this.tipoAlerta = tipoAlerta;
            this.fechaCreacion = fechaCreacion;
            this.usuarioCreador = usuarioCreador;
            this.estado = estado.ToString();
        }
    }
}
