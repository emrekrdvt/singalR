using Microsoft.AspNetCore.SignalR;
using SignalR.Interfaces;
using System.Globalization;

namespace SignalR.Hubs
{
    public class MyHub: Hub<IMessageClient>
    {
        static List<string> clients = new List<string>();
/*        public async Task SendMessageAsync(string message)
        {
            await Clients.All.RecieveMessage(message);
            Console.WriteLine(message); 
        }*/

        public override async Task OnConnectedAsync()
        {
            clients.Add(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserJoined(Context.ConnectionId);

        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clients.Remove(Context.ConnectionId);
            await Clients.All.Clients(clients);
            await Clients.All.UserLeave(Context.ConnectionId);
        }
    }
}