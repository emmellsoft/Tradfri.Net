using Com.AugustCellars.CoAP;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication
{
    internal static class RequestExtensions
    {
        public static async Task<string> Post(this Request request, string payload)
        {
            var coapClientHelper = new CoapClientHelper("Post", request);
            coapClientHelper.Client.PostAsync(payload, coapClientHelper.ResponseCallback, coapClientHelper.FailCallback);
            Response response = await coapClientHelper.GetResponseAsync();
            Log(request.Logger, response);
            return response.PayloadString;
        }

        public static async Task<string> Get(this Request request)
        {
            var coapClientHelper = new CoapClientHelper("Get", request);
            coapClientHelper.Client.GetAsync(coapClientHelper.ResponseCallback, coapClientHelper.FailCallback);
            Response response = await coapClientHelper.GetResponseAsync();
            Log(request.Logger, response);
            return response.PayloadString;
        }

        public static async Task<T> Get<T>(this Request request)
        {
            var coapClientHelper = new CoapClientHelper("Get", request);
            coapClientHelper.Client.GetAsync(coapClientHelper.ResponseCallback, coapClientHelper.FailCallback);
            Response response = await coapClientHelper.GetResponseAsync();
            T obj = Json.Deserialize<T>(response.PayloadString);
            Log(request.Logger, obj);
            return obj;
        }

        public static async Task<bool> Put<T>(this Request request, T payload)
        {
            string json = Json.SerializeIgnoreNull(payload);
            var coapClientHelper = new CoapClientHelper("Put", request);
            coapClientHelper.Client.PutAsync(json, coapClientHelper.ResponseCallback, coapClientHelper.FailCallback);
            Response response = await coapClientHelper.GetResponseAsync();
            Log(request.Logger, response);
            return response.StatusCode == StatusCode.Changed;
        }

        public static void InitObserver(this Request request, EndpointObserver endpointObserver)
        {
            var coapClientHelper = new CoapClientHelper("Observe", request);
            endpointObserver.ObserveRelation = coapClientHelper.Client.ObserveAsync(endpointObserver.Notify, coapClientHelper.FailCallback);
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
