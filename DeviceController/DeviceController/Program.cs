using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceController
{
    class Program
    {
        static void Main(string[] args)
        {
            HubConnection connection = new HubConnectionBuilder()
                            .WithUrl("https://localhost:5001/hub")
                            .Build();

            connection.On<string, bool>("UpdateFan", (fanCode, IsOn) =>
            {
                Console.WriteLine(fanCode);
                Console.WriteLine(IsOn);
            });

            try
            {
                //System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
                connection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex);
            }
            Console.ReadKey();
        }
    }
}
