namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Asistente
    {
        public Asistente(string nombre, string apellido, string descripcion_cargo, int prioridad_cargo, string telefono, string fax, string mail)
        {
            // TODO: Complete member initialization
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Descripcion_Cargo = descripcion_cargo;
            this.Prioridad_Cargo = prioridad_cargo;
            this.Telefono = telefono;
            this.Fax = fax;
            this.Mail = mail;
            
        }

        public Asistente()
        {
            // TODO: Complete member initialization
        }
       
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Descripcion_Cargo { get; set; }
        public int Prioridad_Cargo { get; set; }
        public string Telefono { get; set; }
        public string Fax { get; set; }
        public string Mail { get; set; }
        
        
    }
}