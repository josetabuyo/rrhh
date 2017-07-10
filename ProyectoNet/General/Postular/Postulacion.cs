using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Postular;

namespace General
{
    public class Postulacion
    {
        protected int _id;
      /*  protected Puesto _puesto;*/
        protected Perfil _perfil;
        protected Persona _postulante;
        protected DateTime _fechaPostulacion;
        protected string _motivo;
        protected string _observaciones;
        protected string _numero;
        protected List<EtapaPostulacion> _etapas;
        protected List<DocumentacionRecibida> _docRecibida;
        protected List<DocumentacionRecibida> _docARecibir;
        protected List<string> _numerosDeInformeGDE;

        public virtual int Id { get { return _id; } set { _id = value; } }
        //public virtual Puesto Puesto { get { return _perfil; } set { _perfil = value; } }
        public virtual Perfil Perfil { get { return _perfil; } set { _perfil = value; } }
        public virtual Persona Postulante { get { return _postulante; } set { _postulante = value; } }
        public virtual DateTime FechaPostulacion { get { return _fechaPostulacion; } set { _fechaPostulacion = value; } }
        public virtual string Motivo { get { return _motivo; } set { _motivo = value; } }
        public virtual string Observaciones { get { return _observaciones; } set { _observaciones = value; } }
        public virtual string Numero { get { return _numero; } set { _numero = value; } }
        public virtual List<EtapaPostulacion> Etapas { get { return _etapas; } set { _etapas = value;} }
        public virtual List<DocumentacionRecibida> DocumentacionRecibida { get { return _docRecibida; } set { _docRecibida = value; } }
        public virtual List<DocumentacionRecibida> DocumentacionARecibir { get { return _docARecibir; } set { _docARecibir = value; } }
        public virtual List<string> NumerosDeInformeGDE { get { return _numerosDeInformeGDE; } set { _numerosDeInformeGDE = value; } }


        public Postulacion(int id, Perfil perfil, DateTime fecha, string motivo, string observaciones, string numero, List<EtapaPostulacion> etapas)
        {
            _id = id;
            _perfil = perfil;
            _fechaPostulacion = fecha;
            _motivo = motivo;
            _observaciones = observaciones;
            _numero = numero;
            _etapas = etapas;
            _docRecibida = new List<DocumentacionRecibida>();
            _docARecibir = new List<DocumentacionRecibida>();
        }

        public Postulacion() {
            this._etapas = new List<EtapaPostulacion>();
            this._docRecibida = new List<DocumentacionRecibida>();
            this._docARecibir = new List<DocumentacionRecibida>();
        }


        public EtapaPostulacion EtapaEn(DateTime fecha)
        {
            return this.Etapas.FindLast(e => e.Fecha <= fecha);
        }

        internal void AgregarPostulacion(EtapaPostulacion ep)
        {
            this._etapas.Add(ep);
        }

        //public void AgregarDocumentacionARecibida(DocumentacionRecibida doc)
        //{
        //    this._docARecibir.Add(doc);
        //}

        //public void CrearDocumentacionARecibir(List<Foliable> foliables, CurriculumVitae cv)
        //{ 
        //    foliables.ForEach(f => f.documentacion(cv).ForEach(d => this.AgregarDocumentacionARecibida(new DocumentacionRecibida(0, "", f, DateTime.Today))));

                
        //}
        public EtapaPostulacion EtapaActual()
        {
            var etapas = this.Etapas.OrderByDescending(e => e.Fecha).ToList();
            return etapas.First();
        }


        internal Postulacion SoloEtapaVigente()
        {
            EtapaPostulacion etapa_vigente = new EtapaPostulacion();

            etapa_vigente = this.EtapaActual();
            this.Etapas = new List<EtapaPostulacion>();
            this.Etapas.Add(etapa_vigente);

            return this;
        }
    }
}
