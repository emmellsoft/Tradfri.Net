namespace Tradfri.Net.Communication
{
    public enum CoapCode
    {
        Created = 65,
        Deleted = 66,
        Valid = 67,
        Changed = 68,
        Content = 69,
        BadRequest = 128,
        Unauthorized = 129,
        BadOption = 130,
        Forbidden = 131,
        NotFound = 132,
        MethodNotAllowed = 133,
        NotAcceptable = 134,
        PreconditionFailed = 140,
        RequestEntityTooLarge = 141,
        UnsupportedContentFormat = 143,
        InternalServerError = 160,
        NotImplemented = 161,
        BadGateway = 162,
        ServiceUnavailable = 163,
        GatewayTimeout = 164,
        ProxyingNotSupported = 165
    }
}
