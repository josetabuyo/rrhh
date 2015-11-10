using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using General.MAU;

namespace General.Repositorios
{
    public abstract class RepositorioLazySingleton<T>:Repositorio<T>
    {
        protected List<T> objetos;

        protected DateTime _fecha_creacion;
        protected int minutos_de_vida;
        public RepositorioLazySingleton(IConexionBD conexion, int _minutos_de_vida)
            : base(conexion)
        {
            this.minutos_de_vida = _minutos_de_vida;
            this._fecha_creacion = DateTime.Now;
        }
        protected bool ExpiroTiempoDelRepositorio()
        {
            if (FechaExpiracion() < DateTime.Now)
            {
                return true;
            }
            return false;
        }
        protected DateTime FechaExpiracion()
        {
            return _fecha_creacion.AddMinutes(minutos_de_vida);
        }

        abstract protected List<T> ObtenerDesdeLaBase();
        protected List<T> Obtener()
        {
            if (objetos == null) objetos = ObtenerDesdeLaBase();
            return objetos;
        }

        abstract protected void GuardarEnLaBase(T objeto);
        public T Guardar(T objeto)
        {
            GuardarEnLaBase(objeto);
            if (objetos != null) objetos.Add(objeto);
            return objeto;
        }

        abstract protected void QuitarDeLaBase(T objeto);
        protected void Quitar(T objeto)
        {
            QuitarDeLaBase(objeto);
            if (objetos != null) objetos.Remove(objeto);
        }

        public List<T> Find(string criterio, Usuario usuario=null, int max_resultados=-1)
        {
            var resultados = new List<T>();

            var filtro = new FiltroDeObjetos(criterio);

            resultados = this.Obtener().FindAll(objeto =>
            {
                return filtro.Evaluar(objeto);
            });

            if(usuario!=null)
                resultados = resultados.FindAll(obj =>
                {
                    var propiedad_a_filtrar = obj.GetType().GetProperty("SoloVisiblePara");
                    if (propiedad_a_filtrar != null)
                    {
                        int valor_propiedad = int.Parse(propiedad_a_filtrar.GetValue(obj, null).ToString());
                        return valor_propiedad == usuario.Id || valor_propiedad == -1;
                    }
                    return true;
                });

            if (max_resultados > -1 && resultados.Count > max_resultados)
            {
                resultados = new List<T>();
            }
            return resultados;
        }
    }
}
