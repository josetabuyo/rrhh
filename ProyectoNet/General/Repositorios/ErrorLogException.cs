using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace General.Repositorios
{
    public class ErrorLogException : Exception
    {

        public ErrorLogException(String message, Exception ex):base(message, ex)
        {
            
        }
    }
}
