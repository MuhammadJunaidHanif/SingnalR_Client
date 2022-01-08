using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationServices.Interfaces
{
    public interface ISignalRServerService
    {
        Task<bool> BroadCastPublicMessage(string sender, string message);
        Task<bool> RequestServerToGetSomeData(string recordId);
        void Listen_AllNotifications();
        void Listen_MyNotifications();
    }
}
