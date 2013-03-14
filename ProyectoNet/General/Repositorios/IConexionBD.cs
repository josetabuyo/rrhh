using System;
using System.Collections.Generic;
namespace General.Repositorios
{
    public interface IConexionBD
    {
        TablaDeDatos Ejecutar(string procedimiento);
        TablaDeDatos Ejecutar(string procedimiento, System.Collections.Generic.Dictionary<string, object> parametros);
        object EjecutarEscalar(string nombreProcedimiento);
        object EjecutarEscalar(string nombreProcedimiento, Dictionary<string, object> parametros);
        bool EjecutarSinResultado(string nombreProcedimiento);
        bool EjecutarSinResultado(string nombreProcedimiento, Dictionary<string, object> parametros);
    }
}
