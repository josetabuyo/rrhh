using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class FoliableEstudiosSecundario : Foliable
    {
        protected int _id;
        protected string _descripcion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }

        public FoliableEstudiosSecundario()
        {
        }

        public FoliableEstudiosSecundario(string descripcion)
         {
             _descripcion = descripcion;
         }

        public override List<Foliable> documentacion(CurriculumVitae cv)
        {
            List<Foliable> lista_foliables_secundarios = new List<Foliable>(); ;
            var estudios_universitarios =  from estudio in cv.CvEstudios
                                                        where estudio.Nivel.Equals(4)
                                                        select estudio;
            
            foreach (CvEstudios estudio in estudios_universitarios)
            {
                FoliableEstudiosSecundario un_foliable = new FoliableEstudiosSecundario();
                un_foliable.Descripcion = estudio.Especialidad;
                un_foliable.Id = estudio.Id;
                lista_foliables_secundarios.Add(un_foliable);
            }

            return lista_foliables_secundarios;
           
        }

        public override int tabla()
        {
            //opner el id que figura en la tabla => Tabla id - CvEstudios
            return 3;
        }
       
    }
}
