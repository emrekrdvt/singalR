using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography.X509Certificates;

namespace SignalR.Hubs
{
    public class MessageHub: Hub
    {
        public async Task SendMessageAsync(string message, IEnumerable<string> connectionIds)
        {
            #region Caller 
            // sadece servera bildirim gonderen client ile iletisim kurar
           // await Clients.Caller.SendAsync("receiveMessage", message);
            Console.WriteLine(message);
            #endregion


            #region all
            //servera bagli olan tum clientler ile iletisim kurar
            //await Clients.All.SendAsync("receiveMessage", message);
            #endregion

            #region sedece servera bildirim gonderen client disinda servera bagli olan tum clientlara mesaj gonderir
            //await Clients.Others.SendAsync("receiveMessage", message);
            #endregion

            #region hub client metotlari
                 #region all except
            // belirtilen clientlar haric  servera bagli olan tum clientlara yollar
            Clients.AllExcept(connectionIds).SendAsync("receiveMessage", message);
            #endregion

                #region Client 

                #endregion


            #endregion


        }


        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("getConId", Context.ConnectionId);
        }
    }
}
