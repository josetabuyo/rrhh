using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using General;
using Newtonsoft.Json;
using General.MAU;

namespace General.Repositorios
{
    public class RepositorioGDE : RepositorioLazySingleton<DocumentoGDE>
    {

        private static RepositorioGDE _instancia;

        IConexionBD _conexion;
        private RepositorioGDE(IConexionBD conexion)
            : base(conexion, 10)
        {
            _conexion = conexion;
        }

        public static RepositorioGDE NuevoRepositorioGDE(IConexionBD conexion)
        {
            if (!(_instancia != null)) _instancia = new RepositorioGDE(conexion);
            return _instancia;
        }

        public int insertarDocumentoGDE(string numeroGDE, int idTipoDocumento, bool verificado) {

            try
            {
                var parametros = new Dictionary<string, object>();
                //parametros.Add("@idDocumento", idDocumento);
                parametros.Add("@codigo_gde", numeroGDE);
                parametros.Add("@idTipoDocumento", idTipoDocumento);
                parametros.Add("@verificado", verificado);

                var idDocumento = _conexion.EjecutarEscalar("dbo.GDE_INS_DocumentoGDE", parametros).ToString();

                return int.Parse(idDocumento);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            
        }


        public bool GDE_UPD_DocumentoGDE (string numeroGDE, int id,  Usuario usuario) {
            try
            {
                var parametros = new Dictionary<string, object>();
                //parametros.Add("@idDocumento", idDocumento);
                parametros.Add("@codigo_gde", numeroGDE);
                parametros.Add("@id", id);
                //parametros.Add("@verificado", verificado);

                _conexion.Ejecutar("dbo.GDE_UPD_DocumentoGDE", parametros);

                return true;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        
        }



        protected override List<DocumentoGDE> ObtenerDesdeLaBase()
        {
            throw new NotImplementedException();
        }

        protected override void GuardarEnLaBase(DocumentoGDE objeto)
        {
            throw new NotImplementedException();
        }

        protected override void QuitarDeLaBase(DocumentoGDE objeto)
        {
            throw new NotImplementedException();
        }
    }
}
