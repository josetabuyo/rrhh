using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace General.Modi
{
    public class FileSystem:IFileSystem
    {
        public List<string> getFiles(string path)
        {
            try
            {
                return Directory.GetFiles(path).ToList();
            }
            catch(DirectoryNotFoundException e){
                throw new ExcepcionDeCarpetaDeLegajoNoEncontrada();
            }
        }
    }
}
