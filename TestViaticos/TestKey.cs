using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using General.MAU;

namespace TestViaticos
{
    [TestClass]
    public class TestKey
    {

        /// <summary>
        /// select us.Nombre, pa.password
        ///from                 
        /// dbo.RH_usuarios us 
        ///inner join dbo.web_passwords pa on                
        /// pa.idUsuario = us.id                
        ///where                 
        /// us.Nombre like '%bcevey%'
        /// </summary>
        [TestMethod]
        public void test()
        {
            var bf = new BruteForce();
            
            string clave_encriptada = "c/ppDw9FBUofgAsd5UW+rw1SQnk=";
            string clave = bf.GenerateString();

            while(!Encriptador.EncriptarSHA1(clave).Equals(clave_encriptada)) {
                clave = bf.GenerateString();
            }

            throw new Exception("la clave buscada es " + clave);
            
            
        }
    }
}
