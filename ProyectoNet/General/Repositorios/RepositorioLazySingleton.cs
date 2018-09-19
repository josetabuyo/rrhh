using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace General.Repositorios
{
    public abstract class RepositorioLazySingleton<T>:Repositorio<T>
    {
        protected List<T> objetos;

        protected DateTime _fecha_creacion;
        protected bool _expiracion_forzada;
        protected int minutos_de_vida;
        public RepositorioLazySingleton(IConexionBD conexion, int _minutos_de_vida)
            : base(conexion)
        {
            this.minutos_de_vida = _minutos_de_vida;
            this._fecha_creacion = DateTime.Now;
            this._expiracion_forzada = false;
        }
        protected bool ExpiroTiempoDelRepositorio()
        {
            if (FechaExpiracion() < DateTime.Now || _expiracion_forzada)
            {
                return true;
            }
            return false;
        }
        protected DateTime FechaExpiracion()
        {
            return _fecha_creacion.AddMinutes(minutos_de_vida);
        }

        protected void ForzarExpiracion()
        {
            this._expiracion_forzada = true;
    }

        abstract protected List<T> ObtenerDesdeLaBase();
        protected List<T> Obtener()
        {
            if (objetos == null) objetos = ObtenerDesdeLaBase();
            return objetos;
        }

        abstract protected void GuardarEnLaBase(T objeto, int id_usuario_logueado);
        public T Guardar(T objeto, int id_usuario_logueado)
        {
            GuardarEnLaBase(objeto, id_usuario_logueado);
            if (objetos != null) objetos.Add(objeto);
            return objeto;
        }

        abstract protected void QuitarDeLaBase(T objeto, int id_usuario_logueado);
        protected void Quitar(T objeto, int id_usuario_logueado)
        {
            QuitarDeLaBase(objeto, id_usuario_logueado);
            if (objetos != null) objetos.Remove(objeto);
        }

        public List<T> Find(string criterio)
        {
            var resultados = new List<T>();

            var filtro = new FiltroDeObjetos(criterio);

            resultados = this.Obtener().FindAll(objeto =>
            {
                return filtro.Evaluar(objeto);
            });
            return resultados;
        }
    }
}
