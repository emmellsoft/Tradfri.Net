using Com.AugustCellars.CoAP;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication
{
    internal static class RequestExtensions
    {
        private static CoapClient CreateClient(Request request)
        {
            return new CoapClient
            {
                EndPoint = request.EndPointInfo.EndPoint,
                Uri = request.EndPointInfo.Uri,
                UriPath = request.GetUriPath(),
                Timeout = 3000
            };
        }

        public static async Task<string> Post(this Request request, string payload)
        {
            Response response = await ExecuteClientAction("Post", request, client => client.Post(payload));
            Log(request.Logger, response);
            return response.PayloadString;
        }

        public static async Task<string> Get(this Request request)
        {
            Response response = await ExecuteClientAction("Get", request, client => client.Get());
            Log(request.Logger, response);
            return response.PayloadString;
        }

        public static async Task<T> Get<T>(this Request request)
        {
            Response response = await ExecuteClientAction("Get", request, client => client.Get());
            T obj = Json.Deserialize<T>(response.PayloadString);
            Log(request.Logger, obj);
            return obj;
        }

        public static async Task<bool> Put<T>(this Request request, T payload)
        {
            string json = Json.SerializeIgnoreNull(payload);
            Response response = await ExecuteClientAction("Put " + json, request, client => client.Put(json));
            Log(request.Logger, response);
            return response.StatusCode == StatusCode.Changed;
        }

        private static Task<Response> ExecuteClientAction(string method, Request request, Func<CoapClient, Response> getResponse)
        {
            request.Logger.LogDebug(method + " " + request.GetUriPath());
            Response response = getResponse(CreateClient(request));
            if (response == null)
            {
                throw new TradfriException("Failed getting response from gateway.", null);
            }

            CoapCode coapCode = (CoapCode)response.Code;
            switch (coapCode)
            {
                case CoapCode.Created:
                case CoapCode.Deleted:
                case CoapCode.Valid:
                case CoapCode.Changed:
                case CoapCode.Content:
                    return Task.FromResult(response);
            }

            throw new TradfriException("Non-successful response from gateway.", coapCode);
        }

        private static void Log(ILogger logger, Response response)
        {
            logger.LogDebug(response.PayloadString);
        }

        private static void Log(ILogger logger, object obj)
        {
            logger.LogDebug(Json.SerializeDebug(obj));
        }
    }
}
