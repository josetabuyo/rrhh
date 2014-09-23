using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class FoliableEstudiosUniversitario : Foliable
    {
        protected int _id;
        protected string _descripcion;

        public int Id { get { return _id; } set { _id = value; } }
        public string Descripcion { get { return _descripcion; } set { _descripcion = value; } }

        public FoliableEstudiosUniversitario()
        {
        }

        public FoliableEstudiosUniversitario(string descripcion)
        {
            _descripcion = descripcion;
        }

        public override List<Foliable> documentacion(CurriculumVitae cv)
        {
            List<Foliable> lista_foliables_universitarios = new List<Foliable>(); ;
            var estudios_universitarios =  from estudio in cv.CvEstudios
                                                        where estudio.Nivel.Equals(12)
                                                        select estudio;
            
            foreach (CvEstudios estudio in estudios_universitarios)
            {
                FoliableEstudiosUniversitario un_foliable = new FoliableEstudiosUniversitario();
                un_foliable.Descripcion = estudio.Especialidad;
                un_foliable.Id = estudio.Id;
                lista_foliables_universitarios.Add(un_foliable);
            }

            return lista_foliables_universitarios;
           
        }

        public override int tabla()
        {
            //opner el id que figura en la tabla => Tabla id - CvEstudios
            return 3;
        }
       
    }
}
