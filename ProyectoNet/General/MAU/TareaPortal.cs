using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.MAU
{
    public class TareaPortal
    {
        //public int Id { get; set; }
        //public TipoAlertaPortal Tipo { get; set; }

        public string descripcion { get; set; }
        public string titulo { get; set; }
        public int id { get; set; }
        public DateTime fechaCreacion { get; set; }
        public Usuario usuarioCreador { get; set; }
        public TipoTareaPortal tipoTarea { get; set; }
        public string estado { get; set; }

        public TareaPortal()
        { }

        public TareaPortal(int id, string titulo, string descripcion, TipoTareaPortal tipoTarea, DateTime fechaCreacion, Usuario usuarioCreador, string estado)
        {
            this.descripcion = descripcion;
            this.titulo = titulo;
            this.id = id;
            this.tipoTarea = tipoTarea;
            this.fechaCreacion = fechaCreacion;
            this.usuarioCreador = usuarioCreador;
            this.estado = estado;
        }

        public TareaPortal(int id, TipoTareaPortal tipoTarea, DateTime fechaCreacion, Usuario usuarioCreador, bool estado)
        {
            this.id = id;
            this.tipoTarea = tipoTarea;
            this.fechaCreacion = fechaCreacion;
            this.usuarioCreador = usuarioCreador;
            this.estado = estado.ToString();
        }
    }
}
