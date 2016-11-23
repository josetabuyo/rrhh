using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class PersonaContrato
    {
        public int NroDocumento { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int IdArea { get; set; }
        public string Area { get; set; }
        public string AreaDescripCorta { get; set; }
        public string AreaDescripMedia { get; set; }
        public int OrdenArea { get; set; }
        public int Informe { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public string EstadoCorto { get; set; }

        public PersonaContrato() { }


        public PersonaContrato(int doc, string nom, string apell, int idArea, string area_corta, string area_media, int orden, int infor, string estado, string estado_corto, int idEstado) 
        {
            NroDocumento = doc;
            Apellido = apell;
            Nombre = nom;
            IdArea = idArea;
            Area = area_corta;
            AreaDescripCorta = area_corta;
            AreaDescripMedia = area_media;
            OrdenArea = orden;
            Informe = infor;
            Estado = estado;
            IdEstado = idEstado;
            EstadoCorto = estado_corto;
        }
    }
}
