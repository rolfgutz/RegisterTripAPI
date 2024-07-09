using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Journey.Exception.ExceptionsBase
{
    public class ErrorOnValidationException : JourneyException
    {
        private readonly IList<string> _errors;

        // Neste cenario usamos List pois queremos retornar uma lista de erros nessa validacao
        //como herdamos de journey entao neste caso especifico passamos string empty
        public ErrorOnValidationException(IList<string>messages) : base(string.Empty)
        {

            _errors = messages;
        }

        public override IList<string> GetErrorMessage()
        {
            return _errors;
        }

        public override HttpStatusCode GetStatusCode()
        {
            return HttpStatusCode.BadRequest;
        }
    }
}
