using System;
using System.Runtime.Serialization;

namespace Minor.ServiceBus.PfSLocatorService
{
    [Serializable]
    public class NoRecordsFoundException : Exception
    {
        public NoRecordsFoundException()
        {            
        }

        public NoRecordsFoundException(string message) : base(message)
        {
        }

        public NoRecordsFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoRecordsFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}