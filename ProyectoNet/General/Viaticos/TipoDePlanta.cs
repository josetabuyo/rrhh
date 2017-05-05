using System;
using System.Collections.Generic;

using System.Text;
using General.Repositorios;

namespace General
{
    
    public class TipoDePlanta: IConPersona
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value;  }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value;  }
        }

        public virtual ProrrogaLicenciaOrdinaria Prorroga(DateTime fecha_calculo)
        {
            throw new Exception("Responsabilidad de la subclase");
        }

        public TipoDePlanta InstanciaDeSubclase(IRepositorioLicencia repo)
        {
            if (this.Id == 22)
            {
                return new TipoDePlantaContratado();
            }
            else
            {
                return new TipoDePlantaGeneral(this._Id, this._Descripcion, repo);
            }
        }

        public Persona Persona { get; set; }

        public DateTime Desde()
        {
            return DateTime.Now;
        }
    }
}
