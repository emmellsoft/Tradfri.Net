using System;
using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net.Communication.Objects
{
    internal class GatewayResponse
    {
        [TradfriAttribute(TradfriAttribute.NetworkTimeProtocol)]
        public string NetworkTimeProtocol { get; set; }

        [TradfriAttribute(TradfriAttribute.GatewayTimeSource)]
        public int GatewayTimeSource { get; set; }

        [TradfriAttribute(TradfriAttribute.CurrentTimeISO8601)]
        public DateTime CurrentTime { get; set; }

        [TradfriAttribute(TradfriAttribute.CommissioningMode)]
        public int CommissioningMode { get; set; }

        [TradfriAttribute(TradfriAttribute.FirmwareVersion)]
        public string Firmware { get; set; }

        [TradfriAttribute(TradfriAttribute.GatewayId)]
        public string GatewayId { get; set; }

        [TradfriAttribute(TradfriAttribute.GoogleHomePairStatus)]
        public int GoogleHomePairStatus { get; set; }

        [TradfriAttribute(TradfriAttribute.AlexaPairStatus)]
        public int AlexaPairStatus { get; set; }

        [TradfriAttribute(TradfriAttribute.HomekitId)]
        public string HomekitId { get; set; }

        [TradfriAttribute(TradfriAttribute.OtaUpdateState)]
        public int OtaUpdateState { get; set; }

        [TradfriAttribute(TradfriAttribute.GatewayUpdateProgress)]
        public int GatewayUpdateProgress { get; set; }

        [TradfriAttribute(TradfriAttribute.OtaType)]
        public int OtaType { get; set; }

        [TradfriAttribute(TradfriAttribute.FirstSetup, TradfriAttributeType.UnixEpochSeconds)]
        public DateTime? FirstSetup { get; set; }

        [TradfriAttribute(TradfriAttribute.CertificateProvider)]
        public int CertificateProvider { get; set; }

        [TradfriAttribute(9062)]
        public int The9062 { get; set; }

        [TradfriAttribute(9072)]
        public int DstStartMonth { get; set; }

        [TradfriAttribute(9073)]
        public int DstStartDay { get; set; }

        [TradfriAttribute(9074)]
        public int DstStartHour { get; set; }

        [TradfriAttribute(9075)]
        public int DstStartMinute { get; set; }

        [TradfriAttribute(9076)]
        public int DstEndMonth { get; set; }

        [TradfriAttribute(9077)]
        public int DstEndDay { get; set; }

        [TradfriAttribute(9078)]
        public int DstEndHour { get; set; }

        [TradfriAttribute(9079)]
        public int DstEndMinute { get; set; }

        [TradfriAttribute(9080)]
        public int DstTimeOffset { get; set; }

        [TradfriAttribute(9082)]
        public bool The9082 { get; set; }

        [TradfriAttribute(9106)]
        public int The9106 { get; set; }

        [TradfriAttribute(9107)]
        public int The9107 { get; set; }

        [TradfriAttribute(9200)]
        public Guid The9200 { get; set; }
    }
}
