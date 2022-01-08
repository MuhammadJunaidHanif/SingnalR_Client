using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunicationServices.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;

namespace CommunicationServices.Services
{
    public class SignalRServerService : ISignalRServerService
    {
        private readonly HubConnection _hubConnection;
        private const string serverUrl = "https://localhost:44378/notifcationhub";
        public SignalRServerService()
        {
            _hubConnection = new HubConnectionBuilder()
                   .WithUrl(serverUrl)
                   .WithAutomaticReconnect()
                   .Build();

            _hubConnection.StartAsync().Wait();
        }

        public async Task<bool> BroadCastMessage(string sender, string message)
        {
            await _hubConnection.InvokeAsync("SendMessage", sender, message);
            return true;
        }

        public void ListenMessages()
        {
            _hubConnection.On("chat_notification", (string sender, string message) =>
            {
                Console.WriteLine($"{sender}:  " + message);
            });

        }
    }
}
