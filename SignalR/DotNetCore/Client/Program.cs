using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace Client
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/hubs/skeleton")
                .Build();
            connection.On<String>("announceClientConnected", (msg) => announceClientLoggedIn(msg));
            // Loop is here to wait until the server is running
            while (true)
            {
                try
                {
                    Console.WriteLine("Connecting..");
                    await connection.StartAsync();
                    break;
                }
                catch
                {
                    await Task.Delay(1000);
                }
            }

            Console.WriteLine("Client listening. Hit Ctrl-C to quit.\n\n");
            
            await connection.InvokeAsync("HelloWorld", "Derp\n" );

            Console.ReadLine();
        }
        public static void announceClientLoggedIn(string userName)
        {
            Console.WriteLine($"Announce: '{userName}' has joined the lobby");
        }
    }
}
