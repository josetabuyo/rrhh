using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class MoBi_Bien
    {
        public int Id { get; set; }
        public int IdTipoBien { get; set; }
        public string Descripcion { get; set; }
        public int Id_Estado { get; set; }
        public string Estado { get; set; }
        public DateTime FechaUltMov { get; set; }
        public int IdReceptor { get; set; }
        public string Receptor { get; set; }
        public int IdPropietario { get; set; }
        public string Propietario { get; set; }

        //private string Remitente { get; set; }
        //private string Asignacion { get; set; }

        public List<int> Imagenes { get; set; }

        public string Ubicacion { get; set; }
        public string Verificacion { get; set; }

        public MoBi_Bien()
        {
            this.Imagenes = new List<int>();
        }


        public MoBi_Bien(int id, 
                        int id_tipobien, 
                        string descripcion_bien,
                        int id_estado,             
                        string estado,
                        DateTime fecha_movimiento, 
                        int id_receptor,
                        string receptor,
                        int id_area_propietaria,
                        string area_propietaria)
        {
            Id = id;
            IdTipoBien = id_tipobien;
            Descripcion = descripcion_bien;
            Estado = estado;
            Id_Estado = id_estado;
            FechaUltMov = fecha_movimiento;
            IdReceptor = id_receptor;
            Receptor = receptor;
            IdPropietario = id_area_propietaria;
            Propietario = area_propietaria;
            //Asignacion = asignacion;
        }



        /*
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
        */


    }

}
