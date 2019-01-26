using System;
using System.Collections.Generic;
using Com.AugustCellars.CoAP.Net;
using Tradfri.Net.Communication.Objects;

namespace Tradfri.Net.Communication
{
    internal class EndPointInfo : IDisposable
    {
        private readonly ILogger _logger;

        public EndPointInfo(IEndPoint endPoint, Uri uri, ILogger logger)
        {
            _logger = logger;
            EndPoint = endPoint;
            Uri = uri;
        }

        public IEndPoint EndPoint { get; }

        public Uri Uri { get; }

        public void Dispose()
        {
            EndPoint.Dispose();
        }

        public Request GetRequest(RequestRoot root)
        {
            return new Request(_logger, this, root);
        }

        public Request GetRawRequest(IEnumerable<string> pathValues)
        {
            return new Request(_logger, this, pathValues);
        }
    }
}
