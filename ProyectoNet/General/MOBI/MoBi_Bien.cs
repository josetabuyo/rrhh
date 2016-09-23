using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class MoBi_Bien
    {
        private int _Id;
        private int _IdTipoBien;
        private string _Descripcion;
        private string _Estado;
        private DateTime _UltMov;
        private string _Remitente;
        private string _Asignacion;

        public string Asignacion
        {
            get { return _Asignacion; }
            set { _Asignacion = value; }
        }
        

        public string Remitente
        {
            get { return _Remitente; }
            set { _Remitente = value; }
        }
        

        public DateTime UltMov
        {
            get { return _UltMov; }
            set { _UltMov = value; }
        }
        

        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }


        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }
        
        public int IdTipoBien
        {
            get { return _IdTipoBien; }
            set { _IdTipoBien = value; }
        }
        

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        public List<int> Imagenes;

        public MoBi_Bien()
        {
            this.Imagenes = new List<int>();
        }
    }

}
