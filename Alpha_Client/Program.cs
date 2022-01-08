using CommunicationServices.Interfaces;
using CommunicationServices.Services;
using System;

namespace Alpha_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ISignalRServerService service = new SignalRServerService();
                Console.WriteLine("\t\t\t\t\t Alpha Client (Press N/n to Close The Console)");

                #region Rquest Server, server will send back message only to me
                service.RequestServerToGetSomeData("I'm Alpha Client");
                service.Listen_MyNotifications();
                Console.ReadLine();
                #endregion
                
                /*
                #region Test Broadcasting Message to All clientss
                Console.Write("Enter Your Message: ");
                string message = Console.ReadLine();
                service.BroadCastPublicMessage("Alpha Client", message);

                while (true)
                {
                    if (message.ToLower() == "n")
                        break;

                    Console.Write("Enter Your Message: ");
                    message = Console.ReadLine();
                    service.BroadCastPublicMessage("tAlpha Client", message);

                }
                #endregion

                */
                Environment.Exit(0);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
