using System.Collections.Generic;
using System.Linq;
using System;


namespace General.Repositorios
{
    public class RepositorioDeAsistenciasV2 : RepositorioLazy<List<Acumulador>> 
    {
        List<Acumulador> asistencias = new List<Acumulador>();
        public IConexionBD conexion_bd { get; set; }

        public RepositorioDeAsistenciasV2(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public List<Acumulador> GetAsistencias()
        {
            var tablaAsistencias = conexion_bd.Ejecutar("dbo.SACC_Get_Asistencias_2");
            this.asistencias = GetAsistenciasFromTabla(tablaAsistencias);
            return asistencias;
        }

        public List<Acumulador> GetAsistenciasPorCursoYAlumno(int id_curso, int id_alumno)
        {
            GetAsistencias();
            return this.asistencias.FindAll(asistencia => asistencia.IdCurso.Equals(id_curso) && asistencia.IdAlumno.Equals(id_alumno));
        }

        public List<Acumulador> GetAsistenciasFromTabla(TablaDeDatos tablaAsistencias)
        {
            List<Acumulador> asistencias = new List<Acumulador>();
            Acumulador asistencia;
            int horas_maximas = 3;
            DateTime fecha;
            string valor;
            int id_curso;
            int id_alumno;
            tablaAsistencias.Rows.ForEach(row =>
            {
                fecha = row.GetDateTime("FechaAsistencia");
                valor = row.GetString("Valor");
                id_curso = row.GetSmallintAsInt("IdCurso");
                id_alumno = row.GetSmallintAsInt("IdAlumno");
                
                if (valor.Equals("-"))
                {
                    asistencia = new AcumuladorHorasDiaNoCursado(valor, horas_maximas, fecha, id_alumno, id_curso);
                }
                else
                {
                    asistencia = new AcumuladorHorasDiaCursado(int.Parse(valor), horas_maximas, fecha, id_alumno, id_curso);
                }
                    
                asistencias.Add(asistencia);
            });
            return asistencias;
        }

        public List<Acumulador> GuardarAsistencias(List<Acumulador> asistencias_nuevas, List<Acumulador> asistencias_originales, Usuario usuario)
        {
            var registros_no_procesados = new List<Acumulador>();
            var asistencias_a_dar_de_alta = new List<Acumulador>();
            var asistencias_a_dar_de_baja = new List<Acumulador>();

            foreach (var a in asistencias_a_dar_de_alta)
            {
                if (GuardarAsistencia(a, usuario).Equals(0))
                    registros_no_procesados.Add(a);
            }
            
            foreach (var a in asistencias_a_dar_de_baja)
            {
                if (BorrarAsistencia(a, usuario, CrearBaja(usuario)).Equals(0))
                    registros_no_procesados.Add(a);
            }
            return registros_no_procesados;
        }

        public List<Acumulador> AsistenciasParaDarDeAlta(List<Acumulador> lista_original, List<Acumulador> lista_nueva)
        {
            var asistencias_nuevas = lista_nueva.FindAll(a_nue => 
                {
                    return !lista_original.Exists(a_ant => a_ant.Id.Equals(a_nue.Id));
                });
            return asistencias_nuevas;
        }

        public List<Acumulador> AsistenciasParaDarDeBaja(List<Acumulador> lista_original, List<Acumulador> lista_nueva)
        {
            var query1 = lista_nueva.Where(e1 => {
                var res = lista_original.Exists(e2 => {
                    var res2 = e2.Id.Equals(e1.Id) && e2.Valor != e1.Valor;
                    return res2;
                });
                return res;
            });

            return query1.ToList();
        }

        private int BorrarAsistencia(Acumulador a, Usuario usuario, int idBaja)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", a.Id);
            parametros.Add("@id_alumno", a.IdAlumno);
            parametros.Add("@id_curso", a.IdCurso);
            parametros.Add("@valor", a.Valor);
            parametros.Add("@fecha", DateTime.Today);
            parametros.Add("@id_usuario", usuario.Id);
            if (idBaja != 0)
                parametros.Add("@id_baja", idBaja);

            return (int)conexion_bd.EjecutarEscalar("dbo.SACC_Upd_Del_Asistencia_2", parametros);
        }

        private int GuardarAsistencia(Acumulador a, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("@id", a.Id);
            parametros.Add("@id_alumno", a.IdAlumno);
            parametros.Add("@id_curso", a.IdCurso);
            parametros.Add("@valor", a.Valor);
            parametros.Add("@fecha", DateTime.Today);
            parametros.Add("@id_usuario", usuario.Id);


            return (int)conexion_bd.EjecutarEscalar("dbo.SACC_Ins_Asistencia_2", parametros);
        }

        private int CrearBaja(Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();

            parametros.Add("@Motivo", "");
            parametros.Add("@IdUsuario", usuario.Id);
            parametros.Add("@Fecha", "");

            int id = int.Parse(conexion_bd.EjecutarEscalar("dbo.SACC_Ins_Bajas", parametros).ToString());

            return id;
        }
    }
}