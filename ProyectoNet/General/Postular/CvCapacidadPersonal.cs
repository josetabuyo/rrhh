using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.MAU;
using General.Repositorios;

namespace General
{
    public class CvCapacidadPersonal:ItemCv
    {
        protected int _id;
        protected int _tipo;
        protected string _detalle;

        public int Id { get { return _id; } set { _id = value; } }
        public int Tipo { get { return _tipo; } set { _tipo = value; } }
        public string Detalle { get { return _detalle; } set { _detalle = value; } }

        public CvCapacidadPersonal(int id, int tipo, string detalle):base(id,detalle,11)
        {
            this._id = id;
            this._tipo = tipo;
            this._detalle = detalle;
        }

        public CvCapacidadPersonal()
        {
        }

        override public void validarDatos()
        {
            var validador_capacidad = new Validador();

            validador_capacidad.DeberianSerNoVacias(new string[] { "Detalle" });
            validador_capacidad.DeberianSerNaturalesOCero(new string[] { "Tipo" });

            if (!validador_capacidad.EsValido(this))
                throw new ExcepcionDeValidacion("El tipo de dato no es correcto");
        }

        override public Dictionary<string, object> Parametros(Usuario usuario, RepositorioDeCurriculum repo)
        {
            return repo.ParametrosDeCapacidadPersonal(this, usuario);
        }

        override public string SpInsercion(RepositorioDeCurriculum repo)
        {
            return repo.SpCapacidadPersonal();
        }
    }
}
