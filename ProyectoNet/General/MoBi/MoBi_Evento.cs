using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class MoBi_Evento
    {
        private int _Id;
        private DateTime _Fecha;
        private string _TipoEvento;
        private string _Observaciones;
        private string _Area;
        private string _Responsable;
        private string _Operador;
        public string Receptor { get; set; }

        public enum enumTipoEvento
        {
            ALTA_PROVISORIA, ALTA_DEFINITIVA, ASIGNACION_FORMAL_TRANSITO, ASIGNACION_FORMAL_RECEPCION,
            ASIGNACION_OPERATIVA_TRANSITO, ASIGNACION_OPERATIVA_RECEPCION, ASIGNACION_OPERATIVA_RECHAZO,
            SOLICITUD_REPARACION, EN_REPARACION, BAJA
        };

        public string Operador
        {
            get { return _Operador; }
            set { _Operador = value; }
        }        

        public string Responsable
        {
            get { return _Responsable; }
            set { _Responsable = value; }
        }
        

        public string Area
        {
            get { return _Area; }
            set { _Area = value; }
        }
        
        public string Observaciones
        {
            get { return _Observaciones; }
            set { _Observaciones = value; }
        }
        
        public string TipoEvento
        {
            get { return _TipoEvento; }
            set { _TipoEvento = value; }
        }
        

        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }
        

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        

    }
}
