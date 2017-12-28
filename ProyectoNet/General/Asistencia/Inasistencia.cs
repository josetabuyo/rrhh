using System;
using System.Collections.Generic;

using System.Text;
using General.MAU;
using General;

namespace General
{
    public class Inasistencia
    {
        private int _Id;
        private string _PathFormularioWeb;
        private string _Descripcion;
        private bool _Aprobada;

        private string _Estado;

        public DateTime Desde;
        public DateTime Hasta;
        public string Motivo;
        public Usuario Usuario;
        public Persona Persona;
        public int idPersona;
        public int Documento;

        public int Id    {get { return _Id; }set { _Id = value; } }
        public string PathFormularioWeb {get { return _PathFormularioWeb; } set { _PathFormularioWeb = value;  }}
        public string Descripcion {get { return _Descripcion; }set { _Descripcion = value;  }}
        public bool Aprobada {get { return _Aprobada; }set { _Aprobada = value;  }}
        public string Estado {get { return _Estado; }set { _Estado = value; } }



        public Inasistencia()
        {
        }

        public Inasistencia(int id, Persona persona, string motivo, DateTime desde, DateTime hasta, Usuario usuario)
        {
            this.Id = id;
            this.Persona = persona;
            this.Motivo = motivo;
            this.Desde = desde;
            this.Hasta = hasta;
            this.Usuario = usuario;



        }

    }
}
