namespace Tradfri.Net
{
    public interface ISmartTask
    {
        IGateway Gateway { get; }

        int Id { get; }
    }
}
