using System;
using System.Collections.Generic;
using System.Text;
using General;

namespace General
{
    public class Vehiculo
    {
        public string NumeroVehiculo;
        public string Dominio;
        public string Segmento;
        public string Marca;
        public string Modelo;
        public string Motor;
        public string Chasis;
        public string Anio;
        public string Observacion;
        public string Area;
        public string Apellido;
        public string Nombre;
        public List<int> imagenes;
        public string MensajeTarjeton;
        public string Mensaje;


        public Vehiculo() {
            imagenes = new List<int>();
        }


    }
}
