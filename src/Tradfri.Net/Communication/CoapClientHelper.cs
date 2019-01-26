using Com.AugustCellars.CoAP;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Tradfri.Net.Communication
{
    internal class CoapClientHelper
    {
        private readonly TaskCompletionSource<Response> _taskCompletionSource = new TaskCompletionSource<Response>();

        public CoapClientHelper(string method, Request request)
        {
            request.Logger.LogDebug(method + " " + request.GetUriPath());

            Client = new CoapClient
            {
                EndPoint = request.EndPointInfo.EndPoint,
                Uri = request.EndPointInfo.Uri,
                UriPath = request.GetUriPath(),
                Timeout = 3000
            };
        }

        public CoapClient Client { get; }

        public void ResponseCallback(Response response)
        {
            _taskCompletionSource.SetResult(response);
        }

        public void FailCallback(CoapClient.FailReason failReason)
        {
            switch (failReason)
            {
                case CoapClient.FailReason.Rejected:
                    _taskCompletionSource.SetException(new TradfriException("The gateway rejected the request."));
                    break;

                case CoapClient.FailReason.TimedOut:
                    _taskCompletionSource.SetException(new TradfriException("Timed-out waiting for the gateway."));
                    break;

                default:
                    _taskCompletionSource.SetException(new TradfriException("Gateway communication error: " + (int)failReason));
                    break;
            }
        }

        public async Task<Response> GetResponseAsync()
        {
            try
            {
                Response response = await _taskCompletionSource.Task;
                if (response == null)
                {
                    throw new TradfriException("Failed getting response from gateway.");
                }

                CoapCode coapCode = (CoapCode)response.Code;
                switch (coapCode)
                {
                    case CoapCode.Created:
                    case CoapCode.Deleted:
                    case CoapCode.Valid:
                    case CoapCode.Changed:
                    case CoapCode.Content:
                        return response;
                }

                throw new TradfriException("Non-successful response from gateway.", coapCode);
            }
            catch (TradfriException)
            {
                throw;
            }
            catch (Exception exception)
            {
                throw new TradfriException("Internal error communicating with the gateway.", exception);
            }
        }
    }
}
