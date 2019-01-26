using System;

namespace Tradfri.Net.Communication
{
    public static class CoapCodeExtensions
    {
        public static string GetDisplayName(this CoapCode coapCode)
        {
            switch (coapCode)
            {
                case CoapCode.Created: return "2.01 Created";
                case CoapCode.Deleted: return "2.02 Deleted";
                case CoapCode.Valid: return "2.03 Valid";
                case CoapCode.Changed: return "2.04 Changed";
                case CoapCode.Content: return "2.05 Content";
                case CoapCode.BadRequest: return "4.00 Bad Request";
                case CoapCode.Unauthorized: return "4.01 Unauthorized";
                case CoapCode.BadOption: return "4.02 Bad Option";
                case CoapCode.Forbidden: return "4.03 Forbidden";
                case CoapCode.NotFound: return "4.04 Not Found";
                case CoapCode.MethodNotAllowed: return "4.05 Method Not Allowed";
                case CoapCode.NotAcceptable: return "4.06 Not Acceptable";
                case CoapCode.PreconditionFailed: return "4.12 Precondition Failed";
                case CoapCode.RequestEntityTooLarge: return "4.13 Request Entity Too Large";
                case CoapCode.UnsupportedContentFormat: return "4.15 Unsupported Content-Format";
                case CoapCode.InternalServerError: return "5.00 Internal Server Error";
                case CoapCode.NotImplemented: return "5.01 Not Implemented";
                case CoapCode.BadGateway: return "5.02 Bad Gateway";
                case CoapCode.ServiceUnavailable: return "5.03 Service Unavailable";
                case CoapCode.GatewayTimeout: return "5.04 Gateway Timeout";
                case CoapCode.ProxyingNotSupported: return "Proxying Not Supported";
                default:
                    throw new ArgumentOutOfRangeException(nameof(coapCode), coapCode, null);
            }
        }
    }
}
