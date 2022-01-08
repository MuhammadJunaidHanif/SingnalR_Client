using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunicationServices.Interfaces;
using Microsoft.AspNetCore.SignalR.Client;
using SignalRServices.Notification;

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

        public async Task<bool> BroadCastPublicMessage(string sender, string message)
        {
            await _hubConnection.InvokeAsync("SendMessage", sender, message);
            return true;
        }
        public async Task<bool> RequestServerToGetSomeData(string recordId)
        {
            await _hubConnection.InvokeAsync("SendMessageToCaller", recordId);
            return true;
        }

        public void Listen_AllNotifications()
        {
            _hubConnection.On(NotificationTypes.All, (string sender, string message) =>
            {
                Console.WriteLine($"{sender}:  " + message);
            });

        }

        public void Listen_MyNotifications()
        {
            _hubConnection.On(NotificationTypes.Caller, (string serverResponse) =>
              {
                  Console.WriteLine(serverResponse);
              });

        }
    }
}
