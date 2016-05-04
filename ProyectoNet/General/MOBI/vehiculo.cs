using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;
//using RRHH.Framework;

namespace General
{
    public class Vehiculo
    {
        private int _numerovehiculo;
        private string _dominio;
        private string _segmento;
        private string _marca;
        private string _modelo;
        private string _motor;
        private string _chasis;
        private int _anio;
        private string _observacion;

        public int NumeroVehiculo { get { return _numerovehiculo; } }
        public string Dominio { get { return _dominio; } }
        public string Segmento { get { return _segmento; } }
        public string Marca { get { return _marca; } }
        public string Modelo { get { return _modelo; } }
        public string Motor { get { return _motor; } }
        public string Chasis { get { return _chasis; } }
        public int Anio { get { return _anio; } }
        public string Observacion { get { return _observacion; } }

        public Vehiculo() { }

        public Vehiculo(int NumeroVehiculo,
            string Dominio, string Segmento, string Marca, string Modelo, string Motor, string Chasis, int Anio, string Observacion) 
        {
            this._numerovehiculo = NumeroVehiculo;
            this._dominio = Dominio;
            this._segmento = Segmento;
            this._marca = Marca;
            this._modelo = Modelo;
            this._motor = Motor;
            this._chasis = Chasis;
            this._anio = Anio;
            this._observacion = Observacion;
        }
    }
}
