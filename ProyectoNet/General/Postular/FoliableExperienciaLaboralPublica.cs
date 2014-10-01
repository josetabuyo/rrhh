using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class FoliableExperienciaLaboralPublica : Foliable 
    {
        protected int _id;
        protected string _descripcion;
        protected string _itemCV;

        public int Id { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public string ItemCV { get { return _itemCV; } set { _itemCV = value; } }

        public FoliableExperienciaLaboralPublica()
        {
        }

        public FoliableExperienciaLaboralPublica(string descripcion, string item)
        {
            _descripcion = descripcion;
            _itemCV = item;
        }

       

        public override List<Foliable> documentacion(CurriculumVitae cv)
        {
            List<Foliable> lista_foliables_exp_pub = new List<Foliable>(); ;
            var exp_publicas = from experiencia in cv.CvExperienciaLaboral
                               where experiencia.Pais.Equals(2)//cambiar pais por tipo de exp
                               select experiencia;

            foreach (CvExperienciaLaboral exp_publica in exp_publicas)
            {
                FoliableExperienciaLaboralPrivada un_foliable = new FoliableExperienciaLaboralPrivada();
                un_foliable.Descripcion = exp_publica.Actividad;
                un_foliable.Id = exp_publica.Id;
                lista_foliables_exp_pub.Add(un_foliable);
            }

            return lista_foliables_exp_pub;
           
        }

        public override int tabla()
        {
            return 2;
        }

    }
}
