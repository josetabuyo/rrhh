using System.Collections.Generic;
using System;


namespace General.Repositorios
{
    public class RepositorioDeAsistencias : IRepositorioDeAsistencias
    {
        List<Asistencia> asistencias = new List<Asistencia>();
        public IConexionBD conexion_bd { get; set; }

        public RepositorioDeAsistencias(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public List<Asistencia> GetAsistencias()
        {
            var tablaAsistencias = conexion_bd.Ejecutar("dbo.SACC_Get_Asistencias");
            this.asistencias = GetAsistenciasFromTabla(tablaAsistencias);
            return asistencias;
        }

        public List<Asistencia> GetAsistenciasPorCursoYAlumno(int id_curso, int id_alumno)
        {
            GetAsistencias();
            return this.asistencias.FindAll(asistencia => asistencia.IdCurso.Equals(id_curso) && asistencia.IdAlumno.Equals(id_alumno));
        }

        public void GuardarAsistencia(Asistencia asistencia, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("id_alumno", asistencia.IdAlumno);
            parametros.Add("id_curso", asistencia.IdCurso);
            parametros.Add("fecha_asistencia", asistencia.Fecha);
            parametros.Add("descripcion", asistencia.Descripcion);
            parametros.Add("id_usuario", usuario.Id);
            parametros.Add("fecha", DateTime.Now);
            //parametros.Add("baja", 0);

            conexion_bd.EjecutarSinResultado("dbo.SACC_Ins_Asistencia", parametros);

        }

        public List<Asistencia> GetAsistenciasFromTabla(TablaDeDatos tablaAsistencias)
        {
            List<Asistencia> asistencias = new List<Asistencia>();

            if (tablaAsistencias.Rows.Count > 0)
            {
                tablaAsistencias.Rows.ForEach(row =>
                {
                    if (row.GetString("Descripcion").Trim().Equals("Asistencia Normal"))
                    {
                        var asistencia_normal = new AsistenciaNormal(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                        asistencias.Add(asistencia_normal);
                    }
                    else if (row.GetString("Descripcion").Trim().Equals("Inasistencia Normal"))
                    {
                        var inasistencia_normal = new InasistenciaNormal(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                        asistencias.Add(inasistencia_normal);
                    }

                });
            }

            return asistencias;
        }



        public void GuardarAsistencias(List<Asistencia> asistencias_a_guardar, Usuario usuario)
        {
            foreach (var a in asistencias_a_guardar)
            {
                if (!(this.GetAsistencias().FindAll(_a => _a.Fecha == a.Fecha && _a.IdAlumno == a.IdAlumno & _a.IdCurso == a.IdCurso).Count > 0))
                {
                    if(a.Valor != 0)
                        GuardarAsistencia(a, usuario);
                }
                else if (this.GetAsistencias().FindAll(_a => _a.Fecha == a.Fecha && _a.IdAlumno == a.IdAlumno & _a.IdCurso == a.IdCurso).Count > 0)
                {
                    ModificarAsistencia(a, usuario);
                }

            }
        }

        private void ModificarAsistencia(Asistencia asistencia, Usuario usuario)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("id_alumno", asistencia.IdAlumno);
            parametros.Add("id_curso", asistencia.IdCurso);
            parametros.Add("fecha_asistencia", asistencia.Fecha);
            parametros.Add("descripcion", asistencia.Descripcion);
            parametros.Add("id_usuario", usuario.Id);
            parametros.Add("fecha", DateTime.Now);
            parametros.Add("baja", 0);

            conexion_bd.EjecutarSinResultado("dbo.SACC_Upd_Del_Asistencia", parametros);

        }
    }
}