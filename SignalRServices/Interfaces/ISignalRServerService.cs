using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationServices.Interfaces
{
    public interface ISignalRServerService
    {
        Task<bool> BroadCastMessage(string sender, string message);
        void ListenMessages();
    }
}
