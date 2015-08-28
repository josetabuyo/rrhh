using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class ResumenDePostulaciones
    {
        private int _idPerfil;
        private string _descPerfil;
        private int _numComite;
        private int _postulados;
        private int _inscriptos;

        public ResumenDePostulaciones() { }

        public ResumenDePostulaciones(int id_perfil, string descripcion_perfil,string perfil_nivel, string perfil_numero, string perfil_agrupamiento, int numero_comite, int postulados, int inscriptos)
        {
            // TODO: Complete member initialization
            this._idPerfil = id_perfil;
            this._descPerfil = descripcion_perfil + " - Nivel " + perfil_nivel + " - " + perfil_agrupamiento + " - " + perfil_numero;
            this._numComite = numero_comite;
            this._postulados = postulados;
            this._inscriptos = inscriptos;
        }

        public int IdPerfil { get { return _idPerfil; } set { _idPerfil = value; } }
        public string DescripcionPerfil { get { return _descPerfil; } set { _descPerfil = value; } }
        public int NumeroComite { get { return _numComite; } set { _numComite = value; } }
        public int Postulados { get { return _postulados; } set { _postulados = value; } }
        public int Inscriptos { get { return _inscriptos; } set { _inscriptos = value; } }

        
    }
}
