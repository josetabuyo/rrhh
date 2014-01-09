using System.Collections.Generic;
using System;
using General.MAU;


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
            parametros.Add("valor", asistencia.Valor);
            parametros.Add("id_usuario", usuario.Id);
            parametros.Add("fecha", DateTime.Now);

            conexion_bd.EjecutarSinResultado("dbo.SACC_Ins_Asistencia", parametros);

        }

        public List<Asistencia> GetAsistenciasFromTabla(TablaDeDatos tablaAsistencias)
        {
            List<Asistencia> asistencias = new List<Asistencia>();

            if (tablaAsistencias.Rows.Count > 0)
            {
                tablaAsistencias.Rows.ForEach(row =>
                {
                    Asistencia asistencia;
                    switch (row.GetSmallintAsInt("Valor"))
                    {
                        case 0:
                            asistencia = new AsistenciaIndeterminada(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                            break;
                        case 1:
                            asistencia = new AsistenciaHoraUno(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                            break;
                        case 2:
                            asistencia = new AsistenciaHoraDos(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                            break;
                        case 3:
                            asistencia = new AsistenciaHoraTres(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                            break;
                        case 4:
                            asistencia = new AsistenciaHoraCuatro(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                            break;
                        case 5:
                            asistencia = new InasistenciaNormal(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                            break;
                        case 6:
                            asistencia = new AsistenciaClaseSuspendida(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                            break;
                        default:
                            asistencia = new AsistenciaIndeterminada(row.GetDateTime("FechaAsistencia"), row.GetSmallintAsInt("IdCurso"), row.GetSmallintAsInt("IdAlumno"));
                            break;
                    }
                    asistencias.Add(asistencia);
                   

                });
            }
            return asistencias;
        }

        public void GuardarAsistencias(List<Asistencia> asistencias_a_guardar, Usuario usuario)
        {
            foreach (var a in asistencias_a_guardar)
            {
                BorrarAsistencias(a);
            }
            foreach (var a in asistencias_a_guardar)
            {
                if (a.Valor != 0)
                    GuardarAsistencia(a, usuario);
            }
        }

        private void BorrarAsistencias(Asistencia a)
        {
            var parametros = new Dictionary<string, object>();
            parametros.Add("id_alumno", a.IdAlumno);
            parametros.Add("id_curso", a.IdCurso);
            parametros.Add("fecha_asistencia", a.Fecha);
            conexion_bd.EjecutarSinResultado("dbo.SACC_Del_Asistencias", parametros);

        }
    }
}