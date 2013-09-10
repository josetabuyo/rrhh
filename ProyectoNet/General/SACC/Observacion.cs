using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class Observacion
    {
        private int _id;
        private DateTime _fecha_carga;
        private string _relacion;
        private string _persona_que_cargo;
        private string _pertenece;
        private string _asunto;
        private string _referente_mds;
        private string _seguimiento;
        private string _resultado;
        private DateTime _fecha_rta;
        private string _rta_por_mds;
        private bool _baja;

        public int Id { get { return _id; } }
        public DateTime FechaCarga { get { return _fecha_carga; }  }
        public string Relacion { get { return _relacion; } }
        public string PersonaCarga { get { return _persona_que_cargo; } }
        public string Pertenece { get { return _pertenece; } }
        public string Asunto { get { return _asunto; } }
        public string ReferenteMDS { get { return _referente_mds; } }
        public string Seguimiento { get { return _seguimiento; } }
        public string Resultado { get { return _resultado; } }
        public DateTime FechaResultado { get { return _fecha_rta; } }
        public string ReferenteRespuestaMDS { get { return _rta_por_mds; } }
        public bool Baja { get { return _baja; } }

        public Observacion() { }

        public Observacion(int id, DateTime fecha_carga, string relacion, string persona_carga, string pertenece, string asunto, string referente_mds, string seguimiento, string resultado, DateTime fecha_rta, string rta_por_mds)
        {
            _id = id;
            _fecha_carga = fecha_carga;
            _relacion = relacion;
            _persona_que_cargo = persona_carga;
            _pertenece = pertenece;
            _asunto = asunto;
            _referente_mds = referente_mds;
            _seguimiento = seguimiento;
            _resultado = resultado;
            _fecha_rta = fecha_rta;
            _rta_por_mds = rta_por_mds;
        
        }

    }
}
