using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General
{
    public class ComparadorDeDiferencias
    {
        // private List<Evaluacion> _lista_de_base;
        //private List<Evaluacion> _lista_nueva;

        public ComparadorDeDiferencias()
        { }

        //public ComparadorDeHistoricos()
        //{
        //    //this._lista_de_base = lista_original;
        //    //this._lista_nueva = lista_nueva;
        //}

        public List<Evaluacion> EvaluacionesParaActualizar(List<Evaluacion> lista_original, List<Evaluacion> lista_nueva)
        {
            var query1 = lista_nueva.Where(e1 => {
                var res = lista_original.Exists(e2 => {
                    var res2 = (e2.Alumno.Documento == e1.Alumno.Documento && e2.Curso.Id == e1.Curso.Id && e2.InstanciaEvaluacion.Id == e1.InstanciaEvaluacion.Id) 
                        && ((e2.Calificacion.Descripcion != e1.Calificacion.Descripcion) || (e2.Fecha.Day != e1.Fecha.Day || e2.Fecha.Month != e1.Fecha.Month || e2.Fecha.Month != e1.Fecha.Month));
                    return res2;
                });
                return res;
            });

            return query1.ToList();// new List<Evaluacion>();  
        }
    }
}
