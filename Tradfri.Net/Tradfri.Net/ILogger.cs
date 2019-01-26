namespace Tradfri.Net
{
    public interface ILogger
    {
        void Debug(string text);

        void Info(string text);

        void Error(string text);
    }
}
