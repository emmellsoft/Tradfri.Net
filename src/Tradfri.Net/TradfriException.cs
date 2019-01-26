using System;
using Tradfri.Net.Communication;

namespace Tradfri.Net
{
    public class TradfriException : Exception
    {
        public TradfriException(string message)
            : base(message)
        {
        }

        public TradfriException(string message, CoapCode coapCode)
            : base(message)
        {
            CoapCode = coapCode;
        }

        public TradfriException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        public TradfriException(string message, CoapCode coapCode, Exception innerException)
            : base(message, innerException)
        {
            CoapCode = coapCode;
        }

        public CoapCode? CoapCode { get; }
    }
}
