using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Postular
{
    public class Puesto
    {
        protected int _id;
        protected string _categoria;
        protected string _titulo;
        protected string _descripcion;
        protected int _vacantes;
        protected string _tipo;

        public virtual int Id { get { return _id; } set { _id = value; } }
        public virtual string Categoria { get { return _categoria; } set { _categoria = value; } }
        public virtual string Titulo { get { return _titulo; } set { _titulo = value; } }
        public virtual string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public virtual int Vacantes { get { return _vacantes; } set { _vacantes = value; } }
        public virtual string Tipo { get { return _tipo; } set { _tipo = value; } }

        public Puesto(int id, string categoria, string titulo, string descripcion, int vacantes, string tipo)
        {
            this._id = id;
            this._categoria = categoria;
            this._titulo = titulo;
            this._descripcion = descripcion;
            this._vacantes = vacantes;
            this._tipo = tipo;
        }

        public Puesto() { }

    }
}
