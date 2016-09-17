
using System;
using System.Collections.Generic;
using System.Text;
using General.Repositorios;

    namespace General
    {

    public class ConceptoDeLicencia
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Articulo;
        public string Articulo
        {
            get { return _Articulo; }
            set { _Articulo = value; }
        }

        private string _Inciso;
        public string Inciso
        {
            get { return _Inciso; }
            set { _Inciso = value; }
        }

        private string _PathFormularioWeb;
        public string PathFormularioWeb
        {
            get { return _PathFormularioWeb; }
            set { _PathFormularioWeb = value; }
        }

        private bool _DiasHabiles;
        public bool DiasHabiles
        {
            get { return _DiasHabiles; }
            set { _DiasHabiles = value; }
        }

        public virtual AnalisisDeLicenciaOrdinaria GetAnalisisCalculoVacacionesPara(IRepositorioLicencia iRepositorioLicencia, IRepositorioDePersonas repositorio_personas, Persona persona, DateTime fecha_de_consulta)
        {
            throw new Exception("Responsabilidad de la subclase");
        }

        public virtual SaldoLicencia RealizarCalculoDeSaldo(IRepositorioLicencia iRepositorioLicencia, IRepositorioDePersonas repositorio_personas, Persona persona, DateTime fecha_de_consulta)
        {
            throw new Exception("Responsabilidad de la subclase");
        }

        public ConceptoDeLicencia InstanciaDeSubclase()
        {
            if (this.Id == 1)
            {
                return new ConceptoLicenciaAnualOrdinaria();
            }
            else
            {
                return new ConceptoLicenciaGeneral(this.Id);
            }
        }
    }
}
