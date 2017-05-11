using System;
using System.Runtime.Serialization;

namespace WebApplication4.Controllers
{
    [Serializable]
    internal class Exceoption : Exception
    {
        public Exceoption()
        {
        }

        public Exceoption(string message) : base(message)
        {
        }

        public Exceoption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected Exceoption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}