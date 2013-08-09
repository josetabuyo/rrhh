namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.SqlClient;
    using General;

    public class Area
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public string Alias { get { return NombreConAlias(); } set { } }
        private string _Codigo;
        public string Codigo
        {
            get { return _Codigo; }
            set { _Codigo = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }


        private bool presenta_ddjj;
        public bool PresentaDDJJ
        {
            get { return presenta_ddjj; }
            set { presenta_ddjj = value; }
        }



        public List<Persona> Personas { get; set; }
        public List<Asistente> Asistentes { get; set; }
        public List<Area> Dependencias { get; set; }

        public Area(int IdArea)
        {
            this.Id = IdArea;
            this.Dependencias = new List<Area>();
            this.SetAlias(new AliasNull());
        }


        public Area(int IdArea, string Nombre)
        {
            this.Id = IdArea;
            this.Nombre = Nombre;
            this.Dependencias = new List<Area>();
            this.SetAlias(new AliasNull());
        }

        public Area(int IdArea, string Nombre, string Codigo, bool presenta_ddjj)
        {
            this.Id = IdArea;
            this.Nombre = Nombre;
            this.Codigo = Codigo;
            this.Dependencias = new List<Area>();
            this.presenta_ddjj = presenta_ddjj;
            this.SetAlias(new AliasNull());
        }


        public Area()
        {
            this.Dependencias = new List<Area>();
            this.SetAlias(new AliasNull());
        }

        public Area(int Id, string Nombre, Responsable datos_del_responsable)
        {
            // TODO: Complete member initialization
            this.Id = Id;
            this.Nombre = Nombre;
            this.datos_del_responsable = datos_del_responsable;
            this.SetAlias(new AliasNull());
        }

        private string _Direccion;
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        public List<Persona> Responsables { get; set; }

        private List<ContactoArea> _Contacto = new List<ContactoArea>();
        public Responsable datos_del_responsable;
        public List<ContactoArea> Contacto
        {
            get { return _Contacto; }
            set { _Contacto = value; }
        }

        private Alias _alias;

        public void SetAlias(Alias alias)
        {
            _alias = alias;
        }

        public string GetAlias()
        {
            return _alias.Descripcion;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Area)) return false;
            return this.Id == ((Area)obj).Id;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public override string ToString()
        {
            return this.Nombre;
        }

        public string Telefono { get; set; }

        public string Fax { get; set; }

        public string Mail { get; set; }

        public string NombreConAlias()
        {
            return _alias.ConcatenarCon(this.Nombre);
        }

        public string DescripcionAlias()
        {
            return _alias.Descripcion;
        }
    }
}
