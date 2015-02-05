using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;
using General.Repositorios;

namespace General
{
    public class CvPublicaciones: ItemCv
    {
        protected int _id;
        protected string _titulo;
        protected string _datosEditorial;
        protected string _cantidadHojas;
        protected int _disponeCopia;
        protected int _disponeAdjunto;
        protected DateTime _fechaPublicacion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Titulo { get { return _titulo; } set { _titulo = value; } }
        public string DatosEditorial { get { return _datosEditorial; } set { _datosEditorial = value; } }
        public string CantidadHojas { get { return _cantidadHojas; } set { _cantidadHojas = value; } }
        public int DisponeCopia { get { return _disponeCopia; } set { _disponeCopia = value; } }
        public int DisponeAdjunto { get { return _disponeAdjunto; } set { _disponeAdjunto = value; } }
        public DateTime FechaPublicacion { get { return _fechaPublicacion; } set { _fechaPublicacion = value; } }

        public CvPublicaciones()
        {
        }

        public CvPublicaciones(int id, string titulo, string datosEditorial, string cantidadHojas, int disponeCopia, int disponeAdjunto, DateTime fechaPublicacion):base(id,titulo,5)
        {
            this._id = id;
            this._titulo = titulo;
            this._datosEditorial = datosEditorial;
            this._cantidadHojas = cantidadHojas;
            this._disponeCopia = disponeCopia;
            this._disponeAdjunto = disponeAdjunto;
            this._fechaPublicacion = fechaPublicacion;
        }

        override public void validarDatos()
        {
            var validador_publicacion = new Validador();

            validador_publicacion.DeberianSerNoVacias(new string[] { "Titulo", "CantidadHojas", "DatosEditorial", });
            validador_publicacion.DeberianSerFechasNoVacias(new string[] { "FechaPublicacion" });
            validador_publicacion.DeberianSerNaturalesOCero(new string[] { "DisponeAdjunto", "DisponeCopia" });

            if (!validador_publicacion.EsValido(this))
                throw new ExcepcionDeValidacion("El tipo de dato no es correcto");
        }

        override public Dictionary<string, object> Parametros(Usuario usuario, RepositorioDeCurriculum repo)
        {
            return repo.ParametrosDePublicaciones(this, usuario);
        }

        override public string SpInsercion(RepositorioDeCurriculum repo)
        {
            return repo.SPPubliaciones();
        }
    }
}
