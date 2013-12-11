using System;
using AdministracionDeUsuarios;
namespace General.Repositorios
{
    public interface IRepositorioDeDocumentos
    {
        IConexionBD conexion_bd { get; set; }
        System.Collections.Generic.List<General.Documento> GetDocumentosFromTabla(TablaDeDatos tablaDocumentos);
        System.Collections.Generic.List<General.TipoDeDocumentoSICOI> GetTiposDeDocumentos();
        System.Collections.Generic.List<General.Documento> GetTodosLosDocumentos();
        void GuardarDocumento(General.Documento un_documento, Usuario usuario);
    }
}
