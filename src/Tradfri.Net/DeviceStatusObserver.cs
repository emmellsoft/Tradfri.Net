using System;
using System.Collections.Concurrent;
using Tradfri.Net.Communication;

namespace Tradfri.Net
{
    internal static class DeviceStatusObserver<TDevice, TStatus>
        where TDevice : IDevice
    {
        private static readonly ConcurrentDictionary<TDevice, EndpointObserver<TDevice, TStatus>> EndpointObservers;

        static DeviceStatusObserver()
        {
            EndpointObservers = new ConcurrentDictionary<TDevice, EndpointObserver<TDevice, TStatus>>();
        }

        public static void AddStatusEvent(
                TDevice device,
                Action<TDevice, TStatus> callback,
                Request request,
                Func<string, TStatus> convertAndHandleStatus)
        {
            EndpointObserver<TDevice, TStatus> endpointObserver = EndpointObservers.GetOrAdd(
                device,
                _ => CreateEndpointObserver(device, request, convertAndHandleStatus));

            endpointObserver.Notified += callback;
        }

        public static void RemoveStatusEvent(
            TDevice device,
            Action<TDevice, TStatus> callback)
        {
            if (!EndpointObservers.TryGetValue(device, out var endpointObserver))
            {
                return;
            }

            endpointObserver.Notified -= callback;
        }

        private static EndpointObserver<TDevice, TStatus> CreateEndpointObserver(
            TDevice device,
            Request request,
            Func<string, TStatus> convertAndHandleStatus)
        {
            var endpointObserver = new EndpointObserver<TDevice, TStatus>(
                device,
                convertAndHandleStatus,
                () => EndpointObservers.TryRemove(device, out var __));

            request.InitObserver(endpointObserver);

            return endpointObserver;
        }
    }
}
