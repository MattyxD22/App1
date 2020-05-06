using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Hubs
{
    public class ChatHub : Hub
    {
        public void BroadcastMessage(string name, string message)
        {
            Clients.All.SendAsync("broadcastMessage", name, message);
            Console.WriteLine(Clients.All.SendAsync("broadcastMessage", name, message));
        }

        public void Echo(string name, string message)
        {
            Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)");
            Console.WriteLine(Clients.Client(Context.ConnectionId).SendAsync("echo", name, message + " (echo from server)"));
        }



        public async Task SendMessage(string user, string message)
        {

            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

        public async Task JoinChat(string ID)
        {
            await Clients.All.SendAsync("JoinChat" + " Server...", ID);
            Console.WriteLine(Clients.All.SendAsync("JoinChat", ID));

        }
    }
}
