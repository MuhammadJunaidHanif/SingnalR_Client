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

                Console.Write("Enter Your Message: ");
                string message = Console.ReadLine();
                service.BroadCastMessage("Beta Client", message);


                while (true)
                {
                    if (message.ToLower()=="n")
                        break;

                    Console.Write("Enter Your Message: ");
                    message = Console.ReadLine();
                    service.BroadCastMessage("Beta Client", message);
                    
                }
                Environment.Exit(0);
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }
    }
}
