﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General
{
    public class Puesto
    {
        protected int _id;
        protected string _familia;
        protected string _profesion;
        protected string _denominacion;
        protected string _nivel;
        protected string _agrupamiento;
        protected int _vacantes;
        protected string _tipoConvocatoria;
        protected string _numero;
        protected Comite _comite;
        protected List<Foliable> _documentacionRequerida;

        public virtual int Id { get { return _id; } set { _id = value; } }
        public virtual string Familia { get { return _familia; } set { _familia = value; } }
        public virtual string Profesion { get { return _profesion; } set { _profesion = value; } }
        public virtual string Denominacion { get { return _denominacion; } set { _denominacion = value; } }
        public virtual string Nivel { get { return _nivel; } set { _nivel = value; } }
        public virtual string Agrupamiento { get { return _agrupamiento; } set { _agrupamiento = value; } }
        public virtual int Vacantes { get { return _vacantes; } set { _vacantes = value; } }
        public virtual string Tipo { get { return _tipoConvocatoria; } set { _tipoConvocatoria = value; } }
        public virtual string Numero { get { return _numero; } set { _numero = value; } }
        public virtual Comite Comite { get { return _comite; } set { _comite = value; } }
        public virtual List<Foliable> DocumentacionRequerida { get { return _documentacionRequerida; } set { _documentacionRequerida = value; } }

        public Puesto(int id, string familia, string profesion, string denominacion,string nivel, string agrupamiento, int vacantes, string tipo, string numero, Comite comite)
        {
            this._id = id;
            this._familia = familia;
            this._profesion = profesion;
            this._denominacion = denominacion;
            this._nivel = nivel;
            this._agrupamiento = agrupamiento;
            this._vacantes = vacantes;
            this._tipoConvocatoria = tipo;
            this._numero = numero;
            this._comite = comite;
        }

        public Puesto() { }



        List<RequisitoIdioma> _requisito_idioma = new List<RequisitoIdioma>();
        public void Requiere(RequisitoIdioma requisito_idioma)
        {
            _requisito_idioma.Add(requisito_idioma);
        }

        public bool TieneRequisito(RequisitoIdioma requisitoIdioma)
        {
            return _requisito_idioma.Any(i => i.Equals(requisitoIdioma));
        }
    }
}
