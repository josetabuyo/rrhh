using System;
using System.Collections.Generic;

using System.Text;
using General;
using General.Repositorios;

namespace General.Repositorios
{
    public class RepositorioPasesDeArea
    {
        #region IRepositorioPasesDeArea Members

        public bool CargarSolicitudDePase(PaseDeArea unPase)
        {
            ConexionDB cn = new ConexionDB("dbo.WEB_AltaSolicitudPase");
            cn.AsignarParametro("@documento", unPase.Persona.Documento);
            cn.AsignarParametro("@idAreaActual", unPase.AreaOrigen.Id);
            cn.AsignarParametro("@idAreaNueva", unPase.AreaDestino.Id);
            cn.AsignarParametro("@idUsuarioSolicito", unPase.Auditoria.UsuarioDeCarga.Id);

            cn.EjecutarSinResultado();
            cn.Desconestar();
            return true;
        }

        public void EliminarSolicitudDePase(PaseDeArea unPase)
        {
            ConexionDB cn = new ConexionDB("dbo.WEB_EliminarSolicitudDePase");
            cn.AsignarParametro("@idPase", unPase.Id);
            cn.EjecutarSinResultado();
            cn.Desconestar();
        }
        #endregion
    }
}
