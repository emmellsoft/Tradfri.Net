using Com.AugustCellars.CoAP;
using Com.AugustCellars.CoAP.DTLS;
using Com.AugustCellars.COSE;
using PeterO.Cbor;
using System;
using System.Net;
using System.Text;
using Tradfri.Net.Communication.Objects;
using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net
{
    public class GatewayFactory
    {
        private readonly IPAddress _ipAddress;
        private readonly string _clientIdentity;
        private readonly ILogger _logger;

        public GatewayFactory(IPAddress ipAddress, string clientIdentity, ILogger logger)
        {
            _ipAddress = ipAddress;
            _clientIdentity = clientIdentity;
            _logger = logger;
        }

        public string GeneratePsk(string gatewaySecret)
        {
            try
            {
                _logger.Debug($"Connecting to {_ipAddress} as \"{_clientIdentity}\" to generate new PSK");

                var authKey = new OneKey();
                authKey.Add(CoseKeyKeys.KeyType, GeneralValues.KeyType_Octet);
                authKey.Add(CoseKeyParameterKeys.Octet_k, CBORObject.FromObject(Encoding.UTF8.GetBytes(gatewaySecret)));
                authKey.Add(CoseKeyKeys.KeyIdentifier, CBORObject.FromObject(Encoding.UTF8.GetBytes("Client_identity")));
                using (var clientEndPoint = new DTLSClientEndPoint(authKey))
                {
                    clientEndPoint.Start();

                    var authRequest = new AuthRequest { Identity = _clientIdentity };

                    var request = new Request(Method.POST)
                    {
                        EndPoint = clientEndPoint,
                        AckTimeout = 5000
                    };

                    request.SetUri($"coaps://{_ipAddress}/{(int)RequestRoot.Gateway}/{(int)TradfriAttribute.Auth}/");
                    string json = Json.Serialize(authRequest);
                    request.SetPayload(json);
                    request.Send();

                    Response response = request.WaitForResponse(5000);
                    if (response == null)
                    {
                        throw new TradfriException("No response from gateway");
                    }

                    AuthResponse authResponse = Json.Deserialize<AuthResponse>(response.PayloadString);

                    _logger.Debug($"PSK generated: \"{authResponse.Psk}\"");

                    return authResponse.Psk;
                }
            }
            catch (Exception exception)
            {
                throw new TradfriException("Failed during authentication.", exception);
            }
        }

        public IGateway Connect(string psk)
        {
            _logger.Debug($"Connecting to {_ipAddress} as \"{_clientIdentity}\" with PSK \"{psk}\"");

            var authKey = new OneKey();
            authKey.Add(CoseKeyKeys.KeyType, GeneralValues.KeyType_Octet);
            authKey.Add(CoseKeyParameterKeys.Octet_k, CBORObject.FromObject(Encoding.UTF8.GetBytes(psk)));
            authKey.Add(CoseKeyKeys.KeyIdentifier, CBORObject.FromObject(Encoding.UTF8.GetBytes(_clientIdentity)));

            var clientEndPoint = new DTLSClientEndPoint(authKey);
            clientEndPoint.Start();

            return new Gateway(clientEndPoint, new Uri($"coaps://{_ipAddress}"), _logger);
        }
    }
}
