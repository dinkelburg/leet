using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Minor.ServiceBus.PfSLocatorService
{
    [Serializable]
    public class FunctionalException : Exception
    {
        public FunctionalException(){}
        public FunctionalException(string message) : base(message){}
        public FunctionalException(string message, Exception innerException): base (message, innerException){}
        protected FunctionalException(SerializationInfo info, StreamingContext context) : base(info, context){}
    }
}
