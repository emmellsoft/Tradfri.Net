using System;

namespace Tradfri.Net
{
    public class GatewayStatus
    {
        internal GatewayStatus(
            string networkTimeProtocol,
            int gatewayTimeSource,
            DateTime currentTime,
            int commissioningMode,
            string firmware,
            string gatewayId,
            int googleHomePairStatus,
            int alexaPairStatus,
            string homekitId,
            int otaUpdateState,
            int gatewayUpdateProgress,
            int otaType,
            DateTime? firstSetup,
            int certificateProvider)
        {
            NetworkTimeProtocol = networkTimeProtocol;
            GatewayTimeSource = gatewayTimeSource;
            CurrentTime = currentTime;
            CommissioningMode = commissioningMode;
            Firmware = firmware;
            GatewayId = gatewayId;
            GoogleHomePairStatus = googleHomePairStatus;
            AlexaPairStatus = alexaPairStatus;
            HomekitId = homekitId;
            OtaUpdateState = otaUpdateState;
            GatewayUpdateProgress = gatewayUpdateProgress;
            OtaType = otaType;
            FirstSetup = firstSetup;
            CertificateProvider = certificateProvider;
        }

        public string NetworkTimeProtocol { get; }

        public int GatewayTimeSource { get; }

        public DateTime CurrentTime { get; }

        public int CommissioningMode { get; }

        public string Firmware { get; }

        public string GatewayId { get; }

        public int GoogleHomePairStatus { get; }

        public int AlexaPairStatus { get; }

        public string HomekitId { get; }

        public int OtaUpdateState { get; }

        public int GatewayUpdateProgress { get; }

        public int OtaType { get; }

        public DateTime? FirstSetup { get; }

        public int CertificateProvider { get; }
    }
}
