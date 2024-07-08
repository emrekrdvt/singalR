using Microsoft.AspNetCore.SignalR;
using SignalR.Hubs;

namespace SignalR.Business
{
    public class MyBusiness
    {
        IHubContext<MyHub> _hubCtx;

        public MyBusiness(IHubContext<MyHub> hubCtx)
        {
            _hubCtx = hubCtx;
        }
        public async Task SendMessageAsync(string message)
        {
            await _hubCtx.Clients.All.SendAsync("recieveMessage", message);
        }
    }
}
