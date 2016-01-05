using System;
using System.Runtime.Serialization;

namespace Minor.ServiceBus.PfSLocatorService
{
    [Serializable]
    public class FilePathNotDefinedException : Exception
    {
        public FilePathNotDefinedException()
        {
        }

        public FilePathNotDefinedException(string message) : base(message)
        {
        }

        public FilePathNotDefinedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected FilePathNotDefinedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}