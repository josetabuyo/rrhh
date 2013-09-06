using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public interface IRepositorioDeAsistencias
    {
        IConexionBD conexion_bd { get; set; }
        System.Collections.Generic.List<General.Asistencia> GetAsistenciasFromTabla(TablaDeDatos tablaAsistencias);
        global::System.Collections.Generic.List<global::General.Asistencia> GetAsistencias();
        
    }
}
