using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdministracionDeUsuarios;

namespace General.Modi
{
    public interface IServicioDeDigitalizacionDeLegajos
    {
        RespuestaABusquedaDeLegajos BuscarLegajos(string criterio);
        ImagenModi GetImagenPorId(int id_imagen);
        ImagenModi GetThumbnailPorId(int id_imagen, int alto, int ancho);
        void AsignarImagenAFolioDeLegajo(int id_imagen, int nro_folio, Usuario usuario);
        void DesAsignarImagen(int id_imagen, Usuario usuario);
    }
}
