using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
//using RRHH.Framework;

namespace General
{
    public class Persona
    {
        private int _id;
        private int _Documento;
        private string _Nombre;
        private string _Apellido;
        private Area _Area;
        private int _idArea;
        private PaseDeArea _PasePendiente;
        private Inasistencia _InasistenciaActual;
        private List<Inasistencia> _Inasistencias;
        private TipoDeViatico _TipoDeViatico;
        private ModalidadDeContratacion _ModalidadDeContratacion;
        private string _Nivel;
        private string _Grado;
        private float _Retribucion;
        private TipoDePlanta _TipoDePlanta;
        private bool _Es1184;
        private string _Telefono;
        private string _Cuit;
        private string _Legajo;
        private string _categoria;
        private bool _estaCertificadoEnLaDDJJ;
        private string _certificaHoraDesdeDDJJ;
        private string _certificaHoraHastaDDJJ;
        private string _motivo_no_certificar { get; set; }
        private string _cco_no_certificar { get; set; }


        public int Id { get { return _id; } set { _id = value; } }
        public int Documento { get { return _Documento; } set { _Documento = value;  } }
        public string Nombre { get { return _Nombre; } set { _Nombre = value;  } }  
        public string Apellido { get { return _Apellido; } set { _Apellido = value;  } }
        public Area Area { get { return _Area; } set { _Area = value;  } }
        public int IdArea { get { return _idArea; } set { _idArea = value; } }
        public PaseDeArea PasePendiente { get { return _PasePendiente; } set { _PasePendiente = value;  } }
        public Inasistencia InasistenciaActual { get { return _InasistenciaActual; } set { _InasistenciaActual = value;  } }
        public List<Inasistencia> Inasistencias { get { return _Inasistencias; } set { _Inasistencias = value; } }
        public TipoDeViatico TipoDeViatico { get { return _TipoDeViatico; } set { _TipoDeViatico = value; } }
        public ModalidadDeContratacion ModalidadDeContratacion { get { return _ModalidadDeContratacion; } set { _ModalidadDeContratacion = value; } }
        public string Nivel { get { return _Nivel; } set { _Nivel = value;  } }
        public string Grado { get { return _Grado; } set { _Grado = value;  } }    
        public float Retribucion { get { return _Retribucion; } set { _Retribucion = value;  } }  
        public TipoDePlanta TipoDePlanta { get { return _TipoDePlanta; } set { _TipoDePlanta = value;  } }
        public bool Es1184 { get { return _Es1184; } set { _Es1184 = value;  } }  
        public string Telefono { get { return _Telefono; } set { _Telefono = value;  } }
        public string Cuit { get { return _Cuit; } set { _Cuit = value;  } } 
        public string Legajo { get { return _Legajo; } set { _Legajo = value;  } }
        public string Categoria { get { return _categoria; } set { _categoria = value; } }
        public int Esta_Cargada { get; set; } //si ya existe en una DDJJ104
        public int IdImagen { get; set; }
        public bool BajaLegajo { get; set; }
        public bool EstaCertificadoEnLaDDJJ { get { return _estaCertificadoEnLaDDJJ; } set { _estaCertificadoEnLaDDJJ = value; } }
        public string CertificaHoraDesdeDDJJ { get { return _certificaHoraDesdeDDJJ; } set { _certificaHoraDesdeDDJJ = value; } }
        public string CertificaHoraHastaDDJJ { get { return _certificaHoraHastaDDJJ; } set { _certificaHoraHastaDDJJ = value; } }
        public string MotivoNoCertificar { get { return _motivo_no_certificar; } set { _motivo_no_certificar = value; } }
        public string CCONoCertificar { get { return _cco_no_certificar; } set { _cco_no_certificar = value; } }  

        public Persona() { }

        public Persona(int id, int documento, string nombre, string apellido, Area area) 
        {
            this._id = id;
            this._Documento = documento;
            this._Apellido = apellido;
            this._Nombre = nombre;
            this._Area = area;
            this._Inasistencias = new List<Inasistencia>();
        }

        public Persona(int id, int documento, string nombre, string apellido, Area area, List<Inasistencia> inasistencias)
        {
            this._id = id;
            this._Documento = documento;
            this._Apellido = apellido;
            this._Nombre = nombre;
            this._Area = area;
            this._Inasistencias = inasistencias;
        }

        //public List<Inasistencia> Inasistencias()
        //{
        //    return _Inasistencias;
        //}

        public void AgregarInasistencia(Inasistencia inasistencia)
        {
            if(_Inasistencias == null)
            {_Inasistencias = new List<Inasistencia>();}
            if (!_Inasistencias.Contains(inasistencia))
                _Inasistencias.Add(inasistencia);
        }  

        public override bool Equals(object obj)
        {
            //return this.Id == ((Persona)obj).Id;
            if (!(obj is Persona)) return false;
            Persona otro = (Persona)obj;
            return otro.Documento == Documento;
        }

        public override int GetHashCode()
        {
            return this.Documento.GetHashCode();
        }


    }
}