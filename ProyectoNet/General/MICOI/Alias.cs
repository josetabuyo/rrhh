namespace General
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Alias
    {
        private int _Id;
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private int _Id_Area;
        public int IdArea
        {
            get { return _Id_Area; }
            set { _Id_Area = value; }
        }

        private string _Descripcion;
        virtual public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }


        public Alias()
        {


        }

        public Alias(string descripcion)
        {
            this._Descripcion = descripcion;
        }

        public Alias(int id, string descripcion)
        {
            this._Id = id;
            this._Descripcion = descripcion;
        }

        public Alias(int id, int id_area, string descripcion)
        {
            this._Id = id;
            this._Id_Area = id_area;
            this._Descripcion = descripcion;
        }

        public override bool Equals(object obj)
        {
            return this.Id == ((Alias)obj).Id;
        }

        virtual public string ConcatenarCon(string nombre_area)
        {

            return Descripcion + " - " + nombre_area;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}
