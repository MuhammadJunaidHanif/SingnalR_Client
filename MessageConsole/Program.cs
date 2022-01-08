using CommunicationServices.Interfaces;
using CommunicationServices.Services;
using System;

namespace MessageConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ISignalRServerService service = new SignalRServerService();
                Console.WriteLine("\t\t\t\t\t\t\tMessages Console");
                service.ListenMessages();
                Console.ReadKey();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
