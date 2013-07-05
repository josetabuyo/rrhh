using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace General.Modi
{
    public interface IFileSystem
    {
        List<string> getPathsArchivosEnCarpeta(string path);
        Image getImagenFromPath(string pathImagen);
    }
}
