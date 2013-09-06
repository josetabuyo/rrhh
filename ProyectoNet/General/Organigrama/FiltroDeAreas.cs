namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FiltroDeAreas
    {
        public static Func<Area, String, bool> PredicadoPorNombre = (area, unNombre) => { return area.Nombre.Contains(unNombre); };
        public static Func<Area, string, bool> PredicadoPorResponsable = (area, unResponsable) => { return area.datos_del_responsable.Apellido.Contains(unResponsable) || area.datos_del_responsable.Nombre.Contains(unResponsable); };
        public static Func<Area, string, bool> PredicadoPorAsistente = (area, unAsistente) => { return area.Asistentes.Exists(asistente => asistente.Apellido.Contains(unAsistente) || area.Asistentes.Exists(asistent => asistent.Nombre.Contains(unAsistente))); };
        //public static Func<Area, string, bool> PredicadoPorTelefono = (area, unTelefono) => { return PredicadoPorTelefonoDeAsistente(area, unTelefono) || PredicadoPorTelefonoDeResponsable(area, unTelefono) || PredicadoPorTelefonoDeArea(area, unTelefono); };
        //public static Func<Area, string, bool> PredicadoPorMail = (area, unMail) => { return PredicadoPorMailDeAsistente(area, unMail) || PredicadoPorMailDeResponsable(area, unMail) || PredicadoPorMailDeArea(area, unMail); };
        //public static Func<Area, string, bool> PredicadoPorFax = (area, unFax) => { return PredicadoPorFaxDeAsistente(area, unFax) || PredicadoPorFaxDeResponsable(area, unFax) || PredicadoPorFaxDeArea(area, unFax); };
        public static Func<Area, string, bool> PredicadoPorDireccion = (area, unaDireccion) => { return area.Direccion.Contains(unaDireccion); };


        public static Func<Area, string, bool> PredicadoPorTelefonoDeAsistente = (area, unTelefono) => { return area.Asistentes.Exists(asistente => asistente.Telefono.Contains(unTelefono)); };
        public static Func<Area, string, bool> PredicadoPorTelefonoDeResponsable = (area, unTelefono) => { return area.datos_del_responsable.Telefono.Contains(unTelefono); };
        //public static Func<Area, string, bool> PredicadoPorTelefonoDeArea = (area, unTelefono) => { return area.Telefono.Contains(unTelefono); };

        public static Func<Area, string, bool> PredicadoPorFaxDeAsistente = (area, unFax) => { return area.Asistentes.Exists(asistente => asistente.Fax.Contains(unFax)); };
        public static Func<Area, string, bool> PredicadoPorFaxDeResponsable = (area, unFax) => { return area.datos_del_responsable.Fax.Contains(unFax); };
       // public static Func<Area, string, bool> PredicadoPorFaxDeArea = (area, unFax) => { return area.Fax.Contains(unFax); };

        public static Func<Area, string, bool> PredicadoPorMailDeAsistente = (area, unMail) => { return area.Asistentes.Exists(asistente => asistente.Mail.Contains(unMail)); };
        public static Func<Area, string, bool> PredicadoPorMailDeResponsable = (area, unMail) => { return area.datos_del_responsable.Mail.Contains(unMail); };
        //public static Func<Area, string, bool> PredicadoPorMailDeArea = (area, unMail) => { return area.Mail.Contains(unMail); };
        private string valor;

        Func<Area, String, bool> predicado;

        public FiltroDeAreas(Func<Area, String, bool> filtro, String unValor)
        {
            predicado = filtro;
            valor = unValor;
        }


        public bool aplicaPara(Area area)
        {
            return predicado.Invoke(area, valor);
        }

    }

}
