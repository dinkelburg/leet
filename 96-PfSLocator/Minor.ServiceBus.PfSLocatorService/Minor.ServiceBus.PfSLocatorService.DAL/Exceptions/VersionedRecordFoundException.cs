using System;
using System.Runtime.Serialization;

namespace Minor.ServiceBus.PfSLocatorService
{
    [Serializable]
    public class VersionedRecordFoundException : Exception
    {
        public VersionedRecordFoundException()
        {
        }

        public VersionedRecordFoundException(string message) : base(message)
        {
        }

        public VersionedRecordFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected VersionedRecordFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}