using System;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Server
{
    public class SkeletonHub : Hub<ISkeletonHub>
    {
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: '{Context.ConnectionId}'");
            Clients.Others.announceClientConnected($"{Context.ConnectionId}");
            return base.OnConnectedAsync();
        }
        public void HelloWorld(string msg){
            Console.WriteLine($"{Context.ConnectionId} says: {msg}");
        }
    }
}