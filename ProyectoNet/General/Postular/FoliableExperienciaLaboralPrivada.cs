using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class FoliableExperienciaLaboralPrivada : Foliable 
    {
        protected int _id;
        protected string _descripcion;
        protected string _itemCV;

        public int Id { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }
        public string ItemCV { get { return _itemCV; } set { _itemCV = value; } }

        public FoliableExperienciaLaboralPrivada()
        {
        }

        public FoliableExperienciaLaboralPrivada(string descripcion, string item)
        {
            _descripcion = descripcion;
            _itemCV = item;
        }

        public override List<Foliable> documentacion(CurriculumVitae cv)
        {
            List<Foliable> lista_foliables_exp_priv = new List<Foliable>(); ;
            var exp_privadas = from experiencia in cv.CvExperienciaLaboral
                               where experiencia.Pais.Equals(1)//cambiar pais por tipo de exp
                               select experiencia;

            foreach (CvExperienciaLaboral exp_privada in exp_privadas)
            {
                FoliableExperienciaLaboralPrivada un_foliable = new FoliableExperienciaLaboralPrivada();
                un_foliable.Descripcion = exp_privada.Actividad;
                un_foliable.Id = exp_privada.Id;
                lista_foliables_exp_priv.Add(un_foliable);
            }

            return lista_foliables_exp_priv;
           
        }

        public override int tabla()
        {
            return 2;
        }

    }
}
