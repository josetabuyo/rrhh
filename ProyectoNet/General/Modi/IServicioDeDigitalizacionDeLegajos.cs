using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Modi
{
    public interface IServicioDeDigitalizacionDeLegajos
    {
        RespuestaABusquedaDeLegajos BuscarLegajos(string criterio);
        ImagenModi GetImagenPorId(int id_imagen);
        ImagenModi GetThumbnailPorId(int id_imagen, int alto, int ancho);
        void AsignarImagenADocumento(int id_imagen, string tabla, int id_documento, int orden, Usuario usuario);
        void DesAsignarImagen(int id_imagen, Usuario usuario);
    }
}
