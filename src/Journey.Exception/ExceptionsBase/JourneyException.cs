using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Exception.ExceptionsBase
{
    public abstract class JourneyException : SystemException
    {
        public JourneyException(string message) : base(message)
        {

        }

        // Adionando classe sem chaves obriga todas as classes que herdam dessa
        // a implementarem essa funcao.
        public abstract HttpStatusCode GetStatusCode();


        public abstract IList<string> GetErrorMessage();


    }
}
