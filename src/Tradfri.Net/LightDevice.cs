using System;
using System.Threading.Tasks;
using Tradfri.Net.Communication;
using Tradfri.Net.Communication.Objects;

namespace Tradfri.Net
{
    internal class LightDevice : Device, ILightDevice
    {
        public LightDevice(IGateway gateway, Request deviceRequest, DeviceResponse deviceResponse)
            : base(gateway, deviceRequest, deviceResponse, DeviceType.Light)
        {
            UpdateLastLightStatus(deviceResponse);

            CanSetBrightness = true;

            if (LastLightStatus.Color.HsColor.HasValue)
            {
                Spectrum = ColorSpectrum.Color;
                CanSetColor = true;
                CanSetTemperature = true;
            }
            else if (LastLightStatus.Color.Temperature.HasValue)
            {
                Spectrum = ColorSpectrum.White;
                CanSetTemperature = true;
            }
            else
            {
                Spectrum = ColorSpectrum.None;
            }
        }

        public ColorSpectrum Spectrum { get; }

        public bool CanSetBrightness { get; }

        public bool CanSetTemperature { get; }

        public bool CanSetColor { get; }

        public LightStatus LastLightStatus { get; private set; }

        public async Task<LightStatus> GetLightStatus()
        {
            DeviceResponse deviceResponse = await DeviceRequest.Get<DeviceResponse>();
            UpdateLastLightStatus(deviceResponse);
            return LastLightStatus;
        }

        private void UpdateLastLightStatus(DeviceResponse deviceResponse)
        {
            LightStatusResponse lightStatusResponse = deviceResponse.LightStatus?[0];
            if (lightStatusResponse == null)
            {
                throw new TradfriException("Missing light status");
            }

            LastLightStatus = lightStatusResponse.ToLightStatus(this);
        }

        public Task<bool> SetState(bool turnedOn)
        {
            return SendStatusUpdate(new LightStatusUpdate
            {
                State = turnedOn ? 1 : 0
            });
        }

        public Task<bool> SetState(byte brightness)
        {
            if (!CanSetBrightness)
            {
                throw new InvalidOperationException("Cannot set the brightness on this light.");
            }

            return SendStatusUpdate(new LightStatusUpdate
            {
                State = brightness > 0 ? 1 : 0,
                Dimmer = brightness
            });
        }

        public Task<bool> SetState(byte brightness, ColorTemperature temperature)
        {
            if (!CanSetTemperature)
            {
                throw new InvalidOperationException("Cannot set the temperature on this light.");
            }

            return SendStatusUpdate(new LightStatusUpdate
            {
                State = brightness > 0 ? 1 : 0,
                Dimmer = brightness,
                Mireds = temperature.Mireds
            });
        }

        public Task<bool> SetState(byte brightness, RgbColor color)
        {
            if (!CanSetColor)
            {
                throw new InvalidOperationException("Cannot set the color on this light.");
            }

            return SendStatusUpdate(new LightStatusUpdate
            {
                State = brightness > 0 ? 1 : 0,
                Dimmer = brightness,
                ColorHex = color.Value
            });
        }

        public Task<bool> SetState(byte brightness, XyColor color)
        {
            if (!CanSetColor)
            {
                throw new InvalidOperationException("Cannot set the color on this light.");
            }

            return SendStatusUpdate(new LightStatusUpdate
            {
                State = brightness > 0 ? 1 : 0,
                Dimmer = brightness,
                ColorX = color.X,
                ColorY = color.Y
            });
        }

        public Task<bool> SetState(byte brightness, HsColor color)
        {
            if (!CanSetColor)
            {
                throw new InvalidOperationException("Cannot set the color on this light.");
            }

            return SendStatusUpdate(new LightStatusUpdate
            {
                State = brightness > 0 ? 1 : 0,
                Dimmer = brightness,
                ColorHue = color.Hue,
                ColorSaturation = color.Saturation
            });
        }

        private Task<bool> SendStatusUpdate(LightStatusUpdate statusUpdate)
        {
            return DeviceRequest.Put(new LightControlUpdate { LightControl = new[] { statusUpdate } });
        }
    }
}
