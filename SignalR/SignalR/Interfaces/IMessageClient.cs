using System.Security;

namespace SignalR.Interfaces
{
    public interface IMessageClient
    {
        Task Clients(List<string> clients);
        Task RecieveMessage(string Message);
        Task UserJoined(string connectionId);
        Task UserLeave(string connectionId);
    }
}
