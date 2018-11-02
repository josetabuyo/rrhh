using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Contrato
{
    public class Serv_Adm_Publica_Privada
    {
        public int Id { get; set; }
        public Ambito Ambito { get; set; }
        public string Jurisdiccion { get; set; }
        public string Organismo { get; set; }
        public Cargo Cargo { get; set; }
        public bool Remunerativo { get; set; }
        public DateTime Fecha_Desde { get; set; }
        public DateTime Fecha_Hasta { get; set; }
        public string Causa_Egreso { get; set; }
        public string Folio { get; set; }
        public int Id_Interna { get; set; }
        public int Doc_Titular { get; set; }
        public string Caja { get; set; }
        public string Afiliado { get; set; }
        public bool DatoDeBaja { get; set; }
        public bool datonoimprime { get; set; }
        public bool Ctr_Cert { get; set; }
        public Int16 Usuario { get; set; }
        public DateTime Fecha_Carga { get; set; }

        public string Institucion { get; set; }
        public string Domicilio { get; set; }
    }
}
