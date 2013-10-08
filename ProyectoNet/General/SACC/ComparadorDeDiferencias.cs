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
                    var res2 = (e2.Id.Equals(e1.Id)) 
                        && ((e2.Calificacion.Descripcion != e1.Calificacion.Descripcion) || (e2.Fecha.Day != e1.Fecha.Day || e2.Fecha.Month != e1.Fecha.Month || e2.Fecha.Month != e1.Fecha.Month));
                    return res2;
                });
                return res;
            });

            return query1.ToList();
        }

        public List<Evaluacion> EvaluacionesParaDarDeBaja(List<Evaluacion> evaluaciones_antiguas, List<Evaluacion> evaluaciones_nuevas)
        {

            List<Evaluacion> eval_a_guardar_en_historico = new List<Evaluacion>();
            eval_a_guardar_en_historico.AddRange(this.EvaluacionesParaActualizar(evaluaciones_antiguas, evaluaciones_nuevas));
            eval_a_guardar_en_historico.AddRange(this.EvaluacionesParaDarDeBajaSinInsertarOtra(evaluaciones_antiguas, evaluaciones_nuevas));
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

        public List<Evaluacion> EvaluacionesParaDarDeBajaSinInsertarOtra(List<Evaluacion> evaluaciones_antiguas, List<Evaluacion> evaluaciones_nuevas)
        {
            return evaluaciones_antiguas.FindAll(eval_ant => !evaluaciones_nuevas.Exists(eval_nuevas => eval_nuevas.Id.Equals(eval_ant.Id)));
            //return evaluaciones_antiguas.FindAll(eval_ant => !evaluaciones_nuevas.Exists(eval_nuevas => eval_nuevas.Alumno.Id.Equals(eval_ant.Alumno.Id) && eval_nuevas.InstanciaEvaluacion.Id.Equals(eval_ant.InstanciaEvaluacion.Id) && eval_nuevas.Curso.Id.Equals(eval_ant.Curso.Id)));
        }

        public List<Observacion> ObservacionesParaActualizar(List<Observacion> observaciones_antiguas, List<Observacion> observaciones_nuevas)
        {
            var query1 = observaciones_nuevas.Where(o1 =>
            {
                var res = observaciones_antiguas.Exists(o2 =>
                {
                    var res2 = (o2.Id.Equals(o1.Id))
                        && ((o2.Pertenece != o1.Pertenece) || (o2.FechaCarga.Day != o1.FechaCarga.Day) || (o2.Asunto != o1.Asunto) || (o2.FechaResultado.Day != o1.FechaResultado.Day) || (o2.PersonaCarga != o1.PersonaCarga) || (o2.ReferenteMDS != o1.ReferenteMDS) || (o2.ReferenteRespuestaMDS != o1.ReferenteRespuestaMDS) || (o2.Relacion != o1.Relacion) || (o2.Resultado != o1.Resultado) || (o2.Seguimiento != o1.Seguimiento));
                    return res2;
                });
                return res;
            });

            return query1.ToList();
        }

        public List<Observacion> ObservacionesParaDarDeBaja(List<Observacion> observaciones_antiguas, List<Observacion> observaciones_nuevas)
        {

            List<Observacion> obser_a_guardar_en_historico = new List<Observacion>();
            obser_a_guardar_en_historico.AddRange(this.ObservacionesParaActualizar(observaciones_antiguas, observaciones_nuevas));
            obser_a_guardar_en_historico.AddRange(this.ObservacionesParaDarDeBajaSinInsertarOtra(observaciones_antiguas, observaciones_nuevas));
            var obser_para_actualizar = this.ObservacionesParaActualizar(observaciones_antiguas, observaciones_nuevas);
            //var obser_para_borrar = this.EvaluacionesParaBorrar(observaciones_antiguas, observaciones_nuevas);

            var obser_historicas = observaciones_antiguas.FindAll(obser_ant => obser_a_guardar_en_historico.Exists(obser_act => obser_act.Id.Equals(obser_ant.Id)));

            return obser_historicas;
            
        }

        public List<Observacion> ObservacionesParaGuardar(List<Observacion> observaciones_antiguas, List<Observacion> observaciones_nuevas)
        {
            return observaciones_nuevas.FindAll(obser_nuevas => !observaciones_antiguas.Exists(observ_ant => observ_ant.Id.Equals(obser_nuevas.Id)));
        }

        public List<Observacion> ObservacionesParaDarDeBajaSinInsertarOtra(List<Observacion> observaciones_antiguas, List<Observacion> observaciones_nuevas)
        {
            return observaciones_antiguas.FindAll(obser_ant => !observaciones_nuevas.Exists(obser_nuevas => obser_nuevas.Id.Equals(obser_ant.Id)));
        }
    }
}
