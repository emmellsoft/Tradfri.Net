using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tradfri.Net.Communication.Objects;

namespace Tradfri.Net.Communication
{
    internal class Request
    {
        private readonly string[] _pathItems;

        public Request(ILogger logger, EndPointInfo endPointInfo, RequestRoot root)
            : this(logger, endPointInfo, new[] { ((int)root).ToString() })
        {
            Logger = logger;
        }

        public Request(ILogger logger, EndPointInfo endPointInfo, IEnumerable<string> pathItems)
        {
            Logger = logger;
            EndPointInfo = endPointInfo;
            _pathItems = pathItems.ToArray();
        }

        public ILogger Logger { get; }

        public EndPointInfo EndPointInfo { get; }

        public Request AppendPath(TradfriAttribute attribute)
        {
            return AppendPath(((int)attribute).ToString());
        }

        public Request AppendPath(int item)
        {
            return AppendPath(item.ToString());
        }

        public Request AppendPath(string item)
        {
            return new Request(Logger, EndPointInfo, _pathItems.Concat(new[] { item }));
        }

        public string GetUriPath()
        {
            var uriPathBuilder = new StringBuilder();
            foreach (string pathItem in _pathItems)
            {
                uriPathBuilder.Append('/');
                uriPathBuilder.Append(pathItem);
            }

            return uriPathBuilder.ToString();
        }
    }
}
