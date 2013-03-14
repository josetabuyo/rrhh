using System;
using System.Collections.Generic;
using System.Text;
using General;
using System.Data.SqlClient;
using General.Repositorios;
using System.Linq;
namespace General.Repositorios
{
    public class RepositorioDeTransiciones
    {
        public IConexionBD conexion_bd { get; set; }

        public RepositorioDeTransiciones(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }
    }
}
