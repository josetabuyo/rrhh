using System;
using System.Collections.Generic;

using System.Text;
using General;
using System.Data.SqlClient;

namespace General.Repositorios
{
    public class RepositorioTipoDeViatico
    {
        #region IRepositorioModalidades Members

        public TipoDeViatico GetTipoDeViaticoDe(Persona unaPersona)
        {
            //devolver lo que corresponda
            //return "1184";
            //SqlDataReader dr;
            ConexionDB cn = new ConexionDB("dbo.VIA_GetDatosDeContratacion");
            cn.AsignarParametro("@nro_documento", unaPersona.Documento);

            SqlDataReader rto = cn.EjecutarConsulta();
            //ModalidadDeContratacion modalidad = null;
            //var test = (ModalidadDeContratacion)Activator.CreateInstance(Type.GetType("General.ModalidadDeContratacionNormal, General"));
            //ModalidadDeContratacion modalidad = (ModalidadDeContratacion)test.Unwrap();

            if (rto.Read())
            {
                int idTipoPlanta = rto.GetInt16(7);
                int idNivel = rto.GetInt16(3);
                int idGrado = rto.GetInt16(5);

                //EVALUA SI EL TIPO DE PLANTA ES 3 Y DEPENDIENDO SI EL GRADO ES 2 o 3 o Resto 
                if (idTipoPlanta == 3 & idNivel == 44 & idGrado == 2)
                {
                    return new TipoDeViatico(3, "Ministro");
                }
                else if (idTipoPlanta == 3 & idNivel == 44 & idGrado == 3)
                {
                    return new TipoDeViatico(4, "Secretario");
                }
                else if (idTipoPlanta == 3)
                {
                    return new TipoDeViatico(5, "Subsecretario");
                }

                return new TipoDeViatico(rto.GetInt16(9), rto.GetString(10));

                //return tipoDeViatico;
                //ModalidadDeContratacion modalidad = modalidad.CrearModalidadDeContratacion(rto.GetInt16(9));
            }


            return null;

        }

        public Persona GetNivelGradoDeContratacionDe(Persona unaPersona)
        {
            ConexionDB cn = new ConexionDB("dbo.VIA_GetDatosDeContratacion");
            cn.AsignarParametro("@nro_documento", unaPersona.Documento);

            SqlDataReader rto = cn.EjecutarConsulta();

            if (rto.Read())
            {
                unaPersona.Categoria = rto.GetString(8);
                unaPersona.Nivel = rto.GetString(4);
                unaPersona.Grado = rto.GetString(6);

                return unaPersona;

            }

            //devolver persona nula
            return unaPersona;

        }

        #endregion

    }
}
