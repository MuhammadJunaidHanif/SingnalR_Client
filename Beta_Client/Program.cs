using CommunicationServices.Interfaces;
using CommunicationServices.Services;
using System;

namespace Beta_Client
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ISignalRServerService service = new SignalRServerService();
                Console.WriteLine("\t\t\t\t\t Beta Client (Press N/n to Close The Console)");

                #region Rquest Server, server will send back message only to me
                service.RequestServerToGetSomeData("I'm Beta Client");
                service.Listen_MyNotifications();
                Console.ReadLine();
                #endregion

                /*
              #region Test Broadcasting Message to All clientss
              Console.Write("Enter Your Message: ");
              string message = Console.ReadLine();
              service.BroadCastPublicMessage("Beta Client", message);


              while (true)
              {
                  if (message.ToLower()=="n")
                      break;

                  Console.Write("Enter Your Message: ");
                  message = Console.ReadLine();
                  service.BroadCastPublicMessage("Beta Client", message);

              }
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
