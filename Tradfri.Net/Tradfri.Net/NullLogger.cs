namespace Tradfri.Net
{
    public class NullLogger : ILogger
    {
        public static readonly ILogger Instance = new NullLogger();

        void ILogger.Debug(string text)
        {
        }

        void ILogger.Info(string text)
        {
        }

        void ILogger.Error(string text)
        {
        }
    }
}
