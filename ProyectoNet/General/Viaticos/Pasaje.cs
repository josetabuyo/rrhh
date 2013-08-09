using System;
using System.Collections.Generic;

using System.Text;


namespace General
{
    public class Pasaje
    {
        private ComisionDeServicio _ComisionDeServicio;
        private int _Id;
        private Localidad _Origen;
        private Localidad _Destino;
        private decimal _Precio;
        private DateTime _FechaDeViaje;
        private MedioDeTransporte _MedioDeTransporte;
        private MedioDePago _MedioDePago;
        private bool _Baja;


        public ComisionDeServicio ComisionDeServicio { get { return _ComisionDeServicio; } set { _ComisionDeServicio = value;  } }

        public int Id { get { return _Id; } set { _Id = value;  } }
    
        public Localidad Origen { get { return _Origen; } set { _Origen = value;  } }
   
        public Localidad Destino { get { return _Destino; } set { _Destino = value;  } }

        public decimal Precio { get { return _Precio; } set { _Precio = value; } }
      
        public DateTime FechaDeViaje { get { return _FechaDeViaje; } set { _FechaDeViaje = value;  } }

        public MedioDeTransporte MedioDeTransporte { get { return _MedioDeTransporte; } set { _MedioDeTransporte = value;  } }
 
        public MedioDePago MedioDePago { get { return _MedioDePago; } set { _MedioDePago = value;  } }
  
        public bool Baja { get { return _Baja; } set { _Baja = value;  } }

        public Pasaje()
        { }

        public Pasaje(Localidad origen, Localidad destino, DateTime fecha_de_viaje, MedioDeTransporte medio_transporte, MedioDePago medio_pago)
        {
            this._Origen = origen;
            this._Destino = destino;
            this._FechaDeViaje = fecha_de_viaje;
            this._MedioDeTransporte = medio_transporte;
            this._MedioDePago = medio_pago;
        
        }

        public override bool Equals(object obj)
        {
            if (base.Equals(obj)) { return true; }
            if (((Pasaje)obj).Id == this.Id) { return true; }
            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

    }
}
