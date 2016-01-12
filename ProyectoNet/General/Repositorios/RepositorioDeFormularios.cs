using System;
using Dominio;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace General.Repositorios
{
    public class RepositorioDeFormularios
    {
        public IConexionBD conexion_bd { get; set; }

        public RepositorioDeFormularios(IConexionBD conexion)
        {
            this.conexion_bd = conexion;
        }

        public int GuardarDatos(Formulario formulario)
        {

            var personas = RepositorioDePersonas.NuevoRepositorioDePersonas(conexion_bd).BuscarPersonas("{Documento:" + formulario.nroDocumento + "}");
            var parametros = new Dictionary<string, object>();
            parametros.Add("@idFormulario", formulario.idFormulario);
            parametros.Add("@idPersona", personas[0].Id);
            parametros.Add("@idUsuario", formulario.idUsuario);

            foreach (var unCampo in formulario.campos)
            {
                parametros.Add("@clave", unCampo.clave);
                parametros.Add("@valor", unCampo.valor); 
            }

            var id = conexion_bd.EjecutarEscalar("dbo.FORM_Ins_Generico", parametros).ToString();

            return Int32.Parse(id);
        }

        public Formulario GetFormulario(string criterio) {

            var criterio_deserializado = (JObject)JsonConvert.DeserializeObject(criterio);
            int documento = (int)((JValue)criterio_deserializado["Documento"]);
            var parametros = new Dictionary<string, object>();
            parametros.Add("@nroDocumento", documento);
            var tablaDatos = conexion_bd.Ejecutar("dbo.Form_Get_Generico", parametros);
            List<Campo> campos = new List<Campo>();
            Formulario formulario = new Formulario();

            if (tablaDatos.Rows.Count > 0)
            {
                tablaDatos.Rows.ForEach(row =>
                {
                  campos.Add(new Campo(row.GetString("clave"),row.GetString("valor"))); 
                });

                var fila = tablaDatos.Rows[0];

                formulario = new Formulario(fila.GetSmallintAsInt("idFormulario"), fila.GetInt("NroDocumento"), campos, fila.GetInt("idUsuario"));
               
            }

            return formulario;
        }
    }
}
