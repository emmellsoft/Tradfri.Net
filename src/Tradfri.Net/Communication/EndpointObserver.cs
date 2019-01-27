using Com.AugustCellars.CoAP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Tradfri.Net.Communication
{
    internal abstract class EndpointObserver
    {
        public CoapObserveRelation ObserveRelation { get; set; }

        public abstract void Notify(Response response);
    }

    internal class EndpointObserver<TDevice, TStatus> : EndpointObserver
        where TDevice : IDevice
    {
        private readonly object _syncObj = new object();
        private readonly TDevice _device;
        private readonly Func<string, TStatus> _statusConverter;
        private readonly Action _cancelCallback;
        private readonly ICollection<Action<TDevice, TStatus>> _notifications = new Collection<Action<TDevice, TStatus>>();

        public EndpointObserver(
            TDevice device,
            Func<string, TStatus> statusConverter,
            Action cancelCallback)
        {
            _device = device;
            _statusConverter = statusConverter;
            _cancelCallback = cancelCallback;
        }

        public event Action<TDevice, TStatus> Notified
        {
            add
            {
                lock (_syncObj)
                {
                    _notifications.Add(value);
                }
            }
            remove
            {
                lock (_syncObj)
                {
                    _notifications.Remove(value);
                    if (_notifications.Count == 0)
                    {
                        Cancel();
                    }
                }
            }
        }

        public override void Notify(Response response)
        {
            TStatus status = _statusConverter(response.PayloadString);
            lock (_syncObj)
            {
                foreach (Action<TDevice, TStatus> notification in _notifications)
                {
                    notification(_device, status);
                }
            }
        }

        private void Cancel()
        {
            _cancelCallback.Invoke();
            ObserveRelation.ReactiveCancel();
        }
    }
}
