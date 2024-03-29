﻿using System;
using System.Threading.Tasks;
using Tradfri.Net.Communication;
using Tradfri.Net.Communication.Objects;
using Tradfri.Net.Communication.Serialization;

namespace Tradfri.Net
{
    internal class PlugDevice : Device, IPlugDevice
    {
        public PlugDevice(IGateway gateway, Request deviceRequest, DeviceResponse deviceResponse)
            : base(gateway, deviceRequest, deviceResponse, DeviceType.Plug)
        {
            UpdateLastPlugStatus(deviceResponse);
        }

        public PlugStatus LastPlugStatus { get; private set; }

        public event Action<IPlugDevice, PlugStatus> PlugStatusChanged
        {
            add => DeviceStatusObserver<IPlugDevice, PlugStatus>.AddStatusEvent(this, value, DeviceRequest, ConvertAndHandleObservedStatus);
            remove => DeviceStatusObserver<IPlugDevice, PlugStatus>.RemoveStatusEvent(this, value);
        }

        private PlugStatus ConvertAndHandleObservedStatus(string payloadString)
        {
            DeviceResponse deviceResponse = Json.Deserialize<DeviceResponse>(payloadString);
            UpdateLastPlugStatus(deviceResponse);
            return LastPlugStatus;
        }

        public async Task<PlugStatus> GetPlugStatus()
        {
            DeviceResponse deviceResponse = await DeviceRequest.Get<DeviceResponse>();
            UpdateLastPlugStatus(deviceResponse);
            return LastPlugStatus;
        }

        private void UpdateLastPlugStatus(DeviceResponse deviceResponse)
        {
            SwitchPlugStatusResponse switchPlugStatusResponse = deviceResponse.SwitchPlugStatus?[0];
            if (switchPlugStatusResponse == null)
            {
                throw new TradfriException("Missing switch plug status");
            }

            LastPlugStatus = switchPlugStatusResponse.ToPlugStatus(this);
        }

        public Task<bool> SetState(bool turnedOn)
        {
            return SendStatusUpdate(new SwitchPlugStatusUpdate
            {
                State = turnedOn ? 1 : 0
            });
        }

        public Task<bool> SetState(byte dimmer)
        {
            return SendStatusUpdate(new SwitchPlugStatusUpdate
            {
                State = dimmer > 0 ? 1 : 0,
                Dimmer = dimmer,
            });
        }

        private Task<bool> SendStatusUpdate(SwitchPlugStatusUpdate statusUpdate)
        {
            return DeviceRequest.Put(new SwitchPlugUpdate { SwitchPlugStatus = new[] { statusUpdate } });
        }
    }
}
