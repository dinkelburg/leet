using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Minor.ServiceBus.PfSLocatorService
{
    [Serializable]
    public class MultipleRecordsFoundException: Exception
    {
        public MultipleRecordsFoundException(){}
        public MultipleRecordsFoundException(string message): base(message){}
        public MultipleRecordsFoundException(string message, Exception inner): base(message, inner){}
        protected MultipleRecordsFoundException(SerializationInfo info, StreamingContext context) : base(info, context){}
    }
}
