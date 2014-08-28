using System;
using System.Collections.Generic;
using System.Text;
using General;


namespace General
{
    public class TransicionDeDocumento
    {
        public static string ATOMICA = "A";
        public static string FUTURA = "F";

        private string _tipo;
        public string Tipo { get { return _tipo; } }
        
        public int Id { get; set; }
        public Area AreaOrigen { get; set; }
        public Area AreaDestino { get; set; }
        public DateTime Fecha { get; set; }
        public Documento Documento { get; set; }
        

        public TransicionDeDocumento()
        {

        }

        public TransicionDeDocumento(Area area_origen, Area area_destino, DateTime fecha, Documento documento, string tipo)
            :this(area_origen, area_destino, documento, tipo)
        {
            this.Fecha = fecha;
        }

        public TransicionDeDocumento(int id, Area area_origen, Area area_destino, DateTime fecha, Documento documento, string tipo)
            : this(area_origen, area_destino, fecha, documento, tipo)
        {
            this.Id = id;
        }

        public TransicionDeDocumento(Area area_origen, Area area_destino, General.Documento documento, string tipo)
        {
            this.AreaOrigen = area_origen;
            this.AreaDestino = area_destino;
            
            Validador().NoEsNulo(documento, "El documento de una transaccion (id=" + this.Id.ToString() +")");
            this.Documento = documento;

            _tipo = tipo;
        }

        private ValidadorMICOI Validador()
        {
            return new ValidadorMICOI();
        }
    }
}
