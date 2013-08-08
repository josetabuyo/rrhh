using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General.Repositorios;

namespace General
{
    public class ComparadorDeDiferencias
    {
        // private List<Evaluacion> _lista_de_base;
        //private List<Evaluacion> _lista_nueva;
        //public IConexionBD conexion_bd { get; set; }

        public ComparadorDeDiferencias()
        {
            //this.conexion_bd = conexion;
        }

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

            return query1.ToList();
        }

        public List<Evaluacion> EvaluacionesParaGuardarEnHistorico(List<Evaluacion> evaluaciones_antiguas, List<Evaluacion> evaluaciones_nuevas)
        {

            List<Evaluacion> eval_a_guardar_en_historico = new List<Evaluacion>();
            eval_a_guardar_en_historico.AddRange(this.EvaluacionesParaActualizar(evaluaciones_antiguas, evaluaciones_nuevas));
            eval_a_guardar_en_historico.AddRange(this.EvaluacionesParaBorrar(evaluaciones_antiguas, evaluaciones_nuevas));
            //var eval_para_actualizar = this.EvaluacionesParaActualizar(evaluaciones_antiguas, evaluaciones_nuevas);
            //var eval_para_borrar = this.EvaluacionesParaBorrar(evaluaciones_antiguas, evaluaciones_nuevas);

            var eval_historicas = evaluaciones_antiguas.FindAll(eval_ant => eval_a_guardar_en_historico.Exists(eval_act => eval_act.Alumno.Documento.Equals(eval_ant.Alumno.Documento) && eval_act.Curso.Id.Equals(eval_ant.Curso.Id) && eval_act.InstanciaEvaluacion.Id.Equals(eval_ant.InstanciaEvaluacion.Id)));

            return eval_historicas;
        }


        public List<Evaluacion> EvaluacionesParaGuardar(List<Evaluacion> evaluaciones_antiguas, List<Evaluacion> evaluaciones_nuevas)
        {
            return evaluaciones_nuevas.FindAll(eval_nuevas => !evaluaciones_antiguas.Exists(eval_ant => eval_ant.Id.Equals(eval_nuevas.Id)));
            //return evaluaciones_nuevas.FindAll(eval_nuevas => !evaluaciones_antiguas.Exists(eval_ant => eval_ant.Alumno.Id.Equals(eval_nuevas.Alumno.Id) && eval_ant.InstanciaEvaluacion.Id.Equals(eval_nuevas.InstanciaEvaluacion.Id) && eval_ant.Curso.Id.Equals(eval_nuevas.Curso.Id)) && eval_nuevas.Fecha.Date != DateTime.MinValue);
        }

        public List<Evaluacion> EvaluacionesParaBorrar(List<Evaluacion> evaluaciones_antiguas, List<Evaluacion> evaluaciones_nuevas)
        {
            return evaluaciones_antiguas.FindAll(eval_ant => !evaluaciones_nuevas.Exists(eval_nuevas => eval_nuevas.Id.Equals(eval_ant.Id)));
            //return evaluaciones_antiguas.FindAll(eval_ant => !evaluaciones_nuevas.Exists(eval_nuevas => eval_nuevas.Alumno.Id.Equals(eval_ant.Alumno.Id) && eval_nuevas.InstanciaEvaluacion.Id.Equals(eval_ant.InstanciaEvaluacion.Id) && eval_nuevas.Curso.Id.Equals(eval_ant.Curso.Id)));
        }
    }
}
