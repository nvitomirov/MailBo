using System;
using System.ServiceModel;

namespace MailBoServiceSelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(MailBoService.SignOnService)))
            {
                host.Open();
                Console.WriteLine("Service Started...");
                Console.WriteLine("Press enter to stop the service.");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
