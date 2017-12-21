using System;
using System.Collections.Generic;

using System.Text;
using General.MAU;

namespace General
{
    public class Inasistencia
    {
        private int _Id;
        private string _PathFormularioWeb;
        private string _Descripcion;
        private bool _Aprobada;
        private DateTime _Desde;
        private DateTime _Hasta;
        private string _Estado;
        private string _Motivo;
        private Usuario _Usuario;
        private Persona _Persona;

        public int Id    {get { return _Id; }set { _Id = value; } }
        public string PathFormularioWeb {get { return _PathFormularioWeb; } set { _PathFormularioWeb = value;  }}
        public string Descripcion {get { return _Descripcion; }set { _Descripcion = value;  }}
        public bool Aprobada {get { return _Aprobada; }set { _Aprobada = value;  }}
        public DateTime Desde {get { return _Desde; } set { _Desde = value;  } }
        public DateTime Hasta {get { return _Hasta; } set { _Hasta = value;  }}
        public string Estado {get { return _Estado; }set { _Estado = value; } }

        public string Motivo { get { return _Motivo; } set { _Motivo = value; } }
        public Usuario Usuario { get { return _Usuario; } set { _Usuario = value; } }
        public Persona Persona { get { return _Persona; } set { _Persona = value; } }

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
